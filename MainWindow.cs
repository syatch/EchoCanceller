using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using NAudio.Wave; // for WaveIn
using System.Diagnostics; // debug write
using System.Threading;

namespace eco_canceler
{
    public partial class MainWindow : Form
    {
        private bool canceller_function = false;
        private bool testing = false;
        AudioHandler AudioHandler = new AudioHandler();
        public MainWindow()
        {
            InitializeComponent();
            GetMicInfo();
        }
  
        private void GetMicInfo()
        {
            //var AudioHandler = new AudioHandler();

            // Update input device list
            var InputDeviceList = AudioHandler.GetInputDeviceList();
            for (int i = 0; i < InputDeviceList.Count; i++)
                comboBoxInputDevice.Items.Add(InputDeviceList[i]);
            comboBoxInputDevice.SelectedIndex = 0;
            
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
            label3.Text = "Selected Input Item : " + comboBoxInputDevice.SelectedItem.ToString();
            AudioHandler.SetInputDeviceIndex(comboBoxInputDevice.SelectedIndex);
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

        private void button1_Click(object sender, EventArgs e)
        {
            canceller_function = !canceller_function;

            if (canceller_function)
                button1.Text = "End";
            else
                button1.Text = "Start";
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            testing = !testing;
            if (testing)
            {
                buttonTest.Text = "Testing...";
                labelTest.Text = "Device test : Speak something...";
                AudioHandler.RecordTestAudioStart();

                while (AudioHandler.state == AudioHandler.STATE.RECORDING) {
                    Application.DoEvents();
                    Thread.Sleep(10);
                };

                AudioHandler.RecordTestAudioEnd();

                labelTest.Text = "Device test : Now playing...";
                AudioHandler.PlayTestAudio();

                while (AudioHandler.state == AudioHandler.STATE.PLAYING)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                };

                labelTest.Text = "Device test : Not testing";
                buttonTest.Text = "Test";
            } else {
                buttonTest.Text = "Test";
            }
            AudioHandler.StopTestAudio();
        }


        /* private void GetAudioWave()
         {
             WaveChannel32 wave = new WaveChannel32(new WaveFileReader(txtWave.Text));
             int sampleSize = 1024;
             var bufferSize = 16384 * sampleSize;
             var buffer = new byte[bufferSize];
             int read = 0;
             chart1.Series.Add("wave");
             chart1.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
             chart1.Series["wave"].ChartArea = "ChartArea1";
             while (wave.Position < wave.Length)
             {
                 read = wave.Read(buffer, 0, bufferSize);
                 for (int i = 0; i < read / sampleSize; i++)
                 {
                     var point = BitConverter.ToSingle(buffer, i * sampleSize);

                     chart1.Series["wave"].Points.Add(point);
                 }
             }
         }*/
    }
}
