using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave; // for WaveIn
using NAudio.CoreAudioApi;
using System.Diagnostics; // debug write
using System.Threading;
using System.IO;
using System;
using System.Collections.Generic;
// using NAudio.CoreAudioAPI;
using NAudio.Dsp;
using NAudio.Wave;
//using System.Drawing; // 

namespace echo_canceller
{
    class AudioHandler
    {
        private int micDeviceIndex;
        private int stereoMixerIndex;
        private int outputDeviceIndex;
        private WaveInEvent waveMic;
        private WaveInEvent waveStereo;
        private WaveOut waveOut = new WaveOut();
        private WaveBuffer waveBuffer = new WaveBuffer();
        public int volumeGain = 0;
        WaveFileWriter writer;
        AudioFileReader reader;
        BufferedWaveProvider bufferedWaveProvider;
        private STATE state = STATE.IDLE;
        public UISTATE uiState = UISTATE.DEFAULT;
        private bool recording = false;
        private bool streaming = false;

        // const variable
        private readonly int FFTLength = 512;
        private readonly int testWaitTime = 5000; // msec
        private enum STATE
        {
            IDLE,
            RECORD,
            PLAY,
            STREAM,
        }

        public enum UISTATE
        {
            DEFAULT,
            WAIT,
        }

        public AudioHandler()
        {
            waveMic = new WaveInEvent();
            waveStereo = new WaveInEvent();

            waveMic.WaveFormat = new WaveFormat(44100, 16, 2);
            waveMic.DataAvailable += WaveMic_DataAvailable;
            
            waveStereo.WaveFormat = new WaveFormat(44100, 16, 2);
            waveStereo.DataAvailable += WaveStereo_DataAvailable;

            // record ending func
            waveMic.RecordingStopped += (s, a) =>
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Dispose();
                    writer = null;
                }
                waveMic.Dispose();
            };
        }
        ~AudioHandler()
        {
        }


        /// <summary>
        /// get input device list
        /// </summary>
        /// <returns></returns>
        public List<String> GetInputDeviceList()
        {
            var InputDeviceList = new List<String>();
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var deviceInfo = WaveIn.GetCapabilities(i);
                InputDeviceList.Add(String.Format("Device {0}: {1}, {2} channels", i, deviceInfo.ProductName, deviceInfo.Channels));
            }
            return InputDeviceList;
        }
        /// <summary>
        /// get output device list
        /// </summary>
        /// <returns></returns>
        public List<String> GetOutputDeviceList()
        {
            var OutputDeviceList = new List<String>();
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var deviceInfo = WaveOut.GetCapabilities(i);
                OutputDeviceList.Add(String.Format("Device {0}: {1}, {2} channels", i, deviceInfo.ProductName, deviceInfo.Channels));
            }

            return OutputDeviceList;
        }

        /// <summary>
        /// set input device
        /// </summary>
        /// <param name="Index"></param>
        public void SetInputDeviceIndex(int Index)
        {
            micDeviceIndex = Index;
        }

        /// <summary>
        /// set stereo mixer
        /// </summary>
        /// <param name="Index"></param>
        public void SetStereoMixerIndex(int Index)
        {
            stereoMixerIndex = Index;
        }

        /// <summary>
        /// set output device
        /// </summary>
        /// <param name="Index"></param>
        public void SetOutputDeviceIndex(int Index)
        {
            outputDeviceIndex = Index;
        }

        public void RecordTestAudioStart()
        {
            waveMic.DeviceNumber = micDeviceIndex;
            writer =  new WaveFileWriter("./sounds/test.wav", waveMic.WaveFormat);

            recording = true;
            state = STATE.RECORD;
            uiState = UISTATE.WAIT;
            
            // record in other thread
            Task task_record = Task.Run(() => {
                waveMic.StartRecording();
            });

            Task waitRecord = Task.Run(() => {
                Thread.Sleep(testWaitTime);
                uiState = UISTATE.DEFAULT;
            });

        }

        public void RecordTestAudioEnd()
        {
            recording = false;
            state = STATE.IDLE;
            waveMic.StopRecording();
            waveOut.Stop();
        }

        public void PlayTestAudio()
        {
            waveOut.DeviceNumber = outputDeviceIndex;
            reader = new AudioFileReader("./sounds/test.wav");
            waveOut.Init(reader);
            waveOut.Play();
            state = STATE.PLAY;
            uiState = UISTATE.WAIT;
            Task waitRecord = Task.Run(() => {
                Thread.Sleep(testWaitTime);
                reader.Flush();
                reader.Dispose();
                reader = null;
                uiState = UISTATE.DEFAULT;
            });

        }

        public void StopTestAudio()
        {
            waveMic.StopRecording();
            waveOut.Stop();
            state = STATE.IDLE;
            uiState = UISTATE.DEFAULT;
        }


        public void StartStreaming()
        {
            waveMic.WaveFormat = new WaveFormat(44100, 16, 2);
            streaming = true;
            state = STATE.STREAM;
            waveMic.DeviceNumber = micDeviceIndex;
            waveMic.StartRecording();

            //一般的な44.1kHz, 16bit, ステレオサウンドの音源を想定
            bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat(44100, 16, 2));

            waveOut.DeviceNumber = outputDeviceIndex;
            waveOut.Init(bufferedWaveProvider);
            waveOut.Play();
        }

        private void WaveMic_DataAvailable(object sender, WaveInEventArgs e)
        {
            switch (state) {
                case STATE.RECORD :
                    if (writer != null)
                        writer.Write(e.Buffer, 0, e.BytesRecorded);
                    break;
                case STATE.STREAM:
                    bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
                    /*
                    // バイト列を合成
                    // waveIn.WaveFormat.BlockAlign indicates byte per sample
                    // nomally, 2byte(16bit) per sample (16bit = short)
                    for (int i = 0; i < e.BytesRecorded; i += waveMic.WaveFormat.BlockAlign)
                    {
                        //リトルエンディアンの並びで合成
                        short sample = (short)(e.Buffer[i + 1] << 8 | e.Buffer[i + 0]);
                        // make max 1.0f
                        float data = sample / 32768f;
                        // store data
                        waveBuffer.Add(data);
                    }

                    //バッファが十分溜まった
                    if (waveBuffer.BufferedLength >= FFTLength)
                    {
                        //バッファから読みだしてフーリエ変換
                        var fftsample = waveBuffer.Read(FFTLength);
                        var result = DoFourier(fftsample);
                        //(お好みで)結果を描画
                        RenderSpectrum(result);
                    }*/
                    break;
            }
        }

        private void WaveStereo_DataAvailable(object sender, WaveInEventArgs e)
        {
            switch (state)
            {
                case STATE.STREAM:
                    break;
            }
        }

        public void EndStreaming()
        {
            streaming = false;
            state = STATE.IDLE;
            waveMic.StopRecording();
            waveOut.Stop();
        }

        public void StartWork()
        {

        }


        public void EndWork()
        {

        }

    }

}