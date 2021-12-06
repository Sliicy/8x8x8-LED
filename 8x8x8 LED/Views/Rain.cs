﻿using _8x8x8_LED.Model;
using _8x8x8_LED.Models;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.View
{
    public partial class FrmRain : Form
    {

        private readonly SerialPort serialPort;
        private readonly Cube cube;

        private int rainCount = 90;
        private int speed = 0;
        private bool animate = false;

        private string directionX = "";
        private string directionY = "";
        private string directionZ = "";

        public FrmRain(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void ChkAnimate_CheckedChanged(object sender, EventArgs e)
        {
            animate = chkAnimate.Checked;
            if (chkAnimate.Checked && bwAnimate.IsBusy == false)
            {
                bwAnimate.RunWorkerAsync();
            } else
            {
                bwAnimate.CancelAsync();
            }
        }

        private void BwAnimate_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                Random random = new Random();

                int upwardsOffset = directionZ == "Upwards" ? 7 : 0;

                for (int i = 7 - upwardsOffset; i < cube.matrix_legacy.Length; i += 8)
                {
                    int randomNumber = random.Next(1, rainCount);

                    switch (randomNumber)
                    {
                        case 1:
                            cube.matrix_legacy[i] = 1;
                            break;
                        case 2:
                            cube.matrix_legacy[i] = 2;
                            break;
                        case 3:
                            cube.matrix_legacy[i] = 4;
                            break;
                        case 4:
                            cube.matrix_legacy[i] = 8;
                            break;
                        case 5:
                            cube.matrix_legacy[i] = 16;
                            break;
                        case 6:
                            cube.matrix_legacy[i] = 32;
                            break;
                        case 7:
                            cube.matrix_legacy[i] = 64;
                            break;
                        case 8:
                            cube.matrix_legacy[i] = 128;
                            break;
                    }
                }
                SerialHelper.Send(serialPort, cube);
                if (directionX == "Forwards")
                {
                    cube.Shift(Direction.Forwards, 0);
                }
                else if (directionX == "Backwards")
                {
                    cube.Shift(Direction.Backwards, 0);
                }
                if (directionY == "Leftwards")
                {
                    cube.Shift(Direction.Leftwards, 0);
                }
                else if (directionY == "Rightwards")
                {
                    cube.Shift(Direction.Rightwards, 0);
                }
                if (directionZ == "Upwards")
                {
                    cube.Shift(Direction.Upwards, 0);
                }
                else if (directionZ == "Downwards")
                {
                    cube.Shift(Direction.Downwards, 0);
                }
                System.Threading.Thread.Sleep(speed);
            }
        }

        private void FrmRain_FormClosing(object sender, FormClosingEventArgs e)
        {
            animate = false;
            if (bwAnimate.IsBusy)
                bwAnimate.CancelAsync();
            Properties.Settings.Default.Save();
        }

        private void Tb_Scroll(object sender, EventArgs e)
        {
            rainCount = tbRainCount.Value;
            speed = tbSpeed.Value;
            Properties.Settings.Default.Rain_Count = tbRainCount.Value;
            Properties.Settings.Default.Rain_Speed = tbSpeed.Value;
        }

        private void CbDirectionX_SelectedIndexChanged(object sender, EventArgs e)
        {
            directionX = cbDirectionX.Text;
            Properties.Settings.Default.Rain_X = cbDirectionX.SelectedIndex;
        }

        private void CbDirectionY_SelectedIndexChanged(object sender, EventArgs e)
        {
            directionY = cbDirectionY.Text;
            Properties.Settings.Default.Rain_Y = cbDirectionY.SelectedIndex;
        }

        private void CbDirectionZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            directionZ = cbDirectionZ.Text;
            Properties.Settings.Default.Rain_Z = cbDirectionZ.SelectedIndex;
        }

        private void FrmRain_Load(object sender, EventArgs e)
        {
            cbDirectionX.SelectedIndex = Properties.Settings.Default.Rain_X;
            cbDirectionY.SelectedIndex = Properties.Settings.Default.Rain_Y;
            cbDirectionZ.SelectedIndex = Properties.Settings.Default.Rain_Z;
            tbRainCount.Value = Properties.Settings.Default.Rain_Count;
            tbSpeed.Value = Properties.Settings.Default.Rain_Speed;
            chkRainbow.Checked = Properties.Settings.Default.Rain_Rainbow;
            chkAnimate.Checked = true;
        }

        private void ChkRainbow_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Rain_Rainbow = chkRainbow.Checked;
        }
    }
}
