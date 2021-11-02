
namespace _8x8x8_LED.View
{
    partial class FrmRain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRain));
            this.chkAnimate = new System.Windows.Forms.CheckBox();
            this.bwAnimate = new System.ComponentModel.BackgroundWorker();
            this.lblStarCount = new System.Windows.Forms.Label();
            this.tbRainCount = new System.Windows.Forms.TrackBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.cbDirectionZ = new System.Windows.Forms.ComboBox();
            this.lblDirectionZ = new System.Windows.Forms.Label();
            this.lblDirectionY = new System.Windows.Forms.Label();
            this.cbDirectionY = new System.Windows.Forms.ComboBox();
            this.lblDirectionX = new System.Windows.Forms.Label();
            this.cbDirectionX = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbRainCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAnimate
            // 
            this.chkAnimate.AutoSize = true;
            this.chkAnimate.Location = new System.Drawing.Point(24, 24);
            this.chkAnimate.Margin = new System.Windows.Forms.Padding(6);
            this.chkAnimate.Name = "chkAnimate";
            this.chkAnimate.Size = new System.Drawing.Size(98, 28);
            this.chkAnimate.TabIndex = 0;
            this.chkAnimate.Text = "&Animate";
            this.chkAnimate.UseVisualStyleBackColor = true;
            this.chkAnimate.CheckedChanged += new System.EventHandler(this.ChkAnimate_CheckedChanged);
            // 
            // bwAnimate
            // 
            this.bwAnimate.WorkerSupportsCancellation = true;
            this.bwAnimate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwAnimate_DoWork);
            // 
            // lblStarCount
            // 
            this.lblStarCount.AutoSize = true;
            this.lblStarCount.Location = new System.Drawing.Point(20, 80);
            this.lblStarCount.Name = "lblStarCount";
            this.lblStarCount.Size = new System.Drawing.Size(108, 24);
            this.lblStarCount.TabIndex = 1;
            this.lblStarCount.Text = "Rain &Count:";
            // 
            // tbRainCount
            // 
            this.tbRainCount.Location = new System.Drawing.Point(129, 80);
            this.tbRainCount.Maximum = 900;
            this.tbRainCount.Minimum = 9;
            this.tbRainCount.Name = "tbRainCount";
            this.tbRainCount.Size = new System.Drawing.Size(480, 45);
            this.tbRainCount.TabIndex = 2;
            this.tbRainCount.Value = 90;
            this.tbRainCount.Scroll += new System.EventHandler(this.Tb_Scroll);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(20, 131);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(71, 24);
            this.lblSpeed.TabIndex = 3;
            this.lblSpeed.Text = "&Speed:";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(129, 131);
            this.tbSpeed.Maximum = 1000;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(480, 45);
            this.tbSpeed.TabIndex = 4;
            this.tbSpeed.Scroll += new System.EventHandler(this.Tb_Scroll);
            // 
            // cbDirectionZ
            // 
            this.cbDirectionZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirectionZ.FormattingEnabled = true;
            this.cbDirectionZ.Items.AddRange(new object[] {
            "None",
            "Upwards",
            "Downwards"});
            this.cbDirectionZ.Location = new System.Drawing.Point(154, 270);
            this.cbDirectionZ.Name = "cbDirectionZ";
            this.cbDirectionZ.Size = new System.Drawing.Size(121, 32);
            this.cbDirectionZ.TabIndex = 10;
            this.cbDirectionZ.SelectedIndexChanged += new System.EventHandler(this.CbDirectionZ_SelectedIndexChanged);
            // 
            // lblDirectionZ
            // 
            this.lblDirectionZ.AutoSize = true;
            this.lblDirectionZ.Location = new System.Drawing.Point(20, 273);
            this.lblDirectionZ.Name = "lblDirectionZ";
            this.lblDirectionZ.Size = new System.Drawing.Size(106, 24);
            this.lblDirectionZ.TabIndex = 9;
            this.lblDirectionZ.Text = "Direction &Z:";
            // 
            // lblDirectionY
            // 
            this.lblDirectionY.AutoSize = true;
            this.lblDirectionY.Location = new System.Drawing.Point(20, 230);
            this.lblDirectionY.Name = "lblDirectionY";
            this.lblDirectionY.Size = new System.Drawing.Size(106, 24);
            this.lblDirectionY.TabIndex = 7;
            this.lblDirectionY.Text = "Direction &Y:";
            // 
            // cbDirectionY
            // 
            this.cbDirectionY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirectionY.FormattingEnabled = true;
            this.cbDirectionY.Items.AddRange(new object[] {
            "None",
            "Leftwards",
            "Rightwards"});
            this.cbDirectionY.Location = new System.Drawing.Point(154, 227);
            this.cbDirectionY.Name = "cbDirectionY";
            this.cbDirectionY.Size = new System.Drawing.Size(121, 32);
            this.cbDirectionY.TabIndex = 8;
            this.cbDirectionY.SelectedIndexChanged += new System.EventHandler(this.CbDirectionY_SelectedIndexChanged);
            // 
            // lblDirectionX
            // 
            this.lblDirectionX.AutoSize = true;
            this.lblDirectionX.Location = new System.Drawing.Point(20, 188);
            this.lblDirectionX.Name = "lblDirectionX";
            this.lblDirectionX.Size = new System.Drawing.Size(108, 24);
            this.lblDirectionX.TabIndex = 5;
            this.lblDirectionX.Text = "Direction &X:";
            // 
            // cbDirectionX
            // 
            this.cbDirectionX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirectionX.FormattingEnabled = true;
            this.cbDirectionX.Items.AddRange(new object[] {
            "None",
            "Forwards",
            "Backwards"});
            this.cbDirectionX.Location = new System.Drawing.Point(154, 185);
            this.cbDirectionX.Name = "cbDirectionX";
            this.cbDirectionX.Size = new System.Drawing.Size(121, 32);
            this.cbDirectionX.TabIndex = 6;
            this.cbDirectionX.SelectedIndexChanged += new System.EventHandler(this.CbDirectionX_SelectedIndexChanged);
            // 
            // FrmRain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 328);
            this.Controls.Add(this.cbDirectionX);
            this.Controls.Add(this.cbDirectionY);
            this.Controls.Add(this.cbDirectionZ);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.lblDirectionX);
            this.Controls.Add(this.tbRainCount);
            this.Controls.Add(this.lblDirectionY);
            this.Controls.Add(this.lblDirectionZ);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblStarCount);
            this.Controls.Add(this.chkAnimate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FrmRain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRain_FormClosing);
            this.Load += new System.EventHandler(this.FrmRain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbRainCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAnimate;
        private System.ComponentModel.BackgroundWorker bwAnimate;
        private System.Windows.Forms.Label lblStarCount;
        private System.Windows.Forms.TrackBar tbRainCount;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.ComboBox cbDirectionZ;
        private System.Windows.Forms.Label lblDirectionZ;
        private System.Windows.Forms.Label lblDirectionY;
        private System.Windows.Forms.ComboBox cbDirectionY;
        private System.Windows.Forms.Label lblDirectionX;
        private System.Windows.Forms.ComboBox cbDirectionX;
    }
}