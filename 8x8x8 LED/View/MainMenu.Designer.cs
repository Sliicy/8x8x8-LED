
namespace _8x8x8_LED
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.tcModes = new System.Windows.Forms.TabControl();
            this.tpSetup = new System.Windows.Forms.TabPage();
            this.lstApps = new System.Windows.Forms.ListBox();
            this.btnShowApp = new System.Windows.Forms.Button();
            this.grpAnimationSpeed = new System.Windows.Forms.GroupBox();
            this.nudAnimationSpeed = new System.Windows.Forms.NumericUpDown();
            this.grpRotation = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.tpVideo = new System.Windows.Forms.TabPage();
            this.tpMarquee = new System.Windows.Forms.TabPage();
            this.lblLetterSpacing = new System.Windows.Forms.Label();
            this.trkLetterSpacing = new System.Windows.Forms.TrackBar();
            this.btnMarqueeAnimate = new System.Windows.Forms.Button();
            this.txtMarquee = new System.Windows.Forms.TextBox();
            this.tmrAnimate = new System.Windows.Forms.Timer(this.components);
            this.tcModes.SuspendLayout();
            this.tpSetup.SuspendLayout();
            this.grpAnimationSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnimationSpeed)).BeginInit();
            this.grpRotation.SuspendLayout();
            this.grpSendPacket.SuspendLayout();
            this.grpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDataBits)).BeginInit();
            this.tpMarquee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkLetterSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // tcModes
            // 
            this.tcModes.Controls.Add(this.tpSetup);
            this.tcModes.Controls.Add(this.tpVideo);
            this.tcModes.Controls.Add(this.tpMarquee);
            this.tcModes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcModes.Location = new System.Drawing.Point(0, 0);
            this.tcModes.Margin = new System.Windows.Forms.Padding(6);
            this.tcModes.Name = "tcModes";
            this.tcModes.SelectedIndex = 0;
            this.tcModes.Size = new System.Drawing.Size(1261, 612);
            this.tcModes.TabIndex = 0;
            // 
            // tpSetup
            // 
            this.tpSetup.Controls.Add(this.lstApps);
            this.tpSetup.Controls.Add(this.btnShowApp);
            this.tpSetup.Controls.Add(this.grpAnimationSpeed);
            this.tpSetup.Controls.Add(this.grpRotation);
            this.tpSetup.Controls.Add(this.grpSendPacket);
            this.tpSetup.Controls.Add(this.grpConnection);
            this.tpSetup.Location = new System.Drawing.Point(4, 33);
            this.tpSetup.Margin = new System.Windows.Forms.Padding(6);
            this.tpSetup.Name = "tpSetup";
            this.tpSetup.Padding = new System.Windows.Forms.Padding(6);
            this.tpSetup.Size = new System.Drawing.Size(1253, 575);
            this.tpSetup.TabIndex = 0;
            this.tpSetup.Text = "Setup";
            this.tpSetup.UseVisualStyleBackColor = true;
            // 
            // lstApps
            // 
            this.lstApps.FormattingEnabled = true;
            this.lstApps.ItemHeight = 24;
            this.lstApps.Items.AddRange(new object[] {
            "Image Viewer",
            "Music",
            "Marquee",
            "Video",
            "Tetris",
            "Snake",
            "Game of Life",
            "Atom"});
            this.lstApps.Location = new System.Drawing.Point(1048, 251);
            this.lstApps.Name = "lstApps";
            this.lstApps.Size = new System.Drawing.Size(184, 196);
            this.lstApps.TabIndex = 5;
            // 
            // btnShowApp
            // 
            this.btnShowApp.Location = new System.Drawing.Point(1048, 453);
            this.btnShowApp.Name = "btnShowApp";
            this.btnShowApp.Size = new System.Drawing.Size(184, 42);
            this.btnShowApp.TabIndex = 4;
            this.btnShowApp.Text = "&Open";
            this.btnShowApp.UseVisualStyleBackColor = true;
            this.btnShowApp.Click += new System.EventHandler(this.BtnShowApp_Click);
            // 
            // grpAnimationSpeed
            // 
            this.grpAnimationSpeed.Controls.Add(this.nudAnimationSpeed);
            this.grpAnimationSpeed.Location = new System.Drawing.Point(899, 6);
            this.grpAnimationSpeed.Name = "grpAnimationSpeed";
            this.grpAnimationSpeed.Size = new System.Drawing.Size(258, 124);
            this.grpAnimationSpeed.TabIndex = 3;
            this.grpAnimationSpeed.TabStop = false;
            this.grpAnimationSpeed.Text = "Animation Speed";
            // 
            // nudAnimationSpeed
            // 
            this.nudAnimationSpeed.Location = new System.Drawing.Point(29, 50);
            this.nudAnimationSpeed.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudAnimationSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnimationSpeed.Name = "nudAnimationSpeed";
            this.nudAnimationSpeed.Size = new System.Drawing.Size(175, 29);
            this.nudAnimationSpeed.TabIndex = 0;
            this.nudAnimationSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAnimationSpeed.ValueChanged += new System.EventHandler(this.NudAnimationSpeed_ValueChanged);
            // 
            // grpRotation
            // 
            this.grpRotation.Controls.Add(this.button1);
            this.grpRotation.Controls.Add(this.chkFlipZ);
            this.grpRotation.Controls.Add(this.chkFlipY);
            this.grpRotation.Controls.Add(this.chkFlipX);
            this.grpRotation.Controls.Add(this.cbRotateZ);
            this.grpRotation.Controls.Add(this.cbRotateY);
            this.grpRotation.Controls.Add(this.cbRotateX);
            this.grpRotation.Controls.Add(this.lblRotateZ);
            this.grpRotation.Controls.Add(this.lblRotateY);
            this.grpRotation.Controls.Add(this.lblRotateX);
            this.grpRotation.Location = new System.Drawing.Point(606, 6);
            this.grpRotation.Name = "grpRotation";
            this.grpRotation.Size = new System.Drawing.Size(287, 465);
            this.grpRotation.TabIndex = 2;
            this.grpRotation.TabStop = false;
            this.grpRotation.Text = "Rotation";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Instant Calibration";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // chkFlipZ
            // 
            this.chkFlipZ.AutoSize = true;
            this.chkFlipZ.Location = new System.Drawing.Point(21, 375);
            this.chkFlipZ.Name = "chkFlipZ";
            this.chkFlipZ.Size = new System.Drawing.Size(77, 28);
            this.chkFlipZ.TabIndex = 2;
            this.chkFlipZ.Text = "Flip Z";
            this.chkFlipZ.UseVisualStyleBackColor = true;
            // 
            // chkFlipY
            // 
            this.chkFlipY.AutoSize = true;
            this.chkFlipY.Location = new System.Drawing.Point(23, 341);
            this.chkFlipY.Name = "chkFlipY";
            this.chkFlipY.Size = new System.Drawing.Size(77, 28);
            this.chkFlipY.TabIndex = 2;
            this.chkFlipY.Text = "Flip Y";
            this.chkFlipY.UseVisualStyleBackColor = true;
            // 
            // chkFlipX
            // 
            this.chkFlipX.AutoSize = true;
            this.chkFlipX.Location = new System.Drawing.Point(23, 307);
            this.chkFlipX.Name = "chkFlipX";
            this.chkFlipX.Size = new System.Drawing.Size(79, 28);
            this.chkFlipX.TabIndex = 2;
            this.chkFlipX.Text = "Flip X";
            this.chkFlipX.UseVisualStyleBackColor = true;
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
            this.cbRotateZ.Location = new System.Drawing.Point(124, 245);
            this.cbRotateZ.Name = "cbRotateZ";
            this.cbRotateZ.Size = new System.Drawing.Size(121, 32);
            this.cbRotateZ.TabIndex = 1;
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
            this.cbRotateY.Location = new System.Drawing.Point(124, 199);
            this.cbRotateY.Name = "cbRotateY";
            this.cbRotateY.Size = new System.Drawing.Size(121, 32);
            this.cbRotateY.TabIndex = 1;
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
            this.cbRotateX.Location = new System.Drawing.Point(124, 158);
            this.cbRotateX.Name = "cbRotateX";
            this.cbRotateX.Size = new System.Drawing.Size(121, 32);
            this.cbRotateX.TabIndex = 1;
            // 
            // lblRotateZ
            // 
            this.lblRotateZ.AutoSize = true;
            this.lblRotateZ.Location = new System.Drawing.Point(19, 253);
            this.lblRotateZ.Name = "lblRotateZ";
            this.lblRotateZ.Size = new System.Drawing.Size(85, 24);
            this.lblRotateZ.TabIndex = 0;
            this.lblRotateZ.Text = "Rotate Z:";
            // 
            // lblRotateY
            // 
            this.lblRotateY.AutoSize = true;
            this.lblRotateY.Location = new System.Drawing.Point(19, 204);
            this.lblRotateY.Name = "lblRotateY";
            this.lblRotateY.Size = new System.Drawing.Size(85, 24);
            this.lblRotateY.TabIndex = 0;
            this.lblRotateY.Text = "Rotate Y:";
            // 
            // lblRotateX
            // 
            this.lblRotateX.AutoSize = true;
            this.lblRotateX.Location = new System.Drawing.Point(19, 156);
            this.lblRotateX.Name = "lblRotateX";
            this.lblRotateX.Size = new System.Drawing.Size(87, 24);
            this.lblRotateX.TabIndex = 0;
            this.lblRotateX.Text = "Rotate X:";
            // 
            // grpSendPacket
            // 
            this.grpSendPacket.Controls.Add(this.btnInvertPacket);
            this.grpSendPacket.Controls.Add(this.btnSendPacket);
            this.grpSendPacket.Controls.Add(this.txtBytesToSend);
            this.grpSendPacket.Location = new System.Drawing.Point(255, 6);
            this.grpSendPacket.Margin = new System.Windows.Forms.Padding(6);
            this.grpSendPacket.Name = "grpSendPacket";
            this.grpSendPacket.Padding = new System.Windows.Forms.Padding(6);
            this.grpSendPacket.Size = new System.Drawing.Size(342, 465);
            this.grpSendPacket.TabIndex = 1;
            this.grpSendPacket.TabStop = false;
            this.grpSendPacket.Text = "Send Packet";
            // 
            // btnInvertPacket
            // 
            this.btnInvertPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvertPacket.Location = new System.Drawing.Point(189, 406);
            this.btnInvertPacket.Margin = new System.Windows.Forms.Padding(6);
            this.btnInvertPacket.Name = "btnInvertPacket";
            this.btnInvertPacket.Size = new System.Drawing.Size(138, 42);
            this.btnInvertPacket.TabIndex = 1;
            this.btnInvertPacket.Text = "&Invert";
            this.btnInvertPacket.UseVisualStyleBackColor = true;
            this.btnInvertPacket.Click += new System.EventHandler(this.BtnInvertPacket_Click);
            // 
            // btnSendPacket
            // 
            this.btnSendPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendPacket.Location = new System.Drawing.Point(11, 406);
            this.btnSendPacket.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendPacket.Name = "btnSendPacket";
            this.btnSendPacket.Size = new System.Drawing.Size(138, 42);
            this.btnSendPacket.TabIndex = 1;
            this.btnSendPacket.Text = "S&end";
            this.btnSendPacket.UseVisualStyleBackColor = true;
            this.btnSendPacket.Click += new System.EventHandler(this.BtnSendPacket_Click);
            // 
            // txtBytesToSend
            // 
            this.txtBytesToSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBytesToSend.Location = new System.Drawing.Point(11, 55);
            this.txtBytesToSend.Margin = new System.Windows.Forms.Padding(6);
            this.txtBytesToSend.Multiline = true;
            this.txtBytesToSend.Name = "txtBytesToSend";
            this.txtBytesToSend.Size = new System.Drawing.Size(316, 339);
            this.txtBytesToSend.TabIndex = 0;
            this.txtBytesToSend.Text = resources.GetString("txtBytesToSend.Text");
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.btnConnect);
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
            this.grpConnection.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpConnection.Location = new System.Drawing.Point(6, 6);
            this.grpConnection.Margin = new System.Windows.Forms.Padding(6);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(6);
            this.grpConnection.Size = new System.Drawing.Size(249, 563);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(11, 388);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(224, 42);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Co&nnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // chkAutoconnect
            // 
            this.chkAutoconnect.AutoSize = true;
            this.chkAutoconnect.Location = new System.Drawing.Point(44, 332);
            this.chkAutoconnect.Margin = new System.Windows.Forms.Padding(6);
            this.chkAutoconnect.Name = "chkAutoconnect";
            this.chkAutoconnect.Size = new System.Drawing.Size(136, 28);
            this.chkAutoconnect.TabIndex = 3;
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
            this.nudDataBits.TabIndex = 2;
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
            this.lblParity.TabIndex = 1;
            this.lblParity.Text = "&Parity:";
            // 
            // lblStopbits
            // 
            this.lblStopbits.AutoSize = true;
            this.lblStopbits.Location = new System.Drawing.Point(11, 222);
            this.lblStopbits.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStopbits.Name = "lblStopbits";
            this.lblStopbits.Size = new System.Drawing.Size(87, 24);
            this.lblStopbits.TabIndex = 1;
            this.lblStopbits.Text = "&Stop Bits:";
            // 
            // lblDatabits
            // 
            this.lblDatabits.AutoSize = true;
            this.lblDatabits.Location = new System.Drawing.Point(11, 166);
            this.lblDatabits.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDatabits.Name = "lblDatabits";
            this.lblDatabits.Size = new System.Drawing.Size(86, 24);
            this.lblDatabits.TabIndex = 1;
            this.lblDatabits.Text = "&Data Bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(11, 111);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(102, 24);
            this.lblBaudRate.TabIndex = 1;
            this.lblBaudRate.Text = "&Baud Rate:";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(11, 55);
            this.lblComPort.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(97, 24);
            this.lblComPort.TabIndex = 1;
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
            this.cbBaudRate.TabIndex = 0;
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
            this.cbParity.TabIndex = 0;
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
            this.cbStopBits.TabIndex = 0;
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
            this.cbComPort.TabIndex = 0;
            this.cbComPort.Click += new System.EventHandler(this.CbComPort_Click);
            this.cbComPort.Enter += new System.EventHandler(this.CbComPort_Click);
            // 
            // tpVideo
            // 
            this.tpVideo.Location = new System.Drawing.Point(4, 33);
            this.tpVideo.Margin = new System.Windows.Forms.Padding(6);
            this.tpVideo.Name = "tpVideo";
            this.tpVideo.Padding = new System.Windows.Forms.Padding(6);
            this.tpVideo.Size = new System.Drawing.Size(1253, 575);
            this.tpVideo.TabIndex = 4;
            this.tpVideo.Text = "Video";
            this.tpVideo.UseVisualStyleBackColor = true;
            // 
            // tpMarquee
            // 
            this.tpMarquee.Controls.Add(this.lblLetterSpacing);
            this.tpMarquee.Controls.Add(this.trkLetterSpacing);
            this.tpMarquee.Controls.Add(this.btnMarqueeAnimate);
            this.tpMarquee.Controls.Add(this.txtMarquee);
            this.tpMarquee.Location = new System.Drawing.Point(4, 33);
            this.tpMarquee.Margin = new System.Windows.Forms.Padding(6);
            this.tpMarquee.Name = "tpMarquee";
            this.tpMarquee.Padding = new System.Windows.Forms.Padding(6);
            this.tpMarquee.Size = new System.Drawing.Size(1253, 575);
            this.tpMarquee.TabIndex = 3;
            this.tpMarquee.Text = "Marquee";
            this.tpMarquee.UseVisualStyleBackColor = true;
            // 
            // lblLetterSpacing
            // 
            this.lblLetterSpacing.AutoSize = true;
            this.lblLetterSpacing.Location = new System.Drawing.Point(50, 168);
            this.lblLetterSpacing.Name = "lblLetterSpacing";
            this.lblLetterSpacing.Size = new System.Drawing.Size(135, 24);
            this.lblLetterSpacing.TabIndex = 3;
            this.lblLetterSpacing.Text = "Letter Spacing:";
            // 
            // trkLetterSpacing
            // 
            this.trkLetterSpacing.Location = new System.Drawing.Point(191, 159);
            this.trkLetterSpacing.Name = "trkLetterSpacing";
            this.trkLetterSpacing.Size = new System.Drawing.Size(180, 45);
            this.trkLetterSpacing.TabIndex = 2;
            this.trkLetterSpacing.Value = 4;
            // 
            // btnMarqueeAnimate
            // 
            this.btnMarqueeAnimate.Location = new System.Drawing.Point(9, 57);
            this.btnMarqueeAnimate.Name = "btnMarqueeAnimate";
            this.btnMarqueeAnimate.Size = new System.Drawing.Size(138, 42);
            this.btnMarqueeAnimate.TabIndex = 1;
            this.btnMarqueeAnimate.Text = "&Animate";
            this.btnMarqueeAnimate.UseVisualStyleBackColor = true;
            this.btnMarqueeAnimate.Click += new System.EventHandler(this.BtnMarqueeAnimate_Click);
            // 
            // txtMarquee
            // 
            this.txtMarquee.Location = new System.Drawing.Point(9, 9);
            this.txtMarquee.Multiline = true;
            this.txtMarquee.Name = "txtMarquee";
            this.txtMarquee.Size = new System.Drawing.Size(343, 42);
            this.txtMarquee.TabIndex = 0;
            // 
            // tmrAnimate
            // 
            this.tmrAnimate.Interval = 1000;
            this.tmrAnimate.Tick += new System.EventHandler(this.TmrAnimate_Tick);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 612);
            this.Controls.Add(this.tcModes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "8x8x8 LED";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.tcModes.ResumeLayout(false);
            this.tpSetup.ResumeLayout(false);
            this.grpAnimationSpeed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnimationSpeed)).EndInit();
            this.grpRotation.ResumeLayout(false);
            this.grpRotation.PerformLayout();
            this.grpSendPacket.ResumeLayout(false);
            this.grpSendPacket.PerformLayout();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDataBits)).EndInit();
            this.tpMarquee.ResumeLayout(false);
            this.tpMarquee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkLetterSpacing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcModes;
        private System.Windows.Forms.TabPage tpSetup;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.TabPage tpVideo;
        private System.Windows.Forms.TabPage tpMarquee;
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
        private System.Windows.Forms.Button btnMarqueeAnimate;
        private System.Windows.Forms.TextBox txtMarquee;
        private System.Windows.Forms.GroupBox grpAnimationSpeed;
        private System.Windows.Forms.NumericUpDown nudAnimationSpeed;
        private System.Windows.Forms.Timer tmrAnimate;
        private System.Windows.Forms.Label lblLetterSpacing;
        private System.Windows.Forms.TrackBar trkLetterSpacing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShowApp;
        private System.Windows.Forms.ListBox lstApps;
    }
}

