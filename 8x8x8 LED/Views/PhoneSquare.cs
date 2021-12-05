using _8x8x8_LED.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Net.Http;
using System.Windows.Forms;

namespace _8x8x8_LED.View
{
    public partial class PhoneSquare : Form
    {
        private readonly SerialPort serialPort;
        private readonly MonochromeCube cube;
        private bool animate = false;

        private readonly List<Coordinate> queue = new List<Coordinate>();

        public PhoneSquare(SerialPort serialPort, ref MonochromeCube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }


        private void ChkAnimate_CheckedChanged(object sender, EventArgs e)
        {
            animate = chkAnimate.Checked;
            if (chkAnimate.Checked && bwAnimate.IsBusy == false)
            {
                bwAnimate.RunWorkerAsync();
            }
            else
            {
                bwAnimate.CancelAsync();
            }
        }

        private void BwAnimate_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                using (var httpClient = new HttpClient())
                {
                    string json = httpClient.GetStringAsync("http://" + txtURL.Text + "/sensors.json?sense=accel").Result;
                    AccelRoot data = JsonConvert.DeserializeObject<AccelRoot>(json);
                    if (data.Accel.Data != null)
                    {
                        foreach (var item in data.Accel.Data)
                        {
                            string[] coordSet = item[1].ToString().Replace("[", "").Replace("]", "").Replace(Environment.NewLine, "").Split(',');
                            queue.Add(new Coordinate() { x = Convert.ToDouble(coordSet[0]), y = Convert.ToDouble(coordSet[1]), z = Convert.ToDouble(coordSet[2]) });

                            double x = Math.Round(Convert.ToDouble(coordSet[0]));
                            double y = Math.Round(Convert.ToDouble(coordSet[1]));
                            double z = Math.Round(Convert.ToDouble(coordSet[2]));

                            cube.Clear_Legacy();
                            if ((y == 10 || y == -10) && x == 0 && z == 0)
                            {
                                cube.matrix_legacy[16] = 16;
                                cube.matrix_legacy[17] = 16;
                                cube.matrix_legacy[18] = 16;
                                cube.matrix_legacy[19] = 16;
                                cube.matrix_legacy[20] = 16;
                                cube.matrix_legacy[21] = 16;
                                cube.matrix_legacy[22] = 16;
                                cube.matrix_legacy[23] = 16;

                                cube.matrix_legacy[24] = 16;
                                cube.matrix_legacy[25] = 16;
                                cube.matrix_legacy[26] = 16;
                                cube.matrix_legacy[27] = 16;
                                cube.matrix_legacy[28] = 16;
                                cube.matrix_legacy[29] = 16;
                                cube.matrix_legacy[30] = 16;
                                cube.matrix_legacy[31] = 16;

                                cube.matrix_legacy[32] = 16;
                                cube.matrix_legacy[33] = 16;
                                cube.matrix_legacy[34] = 16;
                                cube.matrix_legacy[35] = 16;
                                cube.matrix_legacy[36] = 16;
                                cube.matrix_legacy[37] = 16;
                                cube.matrix_legacy[38] = 16;
                                cube.matrix_legacy[39] = 16;

                                cube.matrix_legacy[40] = 16;
                                cube.matrix_legacy[41] = 16;
                                cube.matrix_legacy[42] = 16;
                                cube.matrix_legacy[43] = 16;
                                cube.matrix_legacy[44] = 16;
                                cube.matrix_legacy[45] = 16;
                                cube.matrix_legacy[46] = 16;
                                cube.matrix_legacy[47] = 16;

                            }
                            else if (y == 0 && x == 0 && (z == 10 || z == -10))
                            {
                                cube.matrix_legacy[19] = 255;
                                cube.matrix_legacy[27] = 255;
                                cube.matrix_legacy[35] = 255;
                                cube.matrix_legacy[43] = 255;

                            }
                            else if (y == 0 && (x == 10 || x == -10) && z == 0)
                            {
                                cube.matrix_legacy[2] = 16;
                                cube.matrix_legacy[3] = 16;
                                cube.matrix_legacy[4] = 16;
                                cube.matrix_legacy[5] = 16;

                                cube.matrix_legacy[10] = 16;
                                cube.matrix_legacy[11] = 16;
                                cube.matrix_legacy[12] = 16;
                                cube.matrix_legacy[13] = 16;

                                cube.matrix_legacy[18] = 16;
                                cube.matrix_legacy[19] = 16;
                                cube.matrix_legacy[20] = 16;
                                cube.matrix_legacy[21] = 16;

                                cube.matrix_legacy[26] = 16;
                                cube.matrix_legacy[27] = 16;
                                cube.matrix_legacy[28] = 16;
                                cube.matrix_legacy[29] = 16;

                                cube.matrix_legacy[34] = 16;
                                cube.matrix_legacy[35] = 16;
                                cube.matrix_legacy[36] = 16;
                                cube.matrix_legacy[37] = 16;

                                cube.matrix_legacy[42] = 16;
                                cube.matrix_legacy[43] = 16;
                                cube.matrix_legacy[44] = 16;
                                cube.matrix_legacy[45] = 16;

                                cube.matrix_legacy[50] = 16;
                                cube.matrix_legacy[51] = 16;
                                cube.matrix_legacy[52] = 16;
                                cube.matrix_legacy[53] = 16;

                                cube.matrix_legacy[58] = 16;
                                cube.matrix_legacy[59] = 16;
                                cube.matrix_legacy[60] = 16;
                                cube.matrix_legacy[61] = 16;
                            }

                            cube.Flip(Axis.X);
                            SerialHelper.Send(serialPort, cube);
                        }
                    }
                    

                }
                System.Threading.Thread.Sleep(100);

            }
        }

        private void TmrAnimate_Tick(object sender, EventArgs e)
        {
            if (queue.Count > 0)
            {
                cube.Clear_Legacy();

                if (queue[0].y >= 9 && queue[0].x < 1 && queue[0].x > -1 && queue[0].z < 1 &&queue[0].z > -1)
                {
                    cube.matrix_legacy[16] = 16;
                    cube.matrix_legacy[17] = 16;
                    cube.matrix_legacy[18] = 16;
                    cube.matrix_legacy[19] = 16;
                    cube.matrix_legacy[20] = 16;
                    cube.matrix_legacy[21] = 16;
                    cube.matrix_legacy[22] = 16;
                    cube.matrix_legacy[23] = 16;

                    cube.matrix_legacy[24] = 16;
                    cube.matrix_legacy[25] = 16;
                    cube.matrix_legacy[26] = 16;
                    cube.matrix_legacy[27] = 16;
                    cube.matrix_legacy[28] = 16;
                    cube.matrix_legacy[29] = 16;
                    cube.matrix_legacy[30] = 16;
                    cube.matrix_legacy[31] = 16;

                    cube.matrix_legacy[32] = 16;
                    cube.matrix_legacy[33] = 16;
                    cube.matrix_legacy[34] = 16;
                    cube.matrix_legacy[35] = 16;
                    cube.matrix_legacy[36] = 16;
                    cube.matrix_legacy[37] = 16;
                    cube.matrix_legacy[38] = 16;
                    cube.matrix_legacy[39] = 16;

                    cube.matrix_legacy[40] = 16;
                    cube.matrix_legacy[41] = 16;
                    cube.matrix_legacy[42] = 16;
                    cube.matrix_legacy[43] = 16;
                    cube.matrix_legacy[44] = 16;
                    cube.matrix_legacy[45] = 16;
                    cube.matrix_legacy[46] = 16;
                    cube.matrix_legacy[47] = 16;

                } else if (queue[0].y < 1 && queue[0].y > -1 && queue[0].x < 1 && queue[0].x > -1 && queue[0].z >= 9)
                {
                    cube.matrix_legacy[19] = 255;
                    cube.matrix_legacy[27] = 255;
                    cube.matrix_legacy[35] = 255;
                    cube.matrix_legacy[43] = 255;

                }
                
                cube.Flip(Axis.X);
                SerialHelper.Send(serialPort, cube);

                queue.RemoveAt(0);
            }
        }

        private void PhoneSquare_FormClosing(object sender, FormClosingEventArgs e)
        {
            animate = false;
        }

        private void PhoneSquare_Load(object sender, EventArgs e)
        {
            txtURL.Text = Properties.Settings.Default.PhoneSquare_URL;
        }

        private void TxtURL_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PhoneSquare_URL = txtURL.Text;
        }

        private void LinkLabelURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://play.google.com/store/apps/details?id=com.pas.webcam.pro&hl=en_US&gl=US");
        }
    }

    public class AccelRoot
    {
        public Accel Accel { get; set; }
    }

    public class Accel
    {
        public List<string> Desc { get; set; }
        public string Unit { get; set; }
        public object[][] Data { get; set; }
    }
    public class CoordinateArray
    {
        public Coordinate[] c;
    }

    public class Coordinate
    {
        public double x;
        public double y;
        public double z;
    }
}
