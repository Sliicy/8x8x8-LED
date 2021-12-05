using _8x8x8_LED.Helpers;
using _8x8x8_LED.Model;
using _8x8x8_LED.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8x8x8_LED
{
    public partial class Testing : Form
    {
        public Testing(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;
        }

        private readonly SerialPort serialPort;
        //private readonly int delay = 24;
        Bitmap bitmap;
        private readonly OpenFileDialog picSelect = new OpenFileDialog()
        {
            InitialDirectory = Application.StartupPath,
            Multiselect = false,
            Title = "Select image to send:",
            Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.tiff) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.tiff"
        };

        private void BtnRed_Click(object sender, EventArgs e)
        {
            Cube cube = new RGBCube(8, 8, 8);
            for (int x = 0; x < cube.width; x++)
                for (int y = 0; y < cube.length; y++)
                    for (int z = 0; z < cube.height; z++)
                        cube.matrix[x, y, z] = CubeColor.Red;
            SerialHelper.Send(serialPort, cube);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Cube cube = new RGBCube(8, 8, 8);
            for (int x = 0; x < cube.width; x++)
                for (int y = 0; y < cube.length; y++)
                    for (int z = 0; z < cube.height; z++)
                        cube.matrix[x, y, z] = CubeColor.Black;
            SerialHelper.Send(serialPort, cube);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }

        bool red = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (red)
            {
                Cube cube = new RGBCube(8, 8, 8);
                for (int x = 0; x < cube.width; x++)
                    for (int y = 0; y < cube.length; y++)
                        for (int z = 0; z < cube.height; z++)
                            cube.matrix[x, y, z] = CubeColor.Red;
                SerialHelper.Send(serialPort, cube);
            }
            else
            {
                Cube cube = new RGBCube(8, 8, 8);
                for (int x = 0; x < cube.width; x++)
                    for (int y = 0; y < cube.length; y++)
                        for (int z = 0; z < cube.height; z++)
                            cube.matrix[x, y, z] = CubeColor.Cyan;
                SerialHelper.Send(serialPort, cube);
            }
            red = !red;
        }

        private void BtnGreen_Click(object sender, EventArgs e)
        {
            Cube cube = new RGBCube(8, 8, 8);
            for (int x = 0; x < cube.width; x++)
                for (int y = 0; y < cube.length; y++)
                    for (int z = 0; z < cube.height; z++)
                        cube.matrix[x, y, z] = CubeColor.Green;
            SerialHelper.Send(serialPort, cube);
        }

        private void BtnBlue_Click(object sender, EventArgs e)
        {
            Cube cube = new RGBCube(8, 8, 8);
            for (int x = 0; x < cube.width; x++)
                for (int y = 0; y < cube.length; y++)
                    for (int z = 0; z < cube.height; z++)
                        cube.matrix[x, y, z] = CubeColor.Blue;
            SerialHelper.Send(serialPort, cube);
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            Cube cube = new RGBCube(8, 8, 8);
            for (int x = 0; x < cube.width; x++)
                for (int y = 0; y < cube.length; y++)
                    for (int z = 0; z < cube.height; z++)
                        cube.matrix[x, y, z] = CubeColor.Yellow;
            SerialHelper.Send(serialPort, cube);
        }

        private void btnCyan_Click(object sender, EventArgs e)
        {
            Cube cube = new RGBCube(8, 8, 8);
            for (int x = 0; x < cube.width; x++)
                for (int y = 0; y < cube.length; y++)
                    for (int z = 0; z < cube.height; z++)
                        cube.matrix[x, y, z] = CubeColor.Cyan;
            SerialHelper.Send(serialPort, cube);
        }

        private void btnMagenta_Click(object sender, EventArgs e)
        {
            Cube cube = new RGBCube(8, 8, 8);
            for (int x = 0; x < cube.width; x++)
                for (int y = 0; y < cube.length; y++)
                    for (int z = 0; z < cube.height; z++)
                        cube.matrix[x, y, z] = CubeColor.Magenta;
            SerialHelper.Send(serialPort, cube);
        }
        
        private void btnWhite_Click(object sender, EventArgs e)
        {
            Cube cube = new RGBCube(8, 8, 8);
            for (int x = 0; x < cube.width; x++)
                for (int y = 0; y < cube.length; y++)
                    for (int z = 0; z < cube.height; z++)
                        cube.matrix[x, y, z] = CubeColor.White;
            SerialHelper.Send(serialPort, cube);
        }

        private void btnMock_Click(object sender, EventArgs e)
        {
            Cube cube = new RGBCube(8, 8, 8);
            for (int x = 0; x < cube.width; x++)
                for (int y = 0; y < cube.length; y++)
                    for (int z = 0; z < cube.height; z++)
                        cube.matrix[x, y, z] = CubeColor.Red;
            SerialHelper.Send(serialPort, cube);
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
            }
        }

        private void RenderImage()
        {
            if (bitmap.Width != 64 || bitmap.Height % 8 != 0)
            {
                MessageBox.Show("Image width must be exactly 64 pixels wide. Height must be evenly divisible by 8.", "Incorrect Dimensions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RGBCube cube = new RGBCube(8, 8, 8);
            for (int z = 0; z < 64; z += 8)
                for (int y = 7; y > -1; y--)
                    for (int x = 0; x < 8; x++)
                        cube.matrix[x, 7 - y, z / 8] = ColorMapper.ExtractColor(bitmap.GetPixel(x + z, y));

            
            cube.Rotate(Rotation.ClockwiseY);
            SerialHelper.Send(serialPort, cube);
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            RenderImage();
        }
    }
}
