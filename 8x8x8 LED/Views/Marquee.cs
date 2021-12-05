using _8x8x8_LED.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.View
{
    public partial class FrmMarquee : Form
    {
        private readonly SerialPort serialPort;
        private readonly MonochromeCube cube;
        private bool animate = false;

        private Bitmap wideMarquee;
        private int speed = 200;

        // Needle represents the current vertical line being read from the marquee:
        private int needle = 0;

        public FrmMarquee(SerialPort serialPort, ref MonochromeCube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void BwAnimate_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                cube.Clear_Legacy();
                DrawLetters();
                System.Threading.Thread.Sleep(speed);
            }
        }

        private void DrawLetters()
        {
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
            wideMarquee = AppendBitmap(images, int.Parse(nudSpacing.Value.ToString()));

            ProjectImageToCube(wideMarquee, needle);
            needle++;
            if (needle >= wideMarquee.Width)
                needle = 0;
            cube.Rotate(Model.Rotation.ClockwiseX);
            cube.Rotate(Model.Rotation.CounterclockwiseZ);
            SerialHelper.Send(serialPort, cube);
        }

        private void ProjectImageToCube(Bitmap wideMarquee, int positionX)
        {
            for (int j = 0; j < positionX + 1; j++)
            {
                var bits = new BitArray(8);
                for (int i = 0; i < 8; i++)
                {
                    if (wideMarquee.GetPixel(positionX - j, i).R == 255 &&
                    wideMarquee.GetPixel(positionX - j, i).G == 255 &&
                    wideMarquee.GetPixel(positionX - j, i).B == 255)
                    {
                        bits[i] = false;
                    }
                    else
                    {
                        bits[i] = true;
                    }
                }
                byte[] bytes = new byte[1];
                bits.CopyTo(bytes, 0);

                switch (j)
                {
                    case 0:
                        cube.matrix_legacy[0] = bytes[0];
                        break;
                    case 1:
                        cube.matrix_legacy[1] = bytes[0];
                        break;
                    case 2:
                        cube.matrix_legacy[2] = bytes[0];
                        break;
                    case 3:
                        cube.matrix_legacy[3] = bytes[0];
                        break;
                    case 4:
                        cube.matrix_legacy[4] = bytes[0];
                        break;
                    case 5:
                        cube.matrix_legacy[5] = bytes[0];
                        break;
                    case 6:
                        cube.matrix_legacy[6] = bytes[0];
                        break;
                    case 7:
                        cube.matrix_legacy[7] = bytes[0];
                        break;
                    case 8:
                        cube.matrix_legacy[15] = bytes[0];
                        break;
                    case 9:
                        cube.matrix_legacy[23] = bytes[0];
                        break;
                    case 10:
                        cube.matrix_legacy[31] = bytes[0];
                        break;
                    case 11:
                        cube.matrix_legacy[39] = bytes[0];
                        break;
                    case 12:
                        cube.matrix_legacy[47] = bytes[0];
                        break;
                    case 13:
                        cube.matrix_legacy[55] = bytes[0];
                        break;
                    case 14:
                        cube.matrix_legacy[63] = bytes[0];
                        break;
                    case 15:
                        cube.matrix_legacy[62] = bytes[0];
                        break;
                    case 16:
                        cube.matrix_legacy[61] = bytes[0];
                        break;
                    case 17:
                        cube.matrix_legacy[60] = bytes[0];
                        break;
                    case 18:
                        cube.matrix_legacy[59] = bytes[0];
                        break;
                    case 19:
                        cube.matrix_legacy[58] = bytes[0];
                        break;
                    case 20:
                        cube.matrix_legacy[57] = bytes[0];
                        break;
                    case 21:
                        cube.matrix_legacy[56] = bytes[0];
                        break;
                    case 22:
                        cube.matrix_legacy[48] = bytes[0];
                        break;
                    case 23:
                        cube.matrix_legacy[40] = bytes[0];
                        break;
                    case 24:
                        cube.matrix_legacy[32] = bytes[0];
                        break;
                    case 25:
                        cube.matrix_legacy[24] = bytes[0];
                        break;
                    case 26:
                        cube.matrix_legacy[16] = bytes[0];
                        break;
                    case 27:
                        cube.matrix_legacy[8] = bytes[0];
                        break;
                }
            }
        }

        public Bitmap AppendBitmap(List<Bitmap> images, int spacing)
        {
            Bitmap bmp = new Bitmap(1, 1);
            if (images.Count > 0)
            {
                int w = (images[0].Width * images.Count + spacing * images.Count - spacing) + (chkLetterEnding.Checked ? 30 : 0);
                int h = images[0].Height;
                bmp = new Bitmap(w, h);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    for (int i = 0; i < images.Count; i++)
                        g.DrawImage(images[i], images[i].Width * i + spacing * i, 0);
                }
            }
            return bmp;
        }

        private void FrmMarquee_FormClosing(object sender, FormClosingEventArgs e)
        {
            animate = false;
            if (bwAnimate.IsBusy)
                bwAnimate.CancelAsync();
            Properties.Settings.Default.Save();
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
        }

        private void ChkLetterEnding_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Marquee_EndLastLetter = chkLetterEnding.Checked;
        }

        private void NudSpacing_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Marquee_SpacingAmount = Convert.ToInt32(nudSpacing.Value);
        }
    }
}
