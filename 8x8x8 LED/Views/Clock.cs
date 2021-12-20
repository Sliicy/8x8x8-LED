using _8x8x8_LED.Helpers;
using _8x8x8_LED.Models;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace _8x8x8_LED.Views
{
    public partial class FrmClock : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;
        private CubeColor targetHourColor;
        private CubeColor targetMinuteColor;
        private CubeColor targetBackColor;
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
            cube.Clear(targetBackColor);
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            if (!chk24HrStyle.Checked)
                hour %= 12;

            // Handle hour tens column:
            switch (hour / 10)
            {
                case 0:
                    if (chkShowLeadingZeros.Checked)
                    {
                        cube.DrawPoint(0, 0, 6, targetHourColor);
                        cube.DrawPoint(1, 0, 6, targetHourColor);
                        cube.DrawPoint(2, 0, 6, targetHourColor);
                        cube.DrawPoint(0, 0, 5, targetHourColor);
                        cube.DrawPoint(2, 0, 5, targetHourColor);
                        cube.DrawPoint(0, 0, 4, targetHourColor);
                        cube.DrawPoint(2, 0, 4, targetHourColor);
                        cube.DrawPoint(0, 0, 3, targetHourColor);
                        cube.DrawPoint(2, 0, 3, targetHourColor);
                        cube.DrawPoint(0, 0, 2, targetHourColor);
                        cube.DrawPoint(1, 0, 2, targetHourColor);
                        cube.DrawPoint(2, 0, 2, targetHourColor);
                    }
                    break;
                case 1:
                    if (chkFlatOneStyle.Checked)
                    {
                        cube.DrawPoint(1, 0, 6, targetHourColor);
                        cube.DrawPoint(1, 0, 5, targetHourColor);
                        cube.DrawPoint(1, 0, 4, targetHourColor);
                        cube.DrawPoint(1, 0, 3, targetHourColor);
                        cube.DrawPoint(1, 0, 2, targetHourColor);
                    }
                    else
                    {
                        cube.DrawPoint(1, 0, 6, targetHourColor);
                        cube.DrawPoint(0, 0, 5, targetHourColor);
                        cube.DrawPoint(1, 0, 5, targetHourColor);
                        cube.DrawPoint(1, 0, 4, targetHourColor);
                        cube.DrawPoint(1, 0, 3, targetHourColor);
                        cube.DrawPoint(0, 0, 2, targetHourColor);
                        cube.DrawPoint(1, 0, 2, targetHourColor);
                        cube.DrawPoint(2, 0, 2, targetHourColor);
                    }
                    break;
                case 2:
                    cube.DrawPoint(0, 0, 6, targetHourColor);
                    cube.DrawPoint(1, 0, 6, targetHourColor);
                    cube.DrawPoint(2, 0, 6, targetHourColor);
                    cube.DrawPoint(2, 0, 5, targetHourColor);
                    cube.DrawPoint(0, 0, 4, targetHourColor);
                    cube.DrawPoint(1, 0, 4, targetHourColor);
                    cube.DrawPoint(2, 0, 4, targetHourColor);
                    cube.DrawPoint(0, 0, 3, targetHourColor);
                    cube.DrawPoint(0, 0, 2, targetHourColor);
                    cube.DrawPoint(1, 0, 2, targetHourColor);
                    cube.DrawPoint(2, 0, 2, targetHourColor);
                    break;
            }

            // Handle hour ones column:
            switch (hour % 10)
            {
                case 0:
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(5, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 6, targetHourColor);
                    cube.DrawPoint(4, 0, 5, targetHourColor);
                    cube.DrawPoint(6, 0, 5, targetHourColor);
                    cube.DrawPoint(4, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 4, targetHourColor);
                    cube.DrawPoint(4, 0, 3, targetHourColor);
                    cube.DrawPoint(6, 0, 3, targetHourColor);
                    cube.DrawPoint(4, 0, 2, targetHourColor);
                    cube.DrawPoint(5, 0, 2, targetHourColor);
                    cube.DrawPoint(6, 0, 2, targetHourColor);
                    break;
                case 1:
                    if (chkFlatOneStyle.Checked)
                    {
                        cube.DrawPoint(5, 0, 6, targetHourColor);
                        cube.DrawPoint(5, 0, 5, targetHourColor);
                        cube.DrawPoint(5, 0, 4, targetHourColor);
                        cube.DrawPoint(5, 0, 3, targetHourColor);
                        cube.DrawPoint(5, 0, 2, targetHourColor);
                    }
                    else
                    {
                        cube.DrawPoint(5, 0, 6, targetHourColor);
                        cube.DrawPoint(4, 0, 5, targetHourColor);
                        cube.DrawPoint(5, 0, 5, targetHourColor);
                        cube.DrawPoint(5, 0, 4, targetHourColor);
                        cube.DrawPoint(5, 0, 3, targetHourColor);
                        cube.DrawPoint(4, 0, 2, targetHourColor);
                        cube.DrawPoint(5, 0, 2, targetHourColor);
                        cube.DrawPoint(6, 0, 2, targetHourColor);
                    }
                    break;
                case 2:
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(5, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 5, targetHourColor);
                    cube.DrawPoint(4, 0, 4, targetHourColor);
                    cube.DrawPoint(5, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 4, targetHourColor);
                    cube.DrawPoint(4, 0, 3, targetHourColor);
                    cube.DrawPoint(4, 0, 2, targetHourColor);
                    cube.DrawPoint(5, 0, 2, targetHourColor);
                    cube.DrawPoint(6, 0, 2, targetHourColor);
                    break;
                case 3:
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(5, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 6, targetHourColor);
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 5, targetHourColor);
                    cube.DrawPoint(4, 0, 4, targetHourColor);
                    cube.DrawPoint(5, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 3, targetHourColor);
                    cube.DrawPoint(4, 0, 2, targetHourColor);
                    cube.DrawPoint(5, 0, 2, targetHourColor);
                    cube.DrawPoint(6, 0, 2, targetHourColor);
                    break;
                case 4:
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 6, targetHourColor);
                    cube.DrawPoint(4, 0, 5, targetHourColor);
                    cube.DrawPoint(6, 0, 5, targetHourColor);
                    cube.DrawPoint(4, 0, 4, targetHourColor);
                    cube.DrawPoint(5, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 3, targetHourColor);
                    cube.DrawPoint(6, 0, 2, targetHourColor);
                    break;
                case 5:
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(5, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 6, targetHourColor);
                    cube.DrawPoint(4, 0, 5, targetHourColor);
                    cube.DrawPoint(4, 0, 4, targetHourColor);
                    cube.DrawPoint(5, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 3, targetHourColor);
                    cube.DrawPoint(4, 0, 2, targetHourColor);
                    cube.DrawPoint(5, 0, 2, targetHourColor);
                    cube.DrawPoint(6, 0, 2, targetHourColor);
                    break;
                case 6:
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(5, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 6, targetHourColor);
                    cube.DrawPoint(4, 0, 5, targetHourColor);
                    cube.DrawPoint(4, 0, 4, targetHourColor);
                    cube.DrawPoint(5, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 4, targetHourColor);
                    cube.DrawPoint(4, 0, 3, targetHourColor);
                    cube.DrawPoint(6, 0, 3, targetHourColor);
                    cube.DrawPoint(4, 0, 2, targetHourColor);
                    cube.DrawPoint(5, 0, 2, targetHourColor);
                    cube.DrawPoint(6, 0, 2, targetHourColor);
                    break;
                case 7:
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(5, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 5, targetHourColor);
                    cube.DrawPoint(6, 0, 4, targetHourColor);
                    cube.DrawPoint(5, 0, 3, targetHourColor);
                    cube.DrawPoint(5, 0, 2, targetHourColor);
                    break;
                case 8:
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(5, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 6, targetHourColor);
                    cube.DrawPoint(4, 0, 5, targetHourColor);
                    cube.DrawPoint(6, 0, 5, targetHourColor);
                    cube.DrawPoint(4, 0, 4, targetHourColor);
                    cube.DrawPoint(5, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 4, targetHourColor);
                    cube.DrawPoint(4, 0, 3, targetHourColor);
                    cube.DrawPoint(6, 0, 3, targetHourColor);
                    cube.DrawPoint(4, 0, 2, targetHourColor);
                    cube.DrawPoint(5, 0, 2, targetHourColor);
                    cube.DrawPoint(6, 0, 2, targetHourColor);
                    break;
                case 9:
                    cube.DrawPoint(4, 0, 6, targetHourColor);
                    cube.DrawPoint(5, 0, 6, targetHourColor);
                    cube.DrawPoint(6, 0, 6, targetHourColor);
                    cube.DrawPoint(4, 0, 5, targetHourColor);
                    cube.DrawPoint(6, 0, 5, targetHourColor);
                    cube.DrawPoint(4, 0, 4, targetHourColor);
                    cube.DrawPoint(5, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 4, targetHourColor);
                    cube.DrawPoint(6, 0, 3, targetHourColor);
                    cube.DrawPoint(4, 0, 2, targetHourColor);
                    cube.DrawPoint(5, 0, 2, targetHourColor);
                    cube.DrawPoint(6, 0, 2, targetHourColor);
                    break;
            }

            // Handle minute tens column:
            switch (minute / 10)
            {
                case 0:
                    cube.DrawPoint(7, 1, 6, targetMinuteColor);
                    cube.DrawPoint(7, 2, 6, targetMinuteColor);
                    cube.DrawPoint(7, 3, 6, targetMinuteColor);
                    cube.DrawPoint(7, 1, 5, targetMinuteColor);
                    cube.DrawPoint(7, 3, 5, targetMinuteColor);
                    cube.DrawPoint(7, 1, 4, targetMinuteColor);
                    cube.DrawPoint(7, 3, 4, targetMinuteColor);
                    cube.DrawPoint(7, 1, 3, targetMinuteColor);
                    cube.DrawPoint(7, 3, 3, targetMinuteColor);
                    cube.DrawPoint(7, 1, 2, targetMinuteColor);
                    cube.DrawPoint(7, 2, 2, targetMinuteColor);
                    cube.DrawPoint(7, 3, 2, targetMinuteColor);
                    break;
                case 1:
                    if (chkFlatOneStyle.Checked)
                    {
                        cube.DrawPoint(7, 2, 6, targetMinuteColor);
                        cube.DrawPoint(7, 2, 5, targetMinuteColor);
                        cube.DrawPoint(7, 2, 4, targetMinuteColor);
                        cube.DrawPoint(7, 2, 3, targetMinuteColor);
                        cube.DrawPoint(7, 2, 2, targetMinuteColor);
                    }
                    else
                    {
                        cube.DrawPoint(7, 2, 6, targetMinuteColor);
                        cube.DrawPoint(7, 1, 5, targetMinuteColor);
                        cube.DrawPoint(7, 2, 5, targetMinuteColor);
                        cube.DrawPoint(7, 2, 4, targetMinuteColor);
                        cube.DrawPoint(7, 2, 3, targetMinuteColor);
                        cube.DrawPoint(7, 1, 2, targetMinuteColor);
                        cube.DrawPoint(7, 2, 2, targetMinuteColor);
                        cube.DrawPoint(7, 3, 2, targetMinuteColor);
                    }
                    break;
                case 2:
                    cube.DrawPoint(7, 1, 6, targetMinuteColor);
                    cube.DrawPoint(7, 2, 6, targetMinuteColor);
                    cube.DrawPoint(7, 3, 6, targetMinuteColor);
                    cube.DrawPoint(7, 3, 5, targetMinuteColor);
                    cube.DrawPoint(7, 1, 4, targetMinuteColor);
                    cube.DrawPoint(7, 2, 4, targetMinuteColor);
                    cube.DrawPoint(7, 3, 4, targetMinuteColor);
                    cube.DrawPoint(7, 1, 3, targetMinuteColor);
                    cube.DrawPoint(7, 1, 2, targetMinuteColor);
                    cube.DrawPoint(7, 2, 2, targetMinuteColor);
                    cube.DrawPoint(7, 3, 2, targetMinuteColor);
                    break;
                case 3:
                    cube.DrawPoint(7, 1, 6, targetMinuteColor);
                    cube.DrawPoint(7, 2, 6, targetMinuteColor);
                    cube.DrawPoint(7, 3, 6, targetMinuteColor);
                    cube.DrawPoint(7, 3, 5, targetMinuteColor);
                    cube.DrawPoint(7, 1, 4, targetMinuteColor);
                    cube.DrawPoint(7, 2, 4, targetMinuteColor);
                    cube.DrawPoint(7, 3, 4, targetMinuteColor);
                    cube.DrawPoint(7, 3, 3, targetMinuteColor);
                    cube.DrawPoint(7, 1, 2, targetMinuteColor);
                    cube.DrawPoint(7, 2, 2, targetMinuteColor);
                    cube.DrawPoint(7, 3, 2, targetMinuteColor);
                    break;
                case 4:
                    cube.DrawPoint(7, 1, 6, targetMinuteColor);
                    cube.DrawPoint(7, 3, 6, targetMinuteColor);
                    cube.DrawPoint(7, 1, 5, targetMinuteColor);
                    cube.DrawPoint(7, 3, 5, targetMinuteColor);
                    cube.DrawPoint(7, 1, 4, targetMinuteColor);
                    cube.DrawPoint(7, 2, 4, targetMinuteColor);
                    cube.DrawPoint(7, 3, 4, targetMinuteColor);
                    cube.DrawPoint(7, 3, 3, targetMinuteColor);
                    cube.DrawPoint(7, 3, 2, targetMinuteColor);
                    break;
                case 5:
                    cube.DrawPoint(7, 1, 6, targetMinuteColor);
                    cube.DrawPoint(7, 2, 6, targetMinuteColor);
                    cube.DrawPoint(7, 3, 6, targetMinuteColor);
                    cube.DrawPoint(7, 1, 5, targetMinuteColor);
                    cube.DrawPoint(7, 1, 4, targetMinuteColor);
                    cube.DrawPoint(7, 2, 4, targetMinuteColor);
                    cube.DrawPoint(7, 3, 4, targetMinuteColor);
                    cube.DrawPoint(7, 3, 3, targetMinuteColor);
                    cube.DrawPoint(7, 1, 2, targetMinuteColor);
                    cube.DrawPoint(7, 2, 2, targetMinuteColor);
                    cube.DrawPoint(7, 3, 2, targetMinuteColor);
                    break;
            }

            // Handle minute ones column:
            switch (minute % 10)
            {
                case 0:
                    cube.DrawPoint(7, 5, 6, targetMinuteColor);
                    cube.DrawPoint(7, 6, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 6, targetMinuteColor);
                    cube.DrawPoint(7, 5, 5, targetMinuteColor);
                    cube.DrawPoint(7, 7, 5, targetMinuteColor);
                    cube.DrawPoint(7, 5, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 4, targetMinuteColor);
                    cube.DrawPoint(7, 5, 3, targetMinuteColor);
                    cube.DrawPoint(7, 7, 3, targetMinuteColor);
                    cube.DrawPoint(7, 5, 2, targetMinuteColor);
                    cube.DrawPoint(7, 6, 2, targetMinuteColor);
                    cube.DrawPoint(7, 7, 2, targetMinuteColor);
                    break;
                case 1:
                    if (chkFlatOneStyle.Checked)
                    {
                        cube.DrawPoint(7, 6, 6, targetMinuteColor);
                        cube.DrawPoint(7, 6, 5, targetMinuteColor);
                        cube.DrawPoint(7, 6, 4, targetMinuteColor);
                        cube.DrawPoint(7, 6, 3, targetMinuteColor);
                        cube.DrawPoint(7, 6, 2, targetMinuteColor);
                    }
                    else
                    {
                        cube.DrawPoint(7, 6, 6, targetMinuteColor);
                        cube.DrawPoint(7, 5, 5, targetMinuteColor);
                        cube.DrawPoint(7, 6, 5, targetMinuteColor);
                        cube.DrawPoint(7, 6, 4, targetMinuteColor);
                        cube.DrawPoint(7, 6, 3, targetMinuteColor);
                        cube.DrawPoint(7, 5, 2, targetMinuteColor);
                        cube.DrawPoint(7, 6, 2, targetMinuteColor);
                        cube.DrawPoint(7, 7, 2, targetMinuteColor);
                    }
                    break;
                case 2:
                    cube.DrawPoint(7, 5, 6, targetMinuteColor);
                    cube.DrawPoint(7, 6, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 5, targetMinuteColor);
                    cube.DrawPoint(7, 5, 4, targetMinuteColor);
                    cube.DrawPoint(7, 6, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 4, targetMinuteColor);
                    cube.DrawPoint(7, 5, 3, targetMinuteColor);
                    cube.DrawPoint(7, 5, 2, targetMinuteColor);
                    cube.DrawPoint(7, 6, 2, targetMinuteColor);
                    cube.DrawPoint(7, 7, 2, targetMinuteColor);
                    break;
                case 3:
                    cube.DrawPoint(7, 5, 6, targetMinuteColor);
                    cube.DrawPoint(7, 6, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 5, targetMinuteColor);
                    cube.DrawPoint(7, 5, 4, targetMinuteColor);
                    cube.DrawPoint(7, 6, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 3, targetMinuteColor);
                    cube.DrawPoint(7, 5, 2, targetMinuteColor);
                    cube.DrawPoint(7, 6, 2, targetMinuteColor);
                    cube.DrawPoint(7, 7, 2, targetMinuteColor);
                    break;
                case 4:
                    cube.DrawPoint(7, 5, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 6, targetMinuteColor);
                    cube.DrawPoint(7, 5, 5, targetMinuteColor);
                    cube.DrawPoint(7, 7, 5, targetMinuteColor);
                    cube.DrawPoint(7, 5, 4, targetMinuteColor);
                    cube.DrawPoint(7, 6, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 3, targetMinuteColor);
                    cube.DrawPoint(7, 7, 2, targetMinuteColor);
                    break;
                case 5:
                    cube.DrawPoint(7, 5, 6, targetMinuteColor);
                    cube.DrawPoint(7, 6, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 6, targetMinuteColor);
                    cube.DrawPoint(7, 5, 5, targetMinuteColor);
                    cube.DrawPoint(7, 5, 4, targetMinuteColor);
                    cube.DrawPoint(7, 6, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 3, targetMinuteColor);
                    cube.DrawPoint(7, 5, 2, targetMinuteColor);
                    cube.DrawPoint(7, 6, 2, targetMinuteColor);
                    cube.DrawPoint(7, 7, 2, targetMinuteColor);
                    break;
                case 6:
                    cube.DrawPoint(7, 5, 6, targetMinuteColor);
                    cube.DrawPoint(7, 6, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 6, targetMinuteColor);
                    cube.DrawPoint(7, 5, 5, targetMinuteColor);
                    cube.DrawPoint(7, 5, 4, targetMinuteColor);
                    cube.DrawPoint(7, 6, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 4, targetMinuteColor);
                    cube.DrawPoint(7, 5, 3, targetMinuteColor);
                    cube.DrawPoint(7, 7, 3, targetMinuteColor);
                    cube.DrawPoint(7, 5, 2, targetMinuteColor);
                    cube.DrawPoint(7, 6, 2, targetMinuteColor);
                    cube.DrawPoint(7, 7, 2, targetMinuteColor);
                    break;
                case 7:
                    cube.DrawPoint(7, 5, 6, targetMinuteColor);
                    cube.DrawPoint(7, 6, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 5, targetMinuteColor);
                    cube.DrawPoint(7, 7, 4, targetMinuteColor);
                    cube.DrawPoint(7, 6, 3, targetMinuteColor);
                    cube.DrawPoint(7, 6, 2, targetMinuteColor);
                    break;
                case 8:
                    cube.DrawPoint(7, 5, 6, targetMinuteColor);
                    cube.DrawPoint(7, 6, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 6, targetMinuteColor);
                    cube.DrawPoint(7, 5, 5, targetMinuteColor);
                    cube.DrawPoint(7, 7, 5, targetMinuteColor);
                    cube.DrawPoint(7, 5, 4, targetMinuteColor);
                    cube.DrawPoint(7, 6, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 4, targetMinuteColor);
                    cube.DrawPoint(7, 5, 3, targetMinuteColor);
                    cube.DrawPoint(7, 7, 3, targetMinuteColor);
                    cube.DrawPoint(7, 5, 2, targetMinuteColor);
                    cube.DrawPoint(7, 6, 2, targetMinuteColor);
                    cube.DrawPoint(7, 7, 2, targetMinuteColor);
                    break;
                case 9:
                    cube.DrawPoint(7, 5, 6, targetMinuteColor);
                    cube.DrawPoint(7, 6, 6, targetMinuteColor);
                    cube.DrawPoint(7, 7, 6, targetMinuteColor);
                    cube.DrawPoint(7, 5, 5, targetMinuteColor);
                    cube.DrawPoint(7, 7, 5, targetMinuteColor);
                    cube.DrawPoint(7, 5, 4, targetMinuteColor);
                    cube.DrawPoint(7, 6, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 4, targetMinuteColor);
                    cube.DrawPoint(7, 7, 3, targetMinuteColor);
                    cube.DrawPoint(7, 5, 2, targetMinuteColor);
                    cube.DrawPoint(7, 6, 2, targetMinuteColor);
                    cube.DrawPoint(7, 7, 2, targetMinuteColor);
                    break;
            }
            SerialHelper.Send(serialPort, cube);
        }

        private void FrmClock_Load(object sender, EventArgs e)
        {
            chkSyncTime.Checked = true;
            chkShowLeadingZeros.Checked = Properties.Settings.Default.Clock_ShowLeadingZeros;
            chk24HrStyle.Checked = Properties.Settings.Default.Clock_24HourStyle;
            chkFlatOneStyle.Checked = Properties.Settings.Default.Clock_Flat1Style;
            cbColorHour.DataSource = Enum.GetValues(typeof(CubeColor));
            cbColorHour.SelectedIndex = Properties.Settings.Default.Clock_HourColor;
            cbColorMinute.DataSource = Enum.GetValues(typeof(CubeColor));
            cbColorMinute.SelectedIndex = Properties.Settings.Default.Clock_MinuteColor;
            cbBackcolor.DataSource = Enum.GetValues(typeof(CubeColor));
            cbBackcolor.SelectedIndex = Properties.Settings.Default.Clock_BackColor;
        }

        private void ChkShowLeadingZeros_CheckedChanged(object sender, EventArgs e)
        {
            DrawTime();
            Properties.Settings.Default.Clock_ShowLeadingZeros = chkShowLeadingZeros.Checked;
        }

        private void Chk24HrStyle_CheckedChanged(object sender, EventArgs e)
        {
            DrawTime();
            Properties.Settings.Default.Clock_24HourStyle = chk24HrStyle.Checked;
        }

        private void ChkFlatOneStyle_CheckedChanged(object sender, EventArgs e)
        {
            DrawTime();
            Properties.Settings.Default.Clock_Flat1Style = chkFlatOneStyle.Checked;
        }

        private void FrmClock_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Clock_HourColor = cbColorHour.SelectedIndex;
            Properties.Settings.Default.Clock_MinuteColor = cbColorMinute.SelectedIndex;
            Properties.Settings.Default.Clock_BackColor = cbBackcolor.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void CbColorHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetHourColor = (CubeColor)Enum.Parse(typeof(CubeColor), cbColorHour.Text);
            DrawTime();
        }

        private void CbColorMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetMinuteColor = (CubeColor)Enum.Parse(typeof(CubeColor), cbColorMinute.Text);
            DrawTime();
        }

        private void CbBackcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetBackColor = (CubeColor)Enum.Parse(typeof(CubeColor), cbBackcolor.Text);
            DrawTime();
        }
    }
}
