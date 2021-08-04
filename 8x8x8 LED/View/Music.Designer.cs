
namespace _8x8x8_LED.Apps
{
    partial class frmMusic
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
            this.chkSyncMusic = new System.Windows.Forms.CheckBox();
            this.tmrMusic = new System.Windows.Forms.Timer(this.components);
            this.bwVisualize = new System.ComponentModel.BackgroundWorker();
            this.rbSingleBar = new System.Windows.Forms.RadioButton();
            this.grpMusicStyle = new System.Windows.Forms.GroupBox();
            this.rbFloatingBar = new System.Windows.Forms.RadioButton();
            this.rbFilled = new System.Windows.Forms.RadioButton();
            this.trkResponsiveness = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.rbFloatingSquare = new System.Windows.Forms.RadioButton();
            this.rbTube = new System.Windows.Forms.RadioButton();
            this.rbMatrix = new System.Windows.Forms.RadioButton();
            this.grpMusicStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkResponsiveness)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSyncMusic
            // 
            this.chkSyncMusic.AutoSize = true;
            this.chkSyncMusic.Location = new System.Drawing.Point(52, 58);
            this.chkSyncMusic.Name = "chkSyncMusic";
            this.chkSyncMusic.Size = new System.Drawing.Size(81, 17);
            this.chkSyncMusic.TabIndex = 0;
            this.chkSyncMusic.Text = "Sync Music";
            this.chkSyncMusic.UseVisualStyleBackColor = true;
            this.chkSyncMusic.CheckedChanged += new System.EventHandler(this.ChkSyncMusic_CheckedChanged);
            // 
            // tmrMusic
            // 
            this.tmrMusic.Tick += new System.EventHandler(this.TmrMusic_Tick);
            // 
            // bwVisualize
            // 
            this.bwVisualize.WorkerSupportsCancellation = true;
            this.bwVisualize.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwVisualize_DoWork);
            // 
            // rbSingleBar
            // 
            this.rbSingleBar.AutoSize = true;
            this.rbSingleBar.Location = new System.Drawing.Point(6, 19);
            this.rbSingleBar.Name = "rbSingleBar";
            this.rbSingleBar.Size = new System.Drawing.Size(73, 17);
            this.rbSingleBar.TabIndex = 2;
            this.rbSingleBar.TabStop = true;
            this.rbSingleBar.Text = "Single Bar";
            this.rbSingleBar.UseVisualStyleBackColor = true;
            // 
            // grpMusicStyle
            // 
            this.grpMusicStyle.Controls.Add(this.rbMatrix);
            this.grpMusicStyle.Controls.Add(this.rbTube);
            this.grpMusicStyle.Controls.Add(this.rbFloatingSquare);
            this.grpMusicStyle.Controls.Add(this.rbFloatingBar);
            this.grpMusicStyle.Controls.Add(this.rbFilled);
            this.grpMusicStyle.Controls.Add(this.rbSingleBar);
            this.grpMusicStyle.Location = new System.Drawing.Point(52, 81);
            this.grpMusicStyle.Name = "grpMusicStyle";
            this.grpMusicStyle.Size = new System.Drawing.Size(200, 169);
            this.grpMusicStyle.TabIndex = 3;
            this.grpMusicStyle.TabStop = false;
            this.grpMusicStyle.Text = "Style";
            // 
            // rbFloatingBar
            // 
            this.rbFloatingBar.AutoSize = true;
            this.rbFloatingBar.Location = new System.Drawing.Point(6, 65);
            this.rbFloatingBar.Name = "rbFloatingBar";
            this.rbFloatingBar.Size = new System.Drawing.Size(81, 17);
            this.rbFloatingBar.TabIndex = 2;
            this.rbFloatingBar.TabStop = true;
            this.rbFloatingBar.Text = "Floating Bar";
            this.rbFloatingBar.UseVisualStyleBackColor = true;
            // 
            // rbFilled
            // 
            this.rbFilled.AutoSize = true;
            this.rbFilled.Location = new System.Drawing.Point(6, 42);
            this.rbFilled.Name = "rbFilled";
            this.rbFilled.Size = new System.Drawing.Size(49, 17);
            this.rbFilled.TabIndex = 2;
            this.rbFilled.TabStop = true;
            this.rbFilled.Text = "Filled";
            this.rbFilled.UseVisualStyleBackColor = true;
            // 
            // trkResponsiveness
            // 
            this.trkResponsiveness.Location = new System.Drawing.Point(148, 277);
            this.trkResponsiveness.Maximum = 1000000;
            this.trkResponsiveness.Minimum = 1;
            this.trkResponsiveness.Name = "trkResponsiveness";
            this.trkResponsiveness.Size = new System.Drawing.Size(497, 45);
            this.trkResponsiveness.TabIndex = 4;
            this.trkResponsiveness.Value = 1;
            this.trkResponsiveness.Scroll += new System.EventHandler(this.TrkResponsiveness_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Responsiveness:";
            // 
            // rbFloatingSquare
            // 
            this.rbFloatingSquare.AutoSize = true;
            this.rbFloatingSquare.Location = new System.Drawing.Point(7, 88);
            this.rbFloatingSquare.Name = "rbFloatingSquare";
            this.rbFloatingSquare.Size = new System.Drawing.Size(99, 17);
            this.rbFloatingSquare.TabIndex = 2;
            this.rbFloatingSquare.TabStop = true;
            this.rbFloatingSquare.Text = "Floating Square";
            this.rbFloatingSquare.UseVisualStyleBackColor = true;
            // 
            // rbTube
            // 
            this.rbTube.AutoSize = true;
            this.rbTube.Location = new System.Drawing.Point(7, 111);
            this.rbTube.Name = "rbTube";
            this.rbTube.Size = new System.Drawing.Size(50, 17);
            this.rbTube.TabIndex = 2;
            this.rbTube.TabStop = true;
            this.rbTube.Text = "Tube";
            this.rbTube.UseVisualStyleBackColor = true;
            // 
            // rbMatrix
            // 
            this.rbMatrix.AutoSize = true;
            this.rbMatrix.Location = new System.Drawing.Point(7, 134);
            this.rbMatrix.Name = "rbMatrix";
            this.rbMatrix.Size = new System.Drawing.Size(53, 17);
            this.rbMatrix.TabIndex = 2;
            this.rbMatrix.TabStop = true;
            this.rbMatrix.Text = "Matrix";
            this.rbMatrix.UseVisualStyleBackColor = true;
            // 
            // frmMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trkResponsiveness);
            this.Controls.Add(this.grpMusicStyle);
            this.Controls.Add(this.chkSyncMusic);
            this.Name = "frmMusic";
            this.Text = "Music";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMusic_FormClosing);
            this.grpMusicStyle.ResumeLayout(false);
            this.grpMusicStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkResponsiveness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSyncMusic;
        private System.Windows.Forms.Timer tmrMusic;
        private System.ComponentModel.BackgroundWorker bwVisualize;
        private System.Windows.Forms.RadioButton rbSingleBar;
        private System.Windows.Forms.GroupBox grpMusicStyle;
        private System.Windows.Forms.RadioButton rbFilled;
        private System.Windows.Forms.RadioButton rbFloatingBar;
        private System.Windows.Forms.TrackBar trkResponsiveness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbFloatingSquare;
        private System.Windows.Forms.RadioButton rbTube;
        private System.Windows.Forms.RadioButton rbMatrix;
    }
}