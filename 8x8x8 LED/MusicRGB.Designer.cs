namespace _8x8x8_LED
{
    partial class MusicRGB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkSyncMusic = new System.Windows.Forms.CheckBox();
            this.chkMirrored = new System.Windows.Forms.CheckBox();
            this.chkShowSilence = new System.Windows.Forms.CheckBox();
            this.lblSamples = new System.Windows.Forms.Label();
            this.trkSamples = new System.Windows.Forms.TrackBar();
            this.lblResponsiveness = new System.Windows.Forms.Label();
            this.cbResponsiveness = new System.Windows.Forms.ComboBox();
            this.cbMusicStyle = new System.Windows.Forms.ComboBox();
            this.lblMusicStyle = new System.Windows.Forms.Label();
            this.bwVisualize = new System.ComponentModel.BackgroundWorker();
            this.nudLineCount = new System.Windows.Forms.NumericUpDown();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.chkRainbow = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineCount)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSyncMusic
            // 
            this.chkSyncMusic.AutoSize = true;
            this.chkSyncMusic.Location = new System.Drawing.Point(66, 45);
            this.chkSyncMusic.Name = "chkSyncMusic";
            this.chkSyncMusic.Size = new System.Drawing.Size(81, 17);
            this.chkSyncMusic.TabIndex = 0;
            this.chkSyncMusic.Text = "Sync Music";
            this.chkSyncMusic.UseVisualStyleBackColor = true;
            this.chkSyncMusic.CheckedChanged += new System.EventHandler(this.ChkSyncMusic_CheckedChanged);
            // 
            // chkMirrored
            // 
            this.chkMirrored.AutoSize = true;
            this.chkMirrored.Checked = true;
            this.chkMirrored.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMirrored.Location = new System.Drawing.Point(75, 118);
            this.chkMirrored.Margin = new System.Windows.Forms.Padding(6);
            this.chkMirrored.Name = "chkMirrored";
            this.chkMirrored.Size = new System.Drawing.Size(94, 17);
            this.chkMirrored.TabIndex = 1;
            this.chkMirrored.Text = "&Mirrored Audio";
            this.chkMirrored.UseVisualStyleBackColor = true;
            // 
            // chkShowSilence
            // 
            this.chkShowSilence.AutoSize = true;
            this.chkShowSilence.Checked = true;
            this.chkShowSilence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSilence.Location = new System.Drawing.Point(66, 175);
            this.chkShowSilence.Margin = new System.Windows.Forms.Padding(6);
            this.chkShowSilence.Name = "chkShowSilence";
            this.chkShowSilence.Size = new System.Drawing.Size(91, 17);
            this.chkShowSilence.TabIndex = 2;
            this.chkShowSilence.Text = "Show &Silence";
            this.chkShowSilence.UseVisualStyleBackColor = true;
            this.chkShowSilence.CheckedChanged += new System.EventHandler(this.ChkShowSilence_CheckedChanged);
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(62, 283);
            this.lblSamples.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(50, 13);
            this.lblSamples.TabIndex = 5;
            this.lblSamples.Text = "S&amples:";
            // 
            // trkSamples
            // 
            this.trkSamples.LargeChange = 8;
            this.trkSamples.Location = new System.Drawing.Point(225, 285);
            this.trkSamples.Margin = new System.Windows.Forms.Padding(6);
            this.trkSamples.Maximum = 16384;
            this.trkSamples.Minimum = 8;
            this.trkSamples.Name = "trkSamples";
            this.trkSamples.Size = new System.Drawing.Size(340, 45);
            this.trkSamples.SmallChange = 8;
            this.trkSamples.TabIndex = 6;
            this.trkSamples.Value = 1024;
            this.trkSamples.Scroll += new System.EventHandler(this.TrkSamples_Scroll);
            // 
            // lblResponsiveness
            // 
            this.lblResponsiveness.AutoSize = true;
            this.lblResponsiveness.Location = new System.Drawing.Point(62, 250);
            this.lblResponsiveness.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblResponsiveness.Name = "lblResponsiveness";
            this.lblResponsiveness.Size = new System.Drawing.Size(88, 13);
            this.lblResponsiveness.TabIndex = 3;
            this.lblResponsiveness.Text = "&Responsiveness:";
            // 
            // cbResponsiveness
            // 
            this.cbResponsiveness.FormattingEnabled = true;
            this.cbResponsiveness.Items.AddRange(new object[] {
            "1",
            "100",
            "1000",
            "10000",
            "100000",
            "200000",
            "300000",
            "400000",
            "500000",
            "600000",
            "700000",
            "800000",
            "900000",
            "1000000"});
            this.cbResponsiveness.Location = new System.Drawing.Point(225, 247);
            this.cbResponsiveness.Name = "cbResponsiveness";
            this.cbResponsiveness.Size = new System.Drawing.Size(343, 21);
            this.cbResponsiveness.TabIndex = 4;
            this.cbResponsiveness.Text = "1";
            this.cbResponsiveness.SelectedIndexChanged += new System.EventHandler(this.CbResponsiveness_SelectedIndexChanged);
            // 
            // cbMusicStyle
            // 
            this.cbMusicStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMusicStyle.FormattingEnabled = true;
            this.cbMusicStyle.Items.AddRange(new object[] {
            "Electro Ball",
            "Floating Lines",
            "Floating Dots",
            "Solid Lines",
            "Solid Dots",
            "Centered Floating Lines",
            "Centered Floating Dots",
            "Centered Solid Lines",
            "Centered Solid Dots",
            "Matrix",
            "Shuffled"});
            this.cbMusicStyle.Location = new System.Drawing.Point(225, 325);
            this.cbMusicStyle.Name = "cbMusicStyle";
            this.cbMusicStyle.Size = new System.Drawing.Size(343, 21);
            this.cbMusicStyle.TabIndex = 8;
            this.cbMusicStyle.SelectedIndexChanged += new System.EventHandler(this.CbMusicStyle_SelectedIndexChanged);
            // 
            // lblMusicStyle
            // 
            this.lblMusicStyle.AutoSize = true;
            this.lblMusicStyle.Location = new System.Drawing.Point(58, 328);
            this.lblMusicStyle.Name = "lblMusicStyle";
            this.lblMusicStyle.Size = new System.Drawing.Size(64, 13);
            this.lblMusicStyle.TabIndex = 7;
            this.lblMusicStyle.Text = "Music S&tyle:";
            // 
            // bwVisualize
            // 
            this.bwVisualize.WorkerSupportsCancellation = true;
            this.bwVisualize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwVisualize_DoWork);
            // 
            // nudLineCount
            // 
            this.nudLineCount.Location = new System.Drawing.Point(710, 231);
            this.nudLineCount.Name = "nudLineCount";
            this.nudLineCount.Size = new System.Drawing.Size(120, 20);
            this.nudLineCount.TabIndex = 11;
            this.nudLineCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineCount.ValueChanged += new System.EventHandler(this.NudLineCount_ValueChanged);
            // 
            // cbColor
            // 
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(880, 219);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(121, 21);
            this.cbColor.TabIndex = 12;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.CbColor_SelectedIndexChanged);
            // 
            // chkRainbow
            // 
            this.chkRainbow.AutoSize = true;
            this.chkRainbow.Location = new System.Drawing.Point(880, 196);
            this.chkRainbow.Name = "chkRainbow";
            this.chkRainbow.Size = new System.Drawing.Size(98, 17);
            this.chkRainbow.TabIndex = 13;
            this.chkRainbow.Text = "Rainbow Mode";
            this.chkRainbow.UseVisualStyleBackColor = true;
            this.chkRainbow.CheckedChanged += new System.EventHandler(this.ChkRainbow_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(800, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Draw Cube";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MusicRGB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkRainbow);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.nudLineCount);
            this.Controls.Add(this.lblMusicStyle);
            this.Controls.Add(this.chkSyncMusic);
            this.Controls.Add(this.cbMusicStyle);
            this.Controls.Add(this.chkMirrored);
            this.Controls.Add(this.chkShowSilence);
            this.Controls.Add(this.cbResponsiveness);
            this.Controls.Add(this.lblResponsiveness);
            this.Controls.Add(this.lblSamples);
            this.Controls.Add(this.trkSamples);
            this.Name = "MusicRGB";
            this.Text = "MusicRGB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MusicRGB_FormClosing);
            this.Load += new System.EventHandler(this.MusicRGB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSyncMusic;
        private System.Windows.Forms.CheckBox chkMirrored;
        private System.Windows.Forms.CheckBox chkShowSilence;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.TrackBar trkSamples;
        private System.Windows.Forms.Label lblResponsiveness;
        private System.Windows.Forms.ComboBox cbResponsiveness;
        private System.Windows.Forms.ComboBox cbMusicStyle;
        private System.Windows.Forms.Label lblMusicStyle;
        private System.ComponentModel.BackgroundWorker bwVisualize;
        private System.Windows.Forms.NumericUpDown nudLineCount;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.CheckBox chkRainbow;
        private System.Windows.Forms.Button button1;
    }
}