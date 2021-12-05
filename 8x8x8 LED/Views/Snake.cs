using _8x8x8_LED.Model;
using _8x8x8_LED.Model.Pong;
using _8x8x8_LED.Model.Snake;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.View
{
    public partial class FrmSnake : Form
    {
        private readonly SerialPort serialPort;
        private readonly MonochromeCube cube;
        private bool animate = false;
        private int speed = 500;
        
        private readonly Snake snake = new Snake(new Location(3, 3, 3));
        private Direction defaultDirection = Direction.Forwards;
        
        private readonly Location apple = new Location(0, 0, 0);
        private bool appleConsumed = false;

        public FrmSnake(SerialPort serialPort, ref MonochromeCube cube)
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
                cube.Clear_Legacy();
                snake.Crawl(defaultDirection);
                if (!snake.alive)
                {
                    MessageBox.Show("Snake crashed!");
                    animate = false;
                } else
                {
                    RenderSnake();
                    
                    appleConsumed = snake.AppleConsumed(apple);
                    if (appleConsumed)
                    {
                        snake.Grow();
                        if (speed > 50) speed -= 5;
                    }
                    RenderApple();

                    cube.Flip(Axis.X);
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
            int destination = apple.GetZ() + (apple.GetY() * 8);
            switch (apple.GetX())
            {
                case 0:
                    cube.matrix_legacy[destination] += 1;
                    break;
                case 1:
                    cube.matrix_legacy[destination] += 2;
                    break;
                case 2:
                    cube.matrix_legacy[destination] += 4;
                    break;
                case 3:
                    cube.matrix_legacy[destination] += 8;
                    break;
                case 4:
                    cube.matrix_legacy[destination] += 16;
                    break;
                case 5:
                    cube.matrix_legacy[destination] += 32;
                    break;
                case 6:
                    cube.matrix_legacy[destination] += 64;
                    break;
                case 7:
                    cube.matrix_legacy[destination] += 128;
                    break;
            }
        }

        private void RenderSnake()
        {
            foreach (var bodypart in snake.body)
            {
                int destination = bodypart.GetZ() + (bodypart.GetY() * 8);
                switch (bodypart.GetX())
                {
                    case 0:
                        cube.matrix_legacy[destination] += 1;
                        break;
                    case 1:
                        cube.matrix_legacy[destination] += 2;
                        break;
                    case 2:
                        cube.matrix_legacy[destination] += 4;
                        break;
                    case 3:
                        cube.matrix_legacy[destination] += 8;
                        break;
                    case 4:
                        cube.matrix_legacy[destination] += 16;
                        break;
                    case 5:
                        cube.matrix_legacy[destination] += 32;
                        break;
                    case 6:
                        cube.matrix_legacy[destination] += 64;
                        break;
                    case 7:
                        cube.matrix_legacy[destination] += 128;
                        break;
                }
            }
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
            {
                defaultDirection = Direction.Forwards;
            }
            if (keyData.Equals(Keys.A))
            {
                defaultDirection = Direction.Leftwards;
            }
            if (keyData.Equals(Keys.S))
            {
                defaultDirection = Direction.Backwards;
            }
            if (keyData.Equals(Keys.D))
            {
                defaultDirection = Direction.Rightwards;
            }
            if (keyData.Equals(Keys.Up))
            {
                defaultDirection = Direction.Upwards;
            }
            if (keyData.Equals(Keys.Down))
            {
                defaultDirection = Direction.Downwards;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BwGameEngine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStart.Text = "Start &Game";
        }
    }
}
