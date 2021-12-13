
namespace _8x8x8_LED.Views
{
    partial class FrmClock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClock));
            this.chkSyncTime = new System.Windows.Forms.CheckBox();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.chkShowLeadingZeros = new System.Windows.Forms.CheckBox();
            this.chk24HrStyle = new System.Windows.Forms.CheckBox();
            this.chkFlatOneStyle = new System.Windows.Forms.CheckBox();
            this.grpHourColor = new System.Windows.Forms.GroupBox();
            this.cbColorHour = new System.Windows.Forms.ComboBox();
            this.grpMinuteColor = new System.Windows.Forms.GroupBox();
            this.cbColorMinute = new System.Windows.Forms.ComboBox();
            this.grpHourColor.SuspendLayout();
            this.grpMinuteColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSyncTime
            // 
            this.chkSyncTime.AutoSize = true;
            this.chkSyncTime.Location = new System.Drawing.Point(15, 15);
            this.chkSyncTime.Margin = new System.Windows.Forms.Padding(6);
            this.chkSyncTime.Name = "chkSyncTime";
            this.chkSyncTime.Size = new System.Drawing.Size(119, 28);
            this.chkSyncTime.TabIndex = 0;
            this.chkSyncTime.Text = "&Sync Time";
            this.chkSyncTime.UseVisualStyleBackColor = true;
            this.chkSyncTime.CheckedChanged += new System.EventHandler(this.ChkSyncTime_CheckedChanged);
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 60000;
            this.tmrClock.Tick += new System.EventHandler(this.TmrClock_Tick);
            // 
            // chkShowLeadingZeros
            // 
            this.chkShowLeadingZeros.AutoSize = true;
            this.chkShowLeadingZeros.Location = new System.Drawing.Point(15, 52);
            this.chkShowLeadingZeros.Name = "chkShowLeadingZeros";
            this.chkShowLeadingZeros.Size = new System.Drawing.Size(204, 28);
            this.chkShowLeadingZeros.TabIndex = 1;
            this.chkShowLeadingZeros.Text = "Show Leading &Zeros";
            this.chkShowLeadingZeros.UseVisualStyleBackColor = true;
            this.chkShowLeadingZeros.CheckedChanged += new System.EventHandler(this.ChkShowLeadingZeros_CheckedChanged);
            // 
            // chk24HrStyle
            // 
            this.chk24HrStyle.AutoSize = true;
            this.chk24HrStyle.Location = new System.Drawing.Point(15, 86);
            this.chk24HrStyle.Name = "chk24HrStyle";
            this.chk24HrStyle.Size = new System.Drawing.Size(141, 28);
            this.chk24HrStyle.TabIndex = 2;
            this.chk24HrStyle.Text = "&24 Hour Style";
            this.chk24HrStyle.UseVisualStyleBackColor = true;
            this.chk24HrStyle.CheckedChanged += new System.EventHandler(this.Chk24HrStyle_CheckedChanged);
            // 
            // chkFlatOneStyle
            // 
            this.chkFlatOneStyle.AutoSize = true;
            this.chkFlatOneStyle.Location = new System.Drawing.Point(15, 120);
            this.chkFlatOneStyle.Name = "chkFlatOneStyle";
            this.chkFlatOneStyle.Size = new System.Drawing.Size(119, 28);
            this.chkFlatOneStyle.TabIndex = 3;
            this.chkFlatOneStyle.Text = "&Flat 1 Style";
            this.chkFlatOneStyle.UseVisualStyleBackColor = true;
            this.chkFlatOneStyle.CheckedChanged += new System.EventHandler(this.ChkFlatOneStyle_CheckedChanged);
            // 
            // grpHourColor
            // 
            this.grpHourColor.Controls.Add(this.cbColorHour);
            this.grpHourColor.Location = new System.Drawing.Point(12, 154);
            this.grpHourColor.Name = "grpHourColor";
            this.grpHourColor.Size = new System.Drawing.Size(292, 79);
            this.grpHourColor.TabIndex = 4;
            this.grpHourColor.TabStop = false;
            this.grpHourColor.Text = "Hour Color";
            // 
            // cbColorHour
            // 
            this.cbColorHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorHour.FormattingEnabled = true;
            this.cbColorHour.Location = new System.Drawing.Point(6, 28);
            this.cbColorHour.Name = "cbColorHour";
            this.cbColorHour.Size = new System.Drawing.Size(280, 32);
            this.cbColorHour.TabIndex = 5;
            this.cbColorHour.SelectedIndexChanged += new System.EventHandler(this.CbColorHour_SelectedIndexChanged);
            // 
            // grpMinuteColor
            // 
            this.grpMinuteColor.Controls.Add(this.cbColorMinute);
            this.grpMinuteColor.Location = new System.Drawing.Point(12, 239);
            this.grpMinuteColor.Name = "grpMinuteColor";
            this.grpMinuteColor.Size = new System.Drawing.Size(292, 79);
            this.grpMinuteColor.TabIndex = 6;
            this.grpMinuteColor.TabStop = false;
            this.grpMinuteColor.Text = "Minute Color";
            // 
            // cbColorMinute
            // 
            this.cbColorMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorMinute.FormattingEnabled = true;
            this.cbColorMinute.Location = new System.Drawing.Point(6, 28);
            this.cbColorMinute.Name = "cbColorMinute";
            this.cbColorMinute.Size = new System.Drawing.Size(280, 32);
            this.cbColorMinute.TabIndex = 7;
            this.cbColorMinute.SelectedIndexChanged += new System.EventHandler(this.CbColorMinute_SelectedIndexChanged);
            // 
            // FrmClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 327);
            this.Controls.Add(this.grpMinuteColor);
            this.Controls.Add(this.grpHourColor);
            this.Controls.Add(this.chkFlatOneStyle);
            this.Controls.Add(this.chk24HrStyle);
            this.Controls.Add(this.chkShowLeadingZeros);
            this.Controls.Add(this.chkSyncTime);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FrmClock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmClock_FormClosing);
            this.Load += new System.EventHandler(this.FrmClock_Load);
            this.grpHourColor.ResumeLayout(false);
            this.grpMinuteColor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSyncTime;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.CheckBox chkShowLeadingZeros;
        private System.Windows.Forms.CheckBox chk24HrStyle;
        private System.Windows.Forms.CheckBox chkFlatOneStyle;
        private System.Windows.Forms.GroupBox grpHourColor;
        private System.Windows.Forms.ComboBox cbColorHour;
        private System.Windows.Forms.GroupBox grpMinuteColor;
        private System.Windows.Forms.ComboBox cbColorMinute;
    }
}