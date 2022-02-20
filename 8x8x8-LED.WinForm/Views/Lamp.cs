using _8x8x8_LED.Core.Helpers;
using _8x8x8_LED.Core.Models;
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

namespace _8x8x8_LED.Views
{
    public partial class FrmLamp : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;
        public FrmLamp(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void FrmLamp_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lamp_Times != null)
                lstTimes.Items.AddRange(Properties.Settings.Default.Lamp_Times.Cast<string>().ToArray());
            cbColor.DataSource = Enum.GetValues(typeof(CubeColor));
            // Calibrate time to count every minute:
            tmrClock.Interval = (60 - DateTime.Now.Second) * 1000;
            tmrClock.Enabled = true;
            dtpTime.Value = DateTime.Now;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lstTimes.Items.Add(dtpTime.Text + " - " + cbColor.Text);
        }

        private void LstTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = true;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int index = lstTimes.SelectedIndex;
            lstTimes.Items.RemoveAt(index);
            if (lstTimes.Items.Count == 0)
                btnRemove.Enabled = false;
            else if (lstTimes.Items.Count == index)
                lstTimes.SelectedIndex = index - 1;
            else
                lstTimes.SelectedIndex = index;
        }

        private void TmrClock_Tick(object sender, EventArgs e)
        {
            foreach (string timeEntry in lstTimes.Items)
            {
                if (DateTime.Now.ToLongTimeString() == timeEntry.Substring(0, timeEntry.IndexOf(" - ")))
                {
                    cube.Clear((CubeColor)Enum.Parse(typeof(CubeColor), timeEntry.Substring(timeEntry.IndexOf(" - ")).Replace(" - ", "")));
                    SerialHelper.Send(serialPort, cube);
                }
            }
            
        }

        private void FrmLamp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.Lamp_Times != null)
                Properties.Settings.Default.Lamp_Times.Clear();
            else
                Properties.Settings.Default.Lamp_Times = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.Lamp_Times.AddRange(lstTimes.Items.Cast<string>().ToArray());
            Properties.Settings.Default.Save();
        }
    }
}
