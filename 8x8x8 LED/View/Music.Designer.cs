
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
            this.chkSyncMusic = new System.Windows.Forms.CheckBox();
            this.bwVisualize = new System.ComponentModel.BackgroundWorker();
            this.rbFloatingLines = new System.Windows.Forms.RadioButton();
            this.grpMusicStyle = new System.Windows.Forms.GroupBox();
            this.rbCenteredFloatingDots = new System.Windows.Forms.RadioButton();
            this.rbCenteredFloatingLines = new System.Windows.Forms.RadioButton();
            this.rbMatrix = new System.Windows.Forms.RadioButton();
            this.rbSolidDots = new System.Windows.Forms.RadioButton();
            this.rbSolidLines = new System.Windows.Forms.RadioButton();
            this.rbFloatingDots = new System.Windows.Forms.RadioButton();
            this.trkResponsiveness = new System.Windows.Forms.TrackBar();
            this.lblResponsiveness = new System.Windows.Forms.Label();
            this.lblSamples = new System.Windows.Forms.Label();
            this.trkSamples = new System.Windows.Forms.TrackBar();
            this.chkMirrored = new System.Windows.Forms.CheckBox();
            this.chkShowSilence = new System.Windows.Forms.CheckBox();
            this.rbShuffled = new System.Windows.Forms.RadioButton();
            this.grpMusicStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkResponsiveness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSyncMusic
            // 
            this.chkSyncMusic.AutoSize = true;
            this.chkSyncMusic.Location = new System.Drawing.Point(55, 8);
            this.chkSyncMusic.Name = "chkSyncMusic";
            this.chkSyncMusic.Size = new System.Drawing.Size(81, 17);
            this.chkSyncMusic.TabIndex = 0;
            this.chkSyncMusic.Text = "Sync Music";
            this.chkSyncMusic.UseVisualStyleBackColor = true;
            this.chkSyncMusic.CheckedChanged += new System.EventHandler(this.ChkSyncMusic_CheckedChanged);
            // 
            // bwVisualize
            // 
            this.bwVisualize.WorkerSupportsCancellation = true;
            this.bwVisualize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwVisualize_DoWork);
            // 
            // rbFloatingLines
            // 
            this.rbFloatingLines.AutoSize = true;
            this.rbFloatingLines.Location = new System.Drawing.Point(6, 19);
            this.rbFloatingLines.Name = "rbFloatingLines";
            this.rbFloatingLines.Size = new System.Drawing.Size(90, 17);
            this.rbFloatingLines.TabIndex = 2;
            this.rbFloatingLines.TabStop = true;
            this.rbFloatingLines.Text = "Floating Lines";
            this.rbFloatingLines.UseVisualStyleBackColor = true;
            this.rbFloatingLines.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // grpMusicStyle
            // 
            this.grpMusicStyle.Controls.Add(this.rbShuffled);
            this.grpMusicStyle.Controls.Add(this.rbCenteredFloatingDots);
            this.grpMusicStyle.Controls.Add(this.rbCenteredFloatingLines);
            this.grpMusicStyle.Controls.Add(this.rbMatrix);
            this.grpMusicStyle.Controls.Add(this.rbSolidDots);
            this.grpMusicStyle.Controls.Add(this.rbSolidLines);
            this.grpMusicStyle.Controls.Add(this.rbFloatingDots);
            this.grpMusicStyle.Controls.Add(this.rbFloatingLines);
            this.grpMusicStyle.Location = new System.Drawing.Point(55, 31);
            this.grpMusicStyle.Name = "grpMusicStyle";
            this.grpMusicStyle.Size = new System.Drawing.Size(200, 295);
            this.grpMusicStyle.TabIndex = 3;
            this.grpMusicStyle.TabStop = false;
            this.grpMusicStyle.Text = "Style";
            // 
            // rbCenteredFloatingDots
            // 
            this.rbCenteredFloatingDots.AutoSize = true;
            this.rbCenteredFloatingDots.Location = new System.Drawing.Point(6, 184);
            this.rbCenteredFloatingDots.Name = "rbCenteredFloatingDots";
            this.rbCenteredFloatingDots.Size = new System.Drawing.Size(133, 17);
            this.rbCenteredFloatingDots.TabIndex = 2;
            this.rbCenteredFloatingDots.TabStop = true;
            this.rbCenteredFloatingDots.Text = "Centered Floating Dots";
            this.rbCenteredFloatingDots.UseVisualStyleBackColor = true;
            this.rbCenteredFloatingDots.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbCenteredFloatingLines
            // 
            this.rbCenteredFloatingLines.AutoSize = true;
            this.rbCenteredFloatingLines.Location = new System.Drawing.Point(6, 157);
            this.rbCenteredFloatingLines.Name = "rbCenteredFloatingLines";
            this.rbCenteredFloatingLines.Size = new System.Drawing.Size(136, 17);
            this.rbCenteredFloatingLines.TabIndex = 2;
            this.rbCenteredFloatingLines.TabStop = true;
            this.rbCenteredFloatingLines.Text = "Centered Floating Lines";
            this.rbCenteredFloatingLines.UseVisualStyleBackColor = true;
            this.rbCenteredFloatingLines.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbMatrix
            // 
            this.rbMatrix.AutoSize = true;
            this.rbMatrix.Location = new System.Drawing.Point(6, 134);
            this.rbMatrix.Name = "rbMatrix";
            this.rbMatrix.Size = new System.Drawing.Size(53, 17);
            this.rbMatrix.TabIndex = 2;
            this.rbMatrix.TabStop = true;
            this.rbMatrix.Text = "Matrix";
            this.rbMatrix.UseVisualStyleBackColor = true;
            this.rbMatrix.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbSolidDots
            // 
            this.rbSolidDots.AutoSize = true;
            this.rbSolidDots.Location = new System.Drawing.Point(6, 106);
            this.rbSolidDots.Name = "rbSolidDots";
            this.rbSolidDots.Size = new System.Drawing.Size(73, 17);
            this.rbSolidDots.TabIndex = 2;
            this.rbSolidDots.TabStop = true;
            this.rbSolidDots.Text = "Solid Dots";
            this.rbSolidDots.UseVisualStyleBackColor = true;
            this.rbSolidDots.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbSolidLines
            // 
            this.rbSolidLines.AutoSize = true;
            this.rbSolidLines.Location = new System.Drawing.Point(6, 77);
            this.rbSolidLines.Name = "rbSolidLines";
            this.rbSolidLines.Size = new System.Drawing.Size(76, 17);
            this.rbSolidLines.TabIndex = 2;
            this.rbSolidLines.TabStop = true;
            this.rbSolidLines.Text = "Solid Lines";
            this.rbSolidLines.UseVisualStyleBackColor = true;
            this.rbSolidLines.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbFloatingDots
            // 
            this.rbFloatingDots.AutoSize = true;
            this.rbFloatingDots.Location = new System.Drawing.Point(6, 42);
            this.rbFloatingDots.Name = "rbFloatingDots";
            this.rbFloatingDots.Size = new System.Drawing.Size(87, 17);
            this.rbFloatingDots.TabIndex = 2;
            this.rbFloatingDots.TabStop = true;
            this.rbFloatingDots.Text = "Floating Dots";
            this.rbFloatingDots.UseVisualStyleBackColor = true;
            this.rbFloatingDots.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // trkResponsiveness
            // 
            this.trkResponsiveness.Location = new System.Drawing.Point(481, 137);
            this.trkResponsiveness.Maximum = 10000;
            this.trkResponsiveness.Minimum = 1;
            this.trkResponsiveness.Name = "trkResponsiveness";
            this.trkResponsiveness.Size = new System.Drawing.Size(497, 45);
            this.trkResponsiveness.TabIndex = 4;
            this.trkResponsiveness.Value = 1;
            this.trkResponsiveness.Scroll += new System.EventHandler(this.TrkResponsiveness_Scroll);
            // 
            // lblResponsiveness
            // 
            this.lblResponsiveness.AutoSize = true;
            this.lblResponsiveness.Location = new System.Drawing.Point(346, 142);
            this.lblResponsiveness.Name = "lblResponsiveness";
            this.lblResponsiveness.Size = new System.Drawing.Size(88, 13);
            this.lblResponsiveness.TabIndex = 5;
            this.lblResponsiveness.Text = "Responsiveness:";
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(384, 215);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(50, 13);
            this.lblSamples.TabIndex = 5;
            this.lblSamples.Text = "Samples:";
            // 
            // trkSamples
            // 
            this.trkSamples.LargeChange = 8;
            this.trkSamples.Location = new System.Drawing.Point(481, 206);
            this.trkSamples.Maximum = 16384;
            this.trkSamples.Minimum = 8;
            this.trkSamples.Name = "trkSamples";
            this.trkSamples.Size = new System.Drawing.Size(497, 45);
            this.trkSamples.SmallChange = 8;
            this.trkSamples.TabIndex = 4;
            this.trkSamples.Value = 1024;
            this.trkSamples.Scroll += new System.EventHandler(this.TrkSamples_Scroll);
            // 
            // chkMirrored
            // 
            this.chkMirrored.AutoSize = true;
            this.chkMirrored.Checked = true;
            this.chkMirrored.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMirrored.Location = new System.Drawing.Point(61, 332);
            this.chkMirrored.Name = "chkMirrored";
            this.chkMirrored.Size = new System.Drawing.Size(94, 17);
            this.chkMirrored.TabIndex = 6;
            this.chkMirrored.Text = "Mirrored Audio";
            this.chkMirrored.UseVisualStyleBackColor = true;
            // 
            // chkShowSilence
            // 
            this.chkShowSilence.AutoSize = true;
            this.chkShowSilence.Checked = true;
            this.chkShowSilence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSilence.Location = new System.Drawing.Point(62, 356);
            this.chkShowSilence.Name = "chkShowSilence";
            this.chkShowSilence.Size = new System.Drawing.Size(91, 17);
            this.chkShowSilence.TabIndex = 7;
            this.chkShowSilence.Text = "Show Silence";
            this.chkShowSilence.UseVisualStyleBackColor = true;
            this.chkShowSilence.CheckedChanged += new System.EventHandler(this.ChkShowSilence_CheckedChanged);
            // 
            // rbShuffled
            // 
            this.rbShuffled.AutoSize = true;
            this.rbShuffled.Location = new System.Drawing.Point(6, 227);
            this.rbShuffled.Name = "rbShuffled";
            this.rbShuffled.Size = new System.Drawing.Size(64, 17);
            this.rbShuffled.TabIndex = 2;
            this.rbShuffled.TabStop = true;
            this.rbShuffled.Text = "Shuffled";
            this.rbShuffled.UseVisualStyleBackColor = true;
            this.rbShuffled.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // FrmMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 450);
            this.Controls.Add(this.chkShowSilence);
            this.Controls.Add(this.chkMirrored);
            this.Controls.Add(this.lblSamples);
            this.Controls.Add(this.lblResponsiveness);
            this.Controls.Add(this.trkSamples);
            this.Controls.Add(this.trkResponsiveness);
            this.Controls.Add(this.grpMusicStyle);
            this.Controls.Add(this.chkSyncMusic);
            this.Name = "FrmMusic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Music";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMusic_FormClosing);
            this.grpMusicStyle.ResumeLayout(false);
            this.grpMusicStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkResponsiveness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSyncMusic;
        private System.ComponentModel.BackgroundWorker bwVisualize;
        private System.Windows.Forms.RadioButton rbFloatingLines;
        private System.Windows.Forms.GroupBox grpMusicStyle;
        private System.Windows.Forms.RadioButton rbSolidLines;
        private System.Windows.Forms.TrackBar trkResponsiveness;
        private System.Windows.Forms.Label lblResponsiveness;
        private System.Windows.Forms.RadioButton rbSolidDots;
        private System.Windows.Forms.RadioButton rbMatrix;
        private System.Windows.Forms.RadioButton rbCenteredFloatingLines;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.TrackBar trkSamples;
        private System.Windows.Forms.RadioButton rbCenteredFloatingDots;
        private System.Windows.Forms.CheckBox chkMirrored;
        private System.Windows.Forms.CheckBox chkShowSilence;
        private System.Windows.Forms.RadioButton rbFloatingDots;
        private System.Windows.Forms.RadioButton rbShuffled;
    }
}