using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave; // for WaveIn
using NAudio.Wave.SampleProviders; // for WaveIn
using System.Diagnostics; // debug write
using System.Threading;

namespace eco_canceler
{
    class AudioHandler
    {
        private int inputDeviceIndex;
        private int outputDeviceIndex;
        private WaveInEvent waveIn;
        private WaveOut waveOut = new WaveOut();
        public STATE state = STATE.DEFAULT;
        private const int testWaitTime = 5000; // msec
        public enum STATE
        {
            DEFAULT,
            RECORDING,
            PLAYING,
        }

        public AudioHandler()
        {
            waveIn = new WaveInEvent();
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
            inputDeviceIndex = Index;
        }

        /// <summary>
        /// set output device
        /// </summary>
        /// <param name="Index"></param>
        public void SetOutputDeviceIndex(int Index)
        {
            outputDeviceIndex = Index;
        }

        private void PlaySilence()
        {
            var sinesetup = new SignalGenerator()
            {
                Gain = 0.0, // 音量
                Frequency = 440, // 周波数
                Type = SignalGeneratorType.Sin // Sin波に指定
            };

            waveOut.Init(sinesetup);
            waveOut.Play();
            while (waveOut.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(500);
            }
        }
        public void RecordTestAudioStart()
        {
            waveIn.DeviceNumber = inputDeviceIndex;
            var writer =  new WaveFileWriter("./sounds/test.wav", waveIn.WaveFormat);

            // record when data available
            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
            };

            // record ending func
            waveIn.RecordingStopped += (s, a) =>
            {
                Debug.WriteLine("end recording");
                writer.Flush();
                writer.Dispose();
                writer = null;
                waveIn.Dispose();
            };

            state = STATE.RECORDING;
            
            // record in other thread
            Task task_record = Task.Run(() => {
                Debug.WriteLine("start recording");
                waveIn.StartRecording();
            });

            // may be not need
            /*
            Task task_silence = Task.Run(() => {
                Debug.WriteLine("play silence");
                PlaySilence();
            });*/

            Task waitRecord = Task.Run(() => {
                Thread.Sleep(testWaitTime);
                state = STATE.DEFAULT;
            });

        }

        public void RecordTestAudioEnd()
        {
            waveIn.StopRecording();
            waveOut.Stop();
        }

        public void PlayTestAudio()
        {
            waveOut.DeviceNumber = outputDeviceIndex;
            var reader = new AudioFileReader("./sounds/test.wav");
            waveOut.Init(reader);
            waveOut.Play();
            
            state = STATE.PLAYING;
            Task waitRecord = Task.Run(() => {
                Thread.Sleep(testWaitTime);
                state = STATE.DEFAULT;
            });

        }

        public void StopTestAudio()
        {
            waveIn.StopRecording();
            waveOut.Stop();
            state = STATE.DEFAULT;
        }


        // Debug.WriteLine("button clicked");
        /*
        var waveIn = new WaveIn()
        {
            DeviceNumber = 0, // Default
        };
        waveIn.DataAvailable += WaveIn_DataAvailable;
        waveIn.WaveFormat = new WaveFormat(sampleRate: 8000, channels: 1);
        waveIn.StartRecording();*/
        /*
                private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
                {
                    // 32bitで最大値1.0fにする
                    for (int index = 0; index < e.BytesRecorded; index += 2)
                    {
                        short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);

                        float sample32 = sample / 32768f;
                        //                ProcessSample(sample32);
                    }
                }*/

    }
}
