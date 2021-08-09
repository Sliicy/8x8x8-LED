using _8x8x8_LED.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orientation = _8x8x8_LED.Model.Orientation;

namespace _8x8x8_LED.View
{
    public partial class FrmVideo : Form
    {
        private readonly SerialPort serialPort;
        private Cube cube;

        private Bitmap renderImage;

        public FrmVideo(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            DialogResult selection = picSelect.ShowDialog();
            if (selection == DialogResult.OK)
            {
                var stream = File.Open(picSelect.FileName, FileMode.Open);
                renderImage = (Bitmap) Image.FromStream(stream);
                stream.Close();
                if (renderImage.Width != 64 || renderImage.Height % 8 != 0)
                {
                    MessageBox.Show("Image width must be exactly 64 pixels wide. Height must be evenly divisible by 8!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!bwRenderer.IsBusy)
                    bwRenderer.RunWorkerAsync();
            }
        }

        private readonly OpenFileDialog picSelect = new OpenFileDialog()
        {
            InitialDirectory = Application.StartupPath,
            Multiselect = false,
            Title = "Select image to send:",
            Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.tiff) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.tiff"
        };

        private void RenderVideo(Bitmap b)
        {
            byte[] bytesToSend = new byte[64];
            while (chkLooped.Checked) {
                for (int depth = 0; depth < b.Height; depth += 8)
                {
                    int i = 0;
                    for (int z = 0; z < 64; z += 8)
                    {
                        for (int y = 7; y > -1; y--)
                        {
                            var bits = new BitArray(8);

                            for (int x = 0; x < 8; x++)
                            {
                                if (b.GetPixel(x + z, y + depth).B == 255 && b.GetPixel(x + z, y + depth).B == 255 && b.GetPixel(x + z, y + depth).B == 255)
                                {
                                    bits[x] = false;
                                } else
                                {
                                    bits[x] = true;
                                }
                            }
                            byte[] bytes = new byte[1];
                            bits.CopyTo(bytes, 0);
                            bytesToSend[i] = bytes[0];

                            i++;
                        }
                    }

                    bytesToSend.CopyTo(cube.matrix, 0);
                    cube.Rotate(Orientation.ClockwiseZ);
                    SerialHelper.Send(serialPort, cube);
                    System.Threading.Thread.Sleep(int.Parse(nudSpeed.Value.ToString()));
                    if (!chkLooped.Checked) break;
                }
            }
        }

        private void ChkLooped_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLooped.Checked == false)
            {
                bwRenderer.CancelAsync();
            }
            else
            {
                if (!bwRenderer.IsBusy)
                    bwRenderer.RunWorkerAsync();
            }
        }

        private void BwRenderer_DoWork(object sender, DoWorkEventArgs e)
        {
            if (renderImage != null)
                RenderVideo(renderImage);
        }

        private void FrmVideo_FormClosing(object sender, FormClosingEventArgs e)
        {
            bwRenderer.CancelAsync();
        }
    }
}
