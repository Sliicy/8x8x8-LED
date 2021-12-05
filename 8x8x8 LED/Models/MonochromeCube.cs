using _8x8x8_LED.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Model
{
    [Serializable]
    public class MonochromeCube : Cube
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

        // Lighting up the back bottom-left LED:
        // matrix[0] = 1

        // Lighting up the back top-left LED:
        // matrix[7] = 1

        // Lighting up entire top-right row LED:
        // matrix[63] = 255

        // Lighting up the front top-right LED:
        // matrix[56] = 128

        public MonochromeCube(int size)
        {
            matrix_legacy = new byte[size];
        }

        public void Clear_legacy()
        {
            for (int i = 0; i < matrix_legacy.Length; i++)
                matrix_legacy[i] = 0;
        }

        /// <summary>
        /// Returns where a specific point is located relative to the cube.
        /// Valid Positions are Top, Bottom, Left, and Right.
        /// Coordinates represents a number from 0 - 63.
        /// Axis indicates which axis to analyze.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="vertical"></param>
        /// <returns></returns>
        private static Position CoordinatesAt(int coordinates, Axis axis)
        {
            if (axis == Axis.Z)
            {
                if (coordinates == 0 ||
                coordinates == 8 ||
                coordinates == 16 ||
                coordinates == 24 ||
                coordinates == 32 ||
                coordinates == 40 ||
                coordinates == 48 ||
                coordinates == 56)
                {
                    return Position.Bottom;
                }
                else if (coordinates == 7 ||
                    coordinates == 15 ||
                    coordinates == 23 ||
                    coordinates == 31 ||
                    coordinates == 39 ||
                    coordinates == 47 ||
                    coordinates == 55 ||
                    coordinates == 63)
                {
                    return Position.Top;
                }
            } else {
                if (coordinates == 0 ||
                coordinates == 1 ||
                coordinates == 2 ||
                coordinates == 3 ||
                coordinates == 4 ||
                coordinates == 5 ||
                coordinates == 6 ||
                coordinates == 7)
                {
                    return Position.Left;
                }
                else if (coordinates == 56 ||
                    coordinates == 57 ||
                    coordinates == 58 ||
                    coordinates == 59 ||
                    coordinates == 60 ||
                    coordinates == 61 ||
                    coordinates == 62 ||
                    coordinates == 63)
                {
                    return Position.Right;
                }
            }
            return Position.None;
        }

        /// <summary>
        /// Shifts all points on the cube a direction.
        /// Direction is the direction to shift to.
        /// Looping indicates if the points on the edge should "teleport" to the other side.
        /// Iterations is how many times to perform the shift.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="looping"></param>
        /// <param name="iterations"></param>
        public void Shift(Direction direction, bool looping = false, int iterations = 0)
        {
            byte[] output = new byte[matrix_legacy.Length];
            switch (direction)
            {
                case Direction.Upwards:
                    for (int y = 0; y < 63; y += 8)
                    {
                        for (int z = 0; z < 8; z++)
                        {
                            if (looping)
                            {
                                if (CoordinatesAt(y + z, Axis.Z) == Position.Bottom)
                                {
                                    output[y + z] = matrix_legacy[y + z + 7];
                                } else
                                {
                                    output[y + z] = matrix_legacy[(y + z) - 1];
                                }
                            }
                            else
                            {
                                if (CoordinatesAt(y + z, Axis.Z) != Position.Bottom)
                                {
                                    output[y + z] = matrix_legacy[(y + z) - 1];
                                }
                            }
                        }
                    }
                    break;
                case Direction.Downwards:
                    for (int y = 0; y < 63; y += 8)
                    {
                        for (int z = 0; z < 8; z++)
                        {
                            if (looping)
                            {
                                if (CoordinatesAt(y + z, Axis.Z) == Position.Top)
                                {
                                    output[y + z] = matrix_legacy[y + z - 7];
                                }
                                else
                                {
                                    output[y + z] = matrix_legacy[y + z + 1];
                                }
                            }
                            else
                            {
                                if (CoordinatesAt(y + z, Axis.Z) != Position.Top)
                                {
                                    output[y + z] = matrix_legacy[y + z + 1];
                                }
                            }
                        }
                    }
                    break;
                case Direction.Leftwards:
                    for (int y = 0; y < 63; y += 8)
                    {
                        for (int z = 0; z < 8; z++)
                        {
                            if (looping)
                            {
                                if (CoordinatesAt(y + z, Axis.Y) == Position.Right)
                                {
                                    output[y + z] = matrix_legacy[y + z - 56];
                                } else
                                {
                                    output[y + z] = matrix_legacy[(y + z) + 8];
                                }
                            } else
                            {
                                if (CoordinatesAt(y + z, Axis.Y) != Position.Right)
                                {
                                    output[y + z] = matrix_legacy[(y + z) + 8];
                                }
                            }
                        }
                    }
                    break;
                case Direction.Rightwards:
                    for (int y = 0; y < 63; y += 8)
                    {
                        for (int z = 0; z < 8; z++)
                        {
                            if (looping)
                            {
                                if (CoordinatesAt(y + z, Axis.Y) == Position.Left)
                                {
                                    output[y + z] = matrix_legacy[y + z + 56];
                                } else
                                {
                                    output[y + z] = matrix_legacy[(y + z) - 8];
                                }
                            } else
                            {
                                if (CoordinatesAt(y + z, Axis.Y) != Position.Left)
                                {
                                    output[y + z] = matrix_legacy[(y + z) - 8];
                                }
                            }
                        }
                    }
                    break;
                case Direction.Forwards:
                    for (int y = 0; y < 64; y++)
                    {
                        if (looping && matrix_legacy[y] % 2 != 0)
                        {
                            output[y] = Convert.ToByte(((matrix_legacy[y] - 1) / 2 + 128) % 256);
                        }
                        else
                        {
                            output[y] = Convert.ToByte((matrix_legacy[y] / 2) % 256);
                        }
                    }
                    break;
                case Direction.Backwards:
                    for (int y = 0; y < 64; y++)
                    {
                        if (looping && matrix_legacy[y] - 128 > 0)
                        {
                            output[y] = Convert.ToByte(((matrix_legacy[y] + 128) * 2 + 1) % 256);
                        }
                        else
                        {
                            output[y] = Convert.ToByte((matrix_legacy[y] * 2) % 256);
                        }
                    }
                    break;
            }
            output.CopyTo(matrix_legacy, 0);
            if (iterations > 0)
            {
                Shift(direction, looping, iterations - 1);
            }
        }

        /// <summary>
        /// Returns a shifted array.
        /// </summary>
        /// <param name="cube"></param>
        /// <param name="direction"></param>
        /// <param name="looping"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public static byte[] Shifted(MonochromeCube cube, Direction direction, bool looping = false, int iterations = 0)
        {
            cube.Shift(direction, looping, iterations);
            return cube.matrix_legacy;
        }

        /// <summary>
        /// Extrapolates all bases that make up the number (18 becomes 16, 2. 27 becomes 16, 8, 2, 1)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> BasesFromNumber(int input)
        {
            List<int> output = new List<int>();
            if (input - 128 >= 0)
            {
                output.Add(128);
                input -= 128;
            }
            if (input - 64 >= 0)
            {
                output.Add(64);
                input -= 64;
            }
            if (input - 32 >= 0)
            {
                output.Add(32);
                input -= 32;
            }
            if (input - 16 >= 0)
            {
                output.Add(16);
                input -= 16;
            }
            if (input - 8 >= 0)
            {
                output.Add(8);
                input -= 8;
            }
            if (input - 4 >= 0)
            {
                output.Add(4);
                input -= 4;
            }
            if (input - 2 >= 0)
            {
                output.Add(2);
                input -= 2;
            }
            if (input - 1 >= 0)
            {
                output.Add(1);
            }

            return output;
        }

        /// <summary>
        /// Flips the cube along the X, Y, or Z Axis.
        /// </summary>
        /// <param name="axis"></param>
        public void Flip(Axis axis)
        {
            byte[] output = new byte[matrix_legacy.Length];
            if (axis == Axis.X)
            {
                for (int i = 0; i < matrix_legacy.Length; i++)
                {
                    var inputComposition = BasesFromNumber(matrix_legacy[i]);
                    var outputComposition = new List<int>();
                    if (inputComposition.Contains(1))
                    {
                        outputComposition.Add(128);
                    }
                    if (inputComposition.Contains(2))
                    {
                        outputComposition.Add(64);
                    }
                    if (inputComposition.Contains(4))
                    {
                        outputComposition.Add(32);
                    }
                    if (inputComposition.Contains(8))
                    {
                        outputComposition.Add(16);
                    }
                    if (inputComposition.Contains(16))
                    {
                        outputComposition.Add(8);
                    }
                    if (inputComposition.Contains(32))
                    {
                        outputComposition.Add(4);
                    }
                    if (inputComposition.Contains(64))
                    {
                        outputComposition.Add(2);
                    }
                    if (inputComposition.Contains(128))
                    {
                        outputComposition.Add(1);
                    }

                    foreach (int number in outputComposition)
                    {
                        output[i] += Convert.ToByte(number);
                    }
                }
            }
            else if (axis == Axis.Y)
            {
                var array2D = new byte[8, 8];
                int counter = 0;
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        array2D[y, x] = matrix_legacy[counter];
                        counter++;
                    }
                }
                var output2DArray = RotateCounterClockwise(array2D);
                counter = 0;
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        output[counter] = output2DArray[x, y];
                        counter++;
                    }
                }
            }
            else if (axis == Axis.Z)
            {
                var array2D = new byte[8, 8];
                int counter = 63;
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        array2D[x, y] = matrix_legacy[counter];
                        counter--;
                    }
                }
                var output2DArray = RotateCounterClockwise(array2D);
                counter = 0;
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        output[counter] = output2DArray[x, y];
                        counter++;
                    }
                }
            }
            output.CopyTo(matrix_legacy, 0);
        }

        /// <summary>
        /// Returns a flipped array.
        /// </summary>
        /// <param name="cube"></param>
        /// <param name="axis"></param>
        public static byte[] Flipped(MonochromeCube cube, Axis axis)
        {
            cube.Flip(axis);
            return cube.matrix_legacy;
        }

        /// <summary>
        /// Rotate the points on the cube by the X, Y, or Z axis.
        /// Orientation is the direction (clockwise, counterclockwise).
        /// Iterations are how many times to rotate it.
        /// </summary>
        /// <param name="orientation"></param>
        /// <param name="iterations"></param>
        public void Rotate(Rotation orientation, int iterations = 0)
        {
            byte[] output = new byte[matrix_legacy.Length];
            if (orientation == Rotation.ClockwiseX)
            {
                int x = 1;
                int counter = 0;
                for (int i = 0; i < matrix_legacy.Length; i++)
                {
                    if (BasesFromNumber(matrix_legacy[i]).Contains(1))
                        output[counter + 7] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(2))
                        output[counter + 6] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(4))
                        output[counter + 5] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(8))
                        output[counter + 4] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(16))
                        output[counter + 3] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(32))
                        output[counter + 2] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(64))
                        output[counter + 1] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(128))
                        output[counter + 0] += Convert.ToByte(x);
                    x *= 2;
                    if (x == 256)
                    {
                        x = 1;
                        counter += 8;
                    }
                }
            } else if (orientation == Rotation.ClockwiseY)
            {
                Rotate(Rotation.CounterclockwiseY, 2 - iterations);
                return;
            } else if (orientation == Rotation.ClockwiseZ)
            {
                int x = 128;
                int counter = 0;
                for (int i = 0; i < matrix_legacy.Length; i++)
                {
                    if (BasesFromNumber(matrix_legacy[i]).Contains(128))
                        output[56 + i % 8] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(64))
                        output[48 + i % 8] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(32))
                        output[40 + i % 8] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(16))
                        output[32 + i % 8] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(8))
                        output[24 + i % 8] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(4))
                        output[16 + i % 8] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(2))
                        output[8 + i % 8] += Convert.ToByte(x);
                    if (BasesFromNumber(matrix_legacy[i]).Contains(1))
                        output[0 + i % 8] += Convert.ToByte(x);

                    counter++;
                    if (counter % 8 == 0)
                        x /= 2;
                }
            } else if (orientation == Rotation.CounterclockwiseX)
            {
                Rotate(Rotation.ClockwiseX, 2 - iterations);
                return;
            } else if (orientation == Rotation.CounterclockwiseY)
            {
                var array2D = new byte[8, 8];
                int counter = 0;
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        array2D[x, y] = matrix_legacy[counter];
                        counter++;
                    }
                }
                var output2DArray = RotateCounterClockwise(array2D);
                counter = 0;
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        output[counter] = output2DArray[x, y];
                        counter++;
                    }
                }
            } else if (orientation == Rotation.CounterclockwiseZ)
            {
                Rotate(Rotation.ClockwiseZ, 2 - iterations);
                return;

            }
            output.CopyTo(matrix_legacy, 0);
            if (iterations > 0)
            {
                Rotate(orientation, iterations - 1);
            }
        }

        /// <summary>
        /// Returns a rotated array.
        /// </summary>
        /// <param name="cube"></param>
        /// <param name="orientation"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public static byte[] Rotated(MonochromeCube cube, Rotation orientation, int iterations = 0)
        {
            cube.Rotate(orientation, iterations);
            return cube.matrix_legacy;
        }

        /// <summary>
        /// Method used to rotate the Cube.
        /// </summary>
        /// <param name="oldMatrix"></param>
        /// <returns></returns>
        private static byte[,] RotateCounterClockwise(byte[,] oldMatrix)
        {
            byte[,] newMatrix = new byte[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }
    }
}