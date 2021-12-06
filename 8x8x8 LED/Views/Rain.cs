using _8x8x8_LED.Model;
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
                for (int x = 0; x < cube.width; x++)
                {
                    for (int y = 0; y < cube.width; y++)
                    {
                        int randomNumber = random.Next(1, rainCount);
                        if (randomNumber == 1)
                        {
                            cube.matrix[x, y, directionZ == "Upwards" ? 0 : cube.height - 1] = chkRainbow.Checked ? RandomColor() : RandomBlue();
                        }
                    }
                }
                SerialHelper.Send(serialPort, cube);
                System.Threading.Thread.Sleep(speed);
                if (directionX == "Forwards")
                {
                    cube.Shift(Direction.Forwards, 0, false);
                }
                else if (directionX == "Backwards")
                {
                    cube.Shift(Direction.Backwards, 0, false);
                }
                if (directionY == "Leftwards")
                {
                    cube.Shift(Direction.Leftwards, 0, false);
                }
                else if (directionY == "Rightwards")
                {
                    cube.Shift(Direction.Rightwards, 0, false);
                }
                if (directionZ == "Upwards")
                {
                    cube.Shift(Direction.Upwards, 0, false);
                }
                else if (directionZ == "Downwards")
                {
                    cube.Shift(Direction.Downwards, 0, false);
                }
            }
        }

        private CubeColor RandomColor()
        {
            Random random = new Random();
            Array enums = Enum.GetValues(typeof(CubeColor));
            return (CubeColor)enums.GetValue(random.Next(enums.Length));
        }

        private CubeColor RandomBlue()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 6);
            switch (randomNumber)
            {
                case 1:
                    return CubeColor.Blue;
                case 2:
                    return CubeColor.Cyan;
                case 3:
                    return CubeColor.BlueCyan;
                case 4:
                    return CubeColor.DarkBlue;
                case 5:
                    return CubeColor.DarkCyan;
                default:
                    return CubeColor.Blue;
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
