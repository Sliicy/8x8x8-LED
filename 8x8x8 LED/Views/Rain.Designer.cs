
namespace _8x8x8_LED.Views
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
            this.components = new System.ComponentModel.Container();
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
            this.cbAnimationType = new System.Windows.Forms.ComboBox();
            this.cbBackcolor = new System.Windows.Forms.ComboBox();
            this.grpBackcolor = new System.Windows.Forms.GroupBox();
            this.chkShuffled = new System.Windows.Forms.CheckBox();
            this.tmrColorShuffle = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbRainCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.grpBackcolor.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAnimate
            // 
            this.chkAnimate.AutoSize = true;
            this.chkAnimate.Location = new System.Drawing.Point(15, 15);
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
            this.lblStarCount.Location = new System.Drawing.Point(11, 92);
            this.lblStarCount.Name = "lblStarCount";
            this.lblStarCount.Size = new System.Drawing.Size(108, 24);
            this.lblStarCount.TabIndex = 2;
            this.lblStarCount.Text = "Rain &Count:";
            // 
            // tbRainCount
            // 
            this.tbRainCount.Location = new System.Drawing.Point(129, 92);
            this.tbRainCount.Maximum = 900;
            this.tbRainCount.Minimum = 9;
            this.tbRainCount.Name = "tbRainCount";
            this.tbRainCount.Size = new System.Drawing.Size(480, 45);
            this.tbRainCount.TabIndex = 3;
            this.tbRainCount.Value = 90;
            this.tbRainCount.Scroll += new System.EventHandler(this.Tb_Scroll);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(11, 131);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(71, 24);
            this.lblSpeed.TabIndex = 4;
            this.lblSpeed.Text = "&Speed:";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(129, 131);
            this.tbSpeed.Maximum = 1000;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(480, 45);
            this.tbSpeed.TabIndex = 5;
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
            this.cbDirectionZ.Location = new System.Drawing.Point(129, 270);
            this.cbDirectionZ.Name = "cbDirectionZ";
            this.cbDirectionZ.Size = new System.Drawing.Size(121, 32);
            this.cbDirectionZ.TabIndex = 11;
            this.cbDirectionZ.SelectedIndexChanged += new System.EventHandler(this.CbDirectionZ_SelectedIndexChanged);
            // 
            // lblDirectionZ
            // 
            this.lblDirectionZ.AutoSize = true;
            this.lblDirectionZ.Location = new System.Drawing.Point(8, 273);
            this.lblDirectionZ.Name = "lblDirectionZ";
            this.lblDirectionZ.Size = new System.Drawing.Size(106, 24);
            this.lblDirectionZ.TabIndex = 10;
            this.lblDirectionZ.Text = "Direction &Z:";
            // 
            // lblDirectionY
            // 
            this.lblDirectionY.AutoSize = true;
            this.lblDirectionY.Location = new System.Drawing.Point(8, 230);
            this.lblDirectionY.Name = "lblDirectionY";
            this.lblDirectionY.Size = new System.Drawing.Size(106, 24);
            this.lblDirectionY.TabIndex = 8;
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
            this.cbDirectionY.Location = new System.Drawing.Point(129, 227);
            this.cbDirectionY.Name = "cbDirectionY";
            this.cbDirectionY.Size = new System.Drawing.Size(121, 32);
            this.cbDirectionY.TabIndex = 9;
            this.cbDirectionY.SelectedIndexChanged += new System.EventHandler(this.CbDirectionY_SelectedIndexChanged);
            // 
            // lblDirectionX
            // 
            this.lblDirectionX.AutoSize = true;
            this.lblDirectionX.Location = new System.Drawing.Point(8, 188);
            this.lblDirectionX.Name = "lblDirectionX";
            this.lblDirectionX.Size = new System.Drawing.Size(108, 24);
            this.lblDirectionX.TabIndex = 6;
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
            this.cbDirectionX.Location = new System.Drawing.Point(129, 185);
            this.cbDirectionX.Name = "cbDirectionX";
            this.cbDirectionX.Size = new System.Drawing.Size(121, 32);
            this.cbDirectionX.TabIndex = 7;
            this.cbDirectionX.SelectedIndexChanged += new System.EventHandler(this.CbDirectionX_SelectedIndexChanged);
            // 
            // cbAnimationType
            // 
            this.cbAnimationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimationType.FormattingEnabled = true;
            this.cbAnimationType.Items.AddRange(new object[] {
            "Rain",
            "Rainbow",
            "Matrix"});
            this.cbAnimationType.Location = new System.Drawing.Point(12, 52);
            this.cbAnimationType.Name = "cbAnimationType";
            this.cbAnimationType.Size = new System.Drawing.Size(121, 32);
            this.cbAnimationType.TabIndex = 1;
            this.cbAnimationType.SelectedIndexChanged += new System.EventHandler(this.CbAnimationType_SelectedIndexChanged);
            // 
            // cbBackcolor
            // 
            this.cbBackcolor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackcolor.FormattingEnabled = true;
            this.cbBackcolor.Location = new System.Drawing.Point(6, 62);
            this.cbBackcolor.Name = "cbBackcolor";
            this.cbBackcolor.Size = new System.Drawing.Size(188, 32);
            this.cbBackcolor.TabIndex = 14;
            this.cbBackcolor.SelectedIndexChanged += new System.EventHandler(this.CbBackcolor_SelectedIndexChanged);
            // 
            // grpBackcolor
            // 
            this.grpBackcolor.Controls.Add(this.chkShuffled);
            this.grpBackcolor.Controls.Add(this.cbBackcolor);
            this.grpBackcolor.Location = new System.Drawing.Point(410, 208);
            this.grpBackcolor.Name = "grpBackcolor";
            this.grpBackcolor.Size = new System.Drawing.Size(200, 108);
            this.grpBackcolor.TabIndex = 12;
            this.grpBackcolor.TabStop = false;
            this.grpBackcolor.Text = "&Back Color";
            // 
            // chkShuffled
            // 
            this.chkShuffled.AutoSize = true;
            this.chkShuffled.Location = new System.Drawing.Point(6, 28);
            this.chkShuffled.Name = "chkShuffled";
            this.chkShuffled.Size = new System.Drawing.Size(97, 28);
            this.chkShuffled.TabIndex = 13;
            this.chkShuffled.Text = "Shu&ffled";
            this.chkShuffled.UseVisualStyleBackColor = true;
            this.chkShuffled.CheckedChanged += new System.EventHandler(this.ChkShuffled_CheckedChanged);
            // 
            // tmrColorShuffle
            // 
            this.tmrColorShuffle.Tick += new System.EventHandler(this.TmrColorShuffle_Tick);
            // 
            // FrmRain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 328);
            this.Controls.Add(this.grpBackcolor);
            this.Controls.Add(this.cbAnimationType);
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
            this.grpBackcolor.ResumeLayout(false);
            this.grpBackcolor.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbAnimationType;
        private System.Windows.Forms.ComboBox cbBackcolor;
        private System.Windows.Forms.GroupBox grpBackcolor;
        private System.Windows.Forms.CheckBox chkShuffled;
        private System.Windows.Forms.Timer tmrColorShuffle;
    }
}