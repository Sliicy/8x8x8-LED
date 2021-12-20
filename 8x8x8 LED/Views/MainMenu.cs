using _8x8x8_LED.Helpers;
using _8x8x8_LED.Models;
using _8x8x8_LED.Models.Geometry;
using _8x8x8_LED.Views;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace _8x8x8_LED
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu(string requestedApp = "", bool minimized = false)
        {
            InitializeComponent();
            this.requestedApp = requestedApp;
            this.minimized = minimized;
            if (minimized)
                WindowState = FormWindowState.Minimized;
        }

        public readonly SerialPort serialPort = new SerialPort();

        public Cube cube = new Cube(8, 8, 8);

        private readonly string requestedApp = "";
        public bool minimized = false;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ReloadAvailableComPorts();

            // Add all Views to App List:
            var appList = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.FullName.Contains(".Views.")).ToList();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            foreach (var app in appList)
            {
                if (app.Name == "MainMenu")
                    continue;
                lstApps.Items.Add(textInfo.ToTitleCase(app.Name.ToLower().Replace("frm", string.Empty).Replace("_", " ")));
            }

            if (requestedApp != "")
            {
                lstApps.SelectedIndex = lstApps.FindString(requestedApp);
                btnOpen.PerformClick();
            }
            cbSendColor.DataSource = Enum.GetValues(typeof(CubeColor));

            // Load Previous Settings:
            cbCubeType.SelectedIndex = Properties.Settings.Default.CubeType;
            chkAutoconnect.Checked = Properties.Settings.Default.Autoconnect;
            cbBaudRate.Text = Properties.Settings.Default.BaudRate.ToString();
            nudDataBits.Value = Properties.Settings.Default.DataBits;
            cbStopBits.SelectedIndex = Properties.Settings.Default.StopBits;
            cbParity.SelectedIndex = Properties.Settings.Default.Parity;

            cbRotateX.SelectedIndex = Properties.Settings.Default.OrientationX;
            cbRotateY.SelectedIndex = Properties.Settings.Default.OrientationY;
            cbRotateZ.SelectedIndex = Properties.Settings.Default.OrientationZ;

            chkFlipX.Checked = Properties.Settings.Default.FlippedX;
            chkFlipY.Checked = Properties.Settings.Default.FlippedY;
            chkFlipZ.Checked = Properties.Settings.Default.FlippedZ;

            nudOffsetX.Value = Properties.Settings.Default.OffsetX;
            nudOffsetY.Value = Properties.Settings.Default.OffsetY;
            nudOffsetZ.Value = Properties.Settings.Default.OffsetZ;

            if (chkAutoconnect.Checked) btnConnect.PerformClick();
        }

        private void ReloadAvailableComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            cbComPort.Items.Clear();
            cbComPort.Items.AddRange(ports);
            if (cbComPort.Items.Count > 0)
                cbComPort.SelectedIndex = 0;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.OrientationX = cbRotateX.SelectedIndex;
            Properties.Settings.Default.OrientationY = cbRotateY.SelectedIndex;
            Properties.Settings.Default.OrientationZ = cbRotateZ.SelectedIndex;

            Properties.Settings.Default.FlippedX = chkFlipX.Checked;
            Properties.Settings.Default.FlippedY = chkFlipY.Checked;
            Properties.Settings.Default.FlippedZ = chkFlipZ.Checked;

            Properties.Settings.Default.OffsetX = nudOffsetX.Value;
            Properties.Settings.Default.OffsetY = nudOffsetY.Value;
            Properties.Settings.Default.OffsetZ = nudOffsetZ.Value;

            Properties.Settings.Default.Save();
            try
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Co&nnect")
            {
                try
                {
                    serialPort.PortName = cbComPort.Text;
                    serialPort.BaudRate = int.Parse(cbBaudRate.Text);
                    serialPort.DataBits = decimal.ToInt32(nudDataBits.Value);

                    if (cbStopBits.Text == "0")
                        serialPort.StopBits = StopBits.None;
                    else if (cbStopBits.Text == "1")
                        serialPort.StopBits = StopBits.One;
                    else if (cbStopBits.Text == "1.5")
                        serialPort.StopBits = StopBits.OnePointFive;
                    else
                        serialPort.StopBits = StopBits.Two;

                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cbParity.Text, true);

                    serialPort.Open();
                    btnConnect.Text = "Disco&nnect";
                    if (cbCubeType.Text == "Monochrome" && cube != null)
                    {
                        cube.type = CubeType.Monochrome;
                    }
                    else if (cbCubeType.Text == "RGB" && cube != null)
                    {
                        cube.type = CubeType.RGB;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please ensure the cube is connected to computer, and the correct COM port and settings are configured.", "Can't find cube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (serialPort.IsOpen)
                        serialPort.Close();
                    btnConnect.Text = "Co&nnect";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void ChkAutoconnect_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Autoconnect = chkAutoconnect.Checked;
        }

        private void CbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BaudRate = int.Parse(cbBaudRate.Text);
            DisconnectIfConnected();
        }

        private void NudDataBits_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DataBits = decimal.ToInt32(nudDataBits.Value);
        }

        private void CbStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StopBits = cbStopBits.SelectedIndex;
        }

        private void CbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Parity = cbParity.SelectedIndex;
        }

        private void CbComPort_Click(object sender, EventArgs e)
        {
            ReloadAvailableComPorts();
        }

        private void BtnSendPacket_Click(object sender, EventArgs e)
        {
            int lengthOfMessage = txtBytesToSend.Text.Split(',').Length;
            byte[] bytesToSend = new byte[lengthOfMessage];

            int counter = 0;
            foreach (string byteFound in txtBytesToSend.Text.Split(','))
            {
                string trimmedString = byteFound.Replace("0x", "").Trim();
                if (trimmedString == "") continue;
                int hex = Convert.ToInt32(trimmedString, 16);
                bytesToSend[counter] = Convert.ToByte(hex);
                counter++;
            }
            switch (cbCubeType.Text)
            {
                case "Monochrome":
                    SerialHelper.SendPacket(CubeType.Monochrome, serialPort, bytesToSend, false);
                    break;
                case "RGB":
                    SerialHelper.SendPacket(CubeType.RGB, serialPort, bytesToSend, false);
                    break;
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.W)
                Close();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (lstApps.SelectedItem == null)
                    return;
                if (openForm.Text == lstApps.SelectedItem.ToString())
                {
                    openForm.BringToFront();
                    return;
                }
            }
            Form form;
            if (lstApps.SelectedItem == null)
                return;

            switch (lstApps.SelectedItem.ToString())
            {
                case "Balls":
                    form = new FrmBalls(serialPort, ref cube);
                    break;
                case "Clock":
                    form = new FrmClock(serialPort, ref cube);
                    break;
                case "Image Viewer":
                    form = new FrmImage_Viewer(serialPort, ref cube);
                    break;
                case "Lamp":
                    form = new FrmLamp(serialPort, ref cube);
                    break;
                case "Lightning":
                    form = new FrmLightning(serialPort, ref cube);
                    break;
                case "Marquee":
                    form = new FrmMarquee(serialPort, ref cube);
                    break;
                case "Music":
                    form = new FrmMusic(serialPort, ref cube);
                    break;
                case "Pong":
                    form = new FrmPong(serialPort, ref cube);
                    break;
                case "Rain":
                    form = new FrmRain(serialPort, ref cube);
                    break;
                case "Snake":
                    form = new FrmSnake(serialPort, ref cube);
                    break;
                case "Video":
                    form = new FrmVideo(serialPort, ref cube);
                    break;
                default:
                    return;
            }

            if (minimized)
                form.WindowState = FormWindowState.Minimized;
            form.Show();
        }

        private void RenderCube()
        {
            if (cbRotateX.Text == "") cbRotateX.Text = "0";
            if (cbRotateY.Text == "") cbRotateY.Text = "0";
            if (cbRotateZ.Text == "") cbRotateZ.Text = "0";

            if (cube != null)
            {
                cube.FlippedX = chkFlipX.Checked;
                cube.FlippedY = chkFlipY.Checked;
                cube.FlippedZ = chkFlipZ.Checked;
                cube.OrientationX = Convert.ToInt32(cbRotateX.Text);
                cube.OrientationY = Convert.ToInt32(cbRotateY.Text);
                cube.OrientationZ = Convert.ToInt32(cbRotateZ.Text);
                cube.OffsetX = (int)nudOffsetX.Value;
                cube.OffsetY = (int)nudOffsetY.Value;
                cube.OffsetZ = (int)nudOffsetZ.Value;
                SerialHelper.Send(serialPort, cube);
            }
        }

        private void ChkFlipX_CheckedChanged(object sender, EventArgs e)
        {
            RenderCube();
        }

        private void ChkFlipY_CheckedChanged(object sender, EventArgs e)
        {
            RenderCube();
        }

        private void ChkFlipZ_CheckedChanged(object sender, EventArgs e)
        {
            RenderCube();
        }

        private void CbRotateX_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderCube();
        }

        private void CbRotateY_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderCube();
        }

        private void CbRotateZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderCube();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset all settings to default?", "Reset", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Application.Restart();
            }
        }

        private void NudOffsetX_ValueChanged(object sender, EventArgs e)
        {
            RenderCube();
        }

        private void NudOffsetY_ValueChanged(object sender, EventArgs e)
        {
            RenderCube();
        }

        private void NudOffsetZ_ValueChanged(object sender, EventArgs e)
        {
            RenderCube();
        }

        private void BtnWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Sliicy/8x8x8-LED");
        }

        private void LstApps_DoubleClick(object sender, EventArgs e)
        {
            btnOpen.PerformClick();
        }

        private void CbCubeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CubeType = cbCubeType.SelectedIndex;
            switch (cbCubeType.Text)
            {
                case "Monochrome":
                    txtBytesToSend.Text = Properties.Resources.MonochromeExample;
                    if (cube != null)
                        cube.type = CubeType.Monochrome;
                    break;
                case "RGB":
                    txtBytesToSend.Text = Properties.Resources.RGBExample;
                    if (cube != null)
                        cube.type = CubeType.RGB;
                    break;
            }
            DisconnectIfConnected();
        }

        private void DisconnectIfConnected()
        {
            if (btnConnect.Text == "Disco&nnect")
                btnConnect.PerformClick();
        }

        private void CbSendColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cube.Clear((CubeColor)Enum.Parse(typeof(CubeColor), cbSendColor.Text));
            SerialHelper.Send(serialPort, cube);
        }

        private void BtnCalibrate_Click(object sender, EventArgs e)
        {
            cube.Clear();
            cube.DrawPlane(Axis.Y, 0, CubeColor.Red);
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("The front of the cube should be red.", "Calibration Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear();
            cube.DrawPlane(Axis.X, 0, CubeColor.Green);
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("The left side of the cube should be green.", "Calibration Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear();
            cube.DrawPlane(Axis.Z, cube.height - 1, CubeColor.Blue);
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("The top of the cube should be blue.", "Calibration Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear(CubeColor.White);
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("The entire cube should be white.", "Calibration Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear();
            cube.DrawPoint(0, 0, 0, CubeColor.Yellow);
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("The front bottom left of the cube should be a yellow point.", "Calibration Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear();
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("If all the previous colors were displayed correctly, then the cube is calibrated.", "Calibration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CbComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisconnectIfConnected();
        }

        private void LstApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstApps.SelectedIndex != -1)
                btnOpen.Enabled = true;
        }
    }
}
