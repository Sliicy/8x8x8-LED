using _8x8x8_LED.Helpers;
using _8x8x8_LED.Model;
using _8x8x8_LED.Models;
using NAudio.Wave;
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

namespace _8x8x8_LED
{
    public partial class MusicRGB : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;

        private int samples = 1024; // How many samples to calculate wave form from.

        private double[] eightChannels = new double[8]; // Holds 8 bytes of audio.

        private bool matrixIsCleared = false; // Controls whether to clear the screen if no audio is playing.
        private int previousShuffle = 0; // Last animation used if shuffling.

        private bool animate = false; // Whether to animate the visualizer.
        private int speed = 1; // Speed of animation.
        private int timeElapsed = 0; // Used to adjust speed of animation

        private readonly IWaveIn waveIn = new WasapiLoopbackCapture();

        private string currentMusicStyle = "";

        private int lineCount = 1;
        private CubeColor targetColor = CubeColor.White;
        private bool rainbowMode = false;
        public MusicRGB(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }
        private static void WaveIn_DataAvailable(WaveInEventArgs e, ref double[] eightChannels, int samples = 8, bool mirrorRightChannelToLeft = true)
        {
            try
            {
                for (int i = 0; i < e.BytesRecorded; i += samples)
                {
                    eightChannels[0] = BitConverter.ToSingle(e.Buffer, i);
                    eightChannels[1] = BitConverter.ToSingle(e.Buffer, i + samples / 4);
                    eightChannels[2] = BitConverter.ToSingle(e.Buffer, i + (samples / 4) * 2);
                    eightChannels[3] = BitConverter.ToSingle(e.Buffer, i + (samples / 4) * 3);
                    if (mirrorRightChannelToLeft)
                    {
                        eightChannels[7] = BitConverter.ToSingle(e.Buffer, i + 4);
                        eightChannels[6] = BitConverter.ToSingle(e.Buffer, i + 4 + samples / 4);
                        eightChannels[5] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 2);
                        eightChannels[4] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 3);
                    }
                    else
                    {
                        eightChannels[4] = BitConverter.ToSingle(e.Buffer, i + 4);
                        eightChannels[5] = BitConverter.ToSingle(e.Buffer, i + 4 + samples / 4);
                        eightChannels[6] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 2);
                        eightChannels[7] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 3);
                    }
                }
            } catch (Exception) {

            }
        }

        private void MusicRGB_Load(object sender, EventArgs e)
        {
            chkSyncMusic.Checked = true;
            cbColor.DataSource = Enum.GetValues(typeof(CubeColor));
            chkRainbow.Checked = true;
            cbMusicStyle.SelectedIndex = 0;
        }

        private void ChkSyncMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSyncMusic.Checked)
            {
                waveIn.DataAvailable += delegate (object sender2, WaveInEventArgs e2)
                { WaveIn_DataAvailable(e2, ref eightChannels, samples, chkMirrored.Checked); };

                waveIn.StartRecording();

                animate = true;
                bwVisualize.RunWorkerAsync();
            }
            else
            {
                waveIn.StopRecording();
                animate = false;
                bwVisualize.CancelAsync();
            }
        }

        private void ChkShowSilence_CheckedChanged(object sender, EventArgs e)
        {
            matrixIsCleared = false;
        }

        private void TrkSamples_Scroll(object sender, EventArgs e)
        {
            chkSyncMusic.Checked = false;
            samples = trkSamples.Value;
            lblSamples.Text = "Samples (" + samples + "):";
        }

        private void CbResponsiveness_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbResponsiveness.Text != "")
                speed = int.Parse(cbResponsiveness.SelectedItem.ToString());
        }

        private void CbMusicStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            matrixIsCleared = false;
            currentMusicStyle = cbMusicStyle.Text;
        }

        private void BwVisualize_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                
                //for (int i = 0; i < lineCount; i++)
                //{
                    //cube.DrawLine(random.Next(0, 8), random.Next(0, 8), random.Next(0, 8), random.Next(0, 8), random.Next(0, 8), random.Next(0, 8), rainbowMode ? ColorHelper.RandomColor(): targetColor);
                //}
                
                //SerialHelper.Send(serialPort, cube);
                switch (currentMusicStyle)
                {
                    case "Electro Ball":
                        ElectroBall(eightChannels);
                        break;
                    case "Floating Lines":
                        break;
                    case "Floating Dots":
                
                        break;
                    case "Solid Lines":
                
                        break;
                    case "Solid Dots":
                
                        break;
                    case "Matrix":
                
                        break;
                    case "Centered Floating Lines":
                
                        break;
                    case "Centered Floating Dots":
                
                        break;
                    case "Centered Solid Lines":
                
                        break;
                    case "Centered Solid Dots":
                
                        break;
                }
                
                // Animate as normal if there is audio activity:
                if ((Math.Abs(eightChannels[0]) > 0.05 || Math.Abs(eightChannels[5]) > 0.05) && timeElapsed % speed == 0)
                {
                    SerialHelper.Send(serialPort, cube);
                    matrixIsCleared = false;
                }
                else
                {
                    if (!matrixIsCleared) // Animate silence only once:
                    {
                        cube.DrawLine(3, 3, 3, 3, 3, 3, rainbowMode ? ColorHelper.RandomColor() : targetColor);
                        SerialHelper.Send(serialPort, cube);
                        matrixIsCleared = true;
                    }
                }
                timeElapsed++;
            }
        }

        private void MusicRGB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkSyncMusic.Checked)
            {
                waveIn.StopRecording();
                animate = false;
                bwVisualize.CancelAsync();
            }
        }

        private void ElectroBall(double[] channels)
        {
            int channelIndex = 0;
            int xStart = 3;
            int xEnd = 4;

            foreach (double channel in channels)
            {
                if (Math.Abs(channel) > .05 && Math.Abs(channel) <= .1)
                {
                    xStart = 3;
                    xEnd = 4;
                }
                if (Math.Abs(channel) > .1 && Math.Abs(channel) <= .15)
                {
                    xStart = 3;
                    xEnd = 4;
                }
                if (Math.Abs(channel) > .15 && Math.Abs(channel) <= .2)
                {
                    xStart = 2;
                    xEnd = 5;
                }
                if (Math.Abs(channel) > .2 && Math.Abs(channel) <= .25)
                {
                    xStart = 2;
                    xEnd = 5;
                }
                if (Math.Abs(channel) > .25 && Math.Abs(channel) <= .3)
                {
                    xStart = 1;
                    xEnd = 6;
                }
                if (Math.Abs(channel) > .3 && Math.Abs(channel) <= .4)
                {
                    xStart = 1;
                    xEnd = 6;
                }
                if (Math.Abs(channel) > .4 && Math.Abs(channel) <= .5)
                {
                    xStart = 0;
                    xEnd = 7;
                }
                if (Math.Abs(channel) > .5)
                {
                    xStart = 0;
                    xEnd = 7;
                }
                channelIndex++;
            }
            Random random = new Random();
            cube.Clear();
            for (int i = 0; i < lineCount; i++)
                cube.DrawLine(random.Next(xStart, xEnd + 1), random.Next(xStart, xEnd + 1), random.Next(xStart, xEnd + 1), random.Next(xStart, xEnd + 1), random.Next(xStart, xEnd + 1), random.Next(xStart, xEnd + 1), rainbowMode ? ColorHelper.RandomColor() : targetColor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cube.DrawPlane(Axis.X, 7, CubeColor.Green);
            Animate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Animate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Animate();
        }

        private void Animate()
        {
            cube.Clear();
            //cube.DrawLine(1, 3, 6, 5, 2, 2, CubeColor.Cyan);
            cube.DrawLine(trackBar1.Value, trackBar3.Value, trackBar5.Value, trackBar2.Value, trackBar4.Value, trackBar6.Value, CubeColor.Cyan);
            
            SerialHelper.Send(serialPort, cube);
        }

        private void NudLineCount_ValueChanged(object sender, EventArgs e)
        {
            lineCount = (int)nudLineCount.Value;
        }

        private void CbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetColor = (CubeColor)Enum.Parse(typeof(CubeColor), cbColor.Text);
        }

        private void ChkRainbow_CheckedChanged(object sender, EventArgs e)
        {
            rainbowMode = chkRainbow.Checked;
        }
    }
}
