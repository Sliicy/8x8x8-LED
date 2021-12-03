using _8x8x8_LED.Model;
using NAudio.Wave;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Rotation = _8x8x8_LED.Model.Rotation;

namespace _8x8x8_LED.View
{
    public partial class FrmVideo : Form
    {
        private readonly SerialPort serialPort;
        private readonly MonochromeCube cube;

        private Bitmap renderImage;

        private bool animateMusic = false;
        private bool animate = false;
        private bool slideshow = false;
        private int speed = 50;
        private readonly int timeElapsed = 0; // Used to adjust speed of animation

        private readonly int samples = 1024; // How many samples to calculate wave form from.
        private double[] twoChannels = new double[2]; // Holds 2 bytes of audio.

        readonly IWaveIn waveIn = new WasapiLoopbackCapture();

        public FrmVideo(SerialPort serialPort, ref MonochromeCube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            if (picSelect.FileName.Length > 0) picSelect.InitialDirectory = Path.GetDirectoryName(picSelect.FileName);
            DialogResult selection = picSelect.ShowDialog();
            if (selection == DialogResult.OK)
            {
                try
                {
                    var stream = File.Open(picSelect.FileName, FileMode.Open);
                    renderImage = (Bitmap)Image.FromStream(stream);
                    stream.Close();
                    if (renderImage.Width != 64 || renderImage.Height % 8 != 0)
                    {
                        MessageBox.Show("Image width must be exactly 64 pixels wide. Height must be evenly divisible by 8!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                        chkAnimate.Checked = true;
                } catch (Exception)
                {
                    MessageBox.Show("Unable to load image. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private readonly OpenFileDialog picSelect = new OpenFileDialog()
        {
            InitialDirectory = Application.StartupPath,
            Multiselect = false,
            Title = "Select image to send:",
            Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.tiff) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.tiff"
        };

        private void RenderVideo()
        {
            if (renderImage.Width != 64 || renderImage.Height % 8 != 0)
                return;
            byte[] bytesToSend = new byte[64];
            while (animate) {
                try
                {
                    if ((animateMusic && Math.Abs(twoChannels[0]) > 0.05 && timeElapsed % speed == 0) || !animateMusic)
                    {
                        for (int depth = 0; depth < renderImage.Height; depth += 8)
                        {
                            int i = 0;
                            for (int z = 0; z < 64; z += 8)
                            {
                                for (int y = 7; y > -1; y--)
                                {
                                    var bits = new BitArray(8);

                                    for (int x = 0; x < 8; x++)
                                    {
                                        if (renderImage.GetPixel(x + z, y + depth).R == 0 && renderImage.GetPixel(x + z, y + depth).G == 0 && renderImage.GetPixel(x + z, y + depth).B == 0)
                                        {
                                            bits[x] = false;
                                        }
                                        else
                                        {
                                            bits[x] = true;
                                        }
                                    }
                                    byte[] bytes = new byte[1];
                                    bits.CopyTo(bytes, 0);
                                    bytesToSend[i] = bytes[0];

                                    i++;
                                    if (!animate) return;
                                }
                            }
                            if (rbLooped.Checked)
                            {
                                bytesToSend.CopyTo(cube.matrix, 0);
                                cube.Rotate(Rotation.ClockwiseZ);
                            }
                            if (rbGravity.Checked)
                                cube.Shift(Direction.Downwards, true, 0);

                            if (animateMusic)
                            {
                                if (Math.Abs(twoChannels[0]) < .05)
                                {
                                    speed = 45000;
                                }
                                if (Math.Abs(twoChannels[0]) > .05)
                                {
                                    speed = 40000;
                                }
                                if (Math.Abs(twoChannels[0]) > .1)
                                {
                                    speed = 35000;
                                }
                                if (Math.Abs(twoChannels[0]) > .15)
                                {
                                    speed = 30000;
                                }
                                if (Math.Abs(twoChannels[0]) > .2)
                                {
                                    speed = 25000;
                                }
                                if (Math.Abs(twoChannels[0]) > .25)
                                {
                                    speed = 20000;
                                }
                                if (Math.Abs(twoChannels[0]) > .3)
                                {
                                    speed = 15000;
                                }
                                if (Math.Abs(twoChannels[0]) > .4)
                                {
                                    speed = 10000;
                                }
                                if (Math.Abs(twoChannels[0]) > .5)
                                {
                                    speed = 5000;
                                }

                                if ((Math.Abs(twoChannels[0]) > 0.05) && timeElapsed % speed == 0)
                                {
                                    cube.Flip(Axis.X);
                                    SerialHelper.Send(serialPort, cube);
                                }
                            }
                            else
                            {
                                SerialHelper.Send(serialPort, cube);
                                System.Threading.Thread.Sleep(int.Parse(nudSpeed.Value.ToString()));
                            }
                        }

                        if (!chkAnimate.Checked) break;
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void BwRenderer_DoWork(object sender, DoWorkEventArgs e)
        {
            if (renderImage != null)
                RenderVideo();
        }

        private void FrmVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            animate = false;
            bwRenderer.CancelAsync();
        }

        private void ChkAnimate_CheckedChanged(object sender, EventArgs e)
        {
            animate = chkAnimate.Checked;
            if (chkAnimate.Checked == false)
            {
                bwRenderer.CancelAsync();
            }
            else
            {
                if (!bwRenderer.IsBusy)
                    bwRenderer.RunWorkerAsync();
            }
        }

        private void FrmVideo_Load(object sender, EventArgs e)
        {
            chkSyncMusic.Checked = Properties.Settings.Default.Video_SyncToMusic;
            nudSpeed.Value = Properties.Settings.Default.Video_Speed;
            chkSlideshow.Checked = Properties.Settings.Default.Video_Slideshow;
        }

        private void ChkSyncMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSyncMusic.Checked)
            {
                waveIn.DataAvailable += delegate (object sender2, WaveInEventArgs e2)
                { WaveIn_DataAvailable(e2, ref twoChannels, samples); };

                waveIn.StartRecording();
                animateMusic = true;
            } else
            {
                waveIn.StopRecording();
                animateMusic = false;
            }
            Properties.Settings.Default.Video_SyncToMusic = chkSyncMusic.Checked;
        }

        static void WaveIn_DataAvailable(WaveInEventArgs e, ref double[] twoChannels, int samples = 8)
        {
            for (int i = 0; i < e.BytesRecorded; i += samples)
            {
                twoChannels[0] = BitConverter.ToSingle(e.Buffer, i);
                twoChannels[1] = BitConverter.ToSingle(e.Buffer, i + 4);
            }
        }

        private void NudSpeed_ValueChanged(object sender, EventArgs e)
        {
            speed = int.Parse(nudSpeed.Value.ToString());
            Properties.Settings.Default.Video_Speed = int.Parse(nudSpeed.Value.ToString());
        }

        private void ChkSlideshow_CheckedChanged(object sender, EventArgs e)
        {
            slideshow = chkSlideshow.Checked;
            tmrSlideshow.Enabled = slideshow;
            Properties.Settings.Default.Video_Slideshow = chkSlideshow.Checked;
        }

        private void TmrSlideshow_Tick(object sender, EventArgs e)
        {
            if (picSelect.FileName.Length > 0)
            {
                var rand = new Random();
                var files = Directory.GetFiles(Path.GetDirectoryName(picSelect.FileName));
                picSelect.FileName = files[rand.Next(files.Length)];
                try
                {
                    var stream = File.Open(picSelect.FileName, FileMode.Open);
                    renderImage = (Bitmap)Image.FromStream(stream);
                    stream.Close();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
