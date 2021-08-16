
namespace _8x8x8_LED.View
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMarquee));
            this.tmrAnimate = new System.Windows.Forms.Timer(this.components);
            this.txtMarquee = new System.Windows.Forms.TextBox();
            this.chkAnimate = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrAnimate
            // 
            this.tmrAnimate.Tick += new System.EventHandler(this.TmrAnimate_Tick);
            // 
            // txtMarquee
            // 
            this.txtMarquee.Location = new System.Drawing.Point(115, 226);
            this.txtMarquee.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtMarquee.Multiline = true;
            this.txtMarquee.Name = "txtMarquee";
            this.txtMarquee.Size = new System.Drawing.Size(180, 34);
            this.txtMarquee.TabIndex = 0;
            this.txtMarquee.Text = "Hello world!";
            // 
            // chkAnimate
            // 
            this.chkAnimate.AutoSize = true;
            this.chkAnimate.Location = new System.Drawing.Point(97, 285);
            this.chkAnimate.Name = "chkAnimate";
            this.chkAnimate.Size = new System.Drawing.Size(123, 28);
            this.chkAnimate.TabIndex = 1;
            this.chkAnimate.Text = "checkBox1";
            this.chkAnimate.UseVisualStyleBackColor = true;
            this.chkAnimate.CheckedChanged += new System.EventHandler(this.chkAnimate_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(303, 99);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 283);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMarquee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 523);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkAnimate);
            this.Controls.Add(this.txtMarquee);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "FrmMarquee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Marquee";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrAnimate;
        private System.Windows.Forms.TextBox txtMarquee;
        private System.Windows.Forms.CheckBox chkAnimate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}