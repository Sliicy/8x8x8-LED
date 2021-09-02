
namespace _8x8x8_LED
{
    partial class FrmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainMenu));
            this.lstApps = new System.Windows.Forms.ListBox();
            this.btnShowApp = new System.Windows.Forms.Button();
            this.grpRotation = new System.Windows.Forms.GroupBox();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.chkFlipZ = new System.Windows.Forms.CheckBox();
            this.chkFlipY = new System.Windows.Forms.CheckBox();
            this.chkFlipX = new System.Windows.Forms.CheckBox();
            this.cbRotateZ = new System.Windows.Forms.ComboBox();
            this.cbRotateY = new System.Windows.Forms.ComboBox();
            this.cbRotateX = new System.Windows.Forms.ComboBox();
            this.lblRotateZ = new System.Windows.Forms.Label();
            this.lblRotateY = new System.Windows.Forms.Label();
            this.lblRotateX = new System.Windows.Forms.Label();
            this.grpSendPacket = new System.Windows.Forms.GroupBox();
            this.btnInvertPacket = new System.Windows.Forms.Button();
            this.btnSendPacket = new System.Windows.Forms.Button();
            this.txtBytesToSend = new System.Windows.Forms.TextBox();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.chkAutoconnect = new System.Windows.Forms.CheckBox();
            this.nudDataBits = new System.Windows.Forms.NumericUpDown();
            this.lblParity = new System.Windows.Forms.Label();
            this.lblStopbits = new System.Windows.Forms.Label();
            this.lblDatabits = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblComPort = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpRotation.SuspendLayout();
            this.grpSendPacket.SuspendLayout();
            this.grpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDataBits)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstApps
            // 
            this.lstApps.FormattingEnabled = true;
            this.lstApps.ItemHeight = 24;
            this.lstApps.Location = new System.Drawing.Point(307, 33);
            this.lstApps.Name = "lstApps";
            this.lstApps.Size = new System.Drawing.Size(300, 292);
            this.lstApps.TabIndex = 1;
            // 
            // btnShowApp
            // 
            this.btnShowApp.Location = new System.Drawing.Point(307, 338);
            this.btnShowApp.Name = "btnShowApp";
            this.btnShowApp.Size = new System.Drawing.Size(300, 42);
            this.btnShowApp.TabIndex = 2;
            this.btnShowApp.Text = "&Open";
            this.btnShowApp.UseVisualStyleBackColor = true;
            this.btnShowApp.Click += new System.EventHandler(this.BtnShowApp_Click);
            // 
            // grpRotation
            // 
            this.grpRotation.Controls.Add(this.btnCalibrate);
            this.grpRotation.Controls.Add(this.chkFlipZ);
            this.grpRotation.Controls.Add(this.chkFlipY);
            this.grpRotation.Controls.Add(this.chkFlipX);
            this.grpRotation.Controls.Add(this.cbRotateZ);
            this.grpRotation.Controls.Add(this.cbRotateY);
            this.grpRotation.Controls.Add(this.cbRotateX);
            this.grpRotation.Controls.Add(this.lblRotateZ);
            this.grpRotation.Controls.Add(this.lblRotateY);
            this.grpRotation.Controls.Add(this.lblRotateX);
            this.grpRotation.Location = new System.Drawing.Point(621, 9);
            this.grpRotation.Name = "grpRotation";
            this.grpRotation.Size = new System.Drawing.Size(287, 356);
            this.grpRotation.TabIndex = 18;
            this.grpRotation.TabStop = false;
            this.grpRotation.Text = "Rotation";
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(23, 55);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(222, 42);
            this.btnCalibrate.TabIndex = 19;
            this.btnCalibrate.Text = "Calibrate Cube";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.BtnCalibrate_Click);
            // 
            // chkFlipZ
            // 
            this.chkFlipZ.AutoSize = true;
            this.chkFlipZ.Location = new System.Drawing.Point(21, 303);
            this.chkFlipZ.Name = "chkFlipZ";
            this.chkFlipZ.Size = new System.Drawing.Size(77, 28);
            this.chkFlipZ.TabIndex = 28;
            this.chkFlipZ.Text = "Flip &Z";
            this.chkFlipZ.UseVisualStyleBackColor = true;
            this.chkFlipZ.CheckedChanged += new System.EventHandler(this.ChkFlipZ_CheckedChanged);
            // 
            // chkFlipY
            // 
            this.chkFlipY.AutoSize = true;
            this.chkFlipY.Location = new System.Drawing.Point(23, 269);
            this.chkFlipY.Name = "chkFlipY";
            this.chkFlipY.Size = new System.Drawing.Size(77, 28);
            this.chkFlipY.TabIndex = 27;
            this.chkFlipY.Text = "Flip &Y";
            this.chkFlipY.UseVisualStyleBackColor = true;
            this.chkFlipY.CheckedChanged += new System.EventHandler(this.ChkFlipY_CheckedChanged);
            // 
            // chkFlipX
            // 
            this.chkFlipX.AutoSize = true;
            this.chkFlipX.Location = new System.Drawing.Point(23, 235);
            this.chkFlipX.Name = "chkFlipX";
            this.chkFlipX.Size = new System.Drawing.Size(79, 28);
            this.chkFlipX.TabIndex = 26;
            this.chkFlipX.Text = "Flip &X";
            this.chkFlipX.UseVisualStyleBackColor = true;
            this.chkFlipX.CheckedChanged += new System.EventHandler(this.ChkFlipX_CheckedChanged);
            // 
            // cbRotateZ
            // 
            this.cbRotateZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRotateZ.FormattingEnabled = true;
            this.cbRotateZ.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.cbRotateZ.Location = new System.Drawing.Point(124, 181);
            this.cbRotateZ.Name = "cbRotateZ";
            this.cbRotateZ.Size = new System.Drawing.Size(121, 32);
            this.cbRotateZ.TabIndex = 25;
            this.cbRotateZ.SelectedIndexChanged += new System.EventHandler(this.CbRotateZ_SelectedIndexChanged);
            // 
            // cbRotateY
            // 
            this.cbRotateY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRotateY.FormattingEnabled = true;
            this.cbRotateY.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.cbRotateY.Location = new System.Drawing.Point(124, 143);
            this.cbRotateY.Name = "cbRotateY";
            this.cbRotateY.Size = new System.Drawing.Size(121, 32);
            this.cbRotateY.TabIndex = 23;
            this.cbRotateY.SelectedIndexChanged += new System.EventHandler(this.CbRotateY_SelectedIndexChanged);
            // 
            // cbRotateX
            // 
            this.cbRotateX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRotateX.FormattingEnabled = true;
            this.cbRotateX.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.cbRotateX.Location = new System.Drawing.Point(124, 105);
            this.cbRotateX.Name = "cbRotateX";
            this.cbRotateX.Size = new System.Drawing.Size(121, 32);
            this.cbRotateX.TabIndex = 21;
            this.cbRotateX.SelectedIndexChanged += new System.EventHandler(this.CbRotateX_SelectedIndexChanged);
            // 
            // lblRotateZ
            // 
            this.lblRotateZ.AutoSize = true;
            this.lblRotateZ.Location = new System.Drawing.Point(21, 184);
            this.lblRotateZ.Name = "lblRotateZ";
            this.lblRotateZ.Size = new System.Drawing.Size(85, 24);
            this.lblRotateZ.TabIndex = 24;
            this.lblRotateZ.Text = "&Rotate Z:";
            // 
            // lblRotateY
            // 
            this.lblRotateY.AutoSize = true;
            this.lblRotateY.Location = new System.Drawing.Point(19, 146);
            this.lblRotateY.Name = "lblRotateY";
            this.lblRotateY.Size = new System.Drawing.Size(85, 24);
            this.lblRotateY.TabIndex = 22;
            this.lblRotateY.Text = "&Rotate Y:";
            // 
            // lblRotateX
            // 
            this.lblRotateX.AutoSize = true;
            this.lblRotateX.Location = new System.Drawing.Point(19, 111);
            this.lblRotateX.Name = "lblRotateX";
            this.lblRotateX.Size = new System.Drawing.Size(87, 24);
            this.lblRotateX.TabIndex = 20;
            this.lblRotateX.Text = "&Rotate X:";
            // 
            // grpSendPacket
            // 
            this.grpSendPacket.Controls.Add(this.btnInvertPacket);
            this.grpSendPacket.Controls.Add(this.btnSendPacket);
            this.grpSendPacket.Controls.Add(this.txtBytesToSend);
            this.grpSendPacket.Location = new System.Drawing.Point(270, 9);
            this.grpSendPacket.Margin = new System.Windows.Forms.Padding(6);
            this.grpSendPacket.Name = "grpSendPacket";
            this.grpSendPacket.Padding = new System.Windows.Forms.Padding(6);
            this.grpSendPacket.Size = new System.Drawing.Size(342, 356);
            this.grpSendPacket.TabIndex = 14;
            this.grpSendPacket.TabStop = false;
            this.grpSendPacket.Text = "Send Packet";
            // 
            // btnInvertPacket
            // 
            this.btnInvertPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvertPacket.Location = new System.Drawing.Point(192, 302);
            this.btnInvertPacket.Margin = new System.Windows.Forms.Padding(6);
            this.btnInvertPacket.Name = "btnInvertPacket";
            this.btnInvertPacket.Size = new System.Drawing.Size(138, 42);
            this.btnInvertPacket.TabIndex = 17;
            this.btnInvertPacket.Text = "&Invert";
            this.btnInvertPacket.UseVisualStyleBackColor = true;
            this.btnInvertPacket.Click += new System.EventHandler(this.BtnInvertPacket_Click);
            // 
            // btnSendPacket
            // 
            this.btnSendPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendPacket.Location = new System.Drawing.Point(12, 302);
            this.btnSendPacket.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendPacket.Name = "btnSendPacket";
            this.btnSendPacket.Size = new System.Drawing.Size(138, 42);
            this.btnSendPacket.TabIndex = 16;
            this.btnSendPacket.Text = "S&end";
            this.btnSendPacket.UseVisualStyleBackColor = true;
            this.btnSendPacket.Click += new System.EventHandler(this.BtnSendPacket_Click);
            // 
            // txtBytesToSend
            // 
            this.txtBytesToSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBytesToSend.Location = new System.Drawing.Point(11, 50);
            this.txtBytesToSend.Margin = new System.Windows.Forms.Padding(6);
            this.txtBytesToSend.Multiline = true;
            this.txtBytesToSend.Name = "txtBytesToSend";
            this.txtBytesToSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBytesToSend.Size = new System.Drawing.Size(316, 240);
            this.txtBytesToSend.TabIndex = 15;
            this.txtBytesToSend.Text = resources.GetString("txtBytesToSend.Text");
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.chkAutoconnect);
            this.grpConnection.Controls.Add(this.nudDataBits);
            this.grpConnection.Controls.Add(this.lblParity);
            this.grpConnection.Controls.Add(this.lblStopbits);
            this.grpConnection.Controls.Add(this.lblDatabits);
            this.grpConnection.Controls.Add(this.lblBaudRate);
            this.grpConnection.Controls.Add(this.lblComPort);
            this.grpConnection.Controls.Add(this.cbBaudRate);
            this.grpConnection.Controls.Add(this.cbParity);
            this.grpConnection.Controls.Add(this.cbStopBits);
            this.grpConnection.Controls.Add(this.cbComPort);
            this.grpConnection.Location = new System.Drawing.Point(9, 9);
            this.grpConnection.Margin = new System.Windows.Forms.Padding(6);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(6);
            this.grpConnection.Size = new System.Drawing.Size(249, 356);
            this.grpConnection.TabIndex = 1;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(311, 470);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(300, 42);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "Co&nnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // chkAutoconnect
            // 
            this.chkAutoconnect.AutoSize = true;
            this.chkAutoconnect.Location = new System.Drawing.Point(65, 315);
            this.chkAutoconnect.Margin = new System.Windows.Forms.Padding(6);
            this.chkAutoconnect.Name = "chkAutoconnect";
            this.chkAutoconnect.Size = new System.Drawing.Size(136, 28);
            this.chkAutoconnect.TabIndex = 12;
            this.chkAutoconnect.Text = "&Autoconnect";
            this.chkAutoconnect.UseVisualStyleBackColor = true;
            this.chkAutoconnect.CheckedChanged += new System.EventHandler(this.ChkAutoconnect_CheckedChanged);
            // 
            // nudDataBits
            // 
            this.nudDataBits.Location = new System.Drawing.Point(125, 162);
            this.nudDataBits.Margin = new System.Windows.Forms.Padding(6);
            this.nudDataBits.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudDataBits.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDataBits.Name = "nudDataBits";
            this.nudDataBits.Size = new System.Drawing.Size(110, 29);
            this.nudDataBits.TabIndex = 7;
            this.nudDataBits.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudDataBits.ValueChanged += new System.EventHandler(this.NudDataBits_ValueChanged);
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(11, 277);
            this.lblParity.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(60, 24);
            this.lblParity.TabIndex = 10;
            this.lblParity.Text = "&Parity:";
            // 
            // lblStopbits
            // 
            this.lblStopbits.AutoSize = true;
            this.lblStopbits.Location = new System.Drawing.Point(11, 222);
            this.lblStopbits.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStopbits.Name = "lblStopbits";
            this.lblStopbits.Size = new System.Drawing.Size(87, 24);
            this.lblStopbits.TabIndex = 8;
            this.lblStopbits.Text = "&Stop Bits:";
            // 
            // lblDatabits
            // 
            this.lblDatabits.AutoSize = true;
            this.lblDatabits.Location = new System.Drawing.Point(11, 166);
            this.lblDatabits.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDatabits.Name = "lblDatabits";
            this.lblDatabits.Size = new System.Drawing.Size(86, 24);
            this.lblDatabits.TabIndex = 6;
            this.lblDatabits.Text = "&Data Bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(11, 111);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(102, 24);
            this.lblBaudRate.TabIndex = 4;
            this.lblBaudRate.Text = "&Baud Rate:";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(11, 55);
            this.lblComPort.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(97, 24);
            this.lblComPort.TabIndex = 2;
            this.lblComPort.Text = "&COM Port:";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(125, 105);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(6);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(107, 32);
            this.cbBaudRate.TabIndex = 5;
            this.cbBaudRate.SelectedIndexChanged += new System.EventHandler(this.CbBaudRate_SelectedIndexChanged);
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cbParity.Location = new System.Drawing.Point(125, 271);
            this.cbParity.Margin = new System.Windows.Forms.Padding(6);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(107, 32);
            this.cbParity.TabIndex = 11;
            this.cbParity.SelectedIndexChanged += new System.EventHandler(this.CbParity_SelectedIndexChanged);
            // 
            // cbStopBits
            // 
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.cbStopBits.Location = new System.Drawing.Point(125, 216);
            this.cbStopBits.Margin = new System.Windows.Forms.Padding(6);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(107, 32);
            this.cbStopBits.TabIndex = 9;
            this.cbStopBits.SelectedIndexChanged += new System.EventHandler(this.CbStopBits_SelectedIndexChanged);
            // 
            // cbComPort
            // 
            this.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Location = new System.Drawing.Point(125, 50);
            this.cbComPort.Margin = new System.Windows.Forms.Padding(6);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(107, 32);
            this.cbComPort.TabIndex = 3;
            this.cbComPort.Click += new System.EventHandler(this.CbComPort_Click);
            this.cbComPort.Enter += new System.EventHandler(this.CbComPort_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(923, 465);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstApps);
            this.tabPage1.Controls.Add(this.btnShowApp);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(915, 428);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Menu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.grpConnection);
            this.tabPage2.Controls.Add(this.grpRotation);
            this.tabPage2.Controls.Add(this.grpSendPacket);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(915, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(9, 377);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(246, 42);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "&Reset all Settings";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // FrmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 522);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FrmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "8x8x8 LED";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.grpRotation.ResumeLayout(false);
            this.grpRotation.PerformLayout();
            this.grpSendPacket.ResumeLayout(false);
            this.grpSendPacket.PerformLayout();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDataBits)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.NumericUpDown nudDataBits;
        private System.Windows.Forms.Label lblDatabits;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox chkAutoconnect;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.Label lblStopbits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.GroupBox grpSendPacket;
        private System.Windows.Forms.Button btnSendPacket;
        private System.Windows.Forms.TextBox txtBytesToSend;
        private System.Windows.Forms.Button btnInvertPacket;
        private System.Windows.Forms.GroupBox grpRotation;
        private System.Windows.Forms.CheckBox chkFlipZ;
        private System.Windows.Forms.CheckBox chkFlipY;
        private System.Windows.Forms.CheckBox chkFlipX;
        private System.Windows.Forms.ComboBox cbRotateZ;
        private System.Windows.Forms.ComboBox cbRotateY;
        private System.Windows.Forms.ComboBox cbRotateX;
        private System.Windows.Forms.Label lblRotateZ;
        private System.Windows.Forms.Label lblRotateY;
        private System.Windows.Forms.Label lblRotateX;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Button btnShowApp;
        private System.Windows.Forms.ListBox lstApps;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnReset;
    }
}

