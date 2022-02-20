using _8x8x8_LED.Core.Helpers;
using _8x8x8_LED.Core.Models;
using _8x8x8_LED.Core.Models.Geometry;
using _8x8x8_LED.Core.Models.Snake;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.Views
{
    public partial class FrmSnake : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;
        private bool animate = false;
        private int speed = 500;

        private readonly Snake snake = new Snake(new Location(3, 3, 3));
        private Direction defaultDirection = Direction.Forwards;

        private readonly Location apple = new Location(0, 0, 0);
        private bool appleConsumed = false;

        public FrmSnake(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start &Game")
            {
                animate = true;
                btnStart.Text = "Stop &Game";
                snake.Reset();
                speed = 500;

                Random random = new Random();
                apple.SetX(random.Next(0, 8));
                apple.SetY(random.Next(0, 8));
                apple.SetZ(random.Next(0, 8));
                bwGameEngine.RunWorkerAsync();
            }
            else
            {
                animate = false;
                btnStart.Text = "Start &Game";
                if (bwGameEngine.IsBusy)
                    bwGameEngine.CancelAsync();
            }
        }

        private void BwGameEngine_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                cube.Clear();
                snake.Crawl(defaultDirection);
                if (!snake.alive)
                {
                    MessageBox.Show("Snake crashed!");
                    animate = false;
                }
                else
                {
                    RenderSnake();
                    appleConsumed = snake.AppleConsumed(apple);
                    if (appleConsumed)
                    {
                        snake.Grow();
                        if (speed > 50) speed -= 5;
                    }
                    RenderApple();
                    SerialHelper.Send(serialPort, cube);
                    System.Threading.Thread.Sleep(speed);
                }
            }
        }

        private void RenderApple()
        {
            if (appleConsumed)
            {
                Random random = new Random();
                apple.SetX(random.Next(0, 8));
                apple.SetY(random.Next(0, 8));
                apple.SetZ(random.Next(0, 8));
                appleConsumed = false;
            }
            cube.DrawPoint(apple.GetX(), apple.GetY(), apple.GetZ(), CubeColor.Red);
        }

        private void RenderSnake()
        {
            foreach (var bodypart in snake.body)
                cube.DrawPoint(bodypart.GetX(), bodypart.GetY(), bodypart.GetZ(), CubeColor.Green);
        }

        private void FrmSnake_FormClosing(object sender, FormClosingEventArgs e)
        {
            animate = false;
            if (bwGameEngine.IsBusy)
                bwGameEngine.CancelAsync();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.Equals(Keys.W))
                defaultDirection = Direction.Rightwards;
            if (keyData.Equals(Keys.A))
                defaultDirection = Direction.Forwards;
            if (keyData.Equals(Keys.S))
                defaultDirection = Direction.Leftwards;
            if (keyData.Equals(Keys.D))
                defaultDirection = Direction.Backwards;
            if (keyData.Equals(Keys.Up))
                defaultDirection = Direction.Upwards;
            if (keyData.Equals(Keys.Down))
                defaultDirection = Direction.Downwards;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BwGameEngine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStart.Text = "Start &Game";
        }
    }
}
