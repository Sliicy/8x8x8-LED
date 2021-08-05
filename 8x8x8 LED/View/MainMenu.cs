using _8x8x8_LED.Apps;
using _8x8x8_LED.Model;
using NAudio.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        public readonly SerialPort serialPort = new SerialPort();

        public Cube cube = new Cube(8, 8, 8);

        public int animationSpeed = 100;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ReloadAvailableComPorts();
            
            // Load Previous Settings:
            chkAutoconnect.Checked = Properties.Settings.Default.Autoconnect;
            cbBaudRate.SelectedIndex = Properties.Settings.Default.BaudRate;
            nudDataBits.Value = Properties.Settings.Default.DataBits;
            cbStopBits.SelectedIndex = Properties.Settings.Default.StopBits;
            cbParity.SelectedIndex = Properties.Settings.Default.Parity;
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
            Properties.Settings.Default.Save();
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
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
                    {
                        serialPort.StopBits = StopBits.None;
                    } else if (cbStopBits.Text == "1")
                    {
                        serialPort.StopBits = StopBits.One;
                    } else if (cbStopBits.Text == "1.5")
                    {
                        serialPort.StopBits = StopBits.OnePointFive;
                    } else
                    {
                        serialPort.StopBits = StopBits.Two;
                    }

                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cbParity.Text, true);

                    serialPort.Open();
                    btnConnect.Text = "Disco&nnect";
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            } else
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

        private void BtnMarqueeAnimate_Click(object sender, EventArgs e) {
            if (btnMarqueeAnimate.Text == "&Animate")
            {
                tmrAnimate.Enabled = true;
                btnMarqueeAnimate.Text = "&Stop";
            } else
            {
                tmrAnimate.Enabled = false;
                btnMarqueeAnimate.Text = "&Animate";
            }
        }

        private void TmrAnimate_Tick(object sender, EventArgs e)
        {
            byte[] scanner = { };
            // IDEA: have each letter scanned vertically. Space adjustable


            var letterMapping = new Dictionary<string, Bitmap>();


            Bitmap canvas;

            foreach (string letter in txtMarquee.Text.Split())
            {
                if (letterMapping.ContainsKey(letter))
                {
                    canvas = letterMapping[letter];
                } else
                {
                    if (File.Exists(Path.Combine(Application.StartupPath, "Characters", letter + ".png")))
                    {
                        var stream = File.Open(Path.Combine(Application.StartupPath, "Characters", letter + ".png"), FileMode.Open);
                        letterMapping.Add(letter, (Bitmap)Image.FromStream(stream));
                        stream.Close();
                    }
                }

                // Scan layer by layer and send.



            }
        }

        private void NudAnimationSpeed_ValueChanged(object sender, EventArgs e)
        {
            animationSpeed = int.Parse(nudAnimationSpeed.Value.ToString());
        }

        private void BtnShowApp_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Text == lstApps.SelectedItem.ToString())
                {
                    openForm.BringToFront();
                    return;
                }
            }
            Form form = new Form();
            if (lstApps.SelectedItem.ToString() == "Image Viewer")
            {
                form = new frmImageViewer(serialPort);
            } else if (lstApps.SelectedItem.ToString() == "Music")
            {
                form = new FrmMusic(serialPort);
            }

            form.Show();
        }
    }
}
