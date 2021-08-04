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
        private byte[] leftChannel = new byte[64];
        private double leftAudio = 0;
        private float rightChannel = 0;
        private bool animate = false;

        public frmMusic(SerialPort sp)
        {
            InitializeComponent();
            serialPort = sp;
        }

        IWaveIn waveIn = new WasapiLoopbackCapture();
        static void WaveIn_DataAvailable(object sender, WaveInEventArgs e, ref byte[] leftChannel, ref double leftAudio)
        {
            for (int i = 0; i < e.BytesRecorded; i += 8)
            {
                float leftSample = BitConverter.ToSingle(e.Buffer, i);
                float rightSample = BitConverter.ToSingle(e.Buffer, i + 4);
                leftChannel = e.Buffer;
                leftAudio = (double)leftSample;
            }
        }

        private void ChkSyncMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSyncMusic.Checked)
            {
                waveIn.DataAvailable += delegate (object sender2, WaveInEventArgs e2)
                { WaveIn_DataAvailable(sender2, e2, ref leftChannel, ref leftAudio); };

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
            //int counter = 0;
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
                
                if (Math.Abs(leftAudio) > .05 && Math.Abs(leftAudio) <= .1)
                {
                    audioChannelDepth[0] = 0xFF;
                    audioChannelDepth[8] = 0xFF;
                    audioChannelDepth[16] = 0xFF;
                    audioChannelDepth[24] = 0xFF;
                    audioChannelDepth[32] = 0xFF;
                    audioChannelDepth[40] = 0xFF;
                    audioChannelDepth[48] = 0xFF;
                    audioChannelDepth[56] = 0xFF;
                }
                if (Math.Abs(leftAudio) > .1 && Math.Abs(leftAudio) <= .15)
                {
                    audioChannelDepth[1] = 0xFF;
                    audioChannelDepth[9] = 0xFF;
                    audioChannelDepth[17] = 0xFF;
                    audioChannelDepth[25] = 0xFF;
                    audioChannelDepth[33] = 0xFF;
                    audioChannelDepth[41] = 0xFF;
                    audioChannelDepth[49] = 0xFF;
                    audioChannelDepth[57] = 0xFF;
                }
                if (Math.Abs(leftAudio) > .15 && Math.Abs(leftAudio) <= .2)
                {
                    audioChannelDepth[2] = 0xFF;
                    audioChannelDepth[10] = 0xFF;
                    audioChannelDepth[18] = 0xFF;
                    audioChannelDepth[26] = 0xFF;
                    audioChannelDepth[34] = 0xFF;
                    audioChannelDepth[42] = 0xFF;
                    audioChannelDepth[50] = 0xFF;
                    audioChannelDepth[58] = 0xFF;
                }
                if (Math.Abs(leftAudio) > .2 && Math.Abs(leftAudio) <= .25)
                {
                    audioChannelDepth[3] = 0xFF;
                    audioChannelDepth[11] = 0xFF;
                    audioChannelDepth[19] = 0xFF;
                    audioChannelDepth[27] = 0xFF;
                    audioChannelDepth[35] = 0xFF;
                    audioChannelDepth[43] = 0xFF;
                    audioChannelDepth[51] = 0xFF;
                    audioChannelDepth[59] = 0xFF;
                }
                if (Math.Abs(leftAudio) > .25 && Math.Abs(leftAudio) <= .3)
                {
                    audioChannelDepth[4] = 0xFF;
                    audioChannelDepth[12] = 0xFF;
                    audioChannelDepth[20] = 0xFF;
                    audioChannelDepth[28] = 0xFF;
                    audioChannelDepth[36] = 0xFF;
                    audioChannelDepth[44] = 0xFF;
                    audioChannelDepth[52] = 0xFF;
                    audioChannelDepth[60] = 0xFF;
                }
                if (Math.Abs(leftAudio) > .3 && Math.Abs(leftAudio) <= .4)
                {
                    audioChannelDepth[5] = 0xFF;
                    audioChannelDepth[13] = 0xFF;
                    audioChannelDepth[21] = 0xFF;
                    audioChannelDepth[29] = 0xFF;
                    audioChannelDepth[37] = 0xFF;
                    audioChannelDepth[45] = 0xFF;
                    audioChannelDepth[53] = 0xFF;
                    audioChannelDepth[61] = 0xFF;
                }
                if (Math.Abs(leftAudio) > .4 && Math.Abs(leftAudio) <= .5)
                {
                    audioChannelDepth[6] = 0xFF;
                    audioChannelDepth[14] = 0xFF;
                    audioChannelDepth[22] = 0xFF;
                    audioChannelDepth[30] = 0xFF;
                    audioChannelDepth[38] = 0xFF;
                    audioChannelDepth[46] = 0xFF;
                    audioChannelDepth[54] = 0xFF;
                    audioChannelDepth[62] = 0xFF;
                }
                if (Math.Abs(leftAudio) > .5)
                {
                    audioChannelDepth[7] = 0xFF;
                    audioChannelDepth[15] = 0xFF;
                    audioChannelDepth[23] = 0xFF;
                    audioChannelDepth[31] = 0xFF;
                    audioChannelDepth[39] = 0xFF;
                    audioChannelDepth[47] = 0xFF;
                    audioChannelDepth[55] = 0xFF;
                    audioChannelDepth[63] = 0xFF;
                }

                if (Math.Abs(leftAudio) > 0.05)
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
                
            }
            
        }
    }
}
