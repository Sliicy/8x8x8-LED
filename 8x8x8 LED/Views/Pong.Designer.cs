
namespace _8x8x8_LED.Views
{
    partial class FrmPong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPong));
            this.btnStart = new System.Windows.Forms.Button();
            this.bwGameEngine = new System.ComponentModel.BackgroundWorker();
            this.lblPlayer1Controls = new System.Windows.Forms.Label();
            this.lblPlayer2Controls = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.tmrScore = new System.Windows.Forms.Timer(this.components);
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.grpControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 206);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(440, 47);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start &Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // bwGameEngine
            // 
            this.bwGameEngine.WorkerSupportsCancellation = true;
            this.bwGameEngine.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwGameEngine_DoWork);
            this.bwGameEngine.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwGameEngine_RunWorkerCompleted);
            // 
            // lblPlayer1Controls
            // 
            this.lblPlayer1Controls.AutoSize = true;
            this.lblPlayer1Controls.Location = new System.Drawing.Point(6, 25);
            this.lblPlayer1Controls.Name = "lblPlayer1Controls";
            this.lblPlayer1Controls.Size = new System.Drawing.Size(137, 120);
            this.lblPlayer1Controls.TabIndex = 1;
            this.lblPlayer1Controls.Text = "Player 1:\r\nW - Upwards\r\nS - Downwards\r\nA - Backwards\r\nD - Forwards";
            // 
            // lblPlayer2Controls
            // 
            this.lblPlayer2Controls.AutoSize = true;
            this.lblPlayer2Controls.Location = new System.Drawing.Point(149, 25);
            this.lblPlayer2Controls.Name = "lblPlayer2Controls";
            this.lblPlayer2Controls.Size = new System.Drawing.Size(174, 120);
            this.lblPlayer2Controls.TabIndex = 2;
            this.lblPlayer2Controls.Text = "Player 2:\r\nUp - Upwards\r\nDown - Downwards\r\nLeft - Backwards\r\nRight - Forwards";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(351, 12);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(97, 72);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "Score:\r\nPlayer 1: 0\r\nPlayer 2: 0";
            // 
            // tmrScore
            // 
            this.tmrScore.Enabled = true;
            this.tmrScore.Tick += new System.EventHandler(this.TmrScore_Tick);
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.lblPlayer1Controls);
            this.grpControls.Controls.Add(this.lblPlayer2Controls);
            this.grpControls.Location = new System.Drawing.Point(12, 12);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(333, 188);
            this.grpControls.TabIndex = 0;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Controls";
            // 
            // FrmPong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 267);
            this.Controls.Add(this.grpControls);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FrmPong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPong_FormClosing);
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.ComponentModel.BackgroundWorker bwGameEngine;
        private System.Windows.Forms.Label lblPlayer1Controls;
        private System.Windows.Forms.Label lblPlayer2Controls;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer tmrScore;
        private System.Windows.Forms.GroupBox grpControls;
    }
}