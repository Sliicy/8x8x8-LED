namespace _8x8x8_LED.Views
{
    partial class Lightning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lightning));
            this.chkRainbowMode = new System.Windows.Forms.CheckBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.nudLineCount = new System.Windows.Forms.NumericUpDown();
            this.chkAnimate = new System.Windows.Forms.CheckBox();
            this.bwAnimate = new System.ComponentModel.BackgroundWorker();
            this.trkSpeed = new System.Windows.Forms.TrackBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.grpColor = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).BeginInit();
            this.grpColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRainbowMode
            // 
            this.chkRainbowMode.AutoSize = true;
            this.chkRainbowMode.Location = new System.Drawing.Point(6, 28);
            this.chkRainbowMode.Name = "chkRainbowMode";
            this.chkRainbowMode.Size = new System.Drawing.Size(157, 28);
            this.chkRainbowMode.TabIndex = 17;
            this.chkRainbowMode.Text = "&Rainbow Mode";
            this.chkRainbowMode.UseVisualStyleBackColor = true;
            this.chkRainbowMode.CheckedChanged += new System.EventHandler(this.ChkRainbowMode_CheckedChanged);
            // 
            // cbColor
            // 
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(6, 62);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(157, 32);
            this.cbColor.TabIndex = 16;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.CbColor_SelectedIndexChanged);
            // 
            // nudLineCount
            // 
            this.nudLineCount.Location = new System.Drawing.Point(95, 54);
            this.nudLineCount.Name = "nudLineCount";
            this.nudLineCount.Size = new System.Drawing.Size(120, 29);
            this.nudLineCount.TabIndex = 15;
            this.nudLineCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLineCount.ValueChanged += new System.EventHandler(this.NudLineCount_ValueChanged);
            // 
            // chkAnimate
            // 
            this.chkAnimate.AutoSize = true;
            this.chkAnimate.Location = new System.Drawing.Point(12, 12);
            this.chkAnimate.Name = "chkAnimate";
            this.chkAnimate.Size = new System.Drawing.Size(98, 28);
            this.chkAnimate.TabIndex = 14;
            this.chkAnimate.Text = "&Animate";
            this.chkAnimate.UseVisualStyleBackColor = true;
            this.chkAnimate.CheckedChanged += new System.EventHandler(this.ChkAnimate_CheckedChanged);
            // 
            // bwAnimate
            // 
            this.bwAnimate.WorkerSupportsCancellation = true;
            this.bwAnimate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwAnimate_DoWork);
            // 
            // trkSpeed
            // 
            this.trkSpeed.Location = new System.Drawing.Point(95, 195);
            this.trkSpeed.Maximum = 3000;
            this.trkSpeed.Name = "trkSpeed";
            this.trkSpeed.Size = new System.Drawing.Size(120, 45);
            this.trkSpeed.TabIndex = 18;
            this.trkSpeed.Scroll += new System.EventHandler(this.TrkSpeed_Scroll);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(8, 195);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(71, 24);
            this.lblSpeed.TabIndex = 19;
            this.lblSpeed.Text = "&Speed:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(8, 56);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(81, 24);
            this.lblAmount.TabIndex = 20;
            this.lblAmount.Text = "A&mount:";
            // 
            // grpColor
            // 
            this.grpColor.Controls.Add(this.chkRainbowMode);
            this.grpColor.Controls.Add(this.cbColor);
            this.grpColor.Location = new System.Drawing.Point(12, 89);
            this.grpColor.Name = "grpColor";
            this.grpColor.Size = new System.Drawing.Size(203, 100);
            this.grpColor.TabIndex = 21;
            this.grpColor.TabStop = false;
            this.grpColor.Text = "&Color";
            // 
            // Lightning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 264);
            this.Controls.Add(this.grpColor);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.trkSpeed);
            this.Controls.Add(this.nudLineCount);
            this.Controls.Add(this.chkAnimate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Lightning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lightning";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Lightning_FormClosing);
            this.Load += new System.EventHandler(this.Lightning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLineCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).EndInit();
            this.grpColor.ResumeLayout(false);
            this.grpColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRainbowMode;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.NumericUpDown nudLineCount;
        private System.Windows.Forms.CheckBox chkAnimate;
        private System.ComponentModel.BackgroundWorker bwAnimate;
        private System.Windows.Forms.TrackBar trkSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.GroupBox grpColor;
    }
}