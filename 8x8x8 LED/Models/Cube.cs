using _8x8x8_LED.Helpers;
using _8x8x8_LED.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Models
{
    public abstract class Cube : Geometry
    {
        public int width;
        public int length;
        public int height;

        /// <summary>
        /// Represents the current state of the cube (should it be rotated, flipped, have an offset, etc).
        /// </summary>
        public int OrientationX = 0;
        public int OrientationY = 0;
        public int OrientationZ = 0;

        public bool FlippedX = false;
        public bool FlippedY = false;
        public bool FlippedZ = false;

        public int OffsetX = 0;
        public int OffsetY = 0;
        public int OffsetZ = 0;

        public CubeColor[,,] matrix;

        public byte[] matrix_legacy = new byte[64];

        public CubeType type;

        public void Clear()
        {
            if (type == CubeType.Monochrome)
            {
                for (int x = 0; x < 64; x++)
                    matrix_legacy[x] = 0;
            }
            else if (type == CubeType.RGB)
            {
                for (int x = 0; x < matrix.GetLength(0); x++)
                    for (int y = 0; y < matrix.GetLength(1); y++)
                        for (int z = 0; z < matrix.GetLength(2); z++)
                            matrix[x, y, z] = 0;
            }
        }

        public void Flip(Axis axis)
        {
            matrix = Flip(axis, matrix);
        }

        public void Rotate(Rotation orientation, int iterations = 0)
        {
            do
            {
                matrix = Rotate(orientation, matrix);
                iterations--;
            } while (iterations > -1);
        }

        public void Shift(Direction direction, int iterations = 0)
        {
            do
            {
                matrix = Shift(direction, matrix);
                iterations--;
            } while (iterations > -1);
        }
    }
}
