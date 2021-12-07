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
        public MusicRGB(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }
        private static void WaveIn_DataAvailable(WaveInEventArgs e, ref double[] eightChannels, int samples = 8, bool mirrorRightChannelToLeft = true)
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
        }

        private void MusicRGB_Load(object sender, EventArgs e)
        {
            //chkSyncMusic.Checked = true;
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
                switch (currentMusicStyle)
                {
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

                    }
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            cube.DrawPlane(Axis.Z, 7, CubeColor.Green);
            SerialHelper.Send(serialPort, cube);
        }
    }
}
