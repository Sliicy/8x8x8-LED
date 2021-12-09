using _8x8x8_LED.Helpers;
using System;

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

        public void Shift(Direction direction, int iterations = 0, bool repeating = true)
        {
            do
            {
                matrix = Shift(direction, matrix, repeating);
                iterations--;
            } while (iterations > -1);
        }

        public void DrawPlane(Axis axis, int offset = 0, CubeColor color = CubeColor.Black)
        {
            switch (axis)
            {
                case Axis.X:
                    for (int y = 0; y < matrix.GetLength(1); y++)
                        for (int z = 0; z < matrix.GetLength(2); z++)
                            matrix[offset, y, z] = color;
                    break;
                case Axis.Y:
                    for (int x = 0; x < matrix.GetLength(0); x++)
                        for (int z = 0; z < matrix.GetLength(2); z++)
                            matrix[x, offset, z] = color;
                    break;
                case Axis.Z:
                    for (int x = 0; x < matrix.GetLength(0); x++)
                        for (int y = 0; y < matrix.GetLength(1); y++)
                            matrix[x, y, offset] = color;
                    break;
            }
        }

        /// <summary>
        /// Adaptation of Bresenham's Line Algorithm from https://stackoverflow.com/questions/16505905/walk-a-line-between-two-points-in-a-3d-voxel-space-visiting-all-cells
        /// </summary>
        public void DrawLine(double gx0, double gy0, double gz0, double gx1, double gy1, double gz1, CubeColor color)
        {

            var gx0idx = Math.Floor(gx0);
            var gy0idx = Math.Floor(gy0);
            var gz0idx = Math.Floor(gz0);

            var gx1idx = Math.Floor(gx1);
            var gy1idx = Math.Floor(gy1);
            var gz1idx = Math.Floor(gz1);

            var sx = gx1idx > gx0idx ? 1 : gx1idx < gx0idx ? -1 : 0;
            var sy = gy1idx > gy0idx ? 1 : gy1idx < gy0idx ? -1 : 0;
            var sz = gz1idx > gz0idx ? 1 : gz1idx < gz0idx ? -1 : 0;

            var gx = gx0idx;
            var gy = gy0idx;
            var gz = gz0idx;

            // Planes for each axis that we will next cross
            var gxp = gx0idx + (gx1idx > gx0idx ? 1 : 0);
            var gyp = gy0idx + (gy1idx > gy0idx ? 1 : 0);
            var gzp = gz0idx + (gz1idx > gz0idx ? 1 : 0);

            // Only used for multiplying up the error margins
            var vx = gx1 == gx0 ? 1 : gx1 - gx0;
            var vy = gy1 == gy0 ? 1 : gy1 - gy0;
            var vz = gz1 == gz0 ? 1 : gz1 - gz0;

            // Error is normalized to vx * vy * vz so we only have to multiply up
            var vxvy = vx * vy;
            var vxvz = vx * vz;
            var vyvz = vy * vz;

            // Error from the next plane accumulators, scaled up by vx*vy*vz
            // gx0 + vx * rx == gxp
            // vx * rx == gxp - gx0
            // rx == (gxp - gx0) / vx
            var errx = (gxp - gx0) * vyvz;
            var erry = (gyp - gy0) * vxvz;
            var errz = (gzp - gz0) * vxvy;

            var derrx = sx * vyvz;
            var derry = sy * vxvz;
            var derrz = sz * vxvy;

            do
            {
                int renderX = (int)gx;
                int renderY = (int)gy;
                int renderZ = (int)gz;
                if (renderX < 0)
                    renderX = 0;
                if (renderY < 0)
                    renderY = 0;
                if (renderZ < 0)
                    renderZ = 0;
                if (renderX >= width)
                    renderX = width - 1;
                if (renderY >= length)
                    renderY = length - 1;
                if (renderZ >= height)
                    renderZ = height - 1;

                matrix[renderX, renderY, renderZ] = color;

                if (gx == gx1idx && gy == gy1idx && gz == gz1idx) break;
                if (gx < 0 || gy < 0 || gz < 0) break;


                // Which plane do we cross first?
                var xr = Math.Abs(errx);
                var yr = Math.Abs(erry);
                var zr = Math.Abs(errz);

                if (sx != 0 && (sy == 0 || xr < yr) && (sz == 0 || xr < zr))
                {
                    gx += sx;
                    errx += derrx;
                }
                else if (sy != 0 && (sz == 0 || yr < zr))
                {
                    gy += sy;
                    erry += derry;
                }
                else if (sz != 0)
                {
                    gz += sz;
                    errz += derrz;
                }
                ;
            } while (true);
        }
    }
}
