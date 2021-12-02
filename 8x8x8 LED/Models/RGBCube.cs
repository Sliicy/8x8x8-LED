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
        static int width = 8;
        static int length = 8;
        static int height = 8;

        private CubeColor[,,] matrix = new CubeColor[height, length, width];

        public RGBCube(int x, int y, int z)
        {
            length = x;
            width = y;
            height = z;
        }

        public void DrawPoint(int x, int y, int z, CubeColor c)
        {
            matrix[z, y, x] = c;
        }

        public CubeColor[,,] Render()
        {
            return matrix;
        }

    }
}
