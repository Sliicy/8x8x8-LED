using _8x8x8_LED.Model;
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

                for (int i = 7 - upwardsOffset; i < cube.matrix.Length; i += 8)
                {
                    int randomNumber = random.Next(1, rainCount);

                    switch (randomNumber)
                    {
                        case 1:
                            cube.matrix[i] = 1;
                            break;
                        case 2:
                            cube.matrix[i] = 2;
                            break;
                        case 3:
                            cube.matrix[i] = 4;
                            break;
                        case 4:
                            cube.matrix[i] = 8;
                            break;
                        case 5:
                            cube.matrix[i] = 16;
                            break;
                        case 6:
                            cube.matrix[i] = 32;
                            break;
                        case 7:
                            cube.matrix[i] = 64;
                            break;
                        case 8:
                            cube.matrix[i] = 128;
                            break;
                    }
                }
                SerialHelper.Send(serialPort, cube);
                if (directionX == "Forwards")
                {
                    cube.Shift(Direction.Forwards, false, 0);
                }
                else if (directionX == "Backwards")
                {
                    cube.Shift(Direction.Backwards, false, 0);
                }
                if (directionY == "Leftwards")
                {
                    cube.Shift(Direction.Leftwards, false, 0);
                }
                else if (directionY == "Rightwards")
                {
                    cube.Shift(Direction.Rightwards, false, 0);
                }
                if (directionZ == "Upwards")
                {
                    cube.Shift(Direction.Upwards, false, 0);
                }
                else if (directionZ == "Downwards")
                {
                    cube.Shift(Direction.Downwards, false, 0);
                }
                System.Threading.Thread.Sleep(speed);
            }
        }

        private void FrmRain_FormClosing(object sender, FormClosingEventArgs e)
        {
            animate = false;
            if (bwAnimate.IsBusy)
                bwAnimate.CancelAsync();
        }

        private void Tb_Scroll(object sender, EventArgs e)
        {
            rainCount = tbStarCount.Value;
            speed = tbSpeed.Value;
        }

        private void CbDirectionX_SelectedIndexChanged(object sender, EventArgs e)
        {
            directionX = cbDirectionX.Text;
        }

        private void CbDirectionY_SelectedIndexChanged(object sender, EventArgs e)
        {
            directionY = cbDirectionY.Text;
        }

        private void CbDirectionZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            directionZ = cbDirectionZ.Text;
        }

        private void FrmRain_Load(object sender, EventArgs e)
        {
            cbDirectionX.SelectedIndex = 0;
            cbDirectionY.SelectedIndex = 0;
            cbDirectionZ.SelectedIndex = 2;
            chkAnimate.Checked = true;
        }
    }
}
