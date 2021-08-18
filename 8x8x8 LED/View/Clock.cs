using _8x8x8_LED.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8x8x8_LED.View
{
    public partial class FrmClock : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;
        public FrmClock(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void ChkSyncTime_CheckedChanged(object sender, EventArgs e)
        {
            // Calibrate time to count every minute:
            if (chkSyncTime.Checked)
            {
                DrawTime();
                tmrClock.Interval = (60 - DateTime.Now.Second) * 1000;
            }
            tmrClock.Enabled = chkSyncTime.Checked;
        }

        private void TmrClock_Tick(object sender, EventArgs e)
        {
            tmrClock.Interval = 60000;
            DrawTime();
        }

        private void DrawTime()
        {
            cube.Clear();
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            if (!chk24HrStyle.Checked)
            {
                hour %= 12;
            }

            // Handle tens column:
            switch (hour / 10)
            {
                case 0:
                    if (chkShowLeadingZeros.Checked)
                    {
                        cube.matrix[2] += 128;
                        cube.matrix[3] += 128;
                        cube.matrix[4] += 128;
                        cube.matrix[5] += 128;
                        cube.matrix[6] += 128;

                        cube.matrix[10] += 128;
                        //cube.matrix[11] += 128;
                        //cube.matrix[12] += 128;
                        //cube.matrix[13] += 128;
                        cube.matrix[14] += 128;

                        cube.matrix[18] += 128;
                        cube.matrix[19] += 128;
                        cube.matrix[20] += 128;
                        cube.matrix[21] += 128;
                        cube.matrix[22] += 128;
                    }
                    break;
                case 1:
                    if (chkFlatOneStyle.Checked)
                    {
                        //cube.matrix[2] += 128;
                        //cube.matrix[3] += 128;
                        //cube.matrix[4] += 128;
                        //cube.matrix[5] += 128;
                        //cube.matrix[6] += 128;

                        cube.matrix[10] += 128;
                        cube.matrix[11] += 128;
                        cube.matrix[12] += 128;
                        cube.matrix[13] += 128;
                        cube.matrix[14] += 128;

                        //cube.matrix[18] += 128;
                        //cube.matrix[19] += 128;
                        //cube.matrix[20] += 128;
                        //cube.matrix[21] += 128;
                        //cube.matrix[22] += 128;
                    }
                    else
                    {
                        cube.matrix[2] += 128;
                        //cube.matrix[3] += 128;
                        //cube.matrix[4] += 128;
                        cube.matrix[5] += 128;
                        //cube.matrix[6] += 128;

                        cube.matrix[10] += 128;
                        cube.matrix[11] += 128;
                        cube.matrix[12] += 128;
                        cube.matrix[13] += 128;
                        cube.matrix[14] += 128;

                        cube.matrix[18] += 128;
                        //cube.matrix[19] += 128;
                        //cube.matrix[20] += 128;
                        //cube.matrix[21] += 128;
                        //cube.matrix[22] += 128;
                    }
                    break;
                case 2:
                    cube.matrix[2] += 128;
                    cube.matrix[3] += 128;
                    cube.matrix[4] += 128;
                    //cube.matrix[5] += 128;
                    cube.matrix[6] += 128;

                    cube.matrix[10] += 128;
                    //cube.matrix[11] += 128;
                    cube.matrix[12] += 128;
                    //cube.matrix[13] += 128;
                    cube.matrix[14] += 128;

                    cube.matrix[18] += 128;
                    //cube.matrix[19] += 128;
                    cube.matrix[20] += 128;
                    cube.matrix[21] += 128;
                    cube.matrix[22] += 128;
                    break;
            }

            // Handle ones column:
            switch (hour % 10)
            {
                case 0:
                    cube.matrix[34] += 128;
                    cube.matrix[35] += 128;
                    cube.matrix[36] += 128;
                    cube.matrix[37] += 128;
                    cube.matrix[38] += 128;

                    cube.matrix[42] += 128;
                    //cube.matrix[43] += 128;
                    //cube.matrix[44] += 128;
                    //cube.matrix[45] += 128;
                    cube.matrix[46] += 128;

                    cube.matrix[50] += 128;
                    cube.matrix[51] += 128;
                    cube.matrix[52] += 128;
                    cube.matrix[53] += 128;
                    cube.matrix[54] += 128;
                    break;
                case 1:
                    if (chkFlatOneStyle.Checked)
                    {
                        //cube.matrix[34] += 128;
                        //cube.matrix[35] += 128;
                        //cube.matrix[36] += 128;
                        //cube.matrix[37] += 128;
                        //cube.matrix[38] += 128;

                        cube.matrix[42] += 128;
                        cube.matrix[43] += 128;
                        cube.matrix[44] += 128;
                        cube.matrix[45] += 128;
                        cube.matrix[46] += 128;

                        //cube.matrix[50] += 128;
                        //cube.matrix[51] += 128;
                        //cube.matrix[52] += 128;
                        //cube.matrix[53] += 128;
                        //cube.matrix[54] += 128;
                    }
                    else
                    {
                        cube.matrix[34] += 128;
                        //cube.matrix[35] += 128;
                        //cube.matrix[36] += 128;
                        cube.matrix[37] += 128;
                        //cube.matrix[38] += 128;

                        cube.matrix[42] += 128;
                        cube.matrix[43] += 128;
                        cube.matrix[44] += 128;
                        cube.matrix[45] += 128;
                        cube.matrix[46] += 128;

                        cube.matrix[50] += 128;
                        //cube.matrix[51] += 128;
                        //cube.matrix[52] += 128;
                        //cube.matrix[53] += 128;
                        //cube.matrix[54] += 128;
                    }
                    break;
                case 2:
                    cube.matrix[34] += 128;
                    cube.matrix[35] += 128;
                    cube.matrix[36] += 128;
                    //cube.matrix[37] += 128;
                    cube.matrix[38] += 128;

                    cube.matrix[42] += 128;
                    //cube.matrix[43] += 128;
                    cube.matrix[44] += 128;
                    //cube.matrix[45] += 128;
                    cube.matrix[46] += 128;

                    cube.matrix[50] += 128;
                    //cube.matrix[51] += 128;
                    cube.matrix[52] += 128;
                    cube.matrix[53] += 128;
                    cube.matrix[54] += 128;
                    break;
                case 3:
                    cube.matrix[34] += 128;
                    //cube.matrix[35] += 128;
                    cube.matrix[36] += 128;
                    //cube.matrix[37] += 128;
                    cube.matrix[38] += 128;

                    cube.matrix[42] += 128;
                    //cube.matrix[43] += 128;
                    cube.matrix[44] += 128;
                    //cube.matrix[45] += 128;
                    cube.matrix[46] += 128;

                    cube.matrix[50] += 128;
                    cube.matrix[51] += 128;
                    cube.matrix[52] += 128;
                    cube.matrix[53] += 128;
                    cube.matrix[54] += 128;
                    break;
                case 4:
                    //cube.matrix[34] += 128;
                    //cube.matrix[35] += 128;
                    cube.matrix[36] += 128;
                    cube.matrix[37] += 128;
                    cube.matrix[38] += 128;

                    //cube.matrix[42] += 128;
                    //cube.matrix[43] += 128;
                    cube.matrix[44] += 128;
                    //cube.matrix[45] += 128;
                    //cube.matrix[46] += 128;

                    cube.matrix[50] += 128;
                    cube.matrix[51] += 128;
                    cube.matrix[52] += 128;
                    cube.matrix[53] += 128;
                    cube.matrix[54] += 128;
                    break;
                case 5:
                    cube.matrix[34] += 128;
                    //cube.matrix[35] += 128;
                    cube.matrix[36] += 128;
                    cube.matrix[37] += 128;
                    cube.matrix[38] += 128;

                    cube.matrix[42] += 128;
                    //cube.matrix[43] += 128;
                    cube.matrix[44] += 128;
                    //cube.matrix[45] += 128;
                    cube.matrix[46] += 128;

                    cube.matrix[50] += 128;
                    cube.matrix[51] += 128;
                    cube.matrix[52] += 128;
                    //cube.matrix[53] += 128;
                    cube.matrix[54] += 128;
                    break;
                case 6:
                    cube.matrix[34] += 128;
                    cube.matrix[35] += 128;
                    cube.matrix[36] += 128;
                    cube.matrix[37] += 128;
                    cube.matrix[38] += 128;

                    cube.matrix[42] += 128;
                    //cube.matrix[43] += 128;
                    cube.matrix[44] += 128;
                    //cube.matrix[45] += 128;
                    cube.matrix[46] += 128;

                    cube.matrix[50] += 128;
                    cube.matrix[51] += 128;
                    cube.matrix[52] += 128;
                    //cube.matrix[53] += 128;
                    cube.matrix[54] += 128;
                    break;
                case 7:
                    cube.matrix[34] += 128;
                    //cube.matrix[35] += 128;
                    //cube.matrix[36] += 128;
                    //cube.matrix[37] += 128;
                    cube.matrix[38] += 128;

                    //cube.matrix[42] += 128;
                    cube.matrix[43] += 128;
                    //cube.matrix[44] += 128;
                    //cube.matrix[45] += 128;
                    cube.matrix[46] += 128;

                    //cube.matrix[50] += 128;
                    //cube.matrix[51] += 128;
                    cube.matrix[52] += 128;
                    cube.matrix[53] += 128;
                    cube.matrix[54] += 128;
                    break;
                case 8:
                    cube.matrix[34] += 128;
                    cube.matrix[35] += 128;
                    cube.matrix[36] += 128;
                    cube.matrix[37] += 128;
                    cube.matrix[38] += 128;

                    cube.matrix[42] += 128;
                    //cube.matrix[43] += 128;
                    cube.matrix[44] += 128;
                    //cube.matrix[45] += 128;
                    cube.matrix[46] += 128;

                    cube.matrix[50] += 128;
                    cube.matrix[51] += 128;
                    cube.matrix[52] += 128;
                    cube.matrix[53] += 128;
                    cube.matrix[54] += 128;
                    break;
                case 9:
                    cube.matrix[34] += 128;
                    //cube.matrix[35] += 128;
                    cube.matrix[36] += 128;
                    cube.matrix[37] += 128;
                    cube.matrix[38] += 128;

                    cube.matrix[42] += 128;
                    //cube.matrix[43] += 128;
                    cube.matrix[44] += 128;
                    //cube.matrix[45] += 128;
                    cube.matrix[46] += 128;

                    cube.matrix[50] += 128;
                    cube.matrix[51] += 128;
                    cube.matrix[52] += 128;
                    cube.matrix[53] += 128;
                    cube.matrix[54] += 128;
                    break;
            }

            // Handle tens column:
            switch (minute / 10)
            {
                case 0:
                    cube.matrix[58] += 16 + 32 + 64;
                    cube.matrix[59] += 16 + 64;
                    cube.matrix[60] += 16 + 64;
                    cube.matrix[61] += 16 + 64;
                    cube.matrix[62] += 16 + 32 + 64;
                    break;
                case 1:
                    if (chkFlatOneStyle.Checked)
                    {
                        cube.matrix[58] += 32;
                        cube.matrix[59] += 32;
                        cube.matrix[60] += 32;
                        cube.matrix[61] += 32;
                        cube.matrix[62] += 32;
                    } else
                    {
                        cube.matrix[58] += 16 + 32 + 64;
                        cube.matrix[59] += 32;
                        cube.matrix[60] += 32;
                        cube.matrix[61] += 32 + 64;
                        cube.matrix[62] += 32;
                    }
                    break;
                case 2:
                    cube.matrix[58] += 16 + 32 + 64;
                    cube.matrix[59] += 64;
                    cube.matrix[60] += 16 + 32 + 64;
                    cube.matrix[61] += 16;
                    cube.matrix[62] += 16 + 32 + 64;
                    break;
                case 3:
                    cube.matrix[58] += 16 + 32 + 64;
                    cube.matrix[59] += 16;
                    cube.matrix[60] += 16 + 32 + 64;
                    cube.matrix[61] += 16;
                    cube.matrix[62] += 16 + 32 + 64;
                    break;
                case 4:
                    cube.matrix[58] += 16;
                    cube.matrix[59] += 16;
                    cube.matrix[60] += 16 + 32 + 64;
                    cube.matrix[61] += 16 + 64;
                    cube.matrix[62] += 16 + 64;
                    break;
                case 5:
                    cube.matrix[58] += 16 + 32 + 64;
                    cube.matrix[59] += 16;
                    cube.matrix[60] += 16 + 32 + 64;
                    cube.matrix[61] += 64;
                    cube.matrix[62] += 16 + 32 + 64;
                    break;
            }

            // Handle ones column:
            switch (minute % 10)
            {
                case 0:
                    cube.matrix[58] += 1 + 2 + 4;
                    cube.matrix[59] += 1 + 4;
                    cube.matrix[60] += 1 + 4;
                    cube.matrix[61] += 1 + 4;
                    cube.matrix[62] += 1 + 2 + 4;
                    break;
                case 1:
                    if (chkFlatOneStyle.Checked)
                    {
                        cube.matrix[58] += 2;
                        cube.matrix[59] += 2;
                        cube.matrix[60] += 2;
                        cube.matrix[61] += 2;
                        cube.matrix[62] += 2;
                    } else
                    {
                        cube.matrix[58] += 1 + 2 + 4;
                        cube.matrix[59] += 2;
                        cube.matrix[60] += 2;
                        cube.matrix[61] += 2 + 4;
                        cube.matrix[62] += 2;
                    }
                    break;
                case 2:
                    cube.matrix[58] += 1 + 2 + 4;
                    cube.matrix[59] += 4;
                    cube.matrix[60] += 1 + 2 + 4;
                    cube.matrix[61] += 1;
                    cube.matrix[62] += 1 + 2 + 4;
                    break;
                case 3:
                    cube.matrix[58] += 1 + 2 + 4;
                    cube.matrix[59] += 1;
                    cube.matrix[60] += 1 + 2 + 4;
                    cube.matrix[61] += 1;
                    cube.matrix[62] += 1 + 2 + 4;
                    break;
                case 4:
                    cube.matrix[58] += 1;
                    cube.matrix[59] += 1;
                    cube.matrix[60] += 1 + 2 + 4;
                    cube.matrix[61] += 1 + 4;
                    cube.matrix[62] += 1 + 4;
                    break;
                case 5:
                    cube.matrix[58] += 1 + 2 + 4;
                    cube.matrix[59] += 1;
                    cube.matrix[60] += 1 + 2 + 4;
                    cube.matrix[61] += 4;
                    cube.matrix[62] += 1 + 2 + 4;
                    break;
                case 6:
                    cube.matrix[58] += 1 + 2 + 4;
                    cube.matrix[59] += 1 + 4;
                    cube.matrix[60] += 1 + 2 + 4;
                    cube.matrix[61] += 4;
                    cube.matrix[62] += 1 + 2 + 4;
                    break;
                case 7:
                    cube.matrix[58] += 4;
                    cube.matrix[59] += 2;
                    cube.matrix[60] += 1;
                    cube.matrix[61] += 1;
                    cube.matrix[62] += 1 + 2 + 4;
                    break;
                case 8:
                    cube.matrix[58] += 1 + 2 + 4;
                    cube.matrix[59] += 1 + 4;
                    cube.matrix[60] += 1 + 2 + 4;
                    cube.matrix[61] += 1 + 4;
                    cube.matrix[62] += 1 + 2 + 4;
                    break;
                case 9:
                    cube.matrix[58] += 1 + 2 + 4;
                    cube.matrix[59] += 1;
                    cube.matrix[60] += 1 + 2 + 4;
                    cube.matrix[61] += 1 + 4;
                    cube.matrix[62] += 1 + 2 + 4;
                    break;
            }
            cube.Flip(Axis.X);
            SerialHelper.Send(serialPort, cube);
        }

        private void FrmClock_Load(object sender, EventArgs e)
        {
            chkSyncTime.Checked = true;
        }

        private void ChkShowLeadingZeros_CheckedChanged(object sender, EventArgs e)
        {
            DrawTime();
        }

        private void Chk24HrStyle_CheckedChanged(object sender, EventArgs e)
        {
            DrawTime();
        }

        private void ChkFlatOneStyle_CheckedChanged(object sender, EventArgs e)
        {
            DrawTime();
        }
    }
}
