
namespace _8x8x8_LED.Views
{
    partial class FrmBalls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBalls));
            this.bwEngine = new System.ComponentModel.BackgroundWorker();
            this.btnAddBall = new System.Windows.Forms.Button();
            this.btnRemoveBall = new System.Windows.Forms.Button();
            this.trkSpeed = new System.Windows.Forms.TrackBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.cbPhysics = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSyncMusic = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // bwEngine
            // 
            this.bwEngine.WorkerSupportsCancellation = true;
            this.bwEngine.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwEngine_DoWork);
            // 
            // btnAddBall
            // 
            this.btnAddBall.Location = new System.Drawing.Point(12, 12);
            this.btnAddBall.Name = "btnAddBall";
            this.btnAddBall.Size = new System.Drawing.Size(141, 45);
            this.btnAddBall.TabIndex = 0;
            this.btnAddBall.Text = "&Add Ball";
            this.btnAddBall.UseVisualStyleBackColor = true;
            this.btnAddBall.Click += new System.EventHandler(this.BtnAddBall_Click);
            // 
            // btnRemoveBall
            // 
            this.btnRemoveBall.Location = new System.Drawing.Point(161, 12);
            this.btnRemoveBall.Name = "btnRemoveBall";
            this.btnRemoveBall.Size = new System.Drawing.Size(141, 45);
            this.btnRemoveBall.TabIndex = 1;
            this.btnRemoveBall.Text = "&Remove Ball";
            this.btnRemoveBall.UseVisualStyleBackColor = true;
            this.btnRemoveBall.Click += new System.EventHandler(this.BtnRemoveBall_Click);
            // 
            // trkSpeed
            // 
            this.trkSpeed.Location = new System.Drawing.Point(122, 97);
            this.trkSpeed.Maximum = 1000;
            this.trkSpeed.Name = "trkSpeed";
            this.trkSpeed.Size = new System.Drawing.Size(180, 45);
            this.trkSpeed.TabIndex = 4;
            this.trkSpeed.Value = 50;
            this.trkSpeed.Scroll += new System.EventHandler(this.TrkSpeed_Scroll);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(12, 97);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(71, 24);
            this.lblSpeed.TabIndex = 3;
            this.lblSpeed.Text = "&Speed:";
            // 
            // cbPhysics
            // 
            this.cbPhysics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhysics.FormattingEnabled = true;
            this.cbPhysics.Items.AddRange(new object[] {
            "Bounce",
            "Portal"});
            this.cbPhysics.Location = new System.Drawing.Point(97, 148);
            this.cbPhysics.Name = "cbPhysics";
            this.cbPhysics.Size = new System.Drawing.Size(205, 32);
            this.cbPhysics.TabIndex = 6;
            this.cbPhysics.SelectedIndexChanged += new System.EventHandler(this.CbPhysics_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "&Physics:";
            // 
            // chkSyncMusic
            // 
            this.chkSyncMusic.AutoSize = true;
            this.chkSyncMusic.Location = new System.Drawing.Point(16, 63);
            this.chkSyncMusic.Name = "chkSyncMusic";
            this.chkSyncMusic.Size = new System.Drawing.Size(146, 28);
            this.chkSyncMusic.TabIndex = 2;
            this.chkSyncMusic.Text = "Sync to &Music";
            this.chkSyncMusic.UseVisualStyleBackColor = true;
            this.chkSyncMusic.CheckedChanged += new System.EventHandler(this.ChkSyncMusic_CheckedChanged);
            // 
            // FrmBalls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 204);
            this.Controls.Add(this.chkSyncMusic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPhysics);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.trkSpeed);
            this.Controls.Add(this.btnRemoveBall);
            this.Controls.Add(this.btnAddBall);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FrmBalls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBalls_FormClosing);
            this.Load += new System.EventHandler(this.FrmBalls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwEngine;
        private System.Windows.Forms.Button btnAddBall;
        private System.Windows.Forms.Button btnRemoveBall;
        private System.Windows.Forms.TrackBar trkSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.ComboBox cbPhysics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSyncMusic;
    }
}