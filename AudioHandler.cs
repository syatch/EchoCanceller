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
        public int volumeGain = 0;
        WaveFileWriter writer;
        AudioFileReader reader;
        BufferedWaveProvider bufferedWaveProvider;
        public STATE state = STATE.DEFAULT;
        private bool streaming = false;
        private const int testWaitTime = 5000; // msec
        public enum STATE
        {
            DEFAULT,
            WAIT,
        }

        public AudioHandler()
        {
            waveMic = new WaveInEvent();
            waveStereo = new WaveInEvent();

            waveMic.WaveFormat = new WaveFormat(44100, 16, 2);
            // record when data available
            waveMic.DataAvailable += (s, a) =>
            {
                if (writer != null)
                    writer.Write(a.Buffer, 0, a.BytesRecorded);
            };
            waveMic.DataAvailable += WaveIn_DataAvailable;
            
            waveStereo.WaveFormat = new WaveFormat(44100, 16, 2);

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

            state = STATE.WAIT;
            
            // record in other thread
            Task task_record = Task.Run(() => {
                waveMic.StartRecording();
            });

            Task waitRecord = Task.Run(() => {
                Thread.Sleep(testWaitTime);
                state = STATE.DEFAULT;
            });

        }

        public void RecordTestAudioEnd()
        {
            waveMic.StopRecording();
            waveOut.Stop();
        }

        public void PlayTestAudio()
        {
            waveOut.DeviceNumber = outputDeviceIndex;
            reader = new AudioFileReader("./sounds/test.wav");
            waveOut.Init(reader);
            waveOut.Play();
            state = STATE.WAIT;
            Task waitRecord = Task.Run(() => {
                Thread.Sleep(testWaitTime);
                reader.Flush();
                reader.Dispose();
                reader = null;
                state = STATE.DEFAULT;
            });

        }

        public void StopTestAudio()
        {
            waveMic.StopRecording();
            waveOut.Stop();
            state = STATE.DEFAULT;
        }


        public void StartStreaming()
        {
            waveMic.WaveFormat = new WaveFormat(44100, 16, 2);
            streaming = true;
            waveMic.DeviceNumber = micDeviceIndex;
            waveMic.StartRecording();

            //一般的な44.1kHz, 16bit, ステレオサウンドの音源を想定
            bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat(44100, 16, 2));

            waveOut.DeviceNumber = outputDeviceIndex;
            waveOut.Init(bufferedWaveProvider);
            waveOut.Play();
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (streaming)
            {/*
                for (int index = 0; index < e.BytesRecorded; index++)
                {
                    e.Buffer[index] = e.Buffer[index] * volumeGain;
                }*/
                bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
            }
        }

        public void EndStreaming()
        {
            streaming = false;
            waveMic.StopRecording();
            waveOut.Stop();
        }
    }

}