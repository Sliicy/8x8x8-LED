﻿
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.grpGeometry = new System.Windows.Forms.GroupBox();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.lblOffsetZ = new System.Windows.Forms.Label();
            this.lblOffsetY = new System.Windows.Forms.Label();
            this.lblOffsetX = new System.Windows.Forms.Label();
            this.nudOffsetZ = new System.Windows.Forms.NumericUpDown();
            this.nudOffsetY = new System.Windows.Forms.NumericUpDown();
            this.nudOffsetX = new System.Windows.Forms.NumericUpDown();
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
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnSendPacket = new System.Windows.Forms.Button();
            this.txtBytesToSend = new System.Windows.Forms.TextBox();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.chkBlinkOnConnect = new System.Windows.Forms.CheckBox();
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpMenu = new System.Windows.Forms.TabPage();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.grpCubeSize = new System.Windows.Forms.GroupBox();
            this.nudCubeSize = new System.Windows.Forms.NumericUpDown();
            this.grpSendColor = new System.Windows.Forms.GroupBox();
            this.cbSendColor = new System.Windows.Forms.ComboBox();
            this.grpCubeType = new System.Windows.Forms.GroupBox();
            this.cbCubeType = new System.Windows.Forms.ComboBox();
            this.btnWebsite = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpGeometry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).BeginInit();
            this.grpSendPacket.SuspendLayout();
            this.grpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDataBits)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpMenu.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.grpCubeSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCubeSize)).BeginInit();
            this.grpSendColor.SuspendLayout();
            this.grpCubeType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstApps
            // 
            this.lstApps.FormattingEnabled = true;
            this.lstApps.ItemHeight = 24;
            this.lstApps.Location = new System.Drawing.Point(8, 6);
            this.lstApps.Name = "lstApps";
            this.lstApps.Size = new System.Drawing.Size(507, 772);
            this.lstApps.Sorted = true;
            this.lstApps.TabIndex = 1;
            this.lstApps.SelectedIndexChanged += new System.EventHandler(this.LstApps_SelectedIndexChanged);
            this.lstApps.DoubleClick += new System.EventHandler(this.LstApps_DoubleClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(112, 786);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(300, 42);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // grpGeometry
            // 
            this.grpGeometry.Controls.Add(this.chkInvert);
            this.grpGeometry.Controls.Add(this.lblOffsetZ);
            this.grpGeometry.Controls.Add(this.lblOffsetY);
            this.grpGeometry.Controls.Add(this.lblOffsetX);
            this.grpGeometry.Controls.Add(this.nudOffsetZ);
            this.grpGeometry.Controls.Add(this.nudOffsetY);
            this.grpGeometry.Controls.Add(this.nudOffsetX);
            this.grpGeometry.Controls.Add(this.btnCalibrate);
            this.grpGeometry.Controls.Add(this.chkFlipZ);
            this.grpGeometry.Controls.Add(this.chkFlipY);
            this.grpGeometry.Controls.Add(this.chkFlipX);
            this.grpGeometry.Controls.Add(this.cbRotateZ);
            this.grpGeometry.Controls.Add(this.cbRotateY);
            this.grpGeometry.Controls.Add(this.cbRotateX);
            this.grpGeometry.Controls.Add(this.lblRotateZ);
            this.grpGeometry.Controls.Add(this.lblRotateY);
            this.grpGeometry.Controls.Add(this.lblRotateX);
            this.grpGeometry.Location = new System.Drawing.Point(265, 178);
            this.grpGeometry.Name = "grpGeometry";
            this.grpGeometry.Size = new System.Drawing.Size(250, 356);
            this.grpGeometry.TabIndex = 18;
            this.grpGeometry.TabStop = false;
            this.grpGeometry.Text = "Geometry";
            // 
            // chkInvert
            // 
            this.chkInvert.AutoSize = true;
            this.chkInvert.Location = new System.Drawing.Point(16, 322);
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.Size = new System.Drawing.Size(133, 28);
            this.chkInvert.TabIndex = 35;
            this.chkInvert.Text = "&Invert Colors";
            this.chkInvert.UseVisualStyleBackColor = true;
            this.chkInvert.CheckedChanged += new System.EventHandler(this.ChkInvert_CheckedChanged);
            // 
            // lblOffsetZ
            // 
            this.lblOffsetZ.AutoSize = true;
            this.lblOffsetZ.Location = new System.Drawing.Point(113, 290);
            this.lblOffsetZ.Name = "lblOffsetZ";
            this.lblOffsetZ.Size = new System.Drawing.Size(79, 24);
            this.lblOffsetZ.TabIndex = 33;
            this.lblOffsetZ.Text = "&Offset Z:";
            // 
            // lblOffsetY
            // 
            this.lblOffsetY.AutoSize = true;
            this.lblOffsetY.Location = new System.Drawing.Point(113, 256);
            this.lblOffsetY.Name = "lblOffsetY";
            this.lblOffsetY.Size = new System.Drawing.Size(79, 24);
            this.lblOffsetY.TabIndex = 30;
            this.lblOffsetY.Text = "&Offset Y:";
            // 
            // lblOffsetX
            // 
            this.lblOffsetX.AutoSize = true;
            this.lblOffsetX.Location = new System.Drawing.Point(113, 222);
            this.lblOffsetX.Name = "lblOffsetX";
            this.lblOffsetX.Size = new System.Drawing.Size(81, 24);
            this.lblOffsetX.TabIndex = 27;
            this.lblOffsetX.Text = "&Offset X:";
            // 
            // nudOffsetZ
            // 
            this.nudOffsetZ.Location = new System.Drawing.Point(200, 288);
            this.nudOffsetZ.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudOffsetZ.Name = "nudOffsetZ";
            this.nudOffsetZ.Size = new System.Drawing.Size(38, 29);
            this.nudOffsetZ.TabIndex = 34;
            this.nudOffsetZ.ValueChanged += new System.EventHandler(this.NudOffsetZ_ValueChanged);
            // 
            // nudOffsetY
            // 
            this.nudOffsetY.Location = new System.Drawing.Point(200, 254);
            this.nudOffsetY.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudOffsetY.Name = "nudOffsetY";
            this.nudOffsetY.Size = new System.Drawing.Size(38, 29);
            this.nudOffsetY.TabIndex = 31;
            this.nudOffsetY.ValueChanged += new System.EventHandler(this.NudOffsetY_ValueChanged);
            // 
            // nudOffsetX
            // 
            this.nudOffsetX.Location = new System.Drawing.Point(200, 220);
            this.nudOffsetX.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudOffsetX.Name = "nudOffsetX";
            this.nudOffsetX.Size = new System.Drawing.Size(38, 29);
            this.nudOffsetX.TabIndex = 28;
            this.nudOffsetX.ValueChanged += new System.EventHandler(this.NudOffsetX_ValueChanged);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(16, 50);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(222, 42);
            this.btnCalibrate.TabIndex = 19;
            this.btnCalibrate.Text = "Calibration";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.BtnCalibrate_Click);
            // 
            // chkFlipZ
            // 
            this.chkFlipZ.AutoSize = true;
            this.chkFlipZ.Location = new System.Drawing.Point(16, 289);
            this.chkFlipZ.Name = "chkFlipZ";
            this.chkFlipZ.Size = new System.Drawing.Size(77, 28);
            this.chkFlipZ.TabIndex = 32;
            this.chkFlipZ.Text = "Flip &Z";
            this.chkFlipZ.UseVisualStyleBackColor = true;
            this.chkFlipZ.CheckedChanged += new System.EventHandler(this.ChkFlipZ_CheckedChanged);
            // 
            // chkFlipY
            // 
            this.chkFlipY.AutoSize = true;
            this.chkFlipY.Location = new System.Drawing.Point(16, 255);
            this.chkFlipY.Name = "chkFlipY";
            this.chkFlipY.Size = new System.Drawing.Size(77, 28);
            this.chkFlipY.TabIndex = 29;
            this.chkFlipY.Text = "Flip &Y";
            this.chkFlipY.UseVisualStyleBackColor = true;
            this.chkFlipY.CheckedChanged += new System.EventHandler(this.ChkFlipY_CheckedChanged);
            // 
            // chkFlipX
            // 
            this.chkFlipX.AutoSize = true;
            this.chkFlipX.Location = new System.Drawing.Point(16, 221);
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
            this.cbRotateZ.Location = new System.Drawing.Point(117, 179);
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
            this.cbRotateY.Location = new System.Drawing.Point(117, 141);
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
            this.cbRotateX.Location = new System.Drawing.Point(117, 103);
            this.cbRotateX.Name = "cbRotateX";
            this.cbRotateX.Size = new System.Drawing.Size(121, 32);
            this.cbRotateX.TabIndex = 21;
            this.cbRotateX.SelectedIndexChanged += new System.EventHandler(this.CbRotateX_SelectedIndexChanged);
            // 
            // lblRotateZ
            // 
            this.lblRotateZ.AutoSize = true;
            this.lblRotateZ.Location = new System.Drawing.Point(12, 182);
            this.lblRotateZ.Name = "lblRotateZ";
            this.lblRotateZ.Size = new System.Drawing.Size(85, 24);
            this.lblRotateZ.TabIndex = 24;
            this.lblRotateZ.Text = "&Rotate Z:";
            // 
            // lblRotateY
            // 
            this.lblRotateY.AutoSize = true;
            this.lblRotateY.Location = new System.Drawing.Point(12, 144);
            this.lblRotateY.Name = "lblRotateY";
            this.lblRotateY.Size = new System.Drawing.Size(85, 24);
            this.lblRotateY.TabIndex = 22;
            this.lblRotateY.Text = "&Rotate Y:";
            // 
            // lblRotateX
            // 
            this.lblRotateX.AutoSize = true;
            this.lblRotateX.Location = new System.Drawing.Point(12, 106);
            this.lblRotateX.Name = "lblRotateX";
            this.lblRotateX.Size = new System.Drawing.Size(87, 24);
            this.lblRotateX.TabIndex = 20;
            this.lblRotateX.Text = "&Rotate X:";
            // 
            // grpSendPacket
            // 
            this.grpSendPacket.Controls.Add(this.lblVersion);
            this.grpSendPacket.Controls.Add(this.btnSendPacket);
            this.grpSendPacket.Controls.Add(this.txtBytesToSend);
            this.grpSendPacket.Location = new System.Drawing.Point(6, 546);
            this.grpSendPacket.Margin = new System.Windows.Forms.Padding(6);
            this.grpSendPacket.Name = "grpSendPacket";
            this.grpSendPacket.Padding = new System.Windows.Forms.Padding(6);
            this.grpSendPacket.Size = new System.Drawing.Size(509, 225);
            this.grpSendPacket.TabIndex = 36;
            this.grpSendPacket.TabStop = false;
            this.grpSendPacket.Text = "Send Packet";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(387, 180);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(110, 24);
            this.lblVersion.TabIndex = 39;
            this.lblVersion.Text = "Version: 2.3";
            // 
            // btnSendPacket
            // 
            this.btnSendPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendPacket.Location = new System.Drawing.Point(12, 171);
            this.btnSendPacket.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendPacket.Name = "btnSendPacket";
            this.btnSendPacket.Size = new System.Drawing.Size(234, 42);
            this.btnSendPacket.TabIndex = 38;
            this.btnSendPacket.Text = "S&end Test Packet";
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
            this.txtBytesToSend.Size = new System.Drawing.Size(483, 109);
            this.txtBytesToSend.TabIndex = 37;
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.chkBlinkOnConnect);
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
            this.grpConnection.Location = new System.Drawing.Point(6, 178);
            this.grpConnection.Margin = new System.Windows.Forms.Padding(6);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(6);
            this.grpConnection.Size = new System.Drawing.Size(250, 356);
            this.grpConnection.TabIndex = 5;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection";
            // 
            // chkBlinkOnConnect
            // 
            this.chkBlinkOnConnect.AutoSize = true;
            this.chkBlinkOnConnect.Location = new System.Drawing.Point(15, 328);
            this.chkBlinkOnConnect.Name = "chkBlinkOnConnect";
            this.chkBlinkOnConnect.Size = new System.Drawing.Size(172, 28);
            this.chkBlinkOnConnect.TabIndex = 17;
            this.chkBlinkOnConnect.Text = "B&link on Connect";
            this.chkBlinkOnConnect.UseVisualStyleBackColor = true;
            this.chkBlinkOnConnect.CheckedChanged += new System.EventHandler(this.ChkBlinkOnConnect_CheckedChanged);
            // 
            // chkAutoconnect
            // 
            this.chkAutoconnect.AutoSize = true;
            this.chkAutoconnect.Location = new System.Drawing.Point(15, 307);
            this.chkAutoconnect.Margin = new System.Windows.Forms.Padding(6);
            this.chkAutoconnect.Name = "chkAutoconnect";
            this.chkAutoconnect.Size = new System.Drawing.Size(136, 28);
            this.chkAutoconnect.TabIndex = 16;
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
            this.nudDataBits.TabIndex = 11;
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
            this.lblParity.TabIndex = 14;
            this.lblParity.Text = "&Parity:";
            // 
            // lblStopbits
            // 
            this.lblStopbits.AutoSize = true;
            this.lblStopbits.Location = new System.Drawing.Point(11, 222);
            this.lblStopbits.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStopbits.Name = "lblStopbits";
            this.lblStopbits.Size = new System.Drawing.Size(87, 24);
            this.lblStopbits.TabIndex = 12;
            this.lblStopbits.Text = "&Stop Bits:";
            // 
            // lblDatabits
            // 
            this.lblDatabits.AutoSize = true;
            this.lblDatabits.Location = new System.Drawing.Point(11, 166);
            this.lblDatabits.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDatabits.Name = "lblDatabits";
            this.lblDatabits.Size = new System.Drawing.Size(86, 24);
            this.lblDatabits.TabIndex = 10;
            this.lblDatabits.Text = "&Data Bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(11, 111);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(102, 24);
            this.lblBaudRate.TabIndex = 8;
            this.lblBaudRate.Text = "&Baud Rate:";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(11, 55);
            this.lblComPort.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(97, 24);
            this.lblComPort.TabIndex = 6;
            this.lblComPort.Text = "&COM Port:";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400",
            "250000",
            "500000",
            "1000000",
            "2000000"});
            this.cbBaudRate.Location = new System.Drawing.Point(125, 105);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(6);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(107, 32);
            this.cbBaudRate.TabIndex = 9;
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
            this.cbParity.TabIndex = 15;
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
            this.cbStopBits.TabIndex = 13;
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
            this.cbComPort.TabIndex = 7;
            this.cbComPort.SelectedIndexChanged += new System.EventHandler(this.CbComPort_SelectedIndexChanged);
            this.cbComPort.Click += new System.EventHandler(this.CbComPort_Click);
            this.cbComPort.Enter += new System.EventHandler(this.CbComPort_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(116, 880);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(300, 42);
            this.btnConnect.TabIndex = 42;
            this.btnConnect.Text = "Co&nnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpMenu);
            this.tabControl.Controls.Add(this.tpSettings);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(529, 871);
            this.tabControl.TabIndex = 0;
            // 
            // tpMenu
            // 
            this.tpMenu.Controls.Add(this.lstApps);
            this.tpMenu.Controls.Add(this.btnOpen);
            this.tpMenu.Location = new System.Drawing.Point(4, 33);
            this.tpMenu.Name = "tpMenu";
            this.tpMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tpMenu.Size = new System.Drawing.Size(521, 834);
            this.tpMenu.TabIndex = 0;
            this.tpMenu.Text = "Menu";
            this.tpMenu.UseVisualStyleBackColor = true;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.grpCubeSize);
            this.tpSettings.Controls.Add(this.grpSendColor);
            this.tpSettings.Controls.Add(this.grpCubeType);
            this.tpSettings.Controls.Add(this.btnWebsite);
            this.tpSettings.Controls.Add(this.btnReset);
            this.tpSettings.Controls.Add(this.grpConnection);
            this.tpSettings.Controls.Add(this.grpGeometry);
            this.tpSettings.Controls.Add(this.grpSendPacket);
            this.tpSettings.Location = new System.Drawing.Point(4, 33);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(521, 834);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // grpCubeSize
            // 
            this.grpCubeSize.Controls.Add(this.nudCubeSize);
            this.grpCubeSize.Location = new System.Drawing.Point(6, 84);
            this.grpCubeSize.Name = "grpCubeSize";
            this.grpCubeSize.Size = new System.Drawing.Size(250, 72);
            this.grpCubeSize.TabIndex = 3;
            this.grpCubeSize.TabStop = false;
            this.grpCubeSize.Text = "Cube Size";
            // 
            // nudCubeSize
            // 
            this.nudCubeSize.Location = new System.Drawing.Point(93, 28);
            this.nudCubeSize.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudCubeSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCubeSize.Name = "nudCubeSize";
            this.nudCubeSize.Size = new System.Drawing.Size(65, 29);
            this.nudCubeSize.TabIndex = 0;
            this.nudCubeSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudCubeSize.ValueChanged += new System.EventHandler(this.NudCubeSize_ValueChanged);
            // 
            // grpSendColor
            // 
            this.grpSendColor.Controls.Add(this.cbSendColor);
            this.grpSendColor.Location = new System.Drawing.Point(265, 6);
            this.grpSendColor.Name = "grpSendColor";
            this.grpSendColor.Size = new System.Drawing.Size(250, 72);
            this.grpSendColor.TabIndex = 3;
            this.grpSendColor.TabStop = false;
            this.grpSendColor.Text = "Send Color";
            // 
            // cbSendColor
            // 
            this.cbSendColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSendColor.FormattingEnabled = true;
            this.cbSendColor.Location = new System.Drawing.Point(6, 31);
            this.cbSendColor.Name = "cbSendColor";
            this.cbSendColor.Size = new System.Drawing.Size(232, 32);
            this.cbSendColor.TabIndex = 4;
            this.cbSendColor.SelectedIndexChanged += new System.EventHandler(this.CbSendColor_SelectedIndexChanged);
            // 
            // grpCubeType
            // 
            this.grpCubeType.Controls.Add(this.cbCubeType);
            this.grpCubeType.Location = new System.Drawing.Point(6, 6);
            this.grpCubeType.Name = "grpCubeType";
            this.grpCubeType.Size = new System.Drawing.Size(250, 72);
            this.grpCubeType.TabIndex = 1;
            this.grpCubeType.TabStop = false;
            this.grpCubeType.Text = "Cube Type";
            // 
            // cbCubeType
            // 
            this.cbCubeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCubeType.FormattingEnabled = true;
            this.cbCubeType.Items.AddRange(new object[] {
            "Monochrome",
            "RGB"});
            this.cbCubeType.Location = new System.Drawing.Point(9, 31);
            this.cbCubeType.Margin = new System.Windows.Forms.Padding(6);
            this.cbCubeType.Name = "cbCubeType";
            this.cbCubeType.Size = new System.Drawing.Size(232, 32);
            this.cbCubeType.TabIndex = 2;
            this.cbCubeType.SelectedIndexChanged += new System.EventHandler(this.CbCubeType_SelectedIndexChanged);
            this.cbCubeType.Click += new System.EventHandler(this.CbComPort_Click);
            // 
            // btnWebsite
            // 
            this.btnWebsite.Location = new System.Drawing.Point(2, 783);
            this.btnWebsite.Margin = new System.Windows.Forms.Padding(6);
            this.btnWebsite.Name = "btnWebsite";
            this.btnWebsite.Size = new System.Drawing.Size(246, 42);
            this.btnWebsite.TabIndex = 40;
            this.btnWebsite.Text = "&Website && Updates";
            this.btnWebsite.UseVisualStyleBackColor = true;
            this.btnWebsite.Click += new System.EventHandler(this.BtnWebsite_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(265, 783);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(246, 42);
            this.btnReset.TabIndex = 41;
            this.btnReset.Text = "&Reset all Settings";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // FrmMainMenu
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 937);
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
            this.grpGeometry.ResumeLayout(false);
            this.grpGeometry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).EndInit();
            this.grpSendPacket.ResumeLayout(false);
            this.grpSendPacket.PerformLayout();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDataBits)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tpMenu.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.grpCubeSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCubeSize)).EndInit();
            this.grpSendColor.ResumeLayout(false);
            this.grpCubeType.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpGeometry;
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
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ListBox lstApps;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpMenu;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblOffsetZ;
        private System.Windows.Forms.Label lblOffsetY;
        private System.Windows.Forms.Label lblOffsetX;
        private System.Windows.Forms.NumericUpDown nudOffsetZ;
        private System.Windows.Forms.NumericUpDown nudOffsetY;
        private System.Windows.Forms.NumericUpDown nudOffsetX;
        private System.Windows.Forms.Button btnWebsite;
        private System.Windows.Forms.GroupBox grpCubeType;
        private System.Windows.Forms.ComboBox cbCubeType;
        private System.Windows.Forms.GroupBox grpSendColor;
        private System.Windows.Forms.ComboBox cbSendColor;
        private System.Windows.Forms.CheckBox chkBlinkOnConnect;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.CheckBox chkInvert;
        private System.Windows.Forms.GroupBox grpCubeSize;
        private System.Windows.Forms.NumericUpDown nudCubeSize;
    }
}

