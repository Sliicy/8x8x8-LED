using _8x8x8_LED.Helpers;
using _8x8x8_LED.Models;
using _8x8x8_LED.Models.Geometry;
using _8x8x8_LED.Models.Pong;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.Views
{
    public partial class FrmBalls : Form
    {

        private readonly SerialPort serialPort;
        private readonly Cube cube;

        private readonly List<Ball> balls = new List<Ball>();

        private int speed = 50;
        private int timeElapsed = 0; // Used to adjust speed of animation

        private bool animate = true;
        private bool animateMusic = false;
        private bool teleport = false;
        private readonly Random random = new Random();

        private readonly int samples = 1024; // How many samples to calculate wave form from.
        private double[] twoChannels = new double[2]; // Holds 2 bytes of audio.

        readonly IWaveIn waveIn = new WasapiLoopbackCapture();

        public FrmBalls(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void FrmBalls_Load(object sender, EventArgs e)
        {
            cbPhysics.SelectedIndex = Properties.Settings.Default.Balls_Physics;
            btnAddBall.PerformClick();
            chkSyncMusic.Checked = Properties.Settings.Default.Balls_SyncToMusic;
            trkSpeed.Value = Properties.Settings.Default.Balls_Speed;
            bwEngine.RunWorkerAsync();
        }

        private void FrmBalls_FormClosing(object sender, FormClosingEventArgs e)
        {
            animate = false;
            if (bwEngine.IsBusy)
                bwEngine.CancelAsync();
            if (chkSyncMusic.Checked)
            {
                animateMusic = false;
                waveIn.StopRecording();
            }
            Properties.Settings.Default.Save();
        }

        private void BtnAddBall_Click(object sender, EventArgs e)
        {
            bool restartWhenReady = chkSyncMusic.Checked;
            chkSyncMusic.Checked = false;
            Ball b = new Ball
            {
                color = ColorHelper.RandomDarkColor(false)
            };
            int randomNumber = random.Next(1, 4);
            if (randomNumber == 1)
                b.directionX = Direction.Backwards;
            else if (randomNumber == 2)
                b.directionX = Direction.Forwards;

            randomNumber = random.Next(1, 4);

            if (randomNumber == 1)
                b.directionY = Direction.Leftwards;
            else if (randomNumber == 2)
                b.directionY = Direction.Rightwards;

            randomNumber = random.Next(1, 4);

            if (randomNumber == 1)
                b.directionZ = Direction.Upwards;
            else if (randomNumber == 2)
                b.directionZ = Direction.Downwards;

            b.location.SetX(random.Next(0, 8));
            b.location.SetY(random.Next(0, 8));
            b.location.SetZ(random.Next(0, 8));

            // If ball isn't moving, default to downwards:
            if (b.directionX != Direction.Backwards &&
                b.directionX != Direction.Forwards &&
                b.directionY != Direction.Leftwards &&
                b.directionY != Direction.Rightwards &&
                b.directionZ != Direction.Upwards &&
                b.directionZ != Direction.Downwards)
            {
                b.directionZ = Direction.Downwards;
            }

            balls.Add(b);
            System.Threading.Thread.Sleep(100);
            chkSyncMusic.Checked = restartWhenReady;
        }

        private void BtnRemoveBall_Click(object sender, EventArgs e)
        {
            bool restartWhenReady = chkSyncMusic.Checked;
            chkSyncMusic.Checked = false;
            if (balls.Count > 0)
                balls.RemoveAt(0);
            System.Threading.Thread.Sleep(100);
            chkSyncMusic.Checked = restartWhenReady;
        }

        private void TrkSpeed_Scroll(object sender, EventArgs e)
        {
            speed = trkSpeed.Value;
            lblSpeed.Text = "&Speed (" + speed + "):";
            Properties.Settings.Default.Balls_Speed = speed;
        }

        private void BwEngine_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                cube.Clear();
                if ((animateMusic && Math.Abs(twoChannels[0]) > 0.05 && timeElapsed % speed == 0) || !animateMusic)
                {
                    foreach (Ball b in balls)
                    {
                        b.Move(teleport);
                        cube.DrawPoint(b.location.GetX(), b.location.GetY(), b.location.GetZ(), b.color);
                    }
                }

                if (animateMusic)
                {
                    if (Math.Abs(twoChannels[0]) < .05) speed = 45000;
                    if (Math.Abs(twoChannels[0]) > .05) speed = 40000;
                    if (Math.Abs(twoChannels[0]) > .1) speed = 35000;
                    if (Math.Abs(twoChannels[0]) > .15) speed = 30000;
                    if (Math.Abs(twoChannels[0]) > .2) speed = 25000;
                    if (Math.Abs(twoChannels[0]) > .25) speed = 20000;
                    if (Math.Abs(twoChannels[0]) > .3) speed = 15000;
                    if (Math.Abs(twoChannels[0]) > .4) speed = 10000;
                    if (Math.Abs(twoChannels[0]) > .5) speed = 5000;
                    if ((Math.Abs(twoChannels[0]) > 0.05) && timeElapsed % speed == 0)
                        SerialHelper.Send(serialPort, cube);
                }
                else
                {
                    SerialHelper.Send(serialPort, cube);
                    System.Threading.Thread.Sleep(speed);
                }
                timeElapsed++;
            }
        }

        private void CbPhysics_SelectedIndexChanged(object sender, EventArgs e)
        {
            teleport = cbPhysics.Text == "Portal";
            Properties.Settings.Default.Balls_Physics = cbPhysics.SelectedIndex;
        }

        private void ChkSyncMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSyncMusic.Checked)
            {
                waveIn.DataAvailable += delegate (object sender2, WaveInEventArgs e2)
                { WaveIn_DataAvailable(e2, ref twoChannels, samples); };
                waveIn.StartRecording();
                animateMusic = true;
            }
            else
            {
                waveIn.StopRecording();
                animateMusic = false;
                speed = trkSpeed.Value;
            }
            trkSpeed.Enabled = !chkSyncMusic.Checked;
            Properties.Settings.Default.Balls_SyncToMusic = chkSyncMusic.Checked;
        }

        private static void WaveIn_DataAvailable(WaveInEventArgs e, ref double[] twoChannels, int samples = 8)
        {
            try
            {
                for (int i = 0; i < e.BytesRecorded; i += samples)
                {
                    twoChannels[0] = BitConverter.ToSingle(e.Buffer, i);
                    twoChannels[1] = BitConverter.ToSingle(e.Buffer, i + 4);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
