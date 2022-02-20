using _8x8x8_LED.Core.Helpers;
using _8x8x8_LED.Core.Models;
using _8x8x8_LED.Core.Models.Geometry;
using _8x8x8_LED.Core.Models.Pong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        readonly Paddle p2 = new Paddle(6, 7, 6);

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
                lblPlayer1Controls.ForeColor = ColorHelper.GetRGB(p1.color);
                lblPlayer2Controls.ForeColor = ColorHelper.GetRGB(p2.color);
                bwGameEngine.RunWorkerAsync();
            }
            else
            {
                animate = false;
                btnStart.Text = "Start &Game";
                lblPlayer1Controls.ForeColor = Color.Black;
                lblPlayer2Controls.ForeColor = Color.Black;
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
                    cube.DrawPoint(b.location.GetX(), b.location.GetY(), b.location.GetZ(), b.color);
                    if (b.outOfBounds)
                    {
                        if (b.location.GetY() == 1)
                        {
                            player2Score++;
                            cube.DrawPlane(Axis.Y, 0, CubeColor.DarkRed);
                        }
                        else
                        {
                            player1Score++;
                            cube.DrawPlane(Axis.Y, 7, CubeColor.DarkRed);
                        }
                        b.outOfBounds = false; // Reset out-of-bounds
                    }
                }

                RenderPaddle(p1);
                RenderPaddle(p2);

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
            var x = p.location.GetX();
            var y = p.location.GetY();
            var z = p.location.GetZ();

            if (x < 1) x = 1;
            if (z < 1) z = 1;

            cube.DrawPoint(x, y, z, p.color);
            cube.DrawPoint((x + 1) % cube.width, y, z, p.color);
            cube.DrawPoint((x - 1) % cube.width, y, z, p.color);
            cube.DrawPoint(x % cube.width, y, (z + 1) % cube.height, p.color);
            cube.DrawPoint(x % cube.width, y, (z - 1) % cube.height, p.color);
            cube.DrawPoint((x + 1) % cube.width, y, (z + 1) % cube.height, p.color);
            cube.DrawPoint((x + 1) % cube.width, y, (z - 1) % cube.height, p.color);
            cube.DrawPoint((x - 1) % cube.width, y, (z + 1) % cube.height, p.color);
            cube.DrawPoint((x - 1) % cube.width, y, (z - 1) % cube.height, p.color);
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
                p1.Move(Direction.None, Direction.None, Direction.Upwards);
            if (keyData.Equals(Keys.A))
                p1.Move(Direction.Backwards, Direction.None, Direction.None);
            if (keyData.Equals(Keys.S))
                p1.Move(Direction.None, Direction.None, Direction.Downwards);
            if (keyData.Equals(Keys.D))
                p1.Move(Direction.Forwards, Direction.None, Direction.None);
            if (keyData.Equals(Keys.Up))
                p2.Move(Direction.None, Direction.None, Direction.Upwards);
            if (keyData.Equals(Keys.Down))
                p2.Move(Direction.None, Direction.None, Direction.Downwards);
            if (keyData.Equals(Keys.Left))
                p2.Move(Direction.Backwards, Direction.None, Direction.None);
            if (keyData.Equals(Keys.Right))
                p2.Move(Direction.Forwards, Direction.None, Direction.None);
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
                MessageBox.Show("Player 1 wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (player1Score < player2Score)
                MessageBox.Show("Player 2 wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("It's a draw!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            speed = 500;
        }
    }
}
