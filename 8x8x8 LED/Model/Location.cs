using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Model.Pong
{
    public class Location
    {
        private int x = 0;
        private int y = 0;
        private int z = 0;

        public Location(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int GetX()
        {
            return x;
        }

        public void SetX(int value)
        {
            x = value;
        }

        public int GetY()
        {
            return y;
        }

        public void SetY(int value)
        {
            y = value;
        }

        public int GetZ()
        {
            return z;
        }

        public void SetZ(int value)
        {
            z = value;
        }
    }
}
