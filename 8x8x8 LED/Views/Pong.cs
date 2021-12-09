using _8x8x8_LED.Helpers;
using _8x8x8_LED.Models;
using _8x8x8_LED.Models.Pong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.Views
{
    public partial class FrmPong : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;

        private bool animate = false;
        private int speed = 500;
        private readonly List<Ball> balls = new List<Ball>();
        readonly Paddle p1 = new Paddle(2, 0, 2);
        readonly Paddle p2 = new Paddle(7, 7, 7);

        private int player1Score = 0;
        private int player2Score = 0;

        public FrmPong(SerialPort serialPort, ref Cube cube)
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
                player1Score = 0;
                player2Score = 0;
                btnStart.Text = "Stop &Game";
                if (balls.Count == 0)
                {
                    Ball b = new Ball();
                    b.location.SetX(3);
                    b.location.SetY(3);
                    b.location.SetZ(3);
                    b.directionY = Direction.Rightwards;
                    balls.Add(b);
                }

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

                foreach (Ball b in balls)
                {
                    b.Move(false, p1, p2);

                    int destination = b.location.GetZ() + (b.location.GetY() * 8);
                    switch (b.location.GetX())
                    {
                        case 0:
                            cube.matrix_legacy[destination] = 1;
                            break;
                        case 1:
                            cube.matrix_legacy[destination] = 2;
                            break;
                        case 2:
                            cube.matrix_legacy[destination] = 4;
                            break;
                        case 3:
                            cube.matrix_legacy[destination] = 8;
                            break;
                        case 4:
                            cube.matrix_legacy[destination] = 16;
                            break;
                        case 5:
                            cube.matrix_legacy[destination] = 32;
                            break;
                        case 6:
                            cube.matrix_legacy[destination] = 64;
                            break;
                        case 7:
                            cube.matrix_legacy[destination] = 128;
                            break;
                    }
                    if (b.outOfBounds)
                    {

                        if (b.location.GetY() == 1)
                        {
                            player2Score++;
                        }
                        else
                        {
                            player1Score++;
                        }
                        b.outOfBounds = false; // Reset out-of-bounds
                    }
                }

                RenderPaddle(p1);
                RenderPaddle(p2);

                cube.Flip(Axis.X);
                SerialHelper.Send(serialPort, cube);

                System.Threading.Thread.Sleep(speed);
                if (speed > 50) speed -= 5;
                if (player1Score >= 10 || player2Score >= 10)
                {
                    animate = false;
                    bwGameEngine.CancelAsync();
                }
            }
        }

        private void RenderPaddle(Paddle p)
        {
            int destination = p.location.GetZ() + (p.location.GetY() * 8);
            byte value = 0;
            switch (p.location.GetX())
            {
                case 0:
                    value = 193;
                    break;
                case 1:
                    value = 131;
                    break;
                case 2:
                    value = 7;
                    break;
                case 3:
                    value = 14;
                    break;
                case 4:
                    value = 28;
                    break;
                case 5:
                    value = 56;
                    break;
                case 6:
                    value = 112;
                    break;
                case 7:
                    value = 224;
                    break;
            }
            cube.matrix_legacy[destination] = value;
            if (p.location.GetZ() == 0)
            {
                cube.matrix_legacy[destination + 6] = value;
                cube.matrix_legacy[destination + 7] = value;
            }
            else if (p.location.GetZ() == 1)
            {
                cube.matrix_legacy[destination - 1] = value;
                cube.matrix_legacy[destination + 6] = value;
            }
            else
            {
                cube.matrix_legacy[destination - 1] = value;
                cube.matrix_legacy[destination - 2] = value;
            }
        }

        private void FrmPong_FormClosing(object sender, FormClosingEventArgs e)
        {
            animate = false;
            if (bwGameEngine.IsBusy)
                bwGameEngine.CancelAsync();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.Equals(Keys.W))
            {
                p1.Move(Direction.None, Direction.None, Direction.Upwards);
            }
            if (keyData.Equals(Keys.A))
            {
                p1.Move(Direction.Forwards, Direction.None, Direction.None);
            }
            if (keyData.Equals(Keys.S))
            {
                p1.Move(Direction.None, Direction.None, Direction.Downwards);
            }
            if (keyData.Equals(Keys.D))
            {
                p1.Move(Direction.Backwards, Direction.None, Direction.None);
            }


            if (keyData.Equals(Keys.Up))
            {
                p2.Move(Direction.None, Direction.None, Direction.Upwards);
            }
            if (keyData.Equals(Keys.Down))
            {
                p2.Move(Direction.None, Direction.None, Direction.Downwards);
            }
            if (keyData.Equals(Keys.Left))
            {
                p2.Move(Direction.Forwards, Direction.None, Direction.None);
            }
            if (keyData.Equals(Keys.Right))
            {
                p2.Move(Direction.Backwards, Direction.None, Direction.None);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TmrScore_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score:" + Environment.NewLine +
                "Player 1: " + player1Score + Environment.NewLine +
                "Player 2: " + player2Score;
        }

        private void BwGameEngine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStart.Text = "Start &Game";
            if (player1Score > player2Score)
            {
                MessageBox.Show("Player 1 wins!");
            }
            else if (player1Score < player2Score)
            {
                MessageBox.Show("Player 2 wins!");
            }
            else
            {
                MessageBox.Show("It's a draw!");
            }
            speed = 500;
        }
    }
}
