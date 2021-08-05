using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Model
{
    public class Cube
    {

        // Front View of Cube, with corresponding bytes:
        //
        // 07, 15, 23, 31, 39, 47, 55, 63,
        // 06, 14, 22, 30, 38, 46, 54, 62,
        // 05, 13, 21, 29, 37, 45, 53, 61,
        // 04, 12, 20, 28, 36, 44, 52, 60,
        // 03, 11, 19, 27, 35, 43, 51, 59,
        // 02, 10, 18, 26, 34, 42, 50, 58,
        // 01, 09, 17, 25, 33, 41, 49, 57,
        // 00, 08, 16, 24, 32, 40, 48, 56,



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
