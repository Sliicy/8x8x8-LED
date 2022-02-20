namespace _8x8x8_LED.Views
{
    partial class FrmMusic
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMusic));
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
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.chkRainbow = new System.Windows.Forms.CheckBox();
            this.tmrShuffle = new System.Windows.Forms.Timer(this.components);
            this.chkShuffled = new System.Windows.Forms.CheckBox();
            this.grpColor = new System.Windows.Forms.GroupBox();
            this.grpBackcolor = new System.Windows.Forms.GroupBox();
            this.chkFlashtoBeat = new System.Windows.Forms.CheckBox();
            this.cbBackcolor = new System.Windows.Forms.ComboBox();
            this.chkBackcolorRainbow = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).BeginInit();
            this.grpColor.SuspendLayout();
            this.grpBackcolor.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSyncMusic
            // 
            this.chkSyncMusic.AutoSize = true;
            this.chkSyncMusic.Location = new System.Drawing.Point(14, 15);
            this.chkSyncMusic.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkSyncMusic.Name = "chkSyncMusic";
            this.chkSyncMusic.Size = new System.Drawing.Size(126, 28);
            this.chkSyncMusic.TabIndex = 0;
            this.chkSyncMusic.Text = "S&ync Music";
            this.chkSyncMusic.UseVisualStyleBackColor = true;
            this.chkSyncMusic.CheckedChanged += new System.EventHandler(this.ChkSyncMusic_CheckedChanged);
            // 
            // chkMirrored
            // 
            this.chkMirrored.AutoSize = true;
            this.chkMirrored.Checked = true;
            this.chkMirrored.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMirrored.Location = new System.Drawing.Point(14, 60);
            this.chkMirrored.Margin = new System.Windows.Forms.Padding(11);
            this.chkMirrored.Name = "chkMirrored";
            this.chkMirrored.Size = new System.Drawing.Size(155, 28);
            this.chkMirrored.TabIndex = 1;
            this.chkMirrored.Text = "&Mirrored Audio";
            this.chkMirrored.UseVisualStyleBackColor = true;
            // 
            // chkShowSilence
            // 
            this.chkShowSilence.AutoSize = true;
            this.chkShowSilence.Checked = true;
            this.chkShowSilence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSilence.Location = new System.Drawing.Point(14, 110);
            this.chkShowSilence.Margin = new System.Windows.Forms.Padding(11);
            this.chkShowSilence.Name = "chkShowSilence";
            this.chkShowSilence.Size = new System.Drawing.Size(145, 28);
            this.chkShowSilence.TabIndex = 2;
            this.chkShowSilence.Text = "Show &Silence";
            this.chkShowSilence.UseVisualStyleBackColor = true;
            this.chkShowSilence.CheckedChanged += new System.EventHandler(this.ChkShowSilence_CheckedChanged);
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(20, 247);
            this.lblSamples.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(145, 24);
            this.lblSamples.TabIndex = 6;
            this.lblSamples.Text = "S&amples (1024):";
            // 
            // trkSamples
            // 
            this.trkSamples.LargeChange = 8;
            this.trkSamples.Location = new System.Drawing.Point(187, 237);
            this.trkSamples.Margin = new System.Windows.Forms.Padding(11);
            this.trkSamples.Maximum = 16384;
            this.trkSamples.Minimum = 8;
            this.trkSamples.Name = "trkSamples";
            this.trkSamples.Size = new System.Drawing.Size(194, 45);
            this.trkSamples.SmallChange = 8;
            this.trkSamples.TabIndex = 7;
            this.trkSamples.Value = 1024;
            this.trkSamples.Scroll += new System.EventHandler(this.TrkSamples_Scroll);
            // 
            // lblResponsiveness
            // 
            this.lblResponsiveness.AutoSize = true;
            this.lblResponsiveness.Location = new System.Drawing.Point(20, 201);
            this.lblResponsiveness.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblResponsiveness.Name = "lblResponsiveness";
            this.lblResponsiveness.Size = new System.Drawing.Size(154, 24);
            this.lblResponsiveness.TabIndex = 4;
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
            this.cbResponsiveness.Location = new System.Drawing.Point(190, 198);
            this.cbResponsiveness.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbResponsiveness.Name = "cbResponsiveness";
            this.cbResponsiveness.Size = new System.Drawing.Size(191, 32);
            this.cbResponsiveness.TabIndex = 5;
            this.cbResponsiveness.Text = "1";
            this.cbResponsiveness.SelectedIndexChanged += new System.EventHandler(this.CbResponsiveness_SelectedIndexChanged);
            // 
            // cbMusicStyle
            // 
            this.cbMusicStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMusicStyle.FormattingEnabled = true;
            this.cbMusicStyle.Items.AddRange(new object[] {
            "Tesla Ball",
            "Floating Lines",
            "Floating Dots",
            "Filled Lines",
            "Filled Dots",
            "Centered Floating Lines",
            "Centered Floating Dots",
            "Centered Filled Lines",
            "Centered Filled Dots",
            "Filled Fire Lines",
            "Filled Fire Dots",
            "Filled Rainbow Lines",
            "Filled Rainbow Dots",
            "Filled Equalizer Lines",
            "Filled Equalizer Dots"});
            this.cbMusicStyle.Location = new System.Drawing.Point(140, 284);
            this.cbMusicStyle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbMusicStyle.Name = "cbMusicStyle";
            this.cbMusicStyle.Size = new System.Drawing.Size(241, 32);
            this.cbMusicStyle.TabIndex = 9;
            this.cbMusicStyle.SelectedIndexChanged += new System.EventHandler(this.CbMusicStyle_SelectedIndexChanged);
            // 
            // lblMusicStyle
            // 
            this.lblMusicStyle.AutoSize = true;
            this.lblMusicStyle.Location = new System.Drawing.Point(20, 287);
            this.lblMusicStyle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMusicStyle.Name = "lblMusicStyle";
            this.lblMusicStyle.Size = new System.Drawing.Size(110, 24);
            this.lblMusicStyle.TabIndex = 8;
            this.lblMusicStyle.Text = "Music S&tyle:";
            // 
            // bwVisualize
            // 
            this.bwVisualize.WorkerSupportsCancellation = true;
            this.bwVisualize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwVisualize_DoWork);
            // 
            // cbColor
            // 
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(11, 78);
            this.cbColor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(219, 32);
            this.cbColor.TabIndex = 12;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.CbColor_SelectedIndexChanged);
            // 
            // chkRainbow
            // 
            this.chkRainbow.AutoSize = true;
            this.chkRainbow.Location = new System.Drawing.Point(11, 35);
            this.chkRainbow.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkRainbow.Name = "chkRainbow";
            this.chkRainbow.Size = new System.Drawing.Size(157, 28);
            this.chkRainbow.TabIndex = 11;
            this.chkRainbow.Text = "&Rainbow Mode";
            this.chkRainbow.UseVisualStyleBackColor = true;
            this.chkRainbow.CheckedChanged += new System.EventHandler(this.ChkRainbow_CheckedChanged);
            // 
            // tmrShuffle
            // 
            this.tmrShuffle.Interval = 5000;
            this.tmrShuffle.Tick += new System.EventHandler(this.TmrShuffle_Tick);
            // 
            // chkShuffled
            // 
            this.chkShuffled.AutoSize = true;
            this.chkShuffled.Location = new System.Drawing.Point(14, 155);
            this.chkShuffled.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkShuffled.Name = "chkShuffled";
            this.chkShuffled.Size = new System.Drawing.Size(97, 28);
            this.chkShuffled.TabIndex = 3;
            this.chkShuffled.Text = "Shu&ffled";
            this.chkShuffled.UseVisualStyleBackColor = true;
            this.chkShuffled.CheckedChanged += new System.EventHandler(this.ChkShuffled_CheckedChanged);
            // 
            // grpColor
            // 
            this.grpColor.Controls.Add(this.cbColor);
            this.grpColor.Controls.Add(this.chkRainbow);
            this.grpColor.Location = new System.Drawing.Point(80, 328);
            this.grpColor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.grpColor.Name = "grpColor";
            this.grpColor.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.grpColor.Size = new System.Drawing.Size(253, 162);
            this.grpColor.TabIndex = 10;
            this.grpColor.TabStop = false;
            this.grpColor.Text = "&Color";
            // 
            // grpBackcolor
            // 
            this.grpBackcolor.Controls.Add(this.chkFlashtoBeat);
            this.grpBackcolor.Controls.Add(this.cbBackcolor);
            this.grpBackcolor.Controls.Add(this.chkBackcolorRainbow);
            this.grpBackcolor.Location = new System.Drawing.Point(80, 502);
            this.grpBackcolor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.grpBackcolor.Name = "grpBackcolor";
            this.grpBackcolor.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.grpBackcolor.Size = new System.Drawing.Size(253, 162);
            this.grpBackcolor.TabIndex = 13;
            this.grpBackcolor.TabStop = false;
            this.grpBackcolor.Text = "&Back Color";
            // 
            // chkFlashtoBeat
            // 
            this.chkFlashtoBeat.AutoSize = true;
            this.chkFlashtoBeat.Location = new System.Drawing.Point(11, 72);
            this.chkFlashtoBeat.Name = "chkFlashtoBeat";
            this.chkFlashtoBeat.Size = new System.Drawing.Size(137, 28);
            this.chkFlashtoBeat.TabIndex = 15;
            this.chkFlashtoBeat.Text = "&Flash to Beat";
            this.chkFlashtoBeat.UseVisualStyleBackColor = true;
            this.chkFlashtoBeat.CheckedChanged += new System.EventHandler(this.ChkFlashToBeat_CheckedChanged);
            // 
            // cbBackcolor
            // 
            this.cbBackcolor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackcolor.FormattingEnabled = true;
            this.cbBackcolor.Location = new System.Drawing.Point(10, 109);
            this.cbBackcolor.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbBackcolor.Name = "cbBackcolor";
            this.cbBackcolor.Size = new System.Drawing.Size(219, 32);
            this.cbBackcolor.TabIndex = 16;
            this.cbBackcolor.SelectedIndexChanged += new System.EventHandler(this.CbBackcolor_SelectedIndexChanged);
            // 
            // chkBackcolorRainbow
            // 
            this.chkBackcolorRainbow.AutoSize = true;
            this.chkBackcolorRainbow.Location = new System.Drawing.Point(11, 35);
            this.chkBackcolorRainbow.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkBackcolorRainbow.Name = "chkBackcolorRainbow";
            this.chkBackcolorRainbow.Size = new System.Drawing.Size(157, 28);
            this.chkBackcolorRainbow.TabIndex = 14;
            this.chkBackcolorRainbow.Text = "&Rainbow Mode";
            this.chkBackcolorRainbow.UseVisualStyleBackColor = true;
            this.chkBackcolorRainbow.CheckedChanged += new System.EventHandler(this.ChkBackcolorRainbow_CheckedChanged);
            // 
            // FrmMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 674);
            this.Controls.Add(this.grpBackcolor);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.chkShuffled);
            this.Controls.Add(this.lblMusicStyle);
            this.Controls.Add(this.chkSyncMusic);
            this.Controls.Add(this.cbMusicStyle);
            this.Controls.Add(this.chkMirrored);
            this.Controls.Add(this.chkShowSilence);
            this.Controls.Add(this.cbResponsiveness);
            this.Controls.Add(this.lblResponsiveness);
            this.Controls.Add(this.lblSamples);
            this.Controls.Add(this.trkSamples);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "FrmMusic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMusic_FormClosing);
            this.Load += new System.EventHandler(this.FrmMusic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).EndInit();
            this.grpColor.ResumeLayout(false);
            this.grpColor.PerformLayout();
            this.grpBackcolor.ResumeLayout(false);
            this.grpBackcolor.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.CheckBox chkRainbow;
        private System.Windows.Forms.Timer tmrShuffle;
        private System.Windows.Forms.CheckBox chkShuffled;
        private System.Windows.Forms.GroupBox grpColor;
        private System.Windows.Forms.GroupBox grpBackcolor;
        private System.Windows.Forms.ComboBox cbBackcolor;
        private System.Windows.Forms.CheckBox chkBackcolorRainbow;
        private System.Windows.Forms.CheckBox chkFlashtoBeat;
    }
}