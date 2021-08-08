
namespace _8x8x8_LED
{
    partial class FrmImageViewer
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnImageReload = new System.Windows.Forms.Button();
            this.btnUploadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(37, 278);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(512, 64);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 4;
            this.pbImage.TabStop = false;
            // 
            // btnImageReload
            // 
            this.btnImageReload.Location = new System.Drawing.Point(180, 218);
            this.btnImageReload.Name = "btnImageReload";
            this.btnImageReload.Size = new System.Drawing.Size(138, 42);
            this.btnImageReload.TabIndex = 2;
            this.btnImageReload.Text = "&Reload";
            this.btnImageReload.UseVisualStyleBackColor = true;
            this.btnImageReload.Click += new System.EventHandler(this.BtnImageReload_Click);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(36, 218);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(138, 42);
            this.btnUploadImage.TabIndex = 3;
            this.btnUploadImage.Text = "&Upload Image";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.BtnUploadImage_Click);
            // 
            // frmImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnImageReload);
            this.Controls.Add(this.btnUploadImage);
            this.Name = "frmImageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Projection";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnImageReload;
        private System.Windows.Forms.Button btnUploadImage;
    }
}