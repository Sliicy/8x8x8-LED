
namespace _8x8x8_LED.View
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.chkLooped = new System.Windows.Forms.CheckBox();
            this.bwRenderer = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(97, 15);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(6);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(193, 42);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select &File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(93, 68);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(71, 24);
            this.lblSpeed.TabIndex = 1;
            this.lblSpeed.Text = "&Speed:";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(170, 66);
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
            this.nudSpeed.TabIndex = 2;
            this.nudSpeed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // chkLooped
            // 
            this.chkLooped.AutoSize = true;
            this.chkLooped.Location = new System.Drawing.Point(97, 101);
            this.chkLooped.Name = "chkLooped";
            this.chkLooped.Size = new System.Drawing.Size(94, 28);
            this.chkLooped.TabIndex = 3;
            this.chkLooped.Text = "&Looped";
            this.chkLooped.UseVisualStyleBackColor = true;
            this.chkLooped.CheckedChanged += new System.EventHandler(this.ChkLooped_CheckedChanged);
            // 
            // bwRenderer
            // 
            this.bwRenderer.WorkerSupportsCancellation = true;
            this.bwRenderer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwRenderer_DoWork);
            // 
            // FrmVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 370);
            this.Controls.Add(this.chkLooped);
            this.Controls.Add(this.nudSpeed);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.btnSelectFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Video";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVideo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.CheckBox chkLooped;
        private System.ComponentModel.BackgroundWorker bwRenderer;
    }
}