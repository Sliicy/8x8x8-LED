
namespace _8x8x8_LED.View
{
    partial class PhoneSquare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhoneSquare));
            this.chkAnimate = new System.Windows.Forms.CheckBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblPhoneURL = new System.Windows.Forms.Label();
            this.bwAnimate = new System.ComponentModel.BackgroundWorker();
            this.tmrAnimate = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.LinkLabelURL = new System.Windows.Forms.LinkLabel();
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
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(130, 46);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(403, 29);
            this.txtURL.TabIndex = 2;
            this.txtURL.TextChanged += new System.EventHandler(this.TxtURL_TextChanged);
            // 
            // lblPhoneURL
            // 
            this.lblPhoneURL.AutoSize = true;
            this.lblPhoneURL.Location = new System.Drawing.Point(12, 49);
            this.lblPhoneURL.Name = "lblPhoneURL";
            this.lblPhoneURL.Size = new System.Drawing.Size(112, 24);
            this.lblPhoneURL.TabIndex = 1;
            this.lblPhoneURL.Text = "Phone &URL:";
            // 
            // bwAnimate
            // 
            this.bwAnimate.WorkerSupportsCancellation = true;
            this.bwAnimate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwAnimate_DoWork);
            // 
            // tmrAnimate
            // 
            this.tmrAnimate.Tick += new System.EventHandler(this.TmrAnimate_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(774, 120);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // LinkLabelURL
            // 
            this.LinkLabelURL.AutoSize = true;
            this.LinkLabelURL.Location = new System.Drawing.Point(11, 220);
            this.LinkLabelURL.Name = "LinkLabelURL";
            this.LinkLabelURL.Size = new System.Drawing.Size(732, 24);
            this.LinkLabelURL.TabIndex = 4;
            this.LinkLabelURL.TabStop = true;
            this.LinkLabelURL.Text = "https://play.google.com/store/apps/details?id=com.pas.webcam.pro&hl=en_US&gl=US";
            this.LinkLabelURL.UseMnemonic = false;
            this.LinkLabelURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelURL_LinkClicked);
            // 
            // PhoneSquare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 253);
            this.Controls.Add(this.LinkLabelURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPhoneURL);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.chkAnimate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "PhoneSquare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phone Square";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhoneSquare_FormClosing);
            this.Load += new System.EventHandler(this.PhoneSquare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAnimate;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblPhoneURL;
        private System.ComponentModel.BackgroundWorker bwAnimate;
        private System.Windows.Forms.Timer tmrAnimate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LinkLabelURL;
    }
}