namespace echo_canceller
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxMicrophone = new System.Windows.Forms.ComboBox();
            this.labelMicrophone = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.comboBoxOutputDevice = new System.Windows.Forms.ComboBox();
            this.buttonWork = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.buttonStream = new System.Windows.Forms.Button();
            this.labelStereoMixer = new System.Windows.Forms.Label();
            this.comboBoxStereoMixer = new System.Windows.Forms.ComboBox();
            this.labelStreamTest = new System.Windows.Forms.Label();
            this.labelMicGraph = new System.Windows.Forms.Label();
            this.labelStereoGraph = new System.Windows.Forms.Label();
            this.labelOutputGraph = new System.Windows.Forms.Label();
            this.formsPlotMicRaw = new ScottPlot.FormsPlot();
            this.formsPlotMicFFT = new ScottPlot.FormsPlot();
            this.formsPlotStereoRaw = new ScottPlot.FormsPlot();
            this.formsPlotStereoFFT = new ScottPlot.FormsPlot();
            this.formsPlotOutRaw = new ScottPlot.FormsPlot();
            this.formsPlotOutFFT = new ScottPlot.FormsPlot();
            this.timerReplot = new System.Windows.Forms.Timer(this.components);
            this.labeldriver = new System.Windows.Forms.Label();
            this.comboBoxDriver = new System.Windows.Forms.ComboBox();
            this.trackBarCutVolume = new System.Windows.Forms.TrackBar();
            this.labelCutVolume = new System.Windows.Forms.Label();
            this.progressBarCutVolume = new System.Windows.Forms.ProgressBar();
            this.trackBarMicInputLevel = new System.Windows.Forms.TrackBar();
            this.labelMicInputVolume = new System.Windows.Forms.Label();
            this.labelOutputLevel = new System.Windows.Forms.Label();
            this.trackBarOutputLevel = new System.Windows.Forms.TrackBar();
            this.numericUpDownCutVolume = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMicLevel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOutputLevel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCutVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMicInputLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOutputLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCutVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMicLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxMicrophone
            // 
            this.comboBoxMicrophone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMicrophone.FormattingEnabled = true;
            this.comboBoxMicrophone.Location = new System.Drawing.Point(12, 56);
            this.comboBoxMicrophone.Name = "comboBoxMicrophone";
            this.comboBoxMicrophone.Size = new System.Drawing.Size(776, 32);
            this.comboBoxMicrophone.TabIndex = 3;
            this.comboBoxMicrophone.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelMicrophone
            // 
            this.labelMicrophone.AutoSize = true;
            this.labelMicrophone.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMicrophone.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelMicrophone.Location = new System.Drawing.Point(12, 20);
            this.labelMicrophone.Name = "labelMicrophone";
            this.labelMicrophone.Size = new System.Drawing.Size(264, 33);
            this.labelMicrophone.TabIndex = 4;
            this.labelMicrophone.Text = "Select Microphone";
            this.labelMicrophone.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutput.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelOutput.Location = new System.Drawing.Point(12, 203);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(304, 33);
            this.labelOutput.TabIndex = 5;
            this.labelOutput.Text = "Select Output Device";
            // 
            // comboBoxOutputDevice
            // 
            this.comboBoxOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOutputDevice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxOutputDevice.FormattingEnabled = true;
            this.comboBoxOutputDevice.Location = new System.Drawing.Point(12, 239);
            this.comboBoxOutputDevice.Name = "comboBoxOutputDevice";
            this.comboBoxOutputDevice.Size = new System.Drawing.Size(776, 32);
            this.comboBoxOutputDevice.TabIndex = 6;
            this.comboBoxOutputDevice.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // buttonWork
            // 
            this.buttonWork.BackColor = System.Drawing.Color.Silver;
            this.buttonWork.ForeColor = System.Drawing.SystemColors.Info;
            this.buttonWork.Location = new System.Drawing.Point(2433, 1361);
            this.buttonWork.Name = "buttonWork";
            this.buttonWork.Size = new System.Drawing.Size(182, 53);
            this.buttonWork.TabIndex = 10;
            this.buttonWork.Text = "Start";
            this.buttonWork.UseVisualStyleBackColor = false;
            this.buttonWork.Click += new System.EventHandler(this.buttonWork_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.BackColor = System.Drawing.Color.Silver;
            this.buttonTest.ForeColor = System.Drawing.SystemColors.Info;
            this.buttonTest.Location = new System.Drawing.Point(636, 289);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(152, 53);
            this.buttonTest.TabIndex = 11;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = false;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTest.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelTest.Location = new System.Drawing.Point(12, 289);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(353, 33);
            this.labelTest.TabIndex = 12;
            this.labelTest.Text = "Device Test : Not testing";
            // 
            // buttonStream
            // 
            this.buttonStream.BackColor = System.Drawing.Color.Silver;
            this.buttonStream.ForeColor = System.Drawing.SystemColors.Info;
            this.buttonStream.Location = new System.Drawing.Point(636, 381);
            this.buttonStream.Name = "buttonStream";
            this.buttonStream.Size = new System.Drawing.Size(152, 53);
            this.buttonStream.TabIndex = 13;
            this.buttonStream.Text = "Stream";
            this.buttonStream.UseVisualStyleBackColor = false;
            this.buttonStream.Click += new System.EventHandler(this.buttonStream_Click);
            // 
            // labelStereoMixer
            // 
            this.labelStereoMixer.AutoSize = true;
            this.labelStereoMixer.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStereoMixer.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelStereoMixer.Location = new System.Drawing.Point(12, 109);
            this.labelStereoMixer.Name = "labelStereoMixer";
            this.labelStereoMixer.Size = new System.Drawing.Size(282, 33);
            this.labelStereoMixer.TabIndex = 17;
            this.labelStereoMixer.Text = "Select Stereo Mixer";
            // 
            // comboBoxStereoMixer
            // 
            this.comboBoxStereoMixer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStereoMixer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxStereoMixer.FormattingEnabled = true;
            this.comboBoxStereoMixer.Location = new System.Drawing.Point(12, 145);
            this.comboBoxStereoMixer.Name = "comboBoxStereoMixer";
            this.comboBoxStereoMixer.Size = new System.Drawing.Size(776, 32);
            this.comboBoxStereoMixer.TabIndex = 18;
            this.comboBoxStereoMixer.SelectedIndexChanged += new System.EventHandler(this.comboBoxStereoMixer_SelectedIndexChanged);
            // 
            // labelStreamTest
            // 
            this.labelStreamTest.AutoSize = true;
            this.labelStreamTest.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStreamTest.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelStreamTest.Location = new System.Drawing.Point(12, 381);
            this.labelStreamTest.Name = "labelStreamTest";
            this.labelStreamTest.Size = new System.Drawing.Size(220, 33);
            this.labelStreamTest.TabIndex = 19;
            this.labelStreamTest.Text = "Streaming Test";
            // 
            // labelMicGraph
            // 
            this.labelMicGraph.AutoSize = true;
            this.labelMicGraph.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelMicGraph.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMicGraph.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelMicGraph.Location = new System.Drawing.Point(906, 20);
            this.labelMicGraph.Name = "labelMicGraph";
            this.labelMicGraph.Size = new System.Drawing.Size(259, 33);
            this.labelMicGraph.TabIndex = 22;
            this.labelMicGraph.Text = "Microphone Graph";
            // 
            // labelStereoGraph
            // 
            this.labelStereoGraph.AutoSize = true;
            this.labelStereoGraph.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelStereoGraph.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStereoGraph.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelStereoGraph.Location = new System.Drawing.Point(906, 452);
            this.labelStereoGraph.Name = "labelStereoGraph";
            this.labelStereoGraph.Size = new System.Drawing.Size(277, 33);
            this.labelStereoGraph.TabIndex = 23;
            this.labelStereoGraph.Text = "Stereo Mixer Graph";
            this.labelStereoGraph.Click += new System.EventHandler(this.labelStereoGraph_Click);
            // 
            // labelOutputGraph
            // 
            this.labelOutputGraph.AutoSize = true;
            this.labelOutputGraph.BackColor = System.Drawing.SystemColors.WindowText;
            this.labelOutputGraph.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelOutputGraph.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelOutputGraph.Location = new System.Drawing.Point(906, 896);
            this.labelOutputGraph.Name = "labelOutputGraph";
            this.labelOutputGraph.Size = new System.Drawing.Size(212, 33);
            this.labelOutputGraph.TabIndex = 24;
            this.labelOutputGraph.Text = "Out Put Graph";
            // 
            // formsPlotMicRaw
            // 
            this.formsPlotMicRaw.BackColor = System.Drawing.Color.Transparent;
            this.formsPlotMicRaw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlotMicRaw.Location = new System.Drawing.Point(852, 59);
            this.formsPlotMicRaw.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlotMicRaw.Name = "formsPlotMicRaw";
            this.formsPlotMicRaw.Size = new System.Drawing.Size(860, 375);
            this.formsPlotMicRaw.TabIndex = 25;
            // 
            // formsPlotMicFFT
            // 
            this.formsPlotMicFFT.BackColor = System.Drawing.Color.Transparent;
            this.formsPlotMicFFT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlotMicFFT.Location = new System.Drawing.Point(1756, 59);
            this.formsPlotMicFFT.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlotMicFFT.Name = "formsPlotMicFFT";
            this.formsPlotMicFFT.Size = new System.Drawing.Size(860, 375);
            this.formsPlotMicFFT.TabIndex = 26;
            // 
            // formsPlotStereoRaw
            // 
            this.formsPlotStereoRaw.BackColor = System.Drawing.Color.Transparent;
            this.formsPlotStereoRaw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlotStereoRaw.Location = new System.Drawing.Point(852, 502);
            this.formsPlotStereoRaw.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlotStereoRaw.Name = "formsPlotStereoRaw";
            this.formsPlotStereoRaw.Size = new System.Drawing.Size(860, 375);
            this.formsPlotStereoRaw.TabIndex = 27;
            // 
            // formsPlotStereoFFT
            // 
            this.formsPlotStereoFFT.BackColor = System.Drawing.Color.Transparent;
            this.formsPlotStereoFFT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlotStereoFFT.Location = new System.Drawing.Point(1756, 502);
            this.formsPlotStereoFFT.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlotStereoFFT.Name = "formsPlotStereoFFT";
            this.formsPlotStereoFFT.Size = new System.Drawing.Size(860, 375);
            this.formsPlotStereoFFT.TabIndex = 28;
            // 
            // formsPlotOutRaw
            // 
            this.formsPlotOutRaw.BackColor = System.Drawing.Color.Transparent;
            this.formsPlotOutRaw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlotOutRaw.Location = new System.Drawing.Point(852, 935);
            this.formsPlotOutRaw.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlotOutRaw.Name = "formsPlotOutRaw";
            this.formsPlotOutRaw.Size = new System.Drawing.Size(860, 375);
            this.formsPlotOutRaw.TabIndex = 29;
            // 
            // formsPlotOutFFT
            // 
            this.formsPlotOutFFT.BackColor = System.Drawing.Color.Transparent;
            this.formsPlotOutFFT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlotOutFFT.Location = new System.Drawing.Point(1755, 935);
            this.formsPlotOutFFT.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlotOutFFT.Name = "formsPlotOutFFT";
            this.formsPlotOutFFT.Size = new System.Drawing.Size(860, 375);
            this.formsPlotOutFFT.TabIndex = 30;
            // 
            // timerReplot
            // 
            this.timerReplot.Interval = 2;
            this.timerReplot.Tick += new System.EventHandler(this.timerReplot_Tick);
            // 
            // labeldriver
            // 
            this.labeldriver.AutoSize = true;
            this.labeldriver.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldriver.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labeldriver.Location = new System.Drawing.Point(12, 574);
            this.labeldriver.Name = "labeldriver";
            this.labeldriver.Size = new System.Drawing.Size(294, 33);
            this.labeldriver.TabIndex = 31;
            this.labeldriver.Text = "Select Output Driver";
            // 
            // comboBoxDriver
            // 
            this.comboBoxDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDriver.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxDriver.FormattingEnabled = true;
            this.comboBoxDriver.Location = new System.Drawing.Point(18, 623);
            this.comboBoxDriver.Name = "comboBoxDriver";
            this.comboBoxDriver.Size = new System.Drawing.Size(776, 32);
            this.comboBoxDriver.TabIndex = 32;
            this.comboBoxDriver.SelectedIndexChanged += new System.EventHandler(this.comboBoxDriver_SelectedIndexChanged);
            // 
            // trackBarCutVolume
            // 
            this.trackBarCutVolume.BackColor = System.Drawing.Color.Black;
            this.trackBarCutVolume.LargeChange = 10;
            this.trackBarCutVolume.Location = new System.Drawing.Point(18, 778);
            this.trackBarCutVolume.Maximum = 100;
            this.trackBarCutVolume.Name = "trackBarCutVolume";
            this.trackBarCutVolume.Size = new System.Drawing.Size(776, 90);
            this.trackBarCutVolume.SmallChange = 5;
            this.trackBarCutVolume.TabIndex = 33;
            this.trackBarCutVolume.Scroll += new System.EventHandler(this.trackBarCutVolume_Scroll);
            // 
            // labelCutVolume
            // 
            this.labelCutVolume.AutoSize = true;
            this.labelCutVolume.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCutVolume.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelCutVolume.Location = new System.Drawing.Point(22, 725);
            this.labelCutVolume.Name = "labelCutVolume";
            this.labelCutVolume.Size = new System.Drawing.Size(253, 33);
            this.labelCutVolume.TabIndex = 34;
            this.labelCutVolume.Text = "Cut Volume Level";
            // 
            // progressBarCutVolume
            // 
            this.progressBarCutVolume.ForeColor = System.Drawing.SystemColors.WindowText;
            this.progressBarCutVolume.Location = new System.Drawing.Point(42, 841);
            this.progressBarCutVolume.Maximum = 1000;
            this.progressBarCutVolume.Name = "progressBarCutVolume";
            this.progressBarCutVolume.Size = new System.Drawing.Size(730, 27);
            this.progressBarCutVolume.TabIndex = 35;
            // 
            // trackBarMicInputLevel
            // 
            this.trackBarMicInputLevel.BackColor = System.Drawing.Color.Black;
            this.trackBarMicInputLevel.Location = new System.Drawing.Point(18, 944);
            this.trackBarMicInputLevel.Maximum = 50;
            this.trackBarMicInputLevel.Name = "trackBarMicInputLevel";
            this.trackBarMicInputLevel.Size = new System.Drawing.Size(776, 90);
            this.trackBarMicInputLevel.TabIndex = 36;
            this.trackBarMicInputLevel.Value = 10;
            this.trackBarMicInputLevel.Scroll += new System.EventHandler(this.trackBarStereoInputLevel_Scroll);
            // 
            // labelMicInputVolume
            // 
            this.labelMicInputVolume.AutoSize = true;
            this.labelMicInputVolume.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMicInputVolume.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelMicInputVolume.Location = new System.Drawing.Point(22, 896);
            this.labelMicInputVolume.Name = "labelMicInputVolume";
            this.labelMicInputVolume.Size = new System.Drawing.Size(220, 33);
            this.labelMicInputVolume.TabIndex = 37;
            this.labelMicInputVolume.Text = "Mic Input Level";
            // 
            // labelOutputLevel
            // 
            this.labelOutputLevel.AutoSize = true;
            this.labelOutputLevel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutputLevel.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.labelOutputLevel.Location = new System.Drawing.Point(22, 1037);
            this.labelOutputLevel.Name = "labelOutputLevel";
            this.labelOutputLevel.Size = new System.Drawing.Size(189, 33);
            this.labelOutputLevel.TabIndex = 38;
            this.labelOutputLevel.Text = "Output Level";
            // 
            // trackBarOutputLevel
            // 
            this.trackBarOutputLevel.BackColor = System.Drawing.Color.Black;
            this.trackBarOutputLevel.Location = new System.Drawing.Point(18, 1082);
            this.trackBarOutputLevel.Maximum = 50;
            this.trackBarOutputLevel.Name = "trackBarOutputLevel";
            this.trackBarOutputLevel.Size = new System.Drawing.Size(776, 90);
            this.trackBarOutputLevel.TabIndex = 39;
            this.trackBarOutputLevel.Value = 10;
            this.trackBarOutputLevel.Scroll += new System.EventHandler(this.trackBarOutputLevel_Scroll);
            // 
            // numericUpDownCutVolume
            // 
            this.numericUpDownCutVolume.DecimalPlaces = 2;
            this.numericUpDownCutVolume.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownCutVolume.Location = new System.Drawing.Point(652, 753);
            this.numericUpDownCutVolume.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCutVolume.Name = "numericUpDownCutVolume";
            this.numericUpDownCutVolume.Size = new System.Drawing.Size(120, 31);
            this.numericUpDownCutVolume.TabIndex = 41;
            this.numericUpDownCutVolume.ValueChanged += new System.EventHandler(this.numericUpDownCutVolume_ValueChanged);
            // 
            // numericUpDownMicLevel
            // 
            this.numericUpDownMicLevel.DecimalPlaces = 2;
            this.numericUpDownMicLevel.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.numericUpDownMicLevel.Location = new System.Drawing.Point(652, 920);
            this.numericUpDownMicLevel.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMicLevel.Name = "numericUpDownMicLevel";
            this.numericUpDownMicLevel.Size = new System.Drawing.Size(120, 31);
            this.numericUpDownMicLevel.TabIndex = 42;
            this.numericUpDownMicLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMicLevel.ValueChanged += new System.EventHandler(this.numericUpDownInputLevel_ValueChanged);
            // 
            // numericUpDownOutputLevel
            // 
            this.numericUpDownOutputLevel.DecimalPlaces = 2;
            this.numericUpDownOutputLevel.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.numericUpDownOutputLevel.Location = new System.Drawing.Point(652, 1058);
            this.numericUpDownOutputLevel.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownOutputLevel.Name = "numericUpDownOutputLevel";
            this.numericUpDownOutputLevel.Size = new System.Drawing.Size(120, 31);
            this.numericUpDownOutputLevel.TabIndex = 43;
            this.numericUpDownOutputLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownOutputLevel.ValueChanged += new System.EventHandler(this.numericUpDownOutputLevel_ValueChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(2631, 1426);
            this.Controls.Add(this.numericUpDownOutputLevel);
            this.Controls.Add(this.numericUpDownMicLevel);
            this.Controls.Add(this.numericUpDownCutVolume);
            this.Controls.Add(this.trackBarOutputLevel);
            this.Controls.Add(this.labelOutputLevel);
            this.Controls.Add(this.labelMicInputVolume);
            this.Controls.Add(this.trackBarMicInputLevel);
            this.Controls.Add(this.progressBarCutVolume);
            this.Controls.Add(this.labelCutVolume);
            this.Controls.Add(this.trackBarCutVolume);
            this.Controls.Add(this.comboBoxDriver);
            this.Controls.Add(this.labeldriver);
            this.Controls.Add(this.formsPlotOutFFT);
            this.Controls.Add(this.formsPlotOutRaw);
            this.Controls.Add(this.formsPlotStereoFFT);
            this.Controls.Add(this.formsPlotStereoRaw);
            this.Controls.Add(this.formsPlotMicFFT);
            this.Controls.Add(this.formsPlotMicRaw);
            this.Controls.Add(this.labelOutputGraph);
            this.Controls.Add(this.labelStereoGraph);
            this.Controls.Add(this.labelMicGraph);
            this.Controls.Add(this.labelStreamTest);
            this.Controls.Add(this.comboBoxStereoMixer);
            this.Controls.Add(this.labelStereoMixer);
            this.Controls.Add(this.buttonStream);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonWork);
            this.Controls.Add(this.comboBoxOutputDevice);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelMicrophone);
            this.Controls.Add(this.comboBoxMicrophone);
            this.Name = "MainWindow";
            this.Text = "Simple Echo Canceller";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCutVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMicInputLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOutputLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCutVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMicLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxMicrophone;
        private System.Windows.Forms.Label labelMicrophone;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.ComboBox comboBoxOutputDevice;
        private System.Windows.Forms.Button buttonWork;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Button buttonStream;
        private System.Windows.Forms.Label labelStereoMixer;
        private System.Windows.Forms.ComboBox comboBoxStereoMixer;
        private System.Windows.Forms.Label labelStreamTest;
        private System.Windows.Forms.Label labelMicGraph;
        private System.Windows.Forms.Label labelStereoGraph;
        private System.Windows.Forms.Label labelOutputGraph;
        private ScottPlot.FormsPlot formsPlotMicRaw;
        private ScottPlot.FormsPlot formsPlotMicFFT;
        private ScottPlot.FormsPlot formsPlotStereoRaw;
        private ScottPlot.FormsPlot formsPlotStereoFFT;
        private ScottPlot.FormsPlot formsPlotOutRaw;
        private ScottPlot.FormsPlot formsPlotOutFFT;
        private System.Windows.Forms.Timer timerReplot;
        private System.Windows.Forms.Label labeldriver;
        private System.Windows.Forms.ComboBox comboBoxDriver;
        private System.Windows.Forms.TrackBar trackBarCutVolume;
        private System.Windows.Forms.Label labelCutVolume;
        private System.Windows.Forms.ProgressBar progressBarCutVolume;
        private System.Windows.Forms.TrackBar trackBarMicInputLevel;
        private System.Windows.Forms.Label labelMicInputVolume;
        private System.Windows.Forms.Label labelOutputLevel;
        private System.Windows.Forms.TrackBar trackBarOutputLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownCutVolume;
        private System.Windows.Forms.NumericUpDown numericUpDownMicLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownOutputLevel;
    }
}

