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
using System.Numerics;

namespace echo_canceller
{
    class AudioHandler
    {
        private int micDeviceIndex;
        private int stereoMixerIndex;
        private int outputDeviceIndex;
        private String driver;
        private readonly int SAMPLE_RATE = 44100;
        private readonly int SAMPLE_BIT = 16;
        private WaveInEvent waveMic;
        private WaveInEvent waveStereo;
        private WaveOut waveOut = new WaveOut();
        private WaveBuffer waveBuffer = new WaveBuffer();
        public int volumeGain = 0;
        private double cutVolume = 0;
        private double micMeanVolume = 0;
        private double inputStereoLevel = 1.0;
        private double outputLevel = 1.0;
        WaveFileWriter writer;
        AudioFileReader reader;
        BufferedWaveProvider bufferedWaveProvider;
        private int BUFFERSIZE = (int)Math.Pow(2, 11); // must be a multiple of 2
        List<BufferedWaveProvider> buffers = new List<BufferedWaveProvider>();
        BufferedWaveProvider bufferedWaveProviderMic;
        BufferedWaveProvider bufferedWaveProviderStereo;
        AsioOut mixer;
        BufferedWaveProvider bufferedWaveProviderOut;
        MultiplexingWaveProvider mixWaveProvider;
        private STATE state = STATE.IDLE;
        public UISTATE uiState = UISTATE.DEFAULT;

        // const variable
        private readonly int FFTLength = 512;
        private readonly int testWaitTime = 5000; // msec
        private enum STATE
        {
            IDLE,
            RECORD,
            PLAY,
            STREAM,
            WORK,
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

            waveMic.WaveFormat = new WaveFormat(SAMPLE_RATE, SAMPLE_BIT, 2);
            bufferedWaveProviderMic = new BufferedWaveProvider(waveMic.WaveFormat);
            waveMic.DataAvailable += WaveMic_DataAvailable;

            waveStereo.WaveFormat = new WaveFormat(SAMPLE_RATE, SAMPLE_BIT, 2);
            bufferedWaveProviderStereo = new BufferedWaveProvider(waveStereo.WaveFormat);
            //Debug.WriteLine("Buffer Stereo Length : " + bufferedWaveProviderStereo.BufferLength);
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
                micMeanVolume = 0;
            };
        }
        ~AudioHandler()
        {
        }
        double GetVolume()
        {
            var devEnum = new MMDeviceEnumerator();
            var device = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            var masterVolume = device.AudioEndpointVolume.MasterVolumeLevelScalar;
            return masterVolume;
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
        public List<String> GetOutputDriverList()
        {
            var OutputDriverList = new List<String>();
            var asioDriverNames = AsioOut.GetDriverNames();
            foreach (string driverName in asioDriverNames)
                OutputDriverList.Add(driverName);
            return OutputDriverList;
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

        public void SetDriver(String name)
        {
            driver = name;
            Debug.WriteLine(name);
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
            writer = new WaveFileWriter("./sounds/test.wav", waveMic.WaveFormat);

            state = STATE.RECORD;
            uiState = UISTATE.WAIT;

            // record in other thread
            Task task_record = Task.Run(() =>
            {
                waveMic.StartRecording();
            });

            Task waitRecord = Task.Run(() =>
            {
                Thread.Sleep(testWaitTime);
                uiState = UISTATE.DEFAULT;
            });

        }

        public void RecordTestAudioEnd()
        {
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
            Task waitRecord = Task.Run(() =>
            {
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
            waveMic.WaveFormat = new WaveFormat(SAMPLE_RATE, SAMPLE_BIT, 2);
            state = STATE.STREAM;
            waveMic.DeviceNumber = micDeviceIndex;
            waveMic.BufferMilliseconds = (int)((double)BUFFERSIZE / (double)SAMPLE_RATE * 1000.0);
            waveMic.StartRecording();
            // for stream
            bufferedWaveProviderMic = new BufferedWaveProvider(waveMic.WaveFormat);
            bufferedWaveProviderMic.BufferLength = BUFFERSIZE * 2;
            bufferedWaveProviderMic.DiscardOnBufferOverflow = true;

            //一般的な44.1kHz, 16bit, ステレオサウンドの音源を想定
            bufferedWaveProvider = new BufferedWaveProvider(waveMic.WaveFormat);
            bufferedWaveProvider.DiscardOnBufferOverflow = true;
            bufferedWaveProviderOut = new BufferedWaveProvider(waveMic.WaveFormat);
            bufferedWaveProviderOut.DiscardOnBufferOverflow = true;
            waveOut.DeviceNumber = outputDeviceIndex;
            waveOut.Init(bufferedWaveProvider);
            waveOut.Play();

            // stereo data also stream
            waveStereo.DeviceNumber = stereoMixerIndex;
            waveStereo.WaveFormat = new WaveFormat(SAMPLE_RATE, SAMPLE_BIT, 2);
            waveStereo.BufferMilliseconds = (int)((double)BUFFERSIZE / (double)SAMPLE_RATE * 1000.0);
            waveStereo.StartRecording();
            bufferedWaveProviderStereo = new BufferedWaveProvider(waveStereo.WaveFormat);
            bufferedWaveProviderStereo.BufferLength = BUFFERSIZE * 2;
            bufferedWaveProviderStereo.DiscardOnBufferOverflow = true;

            buffers.Clear();
            buffers.Add(bufferedWaveProviderMic);
            buffers.Add(bufferedWaveProviderStereo);
            buffers.Add(bufferedWaveProviderOut);
        }

        private void WaveMic_DataAvailable(object sender, WaveInEventArgs e)
        {
            // store data and get mic volume 
            byte[] rawData = e.Buffer;
            int rawDataNum = e.BytesRecorded / 2;
            var getData = new Int16[rawDataNum];
            double mean = 0;
            for (int i = 0; i < rawDataNum; i++)
            {
                // read the int16 from the two bytes
                Int16 val = BitConverter.ToInt16(rawData, i * 2);
                getData[i] = val;
                mean += Math.Abs(val) / Math.Pow(2, SAMPLE_BIT);
            }
            micMeanVolume = mean / rawDataNum;
            //Debug.WriteLine(Math.Abs(mean));

            switch (state)
            {
                case STATE.RECORD:
                    if (writer != null)
                        writer.Write(e.Buffer, 0, e.BytesRecorded);
                    break;
                case STATE.STREAM:
                    bufferedWaveProviderMic.AddSamples(e.Buffer, 0, e.BytesRecorded);
                    bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
                    bufferedWaveProviderOut.ClearBuffer();
                    bufferedWaveProviderOut.AddSamples(e.Buffer, 0, e.BytesRecorded);
                    break;
                case STATE.WORK:
                    var convertData = new Int16[rawDataNum];
                    var convertRawData = new byte[e.BytesRecorded];
                    var inputData = new Int16[rawDataNum];
                    var inputRawData = new byte[e.BytesRecorded];
                    // convert data
                    for (int i = 0; i < rawDataNum; i++)
                    {
                        // store the value in Ys as a percent (+/- 100% = 200%)
                        short data = (Int16)(-1 * getData[i]);
                        //Debug.WriteLine(data);
                        if ((Math.Abs(data) < cutVolume) || (Math.Abs(data) == 0))
                            convertData[i] = 1;
                        else
                            convertData[i] = data;
                        // input data
                        inputData[i] = convertData[i];// * inputLevel;
                        // get input rawdata
                        //var byteInputData = BitConverter.GetBytes(inputData[i]);
                        inputRawData[i * 2] = BitConverter.GetBytes(inputData[i])[0];
                        inputRawData[i * 2 + 1] = BitConverter.GetBytes(inputData[i])[1];



                        // output level
                        convertData[i] = (short)(convertData[i] * outputLevel);

                        // Debug.WriteLine(" : " + convertData[i]);
                        //var byteData = BitConverter.GetBytes(convertData[i]);
                        convertRawData[i * 2] = BitConverter.GetBytes(convertData[i])[0];
                        convertRawData[i * 2 + 1] = BitConverter.GetBytes(convertData[i])[1];

                    }

                    //bufferedWaveProviderMic.AddSamples(e.Buffer, 0, e.BytesRecorded);
                    bufferedWaveProviderMic.AddSamples(inputRawData, 0, e.BytesRecorded);
                    bufferedWaveProvider.AddSamples(convertRawData, 0, e.BytesRecorded);
                    bufferedWaveProviderOut.ClearBuffer();
                    bufferedWaveProviderOut.AddSamples(convertRawData, 0, e.BytesRecorded);
                    break;
            }

        }

        private void WaveStereo_DataAvailable(object sender, WaveInEventArgs e)
        {
            switch (state)
            {
                case STATE.STREAM:
                    bufferedWaveProviderStereo.AddSamples(e.Buffer, 0, e.BytesRecorded);
                    break;
                case STATE.WORK:
                    bufferedWaveProviderStereo.AddSamples(e.Buffer, 0, e.BytesRecorded);
                    break;
            }
        }


        public void EndStreaming()
        {
            state = STATE.IDLE;
            waveMic.StopRecording();
            waveOut.Stop();
            waveStereo.StopRecording();
            waveStereo.StopRecording();
        }

        public void StartWork()
        {
            waveMic.WaveFormat = new WaveFormat(SAMPLE_RATE, SAMPLE_BIT, 2);
            state = STATE.WORK;
            waveMic.DeviceNumber = micDeviceIndex;
            waveMic.BufferMilliseconds = (int)((double)BUFFERSIZE / (double)SAMPLE_RATE * 1000.0);
            waveMic.StartRecording();
            // for mic
            bufferedWaveProviderMic = new BufferedWaveProvider(waveMic.WaveFormat);
            bufferedWaveProviderMic.BufferLength = BUFFERSIZE * 2;
            bufferedWaveProviderMic.DiscardOnBufferOverflow = true;


            // stereo data also stream
            waveStereo.DeviceNumber = stereoMixerIndex;
            waveStereo.WaveFormat = new WaveFormat(SAMPLE_RATE, SAMPLE_BIT, 2);
            waveStereo.BufferMilliseconds = (int)((double)BUFFERSIZE / (double)SAMPLE_RATE * 1000.0);
            waveStereo.StartRecording();
            bufferedWaveProviderStereo = new BufferedWaveProvider(waveStereo.WaveFormat);
            bufferedWaveProviderStereo.BufferLength = BUFFERSIZE * 2;
            bufferedWaveProviderStereo.DiscardOnBufferOverflow = true;

            bufferedWaveProvider = new BufferedWaveProvider(waveMic.WaveFormat);
            bufferedWaveProvider.DiscardOnBufferOverflow = true;
            bufferedWaveProviderOut = new BufferedWaveProvider(waveMic.WaveFormat);
            bufferedWaveProviderOut.DiscardOnBufferOverflow = true;
            waveOut.DeviceNumber = outputDeviceIndex;
            waveOut.Init(bufferedWaveProvider);
            waveOut.Play();

            buffers.Clear();
            buffers.Add(bufferedWaveProviderMic);
            buffers.Add(bufferedWaveProviderStereo);
            buffers.Add(bufferedWaveProviderOut);
        }

        private string GetDanteDriverName()
        {
            foreach (var driverName in AsioOut.GetDriverNames())
            {
                if (driverName.Contains("Dante Virtual Soundcard"))
                {
                    return driverName;
                }
            }
            return null;
        }

        private void test(object sender, AsioAudioAvailableEventArgs e)
        {
            Debug.WriteLine("test");
        }
        public void EndWork()
        {
            state = STATE.IDLE;
            waveMic.StopRecording();
            waveStereo.StopRecording();
            waveOut.Stop();
            waveStereo.StopRecording();

        }

        public List<(double[], double)> GetPlotData()
        {
            var data = new List<(double[], double)>();
            if ((state != STATE.STREAM) && (state != STATE.WORK))
                return null;

            for (int index = 0; index < buffers.Count; index++)
            { 
                // check the incoming microphone audio
                int frameSize = BUFFERSIZE;
            
                var audioBytes = new byte[frameSize];
                //bufferedWaveProviderMic.ClearBuffer();
                buffers[index].Read(audioBytes, 0, frameSize);

                // return if there's nothing new to plot
                if (audioBytes.Length == 0)
                    return null;
                if (audioBytes[frameSize - 2] == 0)
                    return null;

                // incoming data is 16-bit (2 bytes per audio point)
                int BYTES_PER_POINT = 2;

                // create a (32-bit) int array ready to fill with the 16-bit data
                int graphPointCount = audioBytes.Length / BYTES_PER_POINT;

                // create double arrays to hold the data we will graph
                double[] pcm = new double[graphPointCount];
                double[] fft = new double[graphPointCount];
                double[] fftReal = new double[graphPointCount / 2];

                // populate Xs and Ys with double data
                for (int i = 0; i < graphPointCount; i++)
                {
                    // read the int16 from the two bytes
                    Int16 val = BitConverter.ToInt16(audioBytes, i * 2);
                    // store the value in Ys as a percent (+/- 100% = 200%)
                    pcm[i] = (double)(val) / Math.Pow(2, SAMPLE_BIT) * 200.0;
                }

                // calculate the full FFT
                fft = FFT(pcm);

                // determine horizontal axis units for graphs
                double pcmPointSpacingMs = SAMPLE_RATE / 1000;
                double fftMaxFreq = SAMPLE_RATE / 2;
                double fftPointSpacingHz = fftMaxFreq / graphPointCount;
                
                // just keep the real half (the other half imaginary)
                Array.Copy(fft, fftReal, fftReal.Length);
                data.Add((pcm, pcmPointSpacingMs));
                data.Add((fftReal, fftPointSpacingHz));
            }

            return data;
        }

        public double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
                fftComplex[i] = new System.Numerics.Complex(data[i], 0.0);
            Accord.Math.FourierTransform.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);
            for (int i = 0; i < data.Length; i++)
                fft[i] = fftComplex[i].Magnitude;
            return fft;
        }

        /// <summary>
        /// volume must be from 0.0 to 1.0
        /// </summary>
        /// <param name="volume"></param>
        public void SetCutVolume(double volume)
        {
            cutVolume = volume * 100;
        }
        public double GetMicVolume()
        {
            return micMeanVolume / Math.Pow(2, SAMPLE_BIT) * 100000;
        }
        public void SetInputStereoLevel(double level)
        {
            inputStereoLevel = level;
        }
        public void SetOutputLevel(double level)
        {
            outputLevel = level;
        }
    }
}