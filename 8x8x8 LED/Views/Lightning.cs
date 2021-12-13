using _8x8x8_LED.Helpers;
using _8x8x8_LED.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.Views
{
    public partial class FrmLightning : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;

        private int lineCount = 1;
        private CubeColor targetColor = CubeColor.White;
        private bool rainbowMode = false;
        private bool animate = false;
        private int speed = 0;
        private readonly Random random = new Random();
        private readonly List<Tuple<int, int, int>> lightningStrikes = new List<Tuple<int, int, int>>();
        public FrmLightning(SerialPort serialPort, ref Cube cube)
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
            lineCount = (int)nudLineCount.Value;
            chkRainbowMode.Checked = Properties.Settings.Default.Lightning_Rainbow;
            trkSpeed.Value = Properties.Settings.Default.Lightning_Speed;
            chkAnimate.Checked = true;
            speed = trkSpeed.Value;
            for (int i = 0; i < lineCount; i++)
                lightningStrikes.Add(Tuple.Create(random.Next(0, 8), random.Next(0, 8), random.Next(0, 8)));
        }

        private void BwAnimate_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                cube.Clear();
                for (int i = 0; i < lightningStrikes.Count; i++)
                {
                    var newValues = Tuple.Create(random.Next(0, 8), random.Next(0, 8), random.Next(0, 8));
                    cube.DrawLine(lightningStrikes[i].Item1, lightningStrikes[i].Item2, lightningStrikes[i].Item3, newValues.Item1, newValues.Item2, newValues.Item3, rainbowMode ? ColorHelper.RandomColor() : targetColor);
                    lightningStrikes[i] = Tuple.Create(newValues.Item1, newValues.Item2, newValues.Item3);
                }
                SerialHelper.Send(serialPort, cube);
                System.Threading.Thread.Sleep(speed);
            }
        }

        private void ChkAnimate_CheckedChanged(object sender, EventArgs e)
        {
            animate = chkAnimate.Checked;
            if (animate)
                bwAnimate.RunWorkerAsync();
            else
                bwAnimate.CancelAsync();
        }

        private void ChkRainbowMode_CheckedChanged(object sender, EventArgs e)
        {
            rainbowMode = chkRainbowMode.Checked;
            cbColor.Enabled = !chkRainbowMode.Checked;
        }

        private void NudLineCount_ValueChanged(object sender, EventArgs e)
        {
            lineCount = (int)nudLineCount.Value;
            lightningStrikes.Clear();
            for (int i = 0; i < lineCount; i++)
                lightningStrikes.Add(Tuple.Create(random.Next(0, 8), random.Next(0, 8), random.Next(0, 8)));
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
