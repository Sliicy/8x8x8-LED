
namespace _8x8x8_LED.View
{
    partial class FrmSnake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSnake));
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPlayer1Controls = new System.Windows.Forms.Label();
            this.bwGameEngine = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(74, 214);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(136, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start &Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lblPlayer1Controls
            // 
            this.lblPlayer1Controls.AutoSize = true;
            this.lblPlayer1Controls.Location = new System.Drawing.Point(55, 9);
            this.lblPlayer1Controls.Name = "lblPlayer1Controls";
            this.lblPlayer1Controls.Size = new System.Drawing.Size(174, 168);
            this.lblPlayer1Controls.TabIndex = 4;
            this.lblPlayer1Controls.Text = "Player Controls:\r\nW - Forwards\r\nS - Backwards\r\nA - Leftwards\r\nD - Rightwards\r\nUp " +
    "- Upwards\r\nDown - Downwards";
            // 
            // bwGameEngine
            // 
            this.bwGameEngine.WorkerSupportsCancellation = true;
            this.bwGameEngine.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwGameEngine_DoWork);
            this.bwGameEngine.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwGameEngine_RunWorkerCompleted);
            // 
            // FrmSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblPlayer1Controls);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FrmSnake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSnake_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPlayer1Controls;
        private System.ComponentModel.BackgroundWorker bwGameEngine;
    }
}