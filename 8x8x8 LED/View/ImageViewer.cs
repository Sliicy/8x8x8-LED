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

        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            DialogResult selection = picSelect.ShowDialog();
            if (selection == DialogResult.OK)
                RenderImage2();
        }

        private readonly OpenFileDialog picSelect = new OpenFileDialog()
        {
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
            Multiselect = false,
            Title = "Select image to send:",
            Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.tiff) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.tiff"
        };

        private void BtnImageReload_Click(object sender, EventArgs e)
        {
            if (File.Exists(picSelect.FileName))
                RenderImage2();
        }

        private void RenderImage2()
        {
            // Set the image (copy the image, rename it, convert it to .png, and save it to the Template folder):
            Bitmap b;
            var stream = File.Open(picSelect.FileName, FileMode.Open);
            b = (Bitmap)Image.FromStream(stream);
            stream.Close();
            if (b.Width != 64 || b.Height % 8 != 0)
            {
                MessageBox.Show("Image width must be exactly 64 pixels wide. Height must be evenly divisible by 8!"); // TODO: Replace with code that shrinks image?
                return;
            }
            pbImage.Image = b;

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
            SerialHelper.SendPacket(serialPort, cube.matrix);
            MessageBox.Show("Before");

            var array2D = new byte[8, 8];
            int counter = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    array2D[y, x] = bytesToSend[counter];
                    counter++;
                }
            }

            var output2DArray = RotateCounterClockwise(array2D);
            counter = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    bytesToSend[counter] = output2DArray[x, y];
                    counter++;
                }
            }




            bytesToSend.CopyTo(cube.matrix, 0);
            SerialHelper.SendPacket(serialPort, cube.matrix);



        }

        private static byte[,] RotateCounterClockwise(byte[,] oldMatrix)
        {
            byte[,] newMatrix = new byte[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

        private void RenderImage()
        {
            // Set the image (copy the image, rename it, convert it to .png, and save it to the Template folder):
            Bitmap b;
            var stream = File.Open(picSelect.FileName, FileMode.Open);
            b = (Bitmap)Image.FromStream(stream);
            stream.Close();
            if (b.Width != 64 || b.Height % 8 != 0)
            {
                MessageBox.Show("Image width must be exactly 64 pixels wide. Height must be evenly divisible by 8!"); // TODO: Replace with code that shrinks image?
                return;
            }
            pbImage.Image = b;

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
            SerialHelper.SendPacket(serialPort, cube.matrix);
        }
    }
}
