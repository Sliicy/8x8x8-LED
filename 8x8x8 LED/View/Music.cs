using _8x8x8_LED.Model;
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

namespace _8x8x8_LED.Apps
{
    public partial class FrmMusic : Form
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

        readonly IWaveIn waveIn = new WasapiLoopbackCapture();

        public FrmMusic(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        static void WaveIn_DataAvailable(WaveInEventArgs e, ref double[] eightChannels, int samples = 8, bool mirrorRightChannelToLeft = true)
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
                } else
                {
                    eightChannels[4] = BitConverter.ToSingle(e.Buffer, i + 4);
                    eightChannels[5] = BitConverter.ToSingle(e.Buffer, i + 4 + samples / 4);
                    eightChannels[6] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 2);
                    eightChannels[7] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 3);
                }
            }
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

            } else
            {
                waveIn.StopRecording();
                animate = false;
                bwVisualize.CancelAsync();
            }
        }

        private void BwVisualize_DoWork(object sender, DoWorkEventArgs e)
        {
            int timeUntilNextShuffledAnimation = 0;

            while (animate)
            {
                byte[] arrayOutput = new byte[64];

                if (rbFloatingLines.Checked)
                {
                    AnimateBars(arrayOutput, eightChannels, 255, false);
                } else if (rbFloatingDots.Checked)
                {
                    AnimateBars(arrayOutput, eightChannels, 1, false);
                } else if (rbSolidLines.Checked)
                {
                    AnimateBars(arrayOutput, eightChannels, 255, true);
                } else if (rbSolidDots.Checked)
                {
                    AnimateBars(arrayOutput, eightChannels, 1, true);
                } else if (rbMatrix.Checked)
                {
                    AnimateMatrix(arrayOutput, eightChannels);
                } else if (rbCenteredFloatingLines.Checked)
                {
                    AnimateCenteredBars(arrayOutput, eightChannels, thickness: 255, false);
                } else if (rbCenteredFloatingDots.Checked)
                {
                    AnimateCenteredBars(arrayOutput, eightChannels, thickness: 1, false);
                }
                else if (rbCenteredSolidLines.Checked)
                {
                    AnimateCenteredBars(arrayOutput, eightChannels, thickness: 255, true);
                }
                else if (rbCenteredSolidDots.Checked)
                {
                    AnimateCenteredBars(arrayOutput, eightChannels, thickness: 1, true);
                } else if (rbShuffled.Checked)
                {
                    if (timeUntilNextShuffledAnimation > 0)
                    {
                        timeUntilNextShuffledAnimation--;
                    } else
                    {
                        timeUntilNextShuffledAnimation = 10000;
                        Random random = new Random();
                        previousShuffle = random.Next(1, 10);
                    }
                    switch (previousShuffle)
                    {
                        case 1:
                            AnimateBars(arrayOutput, eightChannels, 255, false);
                            break;
                        case 2:
                            AnimateBars(arrayOutput, eightChannels, 1, false);
                            break;
                        case 3:
                            AnimateBars(arrayOutput, eightChannels, 255, true);
                            break;
                        case 4:
                            AnimateBars(arrayOutput, eightChannels, 1, true);
                            break;
                        case 5:
                            AnimateMatrix(arrayOutput, eightChannels);
                            break;
                        case 6:
                            AnimateCenteredBars(arrayOutput, eightChannels, thickness: 255, false);
                            break;
                        case 7:
                            AnimateCenteredBars(arrayOutput, eightChannels, thickness: 1, false);
                            break;
                        case 8:
                            AnimateCenteredBars(arrayOutput, eightChannels, thickness: 1, true);
                            break;
                        case 9:
                            AnimateCenteredBars(arrayOutput, eightChannels, thickness: 1, true);
                            break;
                    }
                    
                }

                // Ensure that audio has activity, and the speed of detection is properly set:
                if ((Math.Abs(eightChannels[0]) > 0.05 || Math.Abs(eightChannels[5]) > 0.05) && timeElapsed % speed == 0)
                {
                    arrayOutput.CopyTo(cube.matrix, 0);
                    SerialHelper.Send(serialPort, cube);
                    matrixIsCleared = false;
                } else
                {
                    if (!matrixIsCleared) // Do this only once:
                    {
                        arrayOutput = new byte[64]; // Clear the screen.
                        if (chkShowSilence.Checked)
                        {
                            if (rbFloatingLines.Checked || rbSolidLines.Checked)
                            {
                                arrayOutput[0] = arrayOutput[8] = arrayOutput[16] =
                                arrayOutput[24] = arrayOutput[32] = arrayOutput[40] =
                                arrayOutput[48] = arrayOutput[56] = 255;
                            }
                            else if (rbCenteredFloatingLines.Checked || rbCenteredSolidLines.Checked)
                            {
                                arrayOutput[3] = arrayOutput[11] = arrayOutput[19] =
                                arrayOutput[27] = arrayOutput[35] = arrayOutput[43] =
                                arrayOutput[51] = arrayOutput[59] = 255;
                            }
                            else if (rbCenteredFloatingDots.Checked || rbCenteredSolidDots.Checked)
                            {
                                arrayOutput[3] = arrayOutput[11] = arrayOutput[19] =
                                arrayOutput[27] = arrayOutput[35] = arrayOutput[43] =
                                arrayOutput[51] = arrayOutput[59] = 1;
                            }
                            else if (rbMatrix.Checked)
                            {
                                arrayOutput[0] = arrayOutput[8] = arrayOutput[16] =
                                arrayOutput[40] = arrayOutput[48] = arrayOutput[56] = 231;
                            }
                            else if (rbSolidDots.Checked || rbFloatingDots.Checked)
                            {
                                arrayOutput[0] = arrayOutput[8] = arrayOutput[16] =
                                arrayOutput[24] = arrayOutput[32] = arrayOutput[40] =
                                arrayOutput[48] = arrayOutput[56] = 1;
                            }
                            else if (rbShuffled.Checked)
                            {
                                Random random = new Random();
                                arrayOutput[0] = Convert.ToByte(random.Next(0, 256));
                                arrayOutput[8] = Convert.ToByte(random.Next(0, 256));
                                arrayOutput[16] = Convert.ToByte(random.Next(0, 256));
                                arrayOutput[24] = Convert.ToByte(random.Next(0, 256));
                                arrayOutput[32] = Convert.ToByte(random.Next(0, 256));
                                arrayOutput[40] = Convert.ToByte(random.Next(0, 256));
                                arrayOutput[48] = Convert.ToByte(random.Next(0, 256));
                                arrayOutput[56] = Convert.ToByte(random.Next(0, 256));
                            }
                        }

                        arrayOutput.CopyTo(cube.matrix, 0);
                        SerialHelper.Send(serialPort, cube);
                        matrixIsCleared = true;
                    }

                    
                }
                timeElapsed++;
            }
        }

        private void AnimateBars(byte[] arrayOutput, double[] channels, byte thickness, bool filledUnderneath = false)
        {
            int channelIndex = 0;
            foreach (double channel in channels)
            {
                if (Math.Abs(channel) > .05 && (filledUnderneath || Math.Abs(channel) <= .1))
                {
                    arrayOutput[channelIndex * 8] = thickness;
                }
                if (Math.Abs(channel) > .1 && (filledUnderneath || Math.Abs(channel) <= .15))
                {
                    arrayOutput[channelIndex * 8 + 1] = thickness;
                }
                if (Math.Abs(channel) > .15 && (filledUnderneath || Math.Abs(channel) <= .2))
                {
                    arrayOutput[channelIndex * 8 + 2] = thickness;
                }
                if (Math.Abs(channel) > .2 && (filledUnderneath || Math.Abs(channel) <= .25))
                {
                    arrayOutput[channelIndex * 8 + 3] = thickness;
                }
                if (Math.Abs(channel) > .25 && (filledUnderneath || Math.Abs(channel) <= .3))
                {
                    arrayOutput[channelIndex * 8 + 4] = thickness;
                }
                if (Math.Abs(channel) > .3 && (filledUnderneath || Math.Abs(channel) <= .4))
                {
                    arrayOutput[channelIndex * 8 + 5] = thickness;
                }
                if (Math.Abs(channel) > .4 && (filledUnderneath || Math.Abs(channel) <= .5))
                {
                    arrayOutput[channelIndex * 8 + 6] = thickness;
                }
                if (Math.Abs(channel) > .5)
                {
                    arrayOutput[channelIndex * 8 + 7] = thickness;
                }
                channelIndex++;
            }
        }

        private void AnimateMatrix(byte[] arrayOutput, double[] channels)
        {
            channels[0] = Math.Abs(channels[0]);
            channels[1] = Math.Abs(channels[1]);
            channels[2] = Math.Abs(channels[2]);
            channels[5] = Math.Abs(channels[5]);
            channels[6] = Math.Abs(channels[6]);
            channels[7] = Math.Abs(channels[7]);

            double currentLevel = .05;
            arrayOutput[0] = Convert.ToByte((channels[5] > currentLevel ? 7 : 0) + (channels[0] > currentLevel ? 224 : 0));
            arrayOutput[8] = Convert.ToByte((channels[6] > currentLevel ? 7 : 0) + (channels[1] > currentLevel ? 224 : 0));
            arrayOutput[16] = Convert.ToByte((channels[7] > currentLevel ? 7 : 0) + (channels[2] > currentLevel ? 224 : 0));

            arrayOutput[40] = Convert.ToByte((channels[0] > currentLevel ? 7 : 0) + (channels[5] > currentLevel ? 224 : 0));
            arrayOutput[48] = Convert.ToByte((channels[1] > currentLevel ? 7 : 0) + (channels[6] > currentLevel ? 224 : 0));
            arrayOutput[56] = Convert.ToByte((channels[2] > currentLevel ? 7 : 0) + (channels[7] > currentLevel ? 224 : 0));

            currentLevel = .1;
            arrayOutput[1] = Convert.ToByte((channels[5] > currentLevel ? 7 : 0) + (channels[0] > currentLevel ? 224 : 0));
            arrayOutput[9] = Convert.ToByte((channels[6] > currentLevel ? 7 : 0) + (channels[1] > currentLevel ? 224 : 0));
            arrayOutput[17] = Convert.ToByte((channels[7] > currentLevel ? 7 : 0) + (channels[2] > currentLevel ? 224 : 0));

            arrayOutput[41] = Convert.ToByte((channels[0] > currentLevel ? 7 : 0) + (channels[5] > currentLevel ? 224 : 0));
            arrayOutput[49] = Convert.ToByte((channels[1] > currentLevel ? 7 : 0) + (channels[6] > currentLevel ? 224 : 0));
            arrayOutput[57] = Convert.ToByte((channels[2] > currentLevel ? 7 : 0) + (channels[7] > currentLevel ? 224 : 0));

            currentLevel = .15;
            arrayOutput[2] = Convert.ToByte((channels[5] > currentLevel ? 7 : 0) + (channels[0] > currentLevel ? 224 : 0));
            arrayOutput[10] = Convert.ToByte((channels[6] > currentLevel ? 7 : 0) + (channels[1] > currentLevel ? 224 : 0));
            arrayOutput[18] = Convert.ToByte((channels[7] > currentLevel ? 7 : 0) + (channels[2] > currentLevel ? 224 : 0));

            arrayOutput[42] = Convert.ToByte((channels[0] > currentLevel ? 7 : 0) + (channels[5] > currentLevel ? 224 : 0));
            arrayOutput[50] = Convert.ToByte((channels[1] > currentLevel ? 7 : 0) + (channels[6] > currentLevel ? 224 : 0));
            arrayOutput[58] = Convert.ToByte((channels[2] > currentLevel ? 7 : 0) + (channels[7] > currentLevel ? 224 : 0));

            currentLevel = .2;
            arrayOutput[3] = Convert.ToByte((channels[5] > currentLevel ? 7 : 0) + (channels[0] > currentLevel ? 224 : 0));
            arrayOutput[11] = Convert.ToByte((channels[6] > currentLevel ? 7 : 0) + (channels[1] > currentLevel ? 224 : 0));
            arrayOutput[19] = Convert.ToByte((channels[7] > currentLevel ? 7 : 0) + (channels[2] > currentLevel ? 224 : 0));

            arrayOutput[43] = Convert.ToByte((channels[0] > currentLevel ? 7 : 0) + (channels[5] > currentLevel ? 224 : 0));
            arrayOutput[51] = Convert.ToByte((channels[1] > currentLevel ? 7 : 0) + (channels[6] > currentLevel ? 224 : 0));
            arrayOutput[59] = Convert.ToByte((channels[2] > currentLevel ? 7 : 0) + (channels[7] > currentLevel ? 224 : 0));


            currentLevel = .25;
            arrayOutput[4] = Convert.ToByte((channels[5] > currentLevel ? 7 : 0) + (channels[0] > currentLevel ? 224 : 0));
            arrayOutput[12] = Convert.ToByte((channels[6] > currentLevel ? 7 : 0) + (channels[1] > currentLevel ? 224 : 0));
            arrayOutput[20] = Convert.ToByte((channels[7] > currentLevel ? 7 : 0) + (channels[2] > currentLevel ? 224 : 0));

            arrayOutput[44] = Convert.ToByte((channels[0] > currentLevel ? 7 : 0) + (channels[5] > currentLevel ? 224 : 0));
            arrayOutput[52] = Convert.ToByte((channels[1] > currentLevel ? 7 : 0) + (channels[6] > currentLevel ? 224 : 0));
            arrayOutput[60] = Convert.ToByte((channels[2] > currentLevel ? 7 : 0) + (channels[7] > currentLevel ? 224 : 0));

            currentLevel = .3;
            arrayOutput[5] = Convert.ToByte((channels[5] > currentLevel ? 7 : 0) + (channels[0] > currentLevel ? 224 : 0));
            arrayOutput[13] = Convert.ToByte((channels[6] > currentLevel ? 7 : 0) + (channels[1] > currentLevel ? 224 : 0));
            arrayOutput[21] = Convert.ToByte((channels[7] > currentLevel ? 7 : 0) + (channels[2] > currentLevel ? 224 : 0));

            arrayOutput[45] = Convert.ToByte((channels[0] > currentLevel ? 7 : 0) + (channels[5] > currentLevel ? 224 : 0));
            arrayOutput[53] = Convert.ToByte((channels[1] > currentLevel ? 7 : 0) + (channels[6] > currentLevel ? 224 : 0));
            arrayOutput[61] = Convert.ToByte((channels[2] > currentLevel ? 7 : 0) + (channels[7] > currentLevel ? 224 : 0));

            currentLevel = .4;
            arrayOutput[6] = Convert.ToByte((channels[5] > currentLevel ? 7 : 0) + (channels[0] > currentLevel ? 224 : 0));
            arrayOutput[14] = Convert.ToByte((channels[6] > currentLevel ? 7 : 0) + (channels[1] > currentLevel ? 224 : 0));
            arrayOutput[22] = Convert.ToByte((channels[7] > currentLevel ? 7 : 0) + (channels[2] > currentLevel ? 224 : 0));

            arrayOutput[46] = Convert.ToByte((channels[0] > currentLevel ? 7 : 0) + (channels[5] > currentLevel ? 224 : 0));
            arrayOutput[54] = Convert.ToByte((channels[1] > currentLevel ? 7 : 0) + (channels[6] > currentLevel ? 224 : 0));
            arrayOutput[62] = Convert.ToByte((channels[2] > currentLevel ? 7 : 0) + (channels[7] > currentLevel ? 224 : 0));

            currentLevel = .5;
            arrayOutput[7] = Convert.ToByte((channels[5] > currentLevel ? 7 : 0) + (channels[0] > currentLevel ? 224 : 0));
            arrayOutput[15] = Convert.ToByte((channels[6] > currentLevel ? 7 : 0) + (channels[1] > currentLevel ? 224 : 0));
            arrayOutput[23] = Convert.ToByte((channels[7] > currentLevel ? 7 : 0) + (channels[2] > currentLevel ? 224 : 0));

            arrayOutput[47] = Convert.ToByte((channels[0] > currentLevel ? 7 : 0) + (channels[5] > currentLevel ? 224 : 0));
            arrayOutput[55] = Convert.ToByte((channels[1] > currentLevel ? 7 : 0) + (channels[6] > currentLevel ? 224 : 0));
            arrayOutput[63] = Convert.ToByte((channels[2] > currentLevel ? 7 : 0) + (channels[7] > currentLevel ? 224 : 0));
        }

        readonly int[] da_map = { // Direction Of Audio Render Channels:
                03, 02, 01, 00, 04, 05, 06, 07,
                11, 10, 09, 08, 12, 13, 14, 15,
                19, 18, 17, 16, 20, 21, 22, 23,
                27, 26, 25, 24, 28, 29, 30, 31,
                35, 34, 33, 32, 36, 37, 38, 39,
                43, 42, 41, 40, 44, 45, 46, 47,
                51, 50, 49, 48, 52, 53, 54, 55,
                59, 58, 57, 56, 60, 61, 62, 63
            };
        
        private void AnimateCenteredBars(byte[] audioChannelDepth, double[] channels, byte thickness = 1, bool filledUnderneath = false)
        {
            int channelIndex = 0;
            int renderIndex = 0;
            foreach (double channel in channels)
            {

                // Negatives for Channel i:
                if (channels[channelIndex] <= -.05 && (filledUnderneath || channels[channelIndex] > -.15))
                {
                    audioChannelDepth[da_map[renderIndex]] = thickness;
                }
                if (channels[channelIndex] <= -.15 && (filledUnderneath || channels[channelIndex] > -.25))
                {
                    audioChannelDepth[da_map[renderIndex + 1]] = thickness;
                }
                if (channels[channelIndex] <= -.25 && (filledUnderneath || channels[channelIndex] > -.35))
                {
                    audioChannelDepth[da_map[renderIndex + 2]] = thickness;
                }
                if (channels[channelIndex] <= -.35)
                {
                    audioChannelDepth[da_map[renderIndex + 3]] = thickness;
                }

                // Positives for Channel i:
                if (channels[channelIndex] >= .05 && (filledUnderneath || channels[channelIndex] < .15))
                {
                    audioChannelDepth[da_map[renderIndex + 4]] = thickness;
                }
                if (channels[channelIndex] >= .15 && (filledUnderneath || channels[channelIndex] < .25))
                {
                    audioChannelDepth[da_map[renderIndex + 5]] = thickness;
                }
                if (channels[channelIndex] >= .25 && (filledUnderneath || channels[channelIndex] < .35))
                {
                    audioChannelDepth[da_map[renderIndex + 6]] = thickness;
                }
                if (channels[channelIndex] >= .35)
                {
                    audioChannelDepth[da_map[renderIndex + 7]] = thickness;
                }

                channelIndex++;
                renderIndex += 8;
            }
        }

        private void FrmMusic_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkSyncMusic.Checked)
            {
                waveIn.StopRecording();
                animate = false;
                bwVisualize.CancelAsync();
            }
        }

        private void TrkSamples_Scroll(object sender, EventArgs e)
        {
            chkSyncMusic.Checked = false;
            samples = trkSamples.Value;
            lblSamples.Text = "Samples (" + samples + "):";
        }

        private void ChkShowSilence_CheckedChanged(object sender, EventArgs e)
        {
            matrixIsCleared = false;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            matrixIsCleared = false;
        }

        private void FrmMusic_Load(object sender, EventArgs e)
        {
            chkSyncMusic.Checked = true;
            cbResponsiveness.SelectedIndex = 0;
        }

        private void CbResponsiveness_SelectedIndexChanged(object sender, EventArgs e)
        {
            speed = int.Parse(cbResponsiveness.SelectedItem.ToString());
        }
    }
}
