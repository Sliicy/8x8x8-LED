using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8x8x8_LED
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        readonly SerialPort sp = new SerialPort();

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
                if (sp.IsOpen)
                {
                    sp.Close();
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
                    sp.PortName = cbComPort.Text;
                    sp.BaudRate = int.Parse(cbBaudRate.Text);
                    sp.DataBits = decimal.ToInt32(nudDataBits.Value);

                    if (cbStopBits.Text == "0")
                    {
                        sp.StopBits = StopBits.None;
                    } else if (cbStopBits.Text == "1")
                    {
                        sp.StopBits = StopBits.One;
                    } else if (cbStopBits.Text == "1.5")
                    {
                        sp.StopBits = StopBits.OnePointFive;
                    } else
                    {
                        sp.StopBits = StopBits.Two;
                    }

                    sp.Parity = (Parity)Enum.Parse(typeof(Parity), cbParity.Text, true);

                    sp.Open();
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
                    if (sp.IsOpen)
                    {
                        sp.Close();
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
            if (sp.IsOpen)
            {
                sp.Write(bytesToSend, 0, bytesToSend.Length);
            }
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
        IWaveIn waveIn = new WasapiLoopbackCapture();
        static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            for (int i = 0; i < e.BytesRecorded; i += 8)
            {
                float leftSample = BitConverter.ToSingle(e.Buffer, i);
                float rightSample = BitConverter.ToSingle(e.Buffer, i + 4);

            }
        }

        private void ChkSyncMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSyncMusic.Checked)
            {

                
                waveIn.DataAvailable += waveIn_DataAvailable;
                waveIn.StartRecording();

                
            } else
            {
                waveIn.StopRecording();
            }
        }
    }
}
