using _8x8x8_LED.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8x8x8_LED.View
{
    public partial class FrmMarquee : Form
    {
        private readonly SerialPort serialPort;
        private Cube cube;

        public FrmMarquee(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void TmrAnimate_Tick(object sender, EventArgs e)
        {
            byte[] scanner = { };
            // IDEA: have each letter scanned vertically. Space adjustable


            var letterMapping = new Dictionary<string, Bitmap>();


            Bitmap canvas;

            foreach (string letter in txtMarquee.Text.Split())
            {
                if (letterMapping.ContainsKey(letter))
                {
                    canvas = letterMapping[letter];
                } else
                {
                    if (File.Exists(Path.Combine(Application.StartupPath, "Characters", letter + ".png")))
                    {
                        var stream = File.Open(Path.Combine(Application.StartupPath, "Characters", letter + ".png"), FileMode.Open);
                        letterMapping.Add(letter, (Bitmap)Image.FromStream(stream));
                        stream.Close();
                    }
                }

                // Scan layer by layer and send.



            }
        }

        private void chkAnimate_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(64, 8);

            RectangleF rectf = new RectangleF(-2, -2, 64, 10);

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(txtMarquee.Text, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, rectf);

            g.Flush();

            pictureBox1.Image = bmp;
            var sfd = new SaveFileDialog();
            var d = sfd.ShowDialog();
            if (d == DialogResult.OK)
            {
                bmp.Save(sfd.FileName);
            }
        }
    }
}
