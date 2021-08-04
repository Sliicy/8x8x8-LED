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
    public partial class frmMusic : Form
    {
        private SerialPort serialPort;
        //private byte[] leftChannel = new byte[64];
        private double leftChannel = 0;
        private double rightChannel = 0;
        private bool animate = false;
        private int speed = 1;

        public frmMusic(SerialPort sp)
        {
            InitializeComponent();
            serialPort = sp;
        }

        IWaveIn waveIn = new WasapiLoopbackCapture();
        static void WaveIn_DataAvailable(object sender, WaveInEventArgs e, ref double leftAudio, ref double rightAudio)
        {
            for (int i = 0; i < e.BytesRecorded; i += 8)
            {
                float leftSample = BitConverter.ToSingle(e.Buffer, i);
                float rightSample = BitConverter.ToSingle(e.Buffer, i + 4);
                leftAudio = leftSample;
                rightAudio = rightSample;
            }
        }

        private void ChkSyncMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSyncMusic.Checked)
            {
                waveIn.DataAvailable += delegate (object sender2, WaveInEventArgs e2)
                { WaveIn_DataAvailable(sender2, e2, ref leftChannel, ref rightChannel); };

                //waveIn.DataAvailable += WaveIn_DataAvailable;
                waveIn.StartRecording();

                //System.Threading.Thread.Sleep(1000);
                animate = true;
                bwVisualize.RunWorkerAsync();

            } else
            {
                waveIn.StopRecording();
                animate = false;
                bwVisualize.CancelAsync();
            }
        }

        private void TmrMusic_Tick(object sender, EventArgs e)
        {
            
        }

        private void bwVisualize_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 0;
            while (animate)
            {
                //if (counter % 10 == 0)
                //{
                //Invoke((MethodInvoker)delegate {
                //    textBox1.Text += leftAudio.ToString() + Environment.NewLine;
                //});
                //}
                //counter++;
                byte[] audioChannelDepth = new byte[64];
                

                if (rbSingleBar.Checked)
                {
                    AnalyzeAudioSingleBar(audioChannelDepth, leftChannel, 0);
                    AnalyzeAudioSingleBar(audioChannelDepth, rightChannel, 32); // Offset by 32 for right channel

                } else if (rbFilled.Checked)
                {
                    AnalyzeAudioFilled(audioChannelDepth, leftChannel, 0);
                    AnalyzeAudioFilled(audioChannelDepth, rightChannel, 32);

                } else if (rbFloatingBar.Checked)
                {
                    AnalyzeAudioFloatingBar(audioChannelDepth, leftChannel, 0);
                    AnalyzeAudioFloatingBar(audioChannelDepth, rightChannel, 32);
                } else if (rbFloatingSquare.Checked)
                {
                    AnalyzeAudioFloatingSquare(audioChannelDepth, leftChannel, 0);
                    AnalyzeAudioFloatingSquare(audioChannelDepth, rightChannel, 32);
                } else if (rbTube.Checked)
                {
                    AnalyzeAudioTube(audioChannelDepth, leftChannel, 0);
                    AnalyzeAudioTube(audioChannelDepth, rightChannel, 32);
                } else if (rbMatrix.Checked)
                {
                    AnalyzeAudioMatrix(audioChannelDepth, leftChannel, rightChannel);
                }


                if ((Math.Abs(leftChannel) > 0.05 || Math.Abs(rightChannel) > 0.05) && counter % speed == 0)
                {
                    SerialHelper.Send(serialPort, audioChannelDepth);
                }

                /*
                if (Math.Abs(leftAudio) > 0.00001) // Ignore silence after 0.00001
                {
                    byte[] payloadClippedTo64 = new byte[64];

                    for (int i = 0; i < 64; i++)
                    {
                        try
                        {
                            payloadClippedTo64[i] = leftChannel[i];
                        } catch (Exception)
                        {
                            payloadClippedTo64[i] = 0;
                        }
                    
                    }
                    SerialHelper.Send(serialPort, payloadClippedTo64);
                   */
                counter++;
            }
            
        }

        private void AnalyzeAudioSingleBar(byte[] audioChannelDepth, double channel, int offset)
        {
            if (Math.Abs(channel) > .05 && Math.Abs(channel) <= .1)
            {
                audioChannelDepth[0 + offset] = 0xFF;
                audioChannelDepth[8 + offset] = 0xFF;
                audioChannelDepth[16 + offset] = 0xFF;
                audioChannelDepth[24 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .1 && Math.Abs(channel) <= .15)
            {
                audioChannelDepth[1 + offset] = 0xFF;
                audioChannelDepth[9 + offset] = 0xFF;
                audioChannelDepth[17 + offset] = 0xFF;
                audioChannelDepth[25 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .15 && Math.Abs(channel) <= .2)
            {
                audioChannelDepth[2 + offset] = 0xFF;
                audioChannelDepth[10 + offset] = 0xFF;
                audioChannelDepth[18 + offset] = 0xFF;
                audioChannelDepth[26 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .2 && Math.Abs(channel) <= .25)
            {
                audioChannelDepth[3 + offset] = 0xFF;
                audioChannelDepth[11 + offset] = 0xFF;
                audioChannelDepth[19 + offset] = 0xFF;
                audioChannelDepth[27 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .25 && Math.Abs(channel) <= .3)
            {
                audioChannelDepth[4 + offset] = 0xFF;
                audioChannelDepth[12 + offset] = 0xFF;
                audioChannelDepth[20 + offset] = 0xFF;
                audioChannelDepth[28 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .3 && Math.Abs(channel) <= .4)
            {
                audioChannelDepth[5 + offset] = 0xFF;
                audioChannelDepth[13 + offset] = 0xFF;
                audioChannelDepth[21 + offset] = 0xFF;
                audioChannelDepth[29 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .4 && Math.Abs(channel) <= .5)
            {
                audioChannelDepth[6 + offset] = 0xFF;
                audioChannelDepth[14 + offset] = 0xFF;
                audioChannelDepth[22 + offset] = 0xFF;
                audioChannelDepth[30 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .5)
            {
                audioChannelDepth[7 + offset] = 0xFF;
                audioChannelDepth[15 + offset] = 0xFF;
                audioChannelDepth[23 + offset] = 0xFF;
                audioChannelDepth[31 + offset] = 0xFF;
            }
        }

        private void AnalyzeAudioFilled(byte[] audioChannelDepth, double channel, int offset)
        {
            if (Math.Abs(channel) > .05)
            {
                audioChannelDepth[0 + offset] = 0xFF;
                audioChannelDepth[8 + offset] = 0xFF;
                audioChannelDepth[16 + offset] = 0xFF;
                audioChannelDepth[24 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .1)
            {
                audioChannelDepth[1 + offset] = 0xFF;
                audioChannelDepth[9 + offset] = 0xFF;
                audioChannelDepth[17 + offset] = 0xFF;
                audioChannelDepth[25 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .15)
            {
                audioChannelDepth[2 + offset] = 0xFF;
                audioChannelDepth[10 + offset] = 0xFF;
                audioChannelDepth[18 + offset] = 0xFF;
                audioChannelDepth[26 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .2)
            {
                audioChannelDepth[3 + offset] = 0xFF;
                audioChannelDepth[11 + offset] = 0xFF;
                audioChannelDepth[19 + offset] = 0xFF;
                audioChannelDepth[27 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .25)
            {
                audioChannelDepth[4 + offset] = 0xFF;
                audioChannelDepth[12 + offset] = 0xFF;
                audioChannelDepth[20 + offset] = 0xFF;
                audioChannelDepth[28 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .3)
            {
                audioChannelDepth[5 + offset] = 0xFF;
                audioChannelDepth[13 + offset] = 0xFF;
                audioChannelDepth[21 + offset] = 0xFF;
                audioChannelDepth[29 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .4)
            {
                audioChannelDepth[6 + offset] = 0xFF;
                audioChannelDepth[14 + offset] = 0xFF;
                audioChannelDepth[22 + offset] = 0xFF;
                audioChannelDepth[30 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .5)
            {
                audioChannelDepth[7 + offset] = 0xFF;
                audioChannelDepth[15 + offset] = 0xFF;
                audioChannelDepth[23 + offset] = 0xFF;
                audioChannelDepth[31 + offset] = 0xFF;
            }
        }

        private void AnalyzeAudioFloatingBar(byte[] audioChannelDepth, double channel, int offset)
        {
            if (Math.Abs(channel) > .05 && Math.Abs(channel) <= .1)
            {
                audioChannelDepth[0 + offset] = 0xFF;
                audioChannelDepth[8 + offset] = 0xFF;
                audioChannelDepth[16 + offset] = 0xFF;
                audioChannelDepth[24 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .1 && Math.Abs(channel) <= .15)
            {
                audioChannelDepth[1 + offset] = 0xFF;
                audioChannelDepth[9 + offset] = 0xFF;
                audioChannelDepth[17 + offset] = 0xFF;
                audioChannelDepth[25 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .15 && Math.Abs(channel) <= .2)
            {
                audioChannelDepth[2 + offset] = 0xFF;
                audioChannelDepth[10 + offset] = 0xFF;
                audioChannelDepth[18 + offset] = 0xFF;
                audioChannelDepth[26 + offset] = 0xFF;

                audioChannelDepth[0 + offset] = 0xFF;
                audioChannelDepth[8 + offset] = 0xFF;
                audioChannelDepth[16 + offset] = 0xFF;
                audioChannelDepth[24 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .2 && Math.Abs(channel) <= .25)
            {
                audioChannelDepth[3 + offset] = 0xFF;
                audioChannelDepth[11 + offset] = 0xFF;
                audioChannelDepth[19 + offset] = 0xFF;
                audioChannelDepth[27 + offset] = 0xFF;

                audioChannelDepth[1 + offset] = 0xFF;
                audioChannelDepth[9 + offset] = 0xFF;
                audioChannelDepth[17 + offset] = 0xFF;
                audioChannelDepth[25 + offset] = 0xFF;

                audioChannelDepth[0 + offset] = 0xFF;
                audioChannelDepth[8 + offset] = 0xFF;
                audioChannelDepth[16 + offset] = 0xFF;
                audioChannelDepth[24 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .25 && Math.Abs(channel) <= .3)
            {
                audioChannelDepth[4 + offset] = 0xFF;
                audioChannelDepth[12 + offset] = 0xFF;
                audioChannelDepth[20 + offset] = 0xFF;
                audioChannelDepth[28 + offset] = 0xFF;

                audioChannelDepth[2 + offset] = 0xFF;
                audioChannelDepth[10 + offset] = 0xFF;
                audioChannelDepth[18 + offset] = 0xFF;
                audioChannelDepth[26 + offset] = 0xFF;

                audioChannelDepth[1 + offset] = 0xFF;
                audioChannelDepth[9 + offset] = 0xFF;
                audioChannelDepth[17 + offset] = 0xFF;
                audioChannelDepth[25 + offset] = 0xFF;

                audioChannelDepth[0 + offset] = 0xFF;
                audioChannelDepth[8 + offset] = 0xFF;
                audioChannelDepth[16 + offset] = 0xFF;
                audioChannelDepth[24 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .3 && Math.Abs(channel) <= .4)
            {
                audioChannelDepth[5 + offset] = 0xFF;
                audioChannelDepth[13 + offset] = 0xFF;
                audioChannelDepth[21 + offset] = 0xFF;
                audioChannelDepth[29 + offset] = 0xFF;

                audioChannelDepth[3 + offset] = 0xFF;
                audioChannelDepth[11 + offset] = 0xFF;
                audioChannelDepth[19 + offset] = 0xFF;
                audioChannelDepth[27 + offset] = 0xFF;

                audioChannelDepth[2 + offset] = 0xFF;
                audioChannelDepth[10 + offset] = 0xFF;
                audioChannelDepth[18 + offset] = 0xFF;
                audioChannelDepth[26 + offset] = 0xFF;

                audioChannelDepth[1 + offset] = 0xFF;
                audioChannelDepth[9 + offset] = 0xFF;
                audioChannelDepth[17 + offset] = 0xFF;
                audioChannelDepth[25 + offset] = 0xFF;

                audioChannelDepth[0 + offset] = 0xFF;
                audioChannelDepth[8 + offset] = 0xFF;
                audioChannelDepth[16 + offset] = 0xFF;
                audioChannelDepth[24 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .4 && Math.Abs(channel) <= .5)
            {
                audioChannelDepth[6 + offset] = 0xFF;
                audioChannelDepth[14 + offset] = 0xFF;
                audioChannelDepth[22 + offset] = 0xFF;
                audioChannelDepth[30 + offset] = 0xFF;

                audioChannelDepth[4 + offset] = 0xFF;
                audioChannelDepth[12 + offset] = 0xFF;
                audioChannelDepth[20 + offset] = 0xFF;
                audioChannelDepth[28 + offset] = 0xFF;

                audioChannelDepth[3 + offset] = 0xFF;
                audioChannelDepth[11 + offset] = 0xFF;
                audioChannelDepth[19 + offset] = 0xFF;
                audioChannelDepth[27 + offset] = 0xFF;

                audioChannelDepth[2 + offset] = 0xFF;
                audioChannelDepth[10 + offset] = 0xFF;
                audioChannelDepth[18 + offset] = 0xFF;
                audioChannelDepth[26 + offset] = 0xFF;

                audioChannelDepth[1 + offset] = 0xFF;
                audioChannelDepth[9 + offset] = 0xFF;
                audioChannelDepth[17 + offset] = 0xFF;
                audioChannelDepth[25 + offset] = 0xFF;

                audioChannelDepth[0 + offset] = 0xFF;
                audioChannelDepth[8 + offset] = 0xFF;
                audioChannelDepth[16 + offset] = 0xFF;
                audioChannelDepth[24 + offset] = 0xFF;
            }
            if (Math.Abs(channel) > .5)
            {
                audioChannelDepth[7 + offset] = 0xFF;
                audioChannelDepth[15 + offset] = 0xFF;
                audioChannelDepth[23 + offset] = 0xFF;
                audioChannelDepth[31 + offset] = 0xFF;

                audioChannelDepth[5 + offset] = 0xFF;
                audioChannelDepth[13 + offset] = 0xFF;
                audioChannelDepth[21 + offset] = 0xFF;
                audioChannelDepth[29 + offset] = 0xFF;

                audioChannelDepth[4 + offset] = 0xFF;
                audioChannelDepth[12 + offset] = 0xFF;
                audioChannelDepth[20 + offset] = 0xFF;
                audioChannelDepth[28 + offset] = 0xFF;

                audioChannelDepth[3 + offset] = 0xFF;
                audioChannelDepth[11 + offset] = 0xFF;
                audioChannelDepth[19 + offset] = 0xFF;
                audioChannelDepth[27 + offset] = 0xFF;

                audioChannelDepth[2 + offset] = 0xFF;
                audioChannelDepth[10 + offset] = 0xFF;
                audioChannelDepth[18 + offset] = 0xFF;
                audioChannelDepth[26 + offset] = 0xFF;

                audioChannelDepth[1 + offset] = 0xFF;
                audioChannelDepth[9 + offset] = 0xFF;
                audioChannelDepth[17 + offset] = 0xFF;
                audioChannelDepth[25 + offset] = 0xFF;

                audioChannelDepth[0 + offset] = 0xFF;
                audioChannelDepth[8 + offset] = 0xFF;
                audioChannelDepth[16 + offset] = 0xFF;
                audioChannelDepth[24 + offset] = 0xFF;
            }
        }

        private void AnalyzeAudioFloatingSquare(byte[] audioChannelDepth, double channel, int offset)
        {
            if (Math.Abs(channel) > .05 && Math.Abs(channel) < .1)
            {

                audioChannelDepth[0 + offset] = 0x81;
                audioChannelDepth[8 + offset] = 0x81;
                audioChannelDepth[16 + offset] = 0x81;
                audioChannelDepth[24 + offset] = 0x81;
                if (offset == 0)
                {
                    audioChannelDepth[0] = 0xFF;
                } else
                {
                    audioChannelDepth[56] = 0xFF;
                }
                
                
            }
            if (Math.Abs(channel) > .1 && Math.Abs(channel) < .15)
            {
                audioChannelDepth[1 + offset] = 0x81;
                audioChannelDepth[9 + offset] = 0x81;
                audioChannelDepth[17 + offset] = 0x81;
                audioChannelDepth[25 + offset] = 0x81;
                if (offset == 0)
                    audioChannelDepth[1] = 0xFF;
                else
                audioChannelDepth[57] = 0xFF;
            }
            if (Math.Abs(channel) > .15 && Math.Abs(channel) < .2)
            {
                audioChannelDepth[2 + offset] = 0x81;
                audioChannelDepth[10 + offset] = 0x81;
                audioChannelDepth[18 + offset] = 0x81;
                audioChannelDepth[26 + offset] = 0x81;
                if (offset == 0)
                    audioChannelDepth[2] = 0xFF;
                else
                audioChannelDepth[58] = 0xFF;
            }
            if (Math.Abs(channel) > .2 && Math.Abs(channel) < .25)
            {
                audioChannelDepth[3 + offset] = 0x81;
                audioChannelDepth[11 + offset] = 0x81;
                audioChannelDepth[19 + offset] = 0x81;
                audioChannelDepth[27 + offset] = 0x81;
                if (offset == 0)
                    audioChannelDepth[3] = 0xFF;
                else
                audioChannelDepth[59] = 0xFF;
            }
            if (Math.Abs(channel) > .25 && Math.Abs(channel) < .3)
            {
                audioChannelDepth[4 + offset] = 0x81;
                audioChannelDepth[12 + offset] = 0x81;
                audioChannelDepth[20 + offset] = 0x81;
                audioChannelDepth[28 + offset] = 0x81;
                if (offset == 0)
                    audioChannelDepth[4] = 0xFF;
                else
                audioChannelDepth[60] = 0xFF;
            }
            if (Math.Abs(channel) > .3 && Math.Abs(channel) < .4)
            {
                audioChannelDepth[5 + offset] = 0x81;
                audioChannelDepth[13 + offset] = 0x81;
                audioChannelDepth[21 + offset] = 0x81;
                audioChannelDepth[29 + offset] = 0x81;
                if (offset == 0)
                    audioChannelDepth[5] = 0xFF;
                else
                audioChannelDepth[61] = 0xFF;
            }
            if (Math.Abs(channel) > .4 && Math.Abs(channel) < .5)
            {
                audioChannelDepth[6 + offset] = 0x81;
                audioChannelDepth[14 + offset] = 0x81;
                audioChannelDepth[22 + offset] = 0x81;
                audioChannelDepth[30 + offset] = 0x81;
                if (offset == 0)
                    audioChannelDepth[6] = 0xFF;
                else
                audioChannelDepth[62] = 0xFF;
            }
            if (Math.Abs(channel) > .5)
            {
                audioChannelDepth[7 + offset] = 0x81;
                audioChannelDepth[15 + offset] = 0x81;
                audioChannelDepth[23 + offset] = 0x81;
                audioChannelDepth[31 + offset] = 0x81;
                if (offset == 0)
                    audioChannelDepth[7] = 0xFF;
                else
                audioChannelDepth[63] = 0xFF;
            }
        }

        private void AnalyzeAudioTube(byte[] audioChannelDepth, double channel, int offset)
        {
            if (Math.Abs(channel) > .05)
            {
                
                audioChannelDepth[0 + offset] = 0x81;
                audioChannelDepth[8 + offset] = 0x81;
                audioChannelDepth[16 + offset] = 0x81;
                audioChannelDepth[24 + offset] = 0x81;
                audioChannelDepth[0] = 0xFF;
                audioChannelDepth[56] = 0xFF;
            }
            if (Math.Abs(channel) > .1)
            {
                audioChannelDepth[1 + offset] = 0x81;
                audioChannelDepth[9 + offset] = 0x81;
                audioChannelDepth[17 + offset] = 0x81;
                audioChannelDepth[25 + offset] = 0x81;
                audioChannelDepth[1] = 0xFF;
                audioChannelDepth[57] = 0xFF;
            }
            if (Math.Abs(channel) > .15)
            {
                audioChannelDepth[2 + offset] = 0x81;
                audioChannelDepth[10 + offset] = 0x81;
                audioChannelDepth[18 + offset] = 0x81;
                audioChannelDepth[26 + offset] = 0x81;
                audioChannelDepth[2] = 0xFF;
                audioChannelDepth[58] = 0xFF;
            }
            if (Math.Abs(channel) > .2)
            {
                audioChannelDepth[3 + offset] = 0x81;
                audioChannelDepth[11 + offset] = 0x81;
                audioChannelDepth[19 + offset] = 0x81;
                audioChannelDepth[27 + offset] = 0x81;
                audioChannelDepth[3] = 0xFF;
                audioChannelDepth[59] = 0xFF;
            }
            if (Math.Abs(channel) > .25)
            {
                audioChannelDepth[4 + offset] = 0x81;
                audioChannelDepth[12 + offset] = 0x81;
                audioChannelDepth[20 + offset] = 0x81;
                audioChannelDepth[28 + offset] = 0x81;
                audioChannelDepth[4] = 0xFF;
                audioChannelDepth[60] = 0xFF;
            }
            if (Math.Abs(channel) > .3)
            {
                audioChannelDepth[5 + offset] = 0x81;
                audioChannelDepth[13 + offset] = 0x81;
                audioChannelDepth[21 + offset] = 0x81;
                audioChannelDepth[29 + offset] = 0x81;
                audioChannelDepth[5] = 0xFF;
                audioChannelDepth[61] = 0xFF;
            }
            if (Math.Abs(channel) > .4)
            {
                audioChannelDepth[6 + offset] = 0x81;
                audioChannelDepth[14 + offset] = 0x81;
                audioChannelDepth[22 + offset] = 0x81;
                audioChannelDepth[30 + offset] = 0x81;
                audioChannelDepth[6] = 0xFF;
                audioChannelDepth[62] = 0xFF;
            }
            if (Math.Abs(channel) > .5)
            {
                audioChannelDepth[7 + offset] = 0x81;
                audioChannelDepth[15 + offset] = 0x81;
                audioChannelDepth[23 + offset] = 0x81;
                audioChannelDepth[31 + offset] = 0x81;
                audioChannelDepth[7] = 0xFF;
                audioChannelDepth[63] = 0xFF;
            }
        }

        private void AnalyzeAudioMatrix(byte[] audioChannelDepth, double leftChannel, double rightChannel)
        {
            leftChannel = Math.Abs(leftChannel);
            rightChannel = Math.Abs(rightChannel);


            double currentLevel = .05;
            audioChannelDepth[0] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[1] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[2] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            audioChannelDepth[5] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[6] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[7] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            currentLevel = .1;
            audioChannelDepth[8] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[9] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[10] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            audioChannelDepth[13] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[14] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[15] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            currentLevel = .15;
            audioChannelDepth[16] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[17] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[18] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            audioChannelDepth[21] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[22] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[23] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            currentLevel = .2;
            audioChannelDepth[24] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[25] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[26] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            audioChannelDepth[29] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[30] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[31] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));


            currentLevel = .25;
            audioChannelDepth[32] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[33] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[34] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            audioChannelDepth[37] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[38] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[39] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            currentLevel = .3;
            audioChannelDepth[40] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[41] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[42] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            audioChannelDepth[45] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[46] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[47] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            currentLevel = .4;
            audioChannelDepth[48] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[49] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[50] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            audioChannelDepth[53] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[54] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[55] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            currentLevel = .5;
            audioChannelDepth[56] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[57] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[58] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));

            audioChannelDepth[61] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[62] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
            audioChannelDepth[63] = Convert.ToByte((rightChannel > currentLevel ? 7 : 0) + (leftChannel > currentLevel ? 224 : 0));
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

        private void TrkResponsiveness_Scroll(object sender, EventArgs e)
        {
            speed = trkResponsiveness.Value;
        }
    }
}
