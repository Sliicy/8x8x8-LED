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

namespace _8x8x8_LED
{
    public partial class FrmImageViewer : Form
    {
        private readonly SerialPort serialPort;
        private Cube cube;

        public FrmImageViewer(SerialPort serialPort, Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            DialogResult selection = picSelect.ShowDialog();
            if (selection == DialogResult.OK)
                RenderImage();
        }

        private readonly OpenFileDialog picSelect = new OpenFileDialog()
        {
            InitialDirectory = Application.StartupPath,
            Multiselect = false,
            Title = "Select image to send:",
            Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.tiff) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.tiff"
        };

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (File.Exists(picSelect.FileName))
                RenderImage();
        }

        private void RenderImage()
        {
            Bitmap b;
            var stream = File.Open(picSelect.FileName, FileMode.Open);
            b = (Bitmap)Image.FromStream(stream);
            stream.Close();
            if (b.Width != 64 || b.Height % 8 != 0)
            {
                MessageBox.Show("Image width must be exactly 64 pixels wide. Height must be evenly divisible by 8!"); // TODO: Replace with code that shrinks image?
                return;
            }
            //pbImage.Image = b;

            byte[] bytesToSend = new byte[64];

            int i = 0;

            for (int z = 0; z < 64; z += 8)
            {
                for (int y = 7; y > -1; y--)
                {
                    var bits = new BitArray(8);

                    for (int x = 0; x < 8; x++)
                    {
                        if (b.GetPixel(x + z, y).B == 255 && b.GetPixel(x + z, y).B == 255 && b.GetPixel(x + z, y).B == 255)
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
        }

        private void BtnClickOperation_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (b == btnFlipX)
                cube.Flip(Axis.X);
            if (b == btnFlipY)
                cube.Flip(Axis.Y);
            if (b == btnFlipZ)
                cube.Flip(Axis.Z);

            if (b == btnShiftUpwards)
                cube.Shift(Direction.Upwards, chkLoop.Checked);
            if (b == btnShiftDownwards)
                cube.Shift(Direction.Downwards, chkLoop.Checked);
            if (b == btnShiftLeftwards)
                cube.Shift(Direction.Leftwards, chkLoop.Checked);
            if (b == btnShiftRightwards)
                cube.Shift(Direction.Rightwards, chkLoop.Checked);
            if (b == btnShiftForwards)
                cube.Shift(Direction.Forwards, chkLoop.Checked);
            if (b == btnShiftBackwards)
                cube.Shift(Direction.Backwards, chkLoop.Checked);

            if (b == btnRotateXClock)
                cube.Rotate(Orientation.ClockwiseX);
            if (b == btnRotateYClock)
                cube.Rotate(Orientation.ClockwiseY);
            if (b == btnRotateZClock)
                cube.Rotate(Orientation.ClockwiseZ);

            if (b == btnRotateXCounter)
                cube.Rotate(Orientation.CounterclockwiseX);
            if (b == btnRotateYCounter)
                cube.Rotate(Orientation.CounterclockwiseY);
            if (b == btnRotateZCounter)
                cube.Rotate(Orientation.CounterclockwiseZ);

            SerialHelper.Send(serialPort, cube);
            //SerialHelper.SendPacket(serialPort, cube.matrix);
        }
    }
}
