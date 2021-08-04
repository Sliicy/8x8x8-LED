
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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 147);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(374, 262);
            this.textBox1.TabIndex = 1;
            // 
            // frmMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkSyncMusic);
            this.Name = "frmMusic";
            this.Text = "Music";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSyncMusic;
        private System.Windows.Forms.Timer tmrMusic;
        private System.ComponentModel.BackgroundWorker bwVisualize;
        private System.Windows.Forms.TextBox textBox1;
    }
}