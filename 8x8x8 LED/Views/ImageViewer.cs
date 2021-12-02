﻿using _8x8x8_LED.Model;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Orientation = _8x8x8_LED.Model.Orientation;

namespace _8x8x8_LED
{
    public partial class FrmImageViewer : Form
    {
        private readonly SerialPort serialPort;
        private readonly MonochromeCube cube;
        private int fileNameIncrementor = 0;

        public FrmImageViewer(SerialPort serialPort, ref MonochromeCube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            if (picSelect.FileName.Length > 0) picSelect.InitialDirectory = Path.GetDirectoryName(picSelect.FileName);
            DialogResult selection = picSelect.ShowDialog();
            if (selection == DialogResult.OK)
            {
                var stream = File.Open(picSelect.FileName, FileMode.Open);
                bitmap = (Bitmap)Image.FromStream(stream);
                stream.Close();
                RenderImage();
                fileNameIncrementor = 0;
            }
                
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
            {
                var stream = File.Open(picSelect.FileName, FileMode.Open);
                bitmap = (Bitmap)Image.FromStream(stream);
                stream.Close();
                RenderImage();
            }
                
        }

        Bitmap bitmap;

        private void RenderImage()
        {
            foreach (Control c in pnlMatrix.Controls)
            {
                if (c is Panel)
                    c.Dispose();
            }

            if (bitmap.Width != 64 || bitmap.Height % 8 != 0)
            {
                MessageBox.Show("Image width must be exactly 64 pixels wide. Height must be evenly divisible by 8.", "Incorrect Dimensions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] bytesToSend = new byte[64];

            int i = 0;

            for (int z = 0; z < 64; z += 8)
            {
                for (int y = 7; y > -1; y--)
                {
                    var bits = new BitArray(8);
                    for (int x = 0; x < 8; x++)
                    {
                        if (bitmap.GetPixel(x + z, y).R == 0 && bitmap.GetPixel(x + z, y).G == 0 && bitmap.GetPixel(x + z, y).B == 0)
                            bits[x] = false;
                        else
                            bits[x] = true;
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

            
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Panel p = new Panel
                    {
                        Width = pnlMatrix.Width / 64,
                        Height = pnlMatrix.Height / 8,
                    };
                    p.BackColor = Color.FromArgb(bitmap.GetPixel(x, y).ToArgb());
                    p.Left = x * 16;
                    p.Top = y * 16;
                    pnlMatrix.Controls.Add(p);
                    p.MouseEnter += new EventHandler(Panel_MouseEnter);
                    p.MouseDown += new MouseEventHandler(Panel_MouseDown);
                }
            }
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            var c = (Panel)sender;
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                c.BackColor = Color.White;
                bitmap.SetPixel(c.Left / 16, c.Top / 16, c.BackColor);
                return;
            } else if (ModifierKeys.HasFlag(Keys.Shift))
            {
                c.BackColor = Color.Black;
                bitmap.SetPixel(c.Left / 16, c.Top / 16, c.BackColor);
                return;
            }


            byte[] bytesToSend = new byte[64];
            int i = 0;
            
            for (int z = 0; z < 64; z += 8)
            {
                for (int y = 7; y > -1; y--)
                {
                    var bits = new BitArray(8);
                    for (int x = 0; x < 8; x++)
                    {
                        if (bitmap.GetPixel(x + z, y).R == 0 && bitmap.GetPixel(x + z, y).G == 0 && bitmap.GetPixel(x + z, y).B == 0)
                            bits[x] = false;
                        else
                            bits[x] = true;
                        
                        if (x + z == c.Left / 16 && y == c.Top / 16)
                        {
                            if (bits[x] == true)
                                bits[x] = false;
                            else
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
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            var c = (Panel)sender;

            c.BackColor = c.BackColor == Color.Black ? Color.White : Color.Black;
            bitmap.SetPixel(c.Left / 16, c.Top / 16, c.BackColor);
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
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bitmap.Save(picSelect.FileName, System.Drawing.Imaging.ImageFormat.Png);
            RenderImage();
        }

        private void BtnSaveNew_Click(object sender, EventArgs e)
        {
            bitmap.Save(Path.GetFileNameWithoutExtension(picSelect.FileName) + fileNameIncrementor + Path.GetExtension(picSelect.FileName), System.Drawing.Imaging.ImageFormat.Png);
            RenderImage();
            fileNameIncrementor++;
        }
    }
}
