using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.Wave; // for WaveIn
using System.Diagnostics; // debug write
using System.Threading;

namespace echo_canceller
{
    public partial class MainWindow : Form
    {
        private bool canceller_function = false;
        private bool testing = false;
        private bool streaming = false;
        AudioHandler AudioHandler = new AudioHandler();
        public MainWindow()
        {
            InitializeComponent();
            GetMicInfo();
        }
  
        private void EnableConboBox()
        {
            comboBoxMicrophone.Enabled = true;
            comboBoxStereoMixer.Enabled = true;
            comboBoxOutputDevice.Enabled = true;
        }

        private void DisableConboBox()
        {
            comboBoxMicrophone.Enabled = false;
            comboBoxStereoMixer.Enabled = false;
            comboBoxOutputDevice.Enabled = false;
        }

        private void GetMicInfo()
        {
            //var AudioHandler = new AudioHandler();

            // Update input device list
            var InputDeviceList = AudioHandler.GetInputDeviceList();
            for (int i = 0; i < InputDeviceList.Count; i++)
            {
                comboBoxMicrophone.Items.Add(InputDeviceList[i]);
                comboBoxStereoMixer.Items.Add(InputDeviceList[i]);
            }
            comboBoxMicrophone.SelectedIndex = 0;
            comboBoxStereoMixer.SelectedIndex = 0;

            // Update output device list
            var OutputDeviceList = AudioHandler.GetOutputDeviceList();
            for (int i = 0; i < OutputDeviceList.Count; i++)
                comboBoxOutputDevice.Items.Add(OutputDeviceList[i]);
            comboBoxOutputDevice.SelectedIndex = 0;

        }

        /// <summary>
        /// just for check input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = "Selected Input Item : " + comboBoxMicrophone.SelectedItem.ToString();
            AudioHandler.SetInputDeviceIndex(comboBoxMicrophone.SelectedIndex);
        }

        private void comboBoxStereoMixer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioHandler.SetStereoMixerIndex(comboBoxStereoMixer.SelectedIndex);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = "Selected Output Item : " + comboBoxOutputDevice.SelectedItem.ToString();
            AudioHandler.SetOutputDeviceIndex(comboBoxOutputDevice.SelectedIndex);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonWork_Click(object sender, EventArgs e)
        {
            canceller_function = !canceller_function;

            if (canceller_function) {
                buttonWork.Text = "End";
                buttonTest.Enabled = false;
                buttonStream.Enabled = false;
                DisableConboBox();
                AudioHandler.StartWork();
            } else {
                buttonWork.Text = "Start";
                buttonTest.Enabled = true;
                buttonStream.Enabled = true;
                EnableConboBox();
                AudioHandler.EndWork();
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            testing = !testing;
            if (buttonTest.Text == "Test")
            {
                buttonTest.Enabled = false;
                buttonWork.Enabled = false;
                buttonStream.Enabled = false;
                DisableConboBox();
                buttonTest.Text = "Testing...";
                labelTest.Text = "Device Test : Speak something...";
                AudioHandler.RecordTestAudioStart();

                while (AudioHandler.uiState == AudioHandler.UISTATE.WAIT) {
                    Application.DoEvents();
                    Thread.Sleep(10);
                };

                AudioHandler.RecordTestAudioEnd();

                labelTest.Text = "Device Test : Now playing...";
                AudioHandler.PlayTestAudio();

                while (AudioHandler.uiState == AudioHandler.UISTATE.WAIT)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                };
                AudioHandler.StopTestAudio();
                labelTest.Text = "Device Test : Not testing";
                buttonTest.Text = "Test";
                Debug.WriteLine("end testing");
            }
            buttonTest.Enabled = true;
            buttonWork.Enabled = true;
            buttonStream.Enabled = true;
            EnableConboBox();
        }

        private void buttonStream_Click(object sender, EventArgs e)
        {
            streaming = !streaming;

            if (streaming)
            {
                buttonStream.Text = "Streaming";
                buttonTest.Enabled = false;
                buttonWork.Enabled = false;
                DisableConboBox();
                AudioHandler.StartStreaming();
            }
            else
            {
                buttonStream.Text = "Stream";
                buttonTest.Enabled = true;
                buttonWork.Enabled = true;
                EnableConboBox();
                AudioHandler.EndStreaming();
            }
        }

        private void setWaveViewer()
        {
/*
            var waveStereo = new WaveInEvent();
            waveViewerMicrophone.BackColor = Color.White;
            waveViewerMicrophone.SamplesPerPixel = 400;
            waveViewerMicrophone.StartPosition = 40000;
            waveViewerMicrophone.WaveStream = waveStereo; // ストリームを指定するだけでよい
            waveViewerStereoMixer.BackColor = Color.White;
            waveViewerStereoMixer.SamplesPerPixel = 400;
            waveViewerStereoMixer.StartPosition = 40000;
            waveViewerStereoMixer.WaveStream = new WaveFileReader(open.FileName); // ストリームを指定するだけでよい
            waveViewerOutput.BackColor = Color.White;
            waveViewerOutput.SamplesPerPixel = 400;
            waveViewerOutput.StartPosition = 40000;
            waveViewerOutput.WaveStream = new WaveFileReader(open.FileName); // ストリームを指定するだけでよい*/

        }

        private void labelStereoGraph_Click(object sender, EventArgs e)
        {

        }
    }
}
