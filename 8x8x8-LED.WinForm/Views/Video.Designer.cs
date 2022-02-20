
namespace _8x8x8_LED.Views
{
    partial class FrmVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVideo));
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.bwRenderer = new System.ComponentModel.BackgroundWorker();
            this.chkAnimate = new System.Windows.Forms.CheckBox();
            this.chkSyncMusic = new System.Windows.Forms.CheckBox();
            this.chkSlideshow = new System.Windows.Forms.CheckBox();
            this.tmrSlideshow = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 49);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(6);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(193, 42);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Select &File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(8, 102);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(71, 24);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "&Speed:";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(85, 100);
            this.nudSpeed.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(120, 29);
            this.nudSpeed.TabIndex = 3;
            this.nudSpeed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudSpeed.ValueChanged += new System.EventHandler(this.NudSpeed_ValueChanged);
            // 
            // bwRenderer
            // 
            this.bwRenderer.WorkerSupportsCancellation = true;
            this.bwRenderer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwRenderer_DoWork);
            // 
            // chkAnimate
            // 
            this.chkAnimate.AutoSize = true;
            this.chkAnimate.Location = new System.Drawing.Point(12, 12);
            this.chkAnimate.Name = "chkAnimate";
            this.chkAnimate.Size = new System.Drawing.Size(98, 28);
            this.chkAnimate.TabIndex = 0;
            this.chkAnimate.Text = "&Animate";
            this.chkAnimate.UseVisualStyleBackColor = true;
            this.chkAnimate.CheckedChanged += new System.EventHandler(this.ChkAnimate_CheckedChanged);
            // 
            // chkSyncMusic
            // 
            this.chkSyncMusic.AutoSize = true;
            this.chkSyncMusic.Location = new System.Drawing.Point(12, 135);
            this.chkSyncMusic.Name = "chkSyncMusic";
            this.chkSyncMusic.Size = new System.Drawing.Size(146, 28);
            this.chkSyncMusic.TabIndex = 4;
            this.chkSyncMusic.Text = "Sync to &Music";
            this.chkSyncMusic.UseVisualStyleBackColor = true;
            this.chkSyncMusic.CheckedChanged += new System.EventHandler(this.ChkSyncMusic_CheckedChanged);
            // 
            // chkSlideshow
            // 
            this.chkSlideshow.AutoSize = true;
            this.chkSlideshow.Location = new System.Drawing.Point(12, 169);
            this.chkSlideshow.Name = "chkSlideshow";
            this.chkSlideshow.Size = new System.Drawing.Size(116, 28);
            this.chkSlideshow.TabIndex = 5;
            this.chkSlideshow.Text = "S&lideshow";
            this.chkSlideshow.UseVisualStyleBackColor = true;
            this.chkSlideshow.CheckedChanged += new System.EventHandler(this.ChkSlideshow_CheckedChanged);
            // 
            // tmrSlideshow
            // 
            this.tmrSlideshow.Interval = 10000;
            this.tmrSlideshow.Tick += new System.EventHandler(this.TmrSlideshow_Tick);
            // 
            // FrmVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 209);
            this.Controls.Add(this.chkSlideshow);
            this.Controls.Add(this.chkSyncMusic);
            this.Controls.Add(this.chkAnimate);
            this.Controls.Add(this.nudSpeed);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.btnSelectFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FrmVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVideo_FormClosing);
            this.Load += new System.EventHandler(this.FrmVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.ComponentModel.BackgroundWorker bwRenderer;
        private System.Windows.Forms.CheckBox chkAnimate;
        private System.Windows.Forms.CheckBox chkSyncMusic;
        private System.Windows.Forms.CheckBox chkSlideshow;
        private System.Windows.Forms.Timer tmrSlideshow;
    }
}