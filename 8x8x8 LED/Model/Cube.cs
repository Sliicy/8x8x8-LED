using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Model
{
    public class Cube
    {
        public Cube(int x, int y, int z)
        {
            matrix = new int[x, y, z];
        }

        public int[,,] matrix = new int[8, 8, 8];


        public void SetPixel(int x, int y, int z, int value)
        {
            matrix[x, y, z] = value;
        }

        public int GetPixel(int x, int y, int z)
        {
            return matrix[x, y, z];
        }
    }
}
