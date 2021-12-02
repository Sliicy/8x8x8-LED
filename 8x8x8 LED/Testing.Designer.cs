namespace _8x8x8_LED
{
    partial class Testing
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
            this.btnRed = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnCyan = new System.Windows.Forms.Button();
            this.btnMagenta = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSunset = new System.Windows.Forms.Button();
            this.btnSmileyFace = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.nudZ = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnMock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRed
            // 
            this.btnRed.Location = new System.Drawing.Point(177, 15);
            this.btnRed.Margin = new System.Windows.Forms.Padding(6);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(150, 44);
            this.btnRed.TabIndex = 0;
            this.btnRed.Text = "Red";
            this.btnRed.UseVisualStyleBackColor = true;
            this.btnRed.Click += new System.EventHandler(this.BtnRed_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(15, 15);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 44);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(15, 291);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(6);
            this.trackBar1.Maximum = 5000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(636, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(27, 253);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 29);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Animate";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnGreen
            // 
            this.btnGreen.Location = new System.Drawing.Point(339, 15);
            this.btnGreen.Margin = new System.Windows.Forms.Padding(6);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(150, 44);
            this.btnGreen.TabIndex = 0;
            this.btnGreen.Text = "Green";
            this.btnGreen.UseVisualStyleBackColor = true;
            this.btnGreen.Click += new System.EventHandler(this.BtnGreen_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.Location = new System.Drawing.Point(501, 15);
            this.btnBlue.Margin = new System.Windows.Forms.Padding(6);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(150, 44);
            this.btnBlue.TabIndex = 0;
            this.btnBlue.Text = "Blue";
            this.btnBlue.UseVisualStyleBackColor = true;
            this.btnBlue.Click += new System.EventHandler(this.BtnBlue_Click);
            // 
            // nudDepth
            // 
            this.nudDepth.Location = new System.Drawing.Point(103, 162);
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(120, 31);
            this.nudDepth.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Depth:";
            // 
            // btnYellow
            // 
            this.btnYellow.Location = new System.Drawing.Point(177, 71);
            this.btnYellow.Margin = new System.Windows.Forms.Padding(6);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(150, 44);
            this.btnYellow.TabIndex = 0;
            this.btnYellow.Text = "Yellow";
            this.btnYellow.UseVisualStyleBackColor = true;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnCyan
            // 
            this.btnCyan.Location = new System.Drawing.Point(339, 71);
            this.btnCyan.Margin = new System.Windows.Forms.Padding(6);
            this.btnCyan.Name = "btnCyan";
            this.btnCyan.Size = new System.Drawing.Size(150, 44);
            this.btnCyan.TabIndex = 0;
            this.btnCyan.Text = "Cyan";
            this.btnCyan.UseVisualStyleBackColor = true;
            this.btnCyan.Click += new System.EventHandler(this.btnCyan_Click);
            // 
            // btnMagenta
            // 
            this.btnMagenta.Location = new System.Drawing.Point(501, 71);
            this.btnMagenta.Margin = new System.Windows.Forms.Padding(6);
            this.btnMagenta.Name = "btnMagenta";
            this.btnMagenta.Size = new System.Drawing.Size(150, 44);
            this.btnMagenta.TabIndex = 0;
            this.btnMagenta.Text = "Magenta";
            this.btnMagenta.UseVisualStyleBackColor = true;
            this.btnMagenta.Click += new System.EventHandler(this.btnMagenta_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.Location = new System.Drawing.Point(15, 71);
            this.btnWhite.Margin = new System.Windows.Forms.Padding(6);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(150, 44);
            this.btnWhite.TabIndex = 0;
            this.btnWhite.Text = "White";
            this.btnWhite.UseVisualStyleBackColor = true;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(257, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "0";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(413, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 44);
            this.button2.TabIndex = 6;
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSunset
            // 
            this.btnSunset.Location = new System.Drawing.Point(501, 365);
            this.btnSunset.Name = "btnSunset";
            this.btnSunset.Size = new System.Drawing.Size(150, 44);
            this.btnSunset.TabIndex = 6;
            this.btnSunset.Text = "Sunset";
            this.btnSunset.UseVisualStyleBackColor = true;
            this.btnSunset.Click += new System.EventHandler(this.BtnSunset_Click);
            // 
            // btnSmileyFace
            // 
            this.btnSmileyFace.Location = new System.Drawing.Point(501, 415);
            this.btnSmileyFace.Name = "btnSmileyFace";
            this.btnSmileyFace.Size = new System.Drawing.Size(150, 44);
            this.btnSmileyFace.TabIndex = 6;
            this.btnSmileyFace.Text = "Smiley Face";
            this.btnSmileyFace.UseVisualStyleBackColor = true;
            this.btnSmileyFace.Click += new System.EventHandler(this.btnSmileyFace_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(27, 345);
            this.trackBar2.Maximum = 7;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(104, 45);
            this.trackBar2.TabIndex = 7;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(27, 406);
            this.trackBar3.Maximum = 7;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(104, 45);
            this.trackBar3.TabIndex = 7;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Z-Axis:";
            // 
            // nudZ
            // 
            this.nudZ.Location = new System.Drawing.Point(103, 202);
            this.nudZ.Name = "nudZ";
            this.nudZ.Size = new System.Drawing.Size(120, 31);
            this.nudZ.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(257, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 44);
            this.button3.TabIndex = 6;
            this.button3.Text = "0";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(333, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 44);
            this.button4.TabIndex = 6;
            this.button4.Text = "2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(413, 204);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 44);
            this.button5.TabIndex = 6;
            this.button5.Text = "4";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(493, 204);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 44);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnMock
            // 
            this.btnMock.Location = new System.Drawing.Point(373, 484);
            this.btnMock.Name = "btnMock";
            this.btnMock.Size = new System.Drawing.Size(143, 55);
            this.btnMock.TabIndex = 8;
            this.btnMock.Text = "Mock";
            this.btnMock.UseVisualStyleBackColor = true;
            this.btnMock.Click += new System.EventHandler(this.btnMock_Click);
            // 
            // Testing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 600);
            this.Controls.Add(this.btnMock);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.btnSmileyFace);
            this.Controls.Add(this.btnSunset);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudZ);
            this.Controls.Add(this.nudDepth);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnWhite);
            this.Controls.Add(this.btnMagenta);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnCyan);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnRed);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Testing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testing";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.NumericUpDown nudDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnCyan;
        private System.Windows.Forms.Button btnMagenta;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSunset;
        private System.Windows.Forms.Button btnSmileyFace;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudZ;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnMock;
    }
}