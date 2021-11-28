﻿namespace echo_canceller
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
            this.comboBoxMicrophone = new System.Windows.Forms.ComboBox();
            this.labelMicrophone = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.comboBoxOutputDevice = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.formsPlot2 = new ScottPlot.FormsPlot();
            this.formsPlot3 = new ScottPlot.FormsPlot();
            this.formsPlot4 = new ScottPlot.FormsPlot();
            this.formsPlot5 = new ScottPlot.FormsPlot();
            this.formsPlot6 = new ScottPlot.FormsPlot();
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
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
            this.labelOutputGraph.Size = new System.Drawing.Size(277, 33);
            this.labelOutputGraph.TabIndex = 24;
            this.labelOutputGraph.Text = "Stereo Mixer Graph";
            // 
            // formsPlot1
            // 
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlot1.Location = new System.Drawing.Point(852, 59);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(860, 375);
            this.formsPlot1.TabIndex = 25;
            // 
            // formsPlot2
            // 
            this.formsPlot2.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlot2.Location = new System.Drawing.Point(1756, 59);
            this.formsPlot2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(860, 375);
            this.formsPlot2.TabIndex = 26;
            // 
            // formsPlot3
            // 
            this.formsPlot3.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlot3.Location = new System.Drawing.Point(852, 502);
            this.formsPlot3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlot3.Name = "formsPlot3";
            this.formsPlot3.Size = new System.Drawing.Size(860, 375);
            this.formsPlot3.TabIndex = 27;
            // 
            // formsPlot4
            // 
            this.formsPlot4.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlot4.Location = new System.Drawing.Point(1756, 502);
            this.formsPlot4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlot4.Name = "formsPlot4";
            this.formsPlot4.Size = new System.Drawing.Size(860, 375);
            this.formsPlot4.TabIndex = 28;
            // 
            // formsPlot5
            // 
            this.formsPlot5.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlot5.Location = new System.Drawing.Point(852, 935);
            this.formsPlot5.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlot5.Name = "formsPlot5";
            this.formsPlot5.Size = new System.Drawing.Size(860, 375);
            this.formsPlot5.TabIndex = 29;
            // 
            // formsPlot6
            // 
            this.formsPlot6.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.formsPlot6.Location = new System.Drawing.Point(1755, 935);
            this.formsPlot6.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlot6.Name = "formsPlot6";
            this.formsPlot6.Size = new System.Drawing.Size(860, 375);
            this.formsPlot6.TabIndex = 30;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(2631, 1426);
            this.Controls.Add(this.formsPlot6);
            this.Controls.Add(this.formsPlot5);
            this.Controls.Add(this.formsPlot4);
            this.Controls.Add(this.formsPlot3);
            this.Controls.Add(this.formsPlot2);
            this.Controls.Add(this.formsPlot1);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxOutputDevice);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelMicrophone);
            this.Controls.Add(this.comboBoxMicrophone);
            this.Name = "MainWindow";
            this.Text = "Simple Echo Canceller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxMicrophone;
        private System.Windows.Forms.Label labelMicrophone;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.ComboBox comboBoxOutputDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
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
        private ScottPlot.FormsPlot formsPlot1;
        private ScottPlot.FormsPlot formsPlot2;
        private ScottPlot.FormsPlot formsPlot3;
        private ScottPlot.FormsPlot formsPlot4;
        private ScottPlot.FormsPlot formsPlot5;
        private ScottPlot.FormsPlot formsPlot6;
    }
}

