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
        List<ScottPlot.FormsPlot> Plots = new List<ScottPlot.FormsPlot>();
        private readonly int plotNum = 6;
        public bool needsAutoScaling = true;
        readonly String[] deviceType = {"Microphone", "StereoMixer", "OutPut"};
        public MainWindow()
        {
            InitializeComponent();
            GetMicInfo();
            SetupGraphLabels();
            timerReplot.Enabled = true;
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
            var inputDeviceList = AudioHandler.GetInputDeviceList();
            for (int i = 0; i < inputDeviceList.Count; i++)
            {
                comboBoxMicrophone.Items.Add(inputDeviceList[i]);
                comboBoxStereoMixer.Items.Add(inputDeviceList[i]);
            }
            comboBoxMicrophone.SelectedIndex = 0;
            comboBoxStereoMixer.SelectedIndex = 0;

            // Update output device list
            var outputDeviceList = AudioHandler.GetOutputDeviceList();
            for (int i = 0; i < outputDeviceList.Count; i++)
                comboBoxOutputDevice.Items.Add(outputDeviceList[i]);
            comboBoxOutputDevice.SelectedIndex = 0;

            var driverList = AudioHandler.GetOutputDriverList();
            for (int i = 0; i < driverList.Count; i++)
                comboBoxDriver.Items.Add(driverList[i]);
            comboBoxDriver.SelectedIndex = 0;

        }

        public void SetupGraphLabels()
        {
            Plots.Add(formsPlotMicRaw);
            Plots.Add(formsPlotMicFFT);
            Plots.Add(formsPlotStereoRaw);
            Plots.Add(formsPlotStereoFFT);
            Plots.Add(formsPlotOutRaw);
            Plots.Add(formsPlotOutFFT);

            int count = 0;
            for (int i = 0; i < plotNum; i++)
            {
                Plots[i].Plot.XAxis.Ticks(false);
                Plots[i].Plot.XAxis.Grid(false);
                Plots[i].Plot.YAxis.Ticks(false);
                Plots[i].Plot.YAxis.Grid(false);

                Plots[i].Plot.Style(figureBackground: Color.Black,
                                    dataBackground: Color.Black,
                                    grid: Color.White,
                                    tick: Color.White,
                                    axisLabel: Color.White,
                                    titleLabel: Color.White);

                switch (i % 2)
                {
                    case 0:
                        Plots[i].Plot.Title(deviceType[count] + " PCM Data");
                        Plots[i].Plot.YLabel("Amplitude (PCM)");
                        Plots[i].Plot.XLabel("Time (ms)");
                        break;
                    case 1:
                        Plots[i].Plot.Title(deviceType[count] + " FFT Data");
                        Plots[i].Plot.YLabel("Power (raw)");
                        Plots[i].Plot.XLabel("Frequency (Hz)");
                        count++;
                        break;
                }
            }

        }

        /// <summary>
        /// just for check input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioHandler.SetInputDeviceIndex(comboBoxMicrophone.SelectedIndex);
        }

        private void comboBoxStereoMixer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioHandler.SetStereoMixerIndex(comboBoxStereoMixer.SelectedIndex);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioHandler.SetOutputDeviceIndex(comboBoxOutputDevice.SelectedIndex);
        }

        private void comboBoxDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioHandler.SetDriver(comboBoxDriver.SelectedItem.ToString());
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
        private void labelStereoGraph_Click(object sender, EventArgs e)
        {

        }


        private void timerReplot_Tick(object sender, EventArgs e)
        {
            // Debug.WriteLine("timer");
            // turn off the timer, take as long as we need to plot, then turn the timer back on
            timerReplot.Enabled = false;
            PlotLatestData();
            timerReplot.Enabled = true;

            UpdateMicVolume();
        }

        public void PlotLatestData()
        {
            var plotList = AudioHandler.GetPlotData();

            if (plotList == null)
            {
                Application.DoEvents();
                return;
            }

            for (int i = 0; i < plotList.Count; i++)
            {
                var (data, hz) = plotList[i];
                // plot the Xs and Ys for both graphs
                Plots[i].Plot.Clear();
                Plots[i].Plot.PlotSignal(data, hz, color: Color.White);
                Plots[i].RefreshRequest();
            }

            // optionally adjust the scale to automatically fit the data
            if (needsAutoScaling)
            {
                Plots[0].Plot.AxisAuto();
                Plots[1].Plot.AxisAuto();
                needsAutoScaling = false;
            }

            //scottPlotUC1.PlotSignal(Ys, RATE);

            // this reduces flicker and helps keep the program responsive
            Application.DoEvents();

        }

        private void autoScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            needsAutoScaling = true;
        }

        private void trackBarCutVolume_Scroll(object sender, EventArgs e)
        {
            AudioHandler.SetCutVolume((double)trackBarCutVolume.Value / trackBarCutVolume.Maximum);
        }

        private void UpdateMicVolume()
        {
            int value = (int)(AudioHandler.GetMicVolume() * 10000);
            if (value < 0)
                value = 0;
            else if (1000 < value)
                value = 1000;
            progressBarCutVolume.Value = value;
        }
    }
}
