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
    public partial class FrmPong : Form
    {
        private readonly SerialPort serialPort;
        private Cube cube;

        public FrmPong(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }

        private void FrmPong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {

            }
            if (e.KeyCode == Keys.A)
            {

            }
            if (e.KeyCode == Keys.S)
            {

            }
            if (e.KeyCode == Keys.D)
            {

            }
            if (e.KeyCode == Keys.Up)
            {

            }
            if (e.KeyCode == Keys.Down)
            {

            }
            if (e.KeyCode == Keys.Left)
            {

            }
            if (e.KeyCode == Keys.Right)
            {

            }
        }
    }
}
