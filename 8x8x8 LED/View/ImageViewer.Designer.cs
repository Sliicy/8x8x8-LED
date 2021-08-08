
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnShiftLeftwards = new System.Windows.Forms.Button();
            this.btnShiftRightwards = new System.Windows.Forms.Button();
            this.btnShiftUpwards = new System.Windows.Forms.Button();
            this.btnShiftDownwards = new System.Windows.Forms.Button();
            this.btnShiftBackwards = new System.Windows.Forms.Button();
            this.btnShiftForwards = new System.Windows.Forms.Button();
            this.btnRotateYCounter = new System.Windows.Forms.Button();
            this.btnRotateXClock = new System.Windows.Forms.Button();
            this.btnRotateYClock = new System.Windows.Forms.Button();
            this.btnRotateZClock = new System.Windows.Forms.Button();
            this.btnRotateZCounter = new System.Windows.Forms.Button();
            this.btnRotateXCounter = new System.Windows.Forms.Button();
            this.btnFlipX = new System.Windows.Forms.Button();
            this.btnFlipY = new System.Windows.Forms.Button();
            this.btnFlipZ = new System.Windows.Forms.Button();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(165, 15);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(138, 42);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(15, 15);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(138, 42);
            this.btnAddImage.TabIndex = 3;
            this.btnAddImage.Text = "&Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // btnShiftLeftwards
            // 
            this.btnShiftLeftwards.Location = new System.Drawing.Point(90, 343);
            this.btnShiftLeftwards.Margin = new System.Windows.Forms.Padding(6);
            this.btnShiftLeftwards.Name = "btnShiftLeftwards";
            this.btnShiftLeftwards.Size = new System.Drawing.Size(200, 42);
            this.btnShiftLeftwards.TabIndex = 4;
            this.btnShiftLeftwards.Text = "Shift Leftwards";
            this.btnShiftLeftwards.UseVisualStyleBackColor = true;
            this.btnShiftLeftwards.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnShiftRightwards
            // 
            this.btnShiftRightwards.Location = new System.Drawing.Point(538, 343);
            this.btnShiftRightwards.Margin = new System.Windows.Forms.Padding(6);
            this.btnShiftRightwards.Name = "btnShiftRightwards";
            this.btnShiftRightwards.Size = new System.Drawing.Size(200, 42);
            this.btnShiftRightwards.TabIndex = 4;
            this.btnShiftRightwards.Text = "Shift Rightwards";
            this.btnShiftRightwards.UseVisualStyleBackColor = true;
            this.btnShiftRightwards.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnShiftUpwards
            // 
            this.btnShiftUpwards.Location = new System.Drawing.Point(306, 238);
            this.btnShiftUpwards.Margin = new System.Windows.Forms.Padding(6);
            this.btnShiftUpwards.Name = "btnShiftUpwards";
            this.btnShiftUpwards.Size = new System.Drawing.Size(200, 42);
            this.btnShiftUpwards.TabIndex = 4;
            this.btnShiftUpwards.Text = "Shift Upwards";
            this.btnShiftUpwards.UseVisualStyleBackColor = true;
            this.btnShiftUpwards.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnShiftDownwards
            // 
            this.btnShiftDownwards.Location = new System.Drawing.Point(306, 454);
            this.btnShiftDownwards.Margin = new System.Windows.Forms.Padding(6);
            this.btnShiftDownwards.Name = "btnShiftDownwards";
            this.btnShiftDownwards.Size = new System.Drawing.Size(200, 42);
            this.btnShiftDownwards.TabIndex = 4;
            this.btnShiftDownwards.Text = "Shift Downwards";
            this.btnShiftDownwards.UseVisualStyleBackColor = true;
            this.btnShiftDownwards.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnShiftBackwards
            // 
            this.btnShiftBackwards.Location = new System.Drawing.Point(310, 314);
            this.btnShiftBackwards.Margin = new System.Windows.Forms.Padding(6);
            this.btnShiftBackwards.Name = "btnShiftBackwards";
            this.btnShiftBackwards.Size = new System.Drawing.Size(200, 42);
            this.btnShiftBackwards.TabIndex = 4;
            this.btnShiftBackwards.Text = "Shift Backwards";
            this.btnShiftBackwards.UseVisualStyleBackColor = true;
            this.btnShiftBackwards.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnShiftForwards
            // 
            this.btnShiftForwards.Location = new System.Drawing.Point(310, 368);
            this.btnShiftForwards.Margin = new System.Windows.Forms.Padding(6);
            this.btnShiftForwards.Name = "btnShiftForwards";
            this.btnShiftForwards.Size = new System.Drawing.Size(200, 42);
            this.btnShiftForwards.TabIndex = 4;
            this.btnShiftForwards.Text = "Shift Forwards";
            this.btnShiftForwards.UseVisualStyleBackColor = true;
            this.btnShiftForwards.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnRotateYCounter
            // 
            this.btnRotateYCounter.Location = new System.Drawing.Point(868, 476);
            this.btnRotateYCounter.Margin = new System.Windows.Forms.Padding(6);
            this.btnRotateYCounter.Name = "btnRotateYCounter";
            this.btnRotateYCounter.Size = new System.Drawing.Size(250, 42);
            this.btnRotateYCounter.TabIndex = 4;
            this.btnRotateYCounter.Text = "Rotate Y Counterclockwise";
            this.btnRotateYCounter.UseVisualStyleBackColor = true;
            this.btnRotateYCounter.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnRotateXClock
            // 
            this.btnRotateXClock.Location = new System.Drawing.Point(868, 314);
            this.btnRotateXClock.Margin = new System.Windows.Forms.Padding(6);
            this.btnRotateXClock.Name = "btnRotateXClock";
            this.btnRotateXClock.Size = new System.Drawing.Size(250, 42);
            this.btnRotateXClock.TabIndex = 4;
            this.btnRotateXClock.Text = "Rotate X Clockwise";
            this.btnRotateXClock.UseVisualStyleBackColor = true;
            this.btnRotateXClock.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnRotateYClock
            // 
            this.btnRotateYClock.Location = new System.Drawing.Point(868, 422);
            this.btnRotateYClock.Margin = new System.Windows.Forms.Padding(6);
            this.btnRotateYClock.Name = "btnRotateYClock";
            this.btnRotateYClock.Size = new System.Drawing.Size(250, 42);
            this.btnRotateYClock.TabIndex = 4;
            this.btnRotateYClock.Text = "Rotate Y Clockwise";
            this.btnRotateYClock.UseVisualStyleBackColor = true;
            this.btnRotateYClock.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnRotateZClock
            // 
            this.btnRotateZClock.Location = new System.Drawing.Point(868, 530);
            this.btnRotateZClock.Margin = new System.Windows.Forms.Padding(6);
            this.btnRotateZClock.Name = "btnRotateZClock";
            this.btnRotateZClock.Size = new System.Drawing.Size(250, 42);
            this.btnRotateZClock.TabIndex = 4;
            this.btnRotateZClock.Text = "Rotate Z Clockwise";
            this.btnRotateZClock.UseVisualStyleBackColor = true;
            this.btnRotateZClock.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnRotateZCounter
            // 
            this.btnRotateZCounter.Location = new System.Drawing.Point(868, 584);
            this.btnRotateZCounter.Margin = new System.Windows.Forms.Padding(6);
            this.btnRotateZCounter.Name = "btnRotateZCounter";
            this.btnRotateZCounter.Size = new System.Drawing.Size(250, 42);
            this.btnRotateZCounter.TabIndex = 4;
            this.btnRotateZCounter.Text = "Rotate Z Counterclockwise";
            this.btnRotateZCounter.UseVisualStyleBackColor = true;
            this.btnRotateZCounter.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnRotateXCounter
            // 
            this.btnRotateXCounter.Location = new System.Drawing.Point(868, 368);
            this.btnRotateXCounter.Margin = new System.Windows.Forms.Padding(6);
            this.btnRotateXCounter.Name = "btnRotateXCounter";
            this.btnRotateXCounter.Size = new System.Drawing.Size(250, 42);
            this.btnRotateXCounter.TabIndex = 4;
            this.btnRotateXCounter.Text = "Rotate X Counterclockwise";
            this.btnRotateXCounter.UseVisualStyleBackColor = true;
            this.btnRotateXCounter.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnFlipX
            // 
            this.btnFlipX.Location = new System.Drawing.Point(868, 66);
            this.btnFlipX.Margin = new System.Windows.Forms.Padding(6);
            this.btnFlipX.Name = "btnFlipX";
            this.btnFlipX.Size = new System.Drawing.Size(200, 42);
            this.btnFlipX.TabIndex = 4;
            this.btnFlipX.Text = "Flip X Axis";
            this.btnFlipX.UseVisualStyleBackColor = true;
            this.btnFlipX.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnFlipY
            // 
            this.btnFlipY.Location = new System.Drawing.Point(868, 120);
            this.btnFlipY.Margin = new System.Windows.Forms.Padding(6);
            this.btnFlipY.Name = "btnFlipY";
            this.btnFlipY.Size = new System.Drawing.Size(200, 42);
            this.btnFlipY.TabIndex = 4;
            this.btnFlipY.Text = "Flip Y Axis";
            this.btnFlipY.UseVisualStyleBackColor = true;
            this.btnFlipY.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnFlipZ
            // 
            this.btnFlipZ.Location = new System.Drawing.Point(868, 174);
            this.btnFlipZ.Margin = new System.Windows.Forms.Padding(6);
            this.btnFlipZ.Name = "btnFlipZ";
            this.btnFlipZ.Size = new System.Drawing.Size(200, 42);
            this.btnFlipZ.TabIndex = 4;
            this.btnFlipZ.Text = "Flip Z Axis";
            this.btnFlipZ.UseVisualStyleBackColor = true;
            this.btnFlipZ.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // chkLoop
            // 
            this.chkLoop.AutoSize = true;
            this.chkLoop.Checked = true;
            this.chkLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoop.Location = new System.Drawing.Point(90, 297);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(72, 28);
            this.chkLoop.TabIndex = 5;
            this.chkLoop.Text = "Loop";
            this.chkLoop.UseVisualStyleBackColor = true;
            // 
            // FrmImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 737);
            this.Controls.Add(this.chkLoop);
            this.Controls.Add(this.btnRotateXCounter);
            this.Controls.Add(this.btnShiftForwards);
            this.Controls.Add(this.btnRotateZCounter);
            this.Controls.Add(this.btnShiftDownwards);
            this.Controls.Add(this.btnRotateZClock);
            this.Controls.Add(this.btnShiftUpwards);
            this.Controls.Add(this.btnRotateYClock);
            this.Controls.Add(this.btnFlipZ);
            this.Controls.Add(this.btnFlipY);
            this.Controls.Add(this.btnFlipX);
            this.Controls.Add(this.btnShiftRightwards);
            this.Controls.Add(this.btnRotateXClock);
            this.Controls.Add(this.btnRotateYCounter);
            this.Controls.Add(this.btnShiftBackwards);
            this.Controls.Add(this.btnShiftLeftwards);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmImageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnShiftLeftwards;
        private System.Windows.Forms.Button btnShiftRightwards;
        private System.Windows.Forms.Button btnShiftUpwards;
        private System.Windows.Forms.Button btnShiftDownwards;
        private System.Windows.Forms.Button btnShiftBackwards;
        private System.Windows.Forms.Button btnShiftForwards;
        private System.Windows.Forms.Button btnRotateYCounter;
        private System.Windows.Forms.Button btnRotateXClock;
        private System.Windows.Forms.Button btnRotateYClock;
        private System.Windows.Forms.Button btnRotateZClock;
        private System.Windows.Forms.Button btnRotateZCounter;
        private System.Windows.Forms.Button btnRotateXCounter;
        private System.Windows.Forms.Button btnFlipX;
        private System.Windows.Forms.Button btnFlipY;
        private System.Windows.Forms.Button btnFlipZ;
        private System.Windows.Forms.CheckBox chkLoop;
    }
}