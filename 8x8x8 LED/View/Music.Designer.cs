
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
            this.rbShuffled = new System.Windows.Forms.RadioButton();
            this.rbCenteredFloatingDots = new System.Windows.Forms.RadioButton();
            this.rbCenteredSolidDots = new System.Windows.Forms.RadioButton();
            this.rbCenteredSolidLines = new System.Windows.Forms.RadioButton();
            this.rbCenteredFloatingLines = new System.Windows.Forms.RadioButton();
            this.rbMatrix = new System.Windows.Forms.RadioButton();
            this.rbSolidDots = new System.Windows.Forms.RadioButton();
            this.rbSolidLines = new System.Windows.Forms.RadioButton();
            this.rbFloatingDots = new System.Windows.Forms.RadioButton();
            this.lblSamples = new System.Windows.Forms.Label();
            this.trkSamples = new System.Windows.Forms.TrackBar();
            this.chkMirrored = new System.Windows.Forms.CheckBox();
            this.chkShowSilence = new System.Windows.Forms.CheckBox();
            this.lblResponsiveness = new System.Windows.Forms.Label();
            this.trkResponsiveness = new System.Windows.Forms.TrackBar();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.grpMusicStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkResponsiveness)).BeginInit();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSyncMusic
            // 
            this.chkSyncMusic.AutoSize = true;
            this.chkSyncMusic.Location = new System.Drawing.Point(9, 31);
            this.chkSyncMusic.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkSyncMusic.Name = "chkSyncMusic";
            this.chkSyncMusic.Size = new System.Drawing.Size(126, 28);
            this.chkSyncMusic.TabIndex = 1;
            this.chkSyncMusic.Text = "S&ync Music";
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
            this.rbFloatingLines.Location = new System.Drawing.Point(12, 34);
            this.rbFloatingLines.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbFloatingLines.Name = "rbFloatingLines";
            this.rbFloatingLines.Size = new System.Drawing.Size(145, 28);
            this.rbFloatingLines.TabIndex = 9;
            this.rbFloatingLines.Text = "Floating Lines";
            this.rbFloatingLines.UseVisualStyleBackColor = true;
            this.rbFloatingLines.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // grpMusicStyle
            // 
            this.grpMusicStyle.Controls.Add(this.rbShuffled);
            this.grpMusicStyle.Controls.Add(this.rbCenteredFloatingDots);
            this.grpMusicStyle.Controls.Add(this.rbCenteredSolidDots);
            this.grpMusicStyle.Controls.Add(this.rbCenteredSolidLines);
            this.grpMusicStyle.Controls.Add(this.rbCenteredFloatingLines);
            this.grpMusicStyle.Controls.Add(this.rbMatrix);
            this.grpMusicStyle.Controls.Add(this.rbSolidDots);
            this.grpMusicStyle.Controls.Add(this.rbSolidLines);
            this.grpMusicStyle.Controls.Add(this.rbFloatingDots);
            this.grpMusicStyle.Controls.Add(this.rbFloatingLines);
            this.grpMusicStyle.Location = new System.Drawing.Point(580, 15);
            this.grpMusicStyle.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpMusicStyle.Name = "grpMusicStyle";
            this.grpMusicStyle.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpMusicStyle.Size = new System.Drawing.Size(254, 438);
            this.grpMusicStyle.TabIndex = 8;
            this.grpMusicStyle.TabStop = false;
            this.grpMusicStyle.Text = "Style";
            // 
            // rbShuffled
            // 
            this.rbShuffled.AutoSize = true;
            this.rbShuffled.Location = new System.Drawing.Point(12, 394);
            this.rbShuffled.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbShuffled.Name = "rbShuffled";
            this.rbShuffled.Size = new System.Drawing.Size(96, 28);
            this.rbShuffled.TabIndex = 18;
            this.rbShuffled.Text = "Shuffled";
            this.rbShuffled.UseVisualStyleBackColor = true;
            this.rbShuffled.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbCenteredFloatingDots
            // 
            this.rbCenteredFloatingDots.AutoSize = true;
            this.rbCenteredFloatingDots.Location = new System.Drawing.Point(12, 234);
            this.rbCenteredFloatingDots.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbCenteredFloatingDots.Name = "rbCenteredFloatingDots";
            this.rbCenteredFloatingDots.Size = new System.Drawing.Size(220, 28);
            this.rbCenteredFloatingDots.TabIndex = 14;
            this.rbCenteredFloatingDots.Text = "Centered Floating Dots";
            this.rbCenteredFloatingDots.UseVisualStyleBackColor = true;
            this.rbCenteredFloatingDots.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbCenteredSolidDots
            // 
            this.rbCenteredSolidDots.AutoSize = true;
            this.rbCenteredSolidDots.Location = new System.Drawing.Point(12, 314);
            this.rbCenteredSolidDots.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbCenteredSolidDots.Name = "rbCenteredSolidDots";
            this.rbCenteredSolidDots.Size = new System.Drawing.Size(195, 28);
            this.rbCenteredSolidDots.TabIndex = 16;
            this.rbCenteredSolidDots.Text = "Centered Solid Dots";
            this.rbCenteredSolidDots.UseVisualStyleBackColor = true;
            this.rbCenteredSolidDots.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbCenteredSolidLines
            // 
            this.rbCenteredSolidLines.AutoSize = true;
            this.rbCenteredSolidLines.Checked = true;
            this.rbCenteredSolidLines.Location = new System.Drawing.Point(12, 274);
            this.rbCenteredSolidLines.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbCenteredSolidLines.Name = "rbCenteredSolidLines";
            this.rbCenteredSolidLines.Size = new System.Drawing.Size(203, 28);
            this.rbCenteredSolidLines.TabIndex = 15;
            this.rbCenteredSolidLines.TabStop = true;
            this.rbCenteredSolidLines.Text = "Centered Solid Lines";
            this.rbCenteredSolidLines.UseVisualStyleBackColor = true;
            this.rbCenteredSolidLines.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbCenteredFloatingLines
            // 
            this.rbCenteredFloatingLines.AutoSize = true;
            this.rbCenteredFloatingLines.Location = new System.Drawing.Point(12, 194);
            this.rbCenteredFloatingLines.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbCenteredFloatingLines.Name = "rbCenteredFloatingLines";
            this.rbCenteredFloatingLines.Size = new System.Drawing.Size(228, 28);
            this.rbCenteredFloatingLines.TabIndex = 13;
            this.rbCenteredFloatingLines.Text = "Centered Floating Lines";
            this.rbCenteredFloatingLines.UseVisualStyleBackColor = true;
            this.rbCenteredFloatingLines.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbMatrix
            // 
            this.rbMatrix.AutoSize = true;
            this.rbMatrix.Location = new System.Drawing.Point(12, 354);
            this.rbMatrix.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbMatrix.Name = "rbMatrix";
            this.rbMatrix.Size = new System.Drawing.Size(78, 28);
            this.rbMatrix.TabIndex = 17;
            this.rbMatrix.Text = "Matrix";
            this.rbMatrix.UseVisualStyleBackColor = true;
            this.rbMatrix.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbSolidDots
            // 
            this.rbSolidDots.AutoSize = true;
            this.rbSolidDots.Location = new System.Drawing.Point(12, 154);
            this.rbSolidDots.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbSolidDots.Name = "rbSolidDots";
            this.rbSolidDots.Size = new System.Drawing.Size(112, 28);
            this.rbSolidDots.TabIndex = 12;
            this.rbSolidDots.Text = "Solid Dots";
            this.rbSolidDots.UseVisualStyleBackColor = true;
            this.rbSolidDots.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbSolidLines
            // 
            this.rbSolidLines.AutoSize = true;
            this.rbSolidLines.Location = new System.Drawing.Point(12, 114);
            this.rbSolidLines.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbSolidLines.Name = "rbSolidLines";
            this.rbSolidLines.Size = new System.Drawing.Size(120, 28);
            this.rbSolidLines.TabIndex = 11;
            this.rbSolidLines.Text = "Solid Lines";
            this.rbSolidLines.UseVisualStyleBackColor = true;
            this.rbSolidLines.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbFloatingDots
            // 
            this.rbFloatingDots.AutoSize = true;
            this.rbFloatingDots.Location = new System.Drawing.Point(12, 74);
            this.rbFloatingDots.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbFloatingDots.Name = "rbFloatingDots";
            this.rbFloatingDots.Size = new System.Drawing.Size(137, 28);
            this.rbFloatingDots.TabIndex = 10;
            this.rbFloatingDots.Text = "Floating Dots";
            this.rbFloatingDots.UseVisualStyleBackColor = true;
            this.rbFloatingDots.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(9, 178);
            this.lblSamples.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(88, 24);
            this.lblSamples.TabIndex = 6;
            this.lblSamples.Text = "S&amples:";
            // 
            // trkSamples
            // 
            this.trkSamples.LargeChange = 8;
            this.trkSamples.Location = new System.Drawing.Point(175, 178);
            this.trkSamples.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.trkSamples.Maximum = 16384;
            this.trkSamples.Minimum = 8;
            this.trkSamples.Name = "trkSamples";
            this.trkSamples.Size = new System.Drawing.Size(280, 45);
            this.trkSamples.SmallChange = 8;
            this.trkSamples.TabIndex = 7;
            this.trkSamples.Value = 1024;
            this.trkSamples.Scroll += new System.EventHandler(this.TrkSamples_Scroll);
            // 
            // chkMirrored
            // 
            this.chkMirrored.AutoSize = true;
            this.chkMirrored.Checked = true;
            this.chkMirrored.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMirrored.Location = new System.Drawing.Point(9, 71);
            this.chkMirrored.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkMirrored.Name = "chkMirrored";
            this.chkMirrored.Size = new System.Drawing.Size(155, 28);
            this.chkMirrored.TabIndex = 2;
            this.chkMirrored.Text = "&Mirrored Audio";
            this.chkMirrored.UseVisualStyleBackColor = true;
            // 
            // chkShowSilence
            // 
            this.chkShowSilence.AutoSize = true;
            this.chkShowSilence.Checked = true;
            this.chkShowSilence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowSilence.Location = new System.Drawing.Point(9, 111);
            this.chkShowSilence.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkShowSilence.Name = "chkShowSilence";
            this.chkShowSilence.Size = new System.Drawing.Size(145, 28);
            this.chkShowSilence.TabIndex = 3;
            this.chkShowSilence.Text = "Show &Silence";
            this.chkShowSilence.UseVisualStyleBackColor = true;
            this.chkShowSilence.CheckedChanged += new System.EventHandler(this.ChkShowSilence_CheckedChanged);
            // 
            // lblResponsiveness
            // 
            this.lblResponsiveness.AutoSize = true;
            this.lblResponsiveness.Location = new System.Drawing.Point(9, 145);
            this.lblResponsiveness.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblResponsiveness.Name = "lblResponsiveness";
            this.lblResponsiveness.Size = new System.Drawing.Size(154, 24);
            this.lblResponsiveness.TabIndex = 4;
            this.lblResponsiveness.Text = "&Responsiveness:";
            // 
            // trkResponsiveness
            // 
            this.trkResponsiveness.Location = new System.Drawing.Point(175, 140);
            this.trkResponsiveness.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.trkResponsiveness.Maximum = 10000;
            this.trkResponsiveness.Minimum = 1;
            this.trkResponsiveness.Name = "trkResponsiveness";
            this.trkResponsiveness.Size = new System.Drawing.Size(280, 45);
            this.trkResponsiveness.TabIndex = 5;
            this.trkResponsiveness.Value = 1;
            this.trkResponsiveness.Scroll += new System.EventHandler(this.TrkResponsiveness_Scroll);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.chkSyncMusic);
            this.grpSettings.Controls.Add(this.trkSamples);
            this.grpSettings.Controls.Add(this.lblSamples);
            this.grpSettings.Controls.Add(this.chkShowSilence);
            this.grpSettings.Controls.Add(this.lblResponsiveness);
            this.grpSettings.Controls.Add(this.trkResponsiveness);
            this.grpSettings.Controls.Add(this.chkMirrored);
            this.grpSettings.Location = new System.Drawing.Point(12, 12);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(559, 441);
            this.grpSettings.TabIndex = 0;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // FrmMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 463);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.grpMusicStyle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FrmMusic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Music";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMusic_FormClosing);
            this.Load += new System.EventHandler(this.FrmMusic_Load);
            this.grpMusicStyle.ResumeLayout(false);
            this.grpMusicStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkResponsiveness)).EndInit();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSyncMusic;
        private System.ComponentModel.BackgroundWorker bwVisualize;
        private System.Windows.Forms.RadioButton rbFloatingLines;
        private System.Windows.Forms.GroupBox grpMusicStyle;
        private System.Windows.Forms.RadioButton rbSolidLines;
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
        private System.Windows.Forms.RadioButton rbCenteredSolidDots;
        private System.Windows.Forms.RadioButton rbCenteredSolidLines;
        private System.Windows.Forms.Label lblResponsiveness;
        private System.Windows.Forms.TrackBar trkResponsiveness;
        private System.Windows.Forms.GroupBox grpSettings;
    }
}