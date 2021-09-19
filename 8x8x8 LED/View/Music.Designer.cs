
namespace _8x8x8_LED.Apps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMusic));
            this.chkSyncMusic = new System.Windows.Forms.CheckBox();
            this.bwVisualize = new System.ComponentModel.BackgroundWorker();
            this.lblSamples = new System.Windows.Forms.Label();
            this.trkSamples = new System.Windows.Forms.TrackBar();
            this.chkMirrored = new System.Windows.Forms.CheckBox();
            this.chkShowSilence = new System.Windows.Forms.CheckBox();
            this.lblResponsiveness = new System.Windows.Forms.Label();
            this.lblMusicStyle = new System.Windows.Forms.Label();
            this.cbMusicStyle = new System.Windows.Forms.ComboBox();
            this.cbResponsiveness = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSyncMusic
            // 
            this.chkSyncMusic.AutoSize = true;
            this.chkSyncMusic.Location = new System.Drawing.Point(15, 15);
            this.chkSyncMusic.Margin = new System.Windows.Forms.Padding(6);
            this.chkSyncMusic.Name = "chkSyncMusic";
            this.chkSyncMusic.Size = new System.Drawing.Size(126, 28);
            this.chkSyncMusic.TabIndex = 0;
            this.chkSyncMusic.Text = "S&ync Music";
            this.chkSyncMusic.UseVisualStyleBackColor = true;
            this.chkSyncMusic.CheckedChanged += new System.EventHandler(this.ChkSyncMusic_CheckedChanged);
            // 
            // bwVisualize
            // 
            this.bwVisualize.WorkerSupportsCancellation = true;
            this.bwVisualize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwVisualize_DoWork);
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(15, 162);
            this.lblSamples.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(88, 24);
            this.lblSamples.TabIndex = 5;
            this.lblSamples.Text = "S&amples:";
            // 
            // trkSamples
            // 
            this.trkSamples.LargeChange = 8;
            this.trkSamples.Location = new System.Drawing.Point(178, 164);
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
            // chkMirrored
            // 
            this.chkMirrored.AutoSize = true;
            this.chkMirrored.Checked = true;
            this.chkMirrored.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMirrored.Location = new System.Drawing.Point(15, 55);
            this.chkMirrored.Margin = new System.Windows.Forms.Padding(6);
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
            this.chkShowSilence.Location = new System.Drawing.Point(15, 95);
            this.chkShowSilence.Margin = new System.Windows.Forms.Padding(6);
            this.chkShowSilence.Name = "chkShowSilence";
            this.chkShowSilence.Size = new System.Drawing.Size(145, 28);
            this.chkShowSilence.TabIndex = 2;
            this.chkShowSilence.Text = "Show &Silence";
            this.chkShowSilence.UseVisualStyleBackColor = true;
            this.chkShowSilence.CheckedChanged += new System.EventHandler(this.ChkShowSilence_CheckedChanged);
            // 
            // lblResponsiveness
            // 
            this.lblResponsiveness.AutoSize = true;
            this.lblResponsiveness.Location = new System.Drawing.Point(15, 129);
            this.lblResponsiveness.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblResponsiveness.Name = "lblResponsiveness";
            this.lblResponsiveness.Size = new System.Drawing.Size(154, 24);
            this.lblResponsiveness.TabIndex = 3;
            this.lblResponsiveness.Text = "&Responsiveness:";
            // 
            // lblMusicStyle
            // 
            this.lblMusicStyle.AutoSize = true;
            this.lblMusicStyle.Location = new System.Drawing.Point(11, 207);
            this.lblMusicStyle.Name = "lblMusicStyle";
            this.lblMusicStyle.Size = new System.Drawing.Size(110, 24);
            this.lblMusicStyle.TabIndex = 7;
            this.lblMusicStyle.Text = "Music S&tyle:";
            // 
            // cbMusicStyle
            // 
            this.cbMusicStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMusicStyle.FormattingEnabled = true;
            this.cbMusicStyle.Items.AddRange(new object[] {
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
            this.cbMusicStyle.Location = new System.Drawing.Point(178, 204);
            this.cbMusicStyle.Name = "cbMusicStyle";
            this.cbMusicStyle.Size = new System.Drawing.Size(343, 32);
            this.cbMusicStyle.TabIndex = 8;
            this.cbMusicStyle.SelectedIndexChanged += new System.EventHandler(this.CbMusicStyle_SelectedIndexChanged);
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
            this.cbResponsiveness.Location = new System.Drawing.Point(178, 126);
            this.cbResponsiveness.Name = "cbResponsiveness";
            this.cbResponsiveness.Size = new System.Drawing.Size(343, 32);
            this.cbResponsiveness.TabIndex = 4;
            this.cbResponsiveness.SelectedIndexChanged += new System.EventHandler(this.CbResponsiveness_SelectedIndexChanged);
            // 
            // FrmMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 254);
            this.Controls.Add(this.lblMusicStyle);
            this.Controls.Add(this.cbMusicStyle);
            this.Controls.Add(this.chkSyncMusic);
            this.Controls.Add(this.cbResponsiveness);
            this.Controls.Add(this.chkMirrored);
            this.Controls.Add(this.lblResponsiveness);
            this.Controls.Add(this.trkSamples);
            this.Controls.Add(this.chkShowSilence);
            this.Controls.Add(this.lblSamples);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FrmMusic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMusic_FormClosing);
            this.Load += new System.EventHandler(this.FrmMusic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSyncMusic;
        private System.ComponentModel.BackgroundWorker bwVisualize;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.TrackBar trkSamples;
        private System.Windows.Forms.CheckBox chkMirrored;
        private System.Windows.Forms.CheckBox chkShowSilence;
        private System.Windows.Forms.Label lblResponsiveness;
        private System.Windows.Forms.ComboBox cbResponsiveness;
        private System.Windows.Forms.ComboBox cbMusicStyle;
        private System.Windows.Forms.Label lblMusicStyle;
    }
}