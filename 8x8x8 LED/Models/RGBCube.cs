using _8x8x8_LED.Helpers;
using _8x8x8_LED.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Models
{
    public class RGBCube : Cube
    {
        public static int width = 8;
        public static int length = 8;
        public static int height = 8;

        public int OrientationX = 0;
        public int OrientationY = 0;
        public int OrientationZ = 0;

        public bool FlippedX = false;
        public bool FlippedY = false;
        public bool FlippedZ = false;

        public int OffsetX = 0;
        public int OffsetY = 0;
        public int OffsetZ = 0;

        public CubeColor[,,] matrix = new CubeColor[height, length, width];

        public RGBCube(int x = 8, int y = 8, int z = 8)
        {
            length = x;
            width = y;
            height = z;
        }
    }
}
