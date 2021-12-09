
namespace _8x8x8_LED.Views
{
    partial class FrmMarquee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMarquee));
            this.txtMarquee = new System.Windows.Forms.TextBox();
            this.bwAnimate = new System.ComponentModel.BackgroundWorker();
            this.chkAnimate = new System.Windows.Forms.CheckBox();
            this.lblSpacing = new System.Windows.Forms.Label();
            this.nudSpacing = new System.Windows.Forms.NumericUpDown();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trkSpeed = new System.Windows.Forms.TrackBar();
            this.chkLetterEnding = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMarquee
            // 
            this.txtMarquee.Location = new System.Drawing.Point(12, 49);
            this.txtMarquee.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtMarquee.Multiline = true;
            this.txtMarquee.Name = "txtMarquee";
            this.txtMarquee.Size = new System.Drawing.Size(726, 34);
            this.txtMarquee.TabIndex = 1;
            this.txtMarquee.TextChanged += new System.EventHandler(this.TxtMarquee_TextChanged);
            // 
            // bwAnimate
            // 
            this.bwAnimate.WorkerSupportsCancellation = true;
            this.bwAnimate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwAnimate_DoWork);
            // 
            // chkAnimate
            // 
            this.chkAnimate.AutoSize = true;
            this.chkAnimate.Checked = true;
            this.chkAnimate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnimate.Location = new System.Drawing.Point(12, 12);
            this.chkAnimate.Name = "chkAnimate";
            this.chkAnimate.Size = new System.Drawing.Size(98, 28);
            this.chkAnimate.TabIndex = 0;
            this.chkAnimate.Text = "&Animate";
            this.chkAnimate.UseVisualStyleBackColor = true;
            this.chkAnimate.CheckedChanged += new System.EventHandler(this.ChkAnimate_CheckedChanged);
            // 
            // lblSpacing
            // 
            this.lblSpacing.AutoSize = true;
            this.lblSpacing.Location = new System.Drawing.Point(13, 106);
            this.lblSpacing.Name = "lblSpacing";
            this.lblSpacing.Size = new System.Drawing.Size(155, 24);
            this.lblSpacing.TabIndex = 2;
            this.lblSpacing.Text = "S&pacing Amount:";
            // 
            // nudSpacing
            // 
            this.nudSpacing.Location = new System.Drawing.Point(174, 104);
            this.nudSpacing.Name = "nudSpacing";
            this.nudSpacing.Size = new System.Drawing.Size(120, 29);
            this.nudSpacing.TabIndex = 3;
            this.nudSpacing.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpacing.ValueChanged += new System.EventHandler(this.NudSpacing_ValueChanged);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(361, 106);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(71, 24);
            this.lblSpeed.TabIndex = 4;
            this.lblSpeed.Text = "&Speed:";
            // 
            // trkSpeed
            // 
            this.trkSpeed.Location = new System.Drawing.Point(438, 92);
            this.trkSpeed.Maximum = 1000;
            this.trkSpeed.Name = "trkSpeed";
            this.trkSpeed.Size = new System.Drawing.Size(300, 45);
            this.trkSpeed.TabIndex = 5;
            this.trkSpeed.Value = 200;
            this.trkSpeed.Scroll += new System.EventHandler(this.TrkSpeed_Scroll);
            // 
            // chkLetterEnding
            // 
            this.chkLetterEnding.AutoSize = true;
            this.chkLetterEnding.Checked = true;
            this.chkLetterEnding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLetterEnding.Location = new System.Drawing.Point(12, 159);
            this.chkLetterEnding.Name = "chkLetterEnding";
            this.chkLetterEnding.Size = new System.Drawing.Size(240, 28);
            this.chkLetterEnding.TabIndex = 6;
            this.chkLetterEnding.Text = "&End after last letter leaves";
            this.chkLetterEnding.UseVisualStyleBackColor = true;
            this.chkLetterEnding.CheckedChanged += new System.EventHandler(this.ChkLetterEnding_CheckedChanged);
            // 
            // FrmMarquee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 222);
            this.Controls.Add(this.chkLetterEnding);
            this.Controls.Add(this.trkSpeed);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.nudSpacing);
            this.Controls.Add(this.lblSpacing);
            this.Controls.Add(this.chkAnimate);
            this.Controls.Add(this.txtMarquee);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "FrmMarquee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marquee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMarquee_FormClosing);
            this.Load += new System.EventHandler(this.FrmMarquee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMarquee;
        private System.ComponentModel.BackgroundWorker bwAnimate;
        private System.Windows.Forms.CheckBox chkAnimate;
        private System.Windows.Forms.Label lblSpacing;
        private System.Windows.Forms.NumericUpDown nudSpacing;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar trkSpeed;
        private System.Windows.Forms.CheckBox chkLetterEnding;
    }
}