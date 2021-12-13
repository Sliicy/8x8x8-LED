using _8x8x8_LED.Helpers;
using _8x8x8_LED.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.Views
{
    public partial class FrmMarquee : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;
        private bool animate = false;

        private Bitmap wideMarquee;
        private int speed = 200;
        private CubeColor targetColor = CubeColor.White;

        // Needle represents the current vertical line being read from the marquee:
        private int needle = 0;

        public FrmMarquee(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void BwAnimate_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                DrawLetters();
                System.Threading.Thread.Sleep(speed);
            }
        }

        private void DrawLetters()
        {
            cube.Clear();

            // Contains mappings for all letters needed:
            var letterMapping = new Dictionary<string, Bitmap>();

            List<Bitmap> images = new List<Bitmap>();

            // Load any needed letters into memory:
            foreach (char letter in txtMarquee.Text)
            {
                if (letterMapping.ContainsKey(letter.ToString()))
                    images.Add(letterMapping[letter.ToString()]);
                else
                    if (File.Exists(Path.Combine(Application.StartupPath, "Characters", letter + ".png")))
                {
                    var stream = File.Open(Path.Combine(Application.StartupPath, "Characters", letter + ".png"), FileMode.Open);
                    letterMapping.Add(letter.ToString(), (Bitmap)Image.FromStream(stream));
                    images.Add(letterMapping[letter.ToString()]);
                    stream.Close();
                }
            }

            // Append all letters onto canvas:
            wideMarquee = AppendBitmap(images, int.Parse(nudSpacing.Value.ToString()), chkLetterEnding.Checked);

            ProjectImageToCube(wideMarquee, needle);
            needle++;
            if (needle >= wideMarquee.Width)
                needle = 0;
            cube.Rotate(Rotation.ClockwiseX, 1);
            SerialHelper.Send(serialPort, cube);
        }

        private void ProjectImageToCube(Bitmap wideMarquee, int positionX)
        {
            for (int j = 0; j < positionX + 1; j++)
            {
                for (int i = 0; i < cube.length; i++)
                {
                    switch (j)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            cube.DrawPoint(j, 0, i, ColorHelper.GetColorFromRGB(wideMarquee.GetPixel(positionX - j, i)) == CubeColor.Black ? CubeColor.Black : targetColor);
                            break;
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                            cube.DrawPoint(cube.length - 1, j % (cube.length - 1), i, ColorHelper.GetColorFromRGB(wideMarquee.GetPixel(positionX - j, i)) == CubeColor.Black ? CubeColor.Black : targetColor);
                            break;
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                            cube.DrawPoint((cube.length - 1) - j % (cube.length - 1), cube.length - 1, i, ColorHelper.GetColorFromRGB(wideMarquee.GetPixel(positionX - j, i)) == CubeColor.Black ? CubeColor.Black : targetColor);
                            break;
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                            cube.DrawPoint(0, (cube.length - 1) - j % (cube.length - 1), i, ColorHelper.GetColorFromRGB(wideMarquee.GetPixel(positionX - j, i)) == CubeColor.Black ? CubeColor.Black : targetColor);
                            break;
                    }
                }
            }
        }

        private static Bitmap AppendBitmap(List<Bitmap> images, int spacing, bool letterEnding)
        {
            Bitmap bmp = new Bitmap(1, 1);
            if (images.Count > 0)
            {
                int w = (images[0].Width * images.Count + spacing * images.Count - spacing) + (letterEnding ? 30 : 0);
                int h = images[0].Height;
                bmp = new Bitmap(w, h);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Black);
                    for (int i = 0; i < images.Count; i++)
                        g.DrawImage(images[i], images[i].Width * i + spacing * i, 0);
                }
            }
            return bmp;
        }

        private void FrmMarquee_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Marquee_Color = cbColor.SelectedIndex;
            Properties.Settings.Default.Save();
            animate = false;
            if (bwAnimate.IsBusy)
                bwAnimate.CancelAsync();
        }

        private void ChkAnimate_CheckedChanged(object sender, EventArgs e)
        {
            animate = chkAnimate.Checked;
            if (!animate && bwAnimate.IsBusy)
                bwAnimate.CancelAsync();
            if (animate)
                bwAnimate.RunWorkerAsync();
        }

        private void TxtMarquee_TextChanged(object sender, EventArgs e)
        {
            chkAnimate.Checked = false;
            Properties.Settings.Default.Marquee_Text = txtMarquee.Text;
        }

        private void TrkSpeed_Scroll(object sender, EventArgs e)
        {
            speed = trkSpeed.Value;
            Properties.Settings.Default.Marquee_Speed = speed;
        }

        private void FrmMarquee_Load(object sender, EventArgs e)
        {
            txtMarquee.Text = Properties.Settings.Default.Marquee_Text;
            nudSpacing.Value = Properties.Settings.Default.Marquee_SpacingAmount;
            trkSpeed.Value = Properties.Settings.Default.Marquee_Speed;
            chkLetterEnding.Checked = Properties.Settings.Default.Marquee_EndLastLetter;
            cbColor.DataSource = Enum.GetValues(typeof(CubeColor));
            cbColor.SelectedIndex = Properties.Settings.Default.Marquee_Color;
        }

        private void ChkLetterEnding_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Marquee_EndLastLetter = chkLetterEnding.Checked;
        }

        private void NudSpacing_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Marquee_SpacingAmount = Convert.ToInt32(nudSpacing.Value);
        }

        private void CbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetColor = (CubeColor)Enum.Parse(typeof(CubeColor), cbColor.Text);
        }
    }
}
