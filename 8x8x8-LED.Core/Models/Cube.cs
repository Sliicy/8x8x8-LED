using _8x8x8_LED.Core.Models.Geometry;
using System;

namespace _8x8x8_LED.Core.Models
{
    /// <summary>
    /// Class that is passed to the cube over USB serial. By default, it supports RGB.
    /// </summary>
    [Serializable]
    public class Cube : ICube
    {

        #region Cube State

        // Represents the current state of the cube (should it be rotated, flipped, have an offset, etc):

        public int OrientationX = 0;
        public int OrientationY = 0;
        public int OrientationZ = 0;

        public bool FlippedX = false;
        public bool FlippedY = false;
        public bool FlippedZ = false;

        public int OffsetX = 0;
        public int OffsetY = 0;
        public int OffsetZ = 0;

        #endregion

        public CubeColor[,,] matrix;
        public CubeType type;
        public int width;
        public int length;
        public int height;

        /// <summary>
        /// Initializes a <see cref="Cube"/>, optionally by custom dimensions (default is 8x8x8).
        /// </summary>
        /// <param name="x">Width of <see cref="Cube"/>.</param>
        /// <param name="y">Length of <see cref="Cube"/>.</param>
        /// <param name="z">Height of <see cref="Cube"/>.</param>
        public Cube(int x = 8, int y = 8, int z = 8)
        {
            width = x;
            length = y;
            height = z;
            matrix = new CubeColor[width, length, height];
        }

        public CubeColor[,,] Rotate(Rotation rotation, CubeColor[,,] input)
        {
            int inputLength = input.GetLength(0);
            int inputWidth = input.GetLength(1);
            int inputHeight = input.GetLength(2);

            var output = new CubeColor[inputWidth, inputLength, inputHeight];
            int maxHeight = inputWidth - 1;

            for (int k = 0; k < output.GetLength(2); k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        output[i, j, k] = rotation switch
                        {
                            Rotation.ClockwiseX => input[maxHeight - k, j, i],
                            Rotation.ClockwiseY => input[i, k, maxHeight - j],
                            Rotation.ClockwiseZ => input[maxHeight - j, i, k],
                            Rotation.CounterclockwiseX => input[k, j, maxHeight - i],
                            Rotation.CounterclockwiseY => input[i, k, maxHeight - j],
                            Rotation.CounterclockwiseZ => input[j, maxHeight - i, k],
                            _ => input[i, j, k],
                        };
            return output;
        }


        public CubeColor[,,] Shift(Direction direction, CubeColor[,,] input, bool repeating = true, CubeColor backColor = CubeColor.Black)
        {
            int inputLength = input.GetLength(0);
            int inputWidth = input.GetLength(1);
            int inputHeight = input.GetLength(2);
            int maxHeight = inputWidth - 1;

            var output = new CubeColor[inputWidth, inputLength, inputHeight];

            for (int k = 0; k < output.GetLength(2); k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        switch (direction)
                        {
                            case Direction.Upwards:
                                if (!repeating)
                                    input[i, j, maxHeight] = backColor;
                                output[i, j, k] = input[i, j, (k + maxHeight) % output.GetLength(2)];
                                break;
                            case Direction.Downwards:
                                if (!repeating)
                                    input[i, j, 0] = backColor;
                                output[i, j, k] = input[i, j, (k + 1) % output.GetLength(2)];
                                break;
                            case Direction.Leftwards:
                                if (!repeating)
                                    input[0, j, k] = backColor;
                                output[i, j, k] = input[(i + 1) % output.GetLength(0), j, k];
                                break;
                            case Direction.Rightwards:
                                if (!repeating)
                                    input[maxHeight, j, k] = backColor;
                                output[i, j, k] = input[(i + maxHeight) % output.GetLength(0), j, k];
                                break;
                            case Direction.Forwards:
                                if (!repeating)
                                    input[i, 0, k] = backColor;
                                output[i, j, k] = input[i, (j + 1) % output.GetLength(1), k];
                                break;
                            case Direction.Backwards:
                                if (!repeating)
                                    input[i, maxHeight, k] = backColor;
                                output[i, j, k] = input[i, (j + maxHeight) % output.GetLength(1), k];
                                break;
                            default:
                                output[i, j, k] = input[i, j, k];
                                break;
                        }
            return output;
        }

        public CubeColor[,,] Flip(Axis axis, CubeColor[,,] input)
        {
            int inputLength = input.GetLength(0);
            int inputWidth = input.GetLength(1);
            int inputHeight = input.GetLength(2);

            var output = new CubeColor[inputWidth, inputLength, inputHeight];
            int maxHeight = inputWidth - 1;

            for (int k = 0; k < output.GetLength(2); k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        output[i, j, k] = axis switch
                        {
                            Axis.X => input[maxHeight - i, j, k],
                            Axis.Y => input[i, maxHeight - j, k],
                            Axis.Z => input[i, j, maxHeight - k],
                            _ => input[i, j, k],
                        };
            return output;
        }

        public void Clear(CubeColor color = CubeColor.Black)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    for (int z = 0; z < matrix.GetLength(2); z++)
                        matrix[x, y, z] = color;
        }

        /// <summary>
        /// Flips the <see cref="Cube"/> by <paramref name="axis"/>.
        /// </summary>
        /// <param name="axis"><see cref="Axis"/> to flip on.</param>
        public void Flip(Axis axis)
        {
            matrix = Flip(axis, matrix);
        }

        /// <summary>
        /// Rotates the <see cref="Cube"/> by <paramref name="direction"/>, <paramref name="iterations"/> number of times.
        /// </summary>
        /// <param name="direction">Direction of <see cref="Rotation"/>.</param>
        /// <param name="iterations"><see cref="int"/> number of times to rotate.</param>
        public void Rotate(Rotation direction, int iterations = 0)
        {
            do
            {
                matrix = Rotate(direction, matrix);
                iterations--;
            } while (iterations > -1);
        }

        /// <summary>
        /// Shifts the <see cref="Cube"/> by <paramref name="direction"/>, <paramref name="iterations"/> number of times.
        /// </summary>
        /// <remarks>If <paramref name="repeating"/>, edges will reappear on the opposite side.</remarks>
        /// <param name="direction"><see cref="Direction"/> to shift.</param>
        /// <param name="iterations"><see cref="int"/> number of times to shift.</param>
        /// <param name="repeating"><see cref="bool"/> whether or not to repeat on the opposite side.</param>
        public void Shift(Direction direction, int iterations = 0, bool repeating = true)
        {
            do
            {
                matrix = Shift(direction, matrix, repeating);
                iterations--;
            } while (iterations > -1);
        }

        public void DrawPoint(int x, int y, int z, CubeColor color)
        {
            matrix[x, y, z] = color;
        }

        public void DrawStraightLine(Axis axis, int offset1, int offset2, CubeColor color)
        {
            switch (axis)
            {
                case Axis.X:
                    for (int i = 0; i < matrix.GetLength(0); i++)
                        matrix[offset1, i, offset2] = color;
                    break;
                case Axis.Y:
                    for (int i = 0; i < matrix.GetLength(1); i++)
                        matrix[i, offset1, offset2] = color;
                    break;
                case Axis.Z:
                    for (int i = 0; i < matrix.GetLength(2); i++)
                        matrix[offset1, offset2, i] = color;
                    break;
            }
        }

        public void DrawLine(double gx0, double gy0, double gz0, double gx1, double gy1, double gz1, CubeColor color)
        {
            // This method is adapted from Bresenham's Line Algorithm: https://stackoverflow.com/questions/16505905/walk-a-line-between-two-points-in-a-3d-voxel-space-visiting-all-cells
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


                // Which plane to cross first
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
    }
}
