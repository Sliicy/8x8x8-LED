using _8x8x8_LED.Helpers;
using _8x8x8_LED.Model;
using _8x8x8_LED.Models;
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
    public partial class Lightning : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;

        private int lineCount = 1;
        private CubeColor targetColor = CubeColor.White;
        private bool rainbowMode = false;
        private bool animate = false;
        private int speed = 0;
        public Lightning(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void Lightning_Load(object sender, EventArgs e)
        {
            cbColor.DataSource = Enum.GetValues(typeof(CubeColor));
            cbColor.Text = Properties.Settings.Default.Lightning_Color;
            nudLineCount.Value = Properties.Settings.Default.Lightning_Amount;
            chkRainbowMode.Checked = Properties.Settings.Default.Lightning_Rainbow;
            trkSpeed.Value = Properties.Settings.Default.Lightning_Speed;
            chkAnimate.Checked = true;
            speed = trkSpeed.Value;
        }

        private void BwAnimate_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                Random random = new Random();
                cube.Clear();
                for (int i = 0; i < lineCount; i++)
                    cube.DrawLine(random.Next(0, 8), random.Next(0, 8), random.Next(0, 8), random.Next(0, 8), random.Next(0, 8), random.Next(0, 8), rainbowMode ? ColorHelper.RandomColor() : targetColor);
                SerialHelper.Send(serialPort, cube);
                System.Threading.Thread.Sleep(speed);
            }
        }

        private void ChkAnimate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnimate.Checked)
            {
                animate = true;
                bwAnimate.RunWorkerAsync();
            }
            else
            {
                animate = false;
                bwAnimate.CancelAsync();
            }
        }

        private void ChkRainbowMode_CheckedChanged(object sender, EventArgs e)
        {
            rainbowMode = chkRainbowMode.Checked;
            cbColor.Enabled = !chkRainbowMode.Checked;
        }

        private void NudLineCount_ValueChanged(object sender, EventArgs e)
        {
            lineCount = (int)nudLineCount.Value;
        }

        private void CbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetColor = (CubeColor)Enum.Parse(typeof(CubeColor), cbColor.Text);
        }

        private void Lightning_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            if (chkAnimate.Checked)
            {
                animate = false;
                bwAnimate.CancelAsync();
            }
        }

        private void TrkSpeed_Scroll(object sender, EventArgs e)
        {
            speed = trkSpeed.Value;
        }
        private void SaveSettings()
        {
            Properties.Settings.Default.Lightning_Amount = (int)nudLineCount.Value;
            Properties.Settings.Default.Lightning_Speed = speed;
            Properties.Settings.Default.Lightning_Color = cbColor.Text;
            Properties.Settings.Default.Lightning_Rainbow = chkRainbowMode.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
