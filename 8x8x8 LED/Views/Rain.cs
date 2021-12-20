using _8x8x8_LED.Helpers;
using _8x8x8_LED.Models;
using _8x8x8_LED.Models.Geometry;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.Views
{
    public partial class FrmRain : Form
    {

        private readonly SerialPort serialPort;
        private readonly Cube cube;

        private int rainCount = 90;
        private int speed = 0;
        private bool animate = false;
        private string animationType = "";
        private CubeColor targetBackColor;
        private readonly Random random = new Random();

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
            if (animate && bwAnimate.IsBusy == false)
                bwAnimate.RunWorkerAsync();
            else
                bwAnimate.CancelAsync();
        }

        private void BwAnimate_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                Random random = new Random();
                for (int x = 0; x < cube.width; x++)
                    for (int y = 0; y < cube.width; y++)
                        if (random.Next(1, rainCount) == 1)
                        {
                            CubeColor color = CubeColor.Black;
                            switch (animationType)
                            {
                                case "Rain":
                                    color = RandomBlue();
                                    break;
                                case "Rainbow":
                                    color = ColorHelper.RandomColor();
                                    break;
                                case "Matrix":
                                    color = RandomGreenWhite();
                                    break;
                            }
                            cube.matrix[x, y, directionZ == "Upwards" ? 0 : cube.height - 1] = color;
                        }
                        else
                        {
                            cube.matrix[x, y, directionZ == "Upwards" ? 0 : cube.height - 1] = targetBackColor;
                        }
                SerialHelper.Send(serialPort, cube);
                System.Threading.Thread.Sleep(speed);
                switch (directionX)
                {
                    case "Forwards":
                        cube.Shift(Direction.Forwards, 0, false);
                        break;
                    case "Backwards":
                        cube.Shift(Direction.Backwards, 0, false);
                        break;
                }
                switch (directionY)
                {
                    case "Leftwards":
                        cube.Shift(Direction.Leftwards, 0, false);
                        break;
                    case "Rightwards":
                        cube.Shift(Direction.Rightwards, 0, false);
                        break;
                }
                switch (directionZ)
                {
                    case "Upwards":
                        cube.Shift(Direction.Upwards, 0, false);
                        break;
                    case "Downwards":
                        cube.Shift(Direction.Downwards, 0, false);
                        break;
                }
            }
        }

        private CubeColor RandomGreenWhite()
        {
            switch (random.Next(1, 5))
            {
                case 1:
                    return CubeColor.Green;
                case 2:
                    return CubeColor.DarkGreen;
                case 3:
                    return CubeColor.BrightGreen;
                case 4:
                    return CubeColor.GreenYellow;
                default:
                    return CubeColor.White;
            }
        }

        private CubeColor RandomBlue()
        {
            switch (random.Next(1, 6))
            {
                case 1:
                    return CubeColor.Blue;
                case 2:
                    return CubeColor.Cyan;
                case 3:
                    return CubeColor.BlueCyan;
                case 4:
                    return CubeColor.DarkBlue;
                default:
                    return CubeColor.DarkCyan;
            }
        }

        private void FrmRain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Rain_Type = cbAnimationType.SelectedIndex;
            Properties.Settings.Default.Rain_BackColor = cbBackcolor.SelectedIndex;
            Properties.Settings.Default.Rain_BackColorShuffled = chkShuffled.Checked;
            Properties.Settings.Default.Rain_Count = tbRainCount.Value;
            Properties.Settings.Default.Rain_Speed = tbSpeed.Value;
            Properties.Settings.Default.Rain_ShuffleSpeed = (int)nudShuffleSpeed.Value;
            animate = false;
            if (bwAnimate.IsBusy)
                bwAnimate.CancelAsync();
            Properties.Settings.Default.Save();
        }

        private void Tb_Scroll(object sender, EventArgs e)
        {
            rainCount = tbRainCount.Value;
            speed = tbSpeed.Value;
            //tmrColorShuffle.Interval = speed == 0 ? 1 : speed;
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
            cbAnimationType.SelectedIndex = Properties.Settings.Default.Rain_Type;
            cbBackcolor.DataSource = Enum.GetValues(typeof(CubeColor));
            cbBackcolor.SelectedIndex = Properties.Settings.Default.Rain_BackColor;
            chkShuffled.Checked = Properties.Settings.Default.Rain_BackColorShuffled;
            nudShuffleSpeed.Value = Properties.Settings.Default.Rain_ShuffleSpeed;
            chkAnimate.Checked = true;
        }

        private void CbAnimationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            animationType = cbAnimationType.Text;
        }

        private void CbBackcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetBackColor = (CubeColor)Enum.Parse(typeof(CubeColor), cbBackcolor.Text);
        }

        private void ChkShuffled_CheckedChanged(object sender, EventArgs e)
        {
            targetBackColor = (CubeColor)Enum.Parse(typeof(CubeColor), cbBackcolor.Text);
            tmrColorShuffle.Enabled = chkShuffled.Checked;
            cbBackcolor.Enabled = !chkShuffled.Checked;
        }

        private void TmrColorShuffle_Tick(object sender, EventArgs e)
        {
            targetBackColor = ColorHelper.RandomColor();
        }

        private void NudShuffleSpeed_ValueChanged(object sender, EventArgs e)
        {
            tmrColorShuffle.Interval = (int)nudShuffleSpeed.Value;
        }
    }
}
