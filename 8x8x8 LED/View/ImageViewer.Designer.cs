
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
            this.grpShift = new System.Windows.Forms.GroupBox();
            this.grpFlip = new System.Windows.Forms.GroupBox();
            this.grpRotate = new System.Windows.Forms.GroupBox();
            this.pnlMatrix = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHow = new System.Windows.Forms.Label();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.grpShift.SuspendLayout();
            this.grpFlip.SuspendLayout();
            this.grpRotate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(165, 15);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(138, 42);
            this.btnRefresh.TabIndex = 1;
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
            this.btnAddImage.TabIndex = 0;
            this.btnAddImage.Text = "&Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // btnShiftLeftwards
            // 
            this.btnShiftLeftwards.Location = new System.Drawing.Point(11, 102);
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
            this.btnShiftRightwards.Location = new System.Drawing.Point(435, 102);
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
            this.btnShiftUpwards.Location = new System.Drawing.Point(223, 20);
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
            this.btnShiftDownwards.Location = new System.Drawing.Point(223, 182);
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
            this.btnShiftBackwards.Location = new System.Drawing.Point(223, 74);
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
            this.btnShiftForwards.Location = new System.Drawing.Point(223, 128);
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
            this.btnRotateYCounter.Location = new System.Drawing.Point(9, 193);
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
            this.btnRotateXClock.Location = new System.Drawing.Point(9, 31);
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
            this.btnRotateYClock.Location = new System.Drawing.Point(9, 139);
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
            this.btnRotateZClock.Location = new System.Drawing.Point(9, 247);
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
            this.btnRotateZCounter.Location = new System.Drawing.Point(9, 301);
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
            this.btnRotateXCounter.Location = new System.Drawing.Point(9, 85);
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
            this.btnFlipX.Location = new System.Drawing.Point(9, 31);
            this.btnFlipX.Margin = new System.Windows.Forms.Padding(6);
            this.btnFlipX.Name = "btnFlipX";
            this.btnFlipX.Size = new System.Drawing.Size(250, 42);
            this.btnFlipX.TabIndex = 4;
            this.btnFlipX.Text = "Flip &X Axis";
            this.btnFlipX.UseVisualStyleBackColor = true;
            this.btnFlipX.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnFlipY
            // 
            this.btnFlipY.Location = new System.Drawing.Point(9, 85);
            this.btnFlipY.Margin = new System.Windows.Forms.Padding(6);
            this.btnFlipY.Name = "btnFlipY";
            this.btnFlipY.Size = new System.Drawing.Size(250, 42);
            this.btnFlipY.TabIndex = 4;
            this.btnFlipY.Text = "Flip &Y Axis";
            this.btnFlipY.UseVisualStyleBackColor = true;
            this.btnFlipY.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // btnFlipZ
            // 
            this.btnFlipZ.Location = new System.Drawing.Point(9, 139);
            this.btnFlipZ.Margin = new System.Windows.Forms.Padding(6);
            this.btnFlipZ.Name = "btnFlipZ";
            this.btnFlipZ.Size = new System.Drawing.Size(250, 42);
            this.btnFlipZ.TabIndex = 4;
            this.btnFlipZ.Text = "Flip &Z Axis";
            this.btnFlipZ.UseVisualStyleBackColor = true;
            this.btnFlipZ.Click += new System.EventHandler(this.BtnClickOperation_Click);
            // 
            // chkLoop
            // 
            this.chkLoop.AutoSize = true;
            this.chkLoop.Checked = true;
            this.chkLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoop.Location = new System.Drawing.Point(6, 28);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(72, 28);
            this.chkLoop.TabIndex = 5;
            this.chkLoop.Text = "Loop";
            this.chkLoop.UseVisualStyleBackColor = true;
            // 
            // grpShift
            // 
            this.grpShift.Controls.Add(this.btnShiftUpwards);
            this.grpShift.Controls.Add(this.chkLoop);
            this.grpShift.Controls.Add(this.btnShiftLeftwards);
            this.grpShift.Controls.Add(this.btnShiftBackwards);
            this.grpShift.Controls.Add(this.btnShiftForwards);
            this.grpShift.Controls.Add(this.btnShiftRightwards);
            this.grpShift.Controls.Add(this.btnShiftDownwards);
            this.grpShift.Location = new System.Drawing.Point(44, 319);
            this.grpShift.Name = "grpShift";
            this.grpShift.Size = new System.Drawing.Size(649, 250);
            this.grpShift.TabIndex = 6;
            this.grpShift.TabStop = false;
            this.grpShift.Text = "Shift";
            // 
            // grpFlip
            // 
            this.grpFlip.Controls.Add(this.btnFlipX);
            this.grpFlip.Controls.Add(this.btnFlipY);
            this.grpFlip.Controls.Add(this.btnFlipZ);
            this.grpFlip.Location = new System.Drawing.Point(1128, 12);
            this.grpFlip.Name = "grpFlip";
            this.grpFlip.Size = new System.Drawing.Size(267, 196);
            this.grpFlip.TabIndex = 7;
            this.grpFlip.TabStop = false;
            this.grpFlip.Text = "Flip";
            // 
            // grpRotate
            // 
            this.grpRotate.Controls.Add(this.btnRotateXClock);
            this.grpRotate.Controls.Add(this.btnRotateYCounter);
            this.grpRotate.Controls.Add(this.btnRotateYClock);
            this.grpRotate.Controls.Add(this.btnRotateXCounter);
            this.grpRotate.Controls.Add(this.btnRotateZClock);
            this.grpRotate.Controls.Add(this.btnRotateZCounter);
            this.grpRotate.Location = new System.Drawing.Point(1128, 214);
            this.grpRotate.Name = "grpRotate";
            this.grpRotate.Size = new System.Drawing.Size(267, 355);
            this.grpRotate.TabIndex = 8;
            this.grpRotate.TabStop = false;
            this.grpRotate.Text = "Rotate";
            // 
            // pnlMatrix
            // 
            this.pnlMatrix.Location = new System.Drawing.Point(44, 97);
            this.pnlMatrix.Name = "pnlMatrix";
            this.pnlMatrix.Size = new System.Drawing.Size(1024, 128);
            this.pnlMatrix.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(930, 234);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 42);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblHow
            // 
            this.lblHow.AutoSize = true;
            this.lblHow.Location = new System.Drawing.Point(40, 228);
            this.lblHow.Name = "lblHow";
            this.lblHow.Size = new System.Drawing.Size(249, 24);
            this.lblHow.TabIndex = 10;
            this.lblHow.Text = "Control = Draw; Shift = Erase";
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Location = new System.Drawing.Point(868, 288);
            this.btnSaveNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(200, 42);
            this.btnSaveNew.TabIndex = 1;
            this.btnSaveNew.Text = "Save As &New Frame";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.BtnSaveNew_Click);
            // 
            // FrmImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 575);
            this.Controls.Add(this.lblHow);
            this.Controls.Add(this.pnlMatrix);
            this.Controls.Add(this.grpRotate);
            this.Controls.Add(this.grpFlip);
            this.Controls.Add(this.grpShift);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmImageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Viewer";
            this.grpShift.ResumeLayout(false);
            this.grpShift.PerformLayout();
            this.grpFlip.ResumeLayout(false);
            this.grpRotate.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpShift;
        private System.Windows.Forms.GroupBox grpFlip;
        private System.Windows.Forms.GroupBox grpRotate;
        private System.Windows.Forms.Panel pnlMatrix;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHow;
        private System.Windows.Forms.Button btnSaveNew;
    }
}