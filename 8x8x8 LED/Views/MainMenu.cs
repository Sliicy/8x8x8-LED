using _8x8x8_LED.Apps;
using _8x8x8_LED.Model;
using _8x8x8_LED.View;
using NAudio.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        public Cube cube = new Cube(64);

        private readonly string requestedApp = "";
        public bool minimized = false;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ReloadAvailableComPorts();
            lstApps.Items.AddRange(Program.existingApps.ToArray());
            if (requestedApp != "")
            {
                lstApps.SelectedIndex = lstApps.FindString(requestedApp);
                btnShowApp.PerformClick();
            }

            // Load Previous Settings:
            chkAutoconnect.Checked = Properties.Settings.Default.Autoconnect;
            cbBaudRate.SelectedIndex = Properties.Settings.Default.BaudRate;
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
            if (cbComPort.Items.Count > 0) cbComPort.SelectedIndex = 0;
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
                }
                catch (Exception)
                {
                    MessageBox.Show("Please ensure cube is connected to computer, and correct COM port and settings are configured.", "Can't find cube", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                        btnConnect.Text = "Co&nnect";
                    }
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
            Properties.Settings.Default.BaudRate = cbBaudRate.SelectedIndex;
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
            SerialHelper.SendPacket(serialPort, bytesToSend, false);
        }

        private void BtnInvertPacket_Click(object sender, EventArgs e)
        {
            string sb = "";
            bool ignoreFirstByte = true;

            foreach (string byteFound in txtBytesToSend.Text.Split(','))
            {
                if (ignoreFirstByte)
                {
                    ignoreFirstByte = false;
                    continue;
                }
                string trimmedString = byteFound.Replace("0x", "").Trim();
                if (trimmedString == "") continue;
                int hex = Convert.ToInt32(trimmedString, 16);
                sb += "0x" + (~hex).ToString("X").Substring(6) + ", ";
            }
            txtBytesToSend.Text = "0xF2, " + Environment.NewLine + sb;
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.W)
                Close();
        }

        private void BtnShowApp_Click(object sender, EventArgs e)
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
            if (lstApps.SelectedItem.ToString() == "Image Viewer")
                form = new FrmImageViewer(serialPort, ref cube);
            else if (lstApps.SelectedItem.ToString() == "Video")
                form = new FrmVideo(serialPort, ref cube);
            else if (lstApps.SelectedItem.ToString() == "Music")
                form = new FrmMusic(serialPort, ref cube);
            else if (lstApps.SelectedItem.ToString() == "Pong")
                form = new FrmPong(serialPort, ref cube);
            else if (lstApps.SelectedItem.ToString() == "Marquee")
                form = new FrmMarquee(serialPort, ref cube);
            else if (lstApps.SelectedItem.ToString() == "Rain")
                form = new FrmRain(serialPort, ref cube);
            else if (lstApps.SelectedItem.ToString() == "Balls")
                form = new FrmBalls(serialPort, ref cube);
            else if (lstApps.SelectedItem.ToString() == "Clock")
                form = new FrmClock(serialPort, ref cube);
            else if (lstApps.SelectedItem.ToString() == "Snake")
                form = new FrmSnake(serialPort, ref cube);
            else if (lstApps.SelectedItem.ToString() == "Phone Square")
                form = new PhoneSquare(serialPort, ref cube);
            else
                return;
            
            if (minimized)
                form.WindowState = FormWindowState.Minimized;
            form.Show();
        }

        private void RenderCube()
        {
            if (cbRotateX.Text == "") cbRotateX.Text = "0";
            if (cbRotateY.Text == "") cbRotateY.Text = "0";
            if (cbRotateZ.Text == "") cbRotateZ.Text = "0";

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

        private void BtnCalibrate_Click(object sender, EventArgs e)
        {
            cube.Clear();
            SerialHelper.Send(serialPort, cube);
            var d = MessageBox.Show("Please play with the settings until the next 5 messages are all describing the cube correctly." + Environment.NewLine + Environment.NewLine +
                "Alternatively, there is a \"Calibration Cube.png\" image which can be loaded into the Image Viewer and used to calibrate the cube (make sure to use the controls found in settings for changes to stay persistent)." + Environment.NewLine + Environment.NewLine +
                "Continue with manual calibration?", "Calibrate Cube", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (d != DialogResult.Yes) return;
            cube.matrix[0] = 128;
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("If the LEDs are calibrated correctly, then right now, the back bottom left LED should be the only one on.", "Calibrate Cube", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear();
            cube.matrix[0] = 255;
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("Now, the bottom left row should be lit.", "Calibrate Cube", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear();
            cube.matrix[0] = 128;
            cube.matrix[8] = 128;
            cube.matrix[16] = 128;
            cube.matrix[24] = 128;
            cube.matrix[32] = 128;
            cube.matrix[40] = 128;
            cube.matrix[48] = 128;
            cube.matrix[56] = 128;
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("Now, the bottom back row should be lit.", "Calibrate Cube", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear();
            cube.matrix[56] = 1;
            cube.matrix[57] = 1;
            cube.matrix[58] = 1;
            cube.matrix[59] = 1;
            cube.matrix[60] = 1;
            cube.matrix[61] = 1;
            cube.matrix[62] = 1;
            cube.matrix[63] = 1;
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("Now, the right front row should be lit.", "Calibrate Cube", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear();
            cube.matrix[7] = 255;
            cube.matrix[15] = 255;
            cube.matrix[23] = 255;
            cube.matrix[31] = 255;
            cube.matrix[39] = 255;
            cube.matrix[47] = 255;
            cube.matrix[55] = 255;
            cube.matrix[63] = 255;
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("Now, the entire top section should be lit.", "Calibrate Cube", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cube.Clear();
            SerialHelper.Send(serialPort, cube);
            MessageBox.Show("If each of these message boxes were correct, then the cube is calibrated!", "Calibrate Cube", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            btnShowApp.PerformClick();
        }
    }
}
