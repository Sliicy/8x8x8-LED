using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Model
{
    [Serializable]
    public class Cube
    {

        public byte[] matrix = new byte[64];

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


        public Cube(int size)
        {
            matrix = new byte[size];
        }

        public void Set(byte[] newMatrix)
        {
            matrix = newMatrix;
        }

        public byte[] Get()
        {
            return matrix;
        }

        public void Animate(SerialPort serialPort)
        {
            SerialHelper.SendPacket(serialPort, matrix);
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
        public static Position CoordinatesAt(int coordinates, Axis axis)
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
            byte[] output = new byte[matrix.Length];
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
                                    output[y + z] = matrix[y + z + 7];
                                } else
                                {
                                    output[y + z] = matrix[(y + z) - 1];
                                }
                            }
                            else
                            {
                                if (CoordinatesAt(y + z, Axis.Z) != Position.Bottom)
                                {
                                    output[y + z] = matrix[(y + z) - 1];
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
                                    output[y + z] = matrix[y + z - 7];
                                }
                                else
                                {
                                    output[y + z] = matrix[y + z + 1];
                                }
                            }
                            else
                            {
                                if (CoordinatesAt(y + z, Axis.Z) != Position.Top)
                                {
                                    output[y + z] = matrix[y + z + 1];
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
                                    output[y + z] = matrix[y + z - 56];
                                } else
                                {
                                    output[y + z] = matrix[(y + z) + 8];
                                }
                            } else
                            {
                                if (CoordinatesAt(y + z, Axis.Y) != Position.Right)
                                {
                                    output[y + z] = matrix[(y + z) + 8];
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
                                    output[y + z] = matrix[y + z + 56];
                                } else
                                {
                                    output[y + z] = matrix[(y + z) - 8];
                                }
                            } else
                            {
                                if (CoordinatesAt(y + z, Axis.Y) != Position.Left)
                                {
                                    output[y + z] = matrix[(y + z) - 8];
                                }
                            }
                        }
                    }
                    break;
                case Direction.Forwards:
                    for (int y = 0; y < 64; y++)
                    {
                        if (looping && matrix[y] % 2 != 0)
                        {
                            output[y] = Convert.ToByte(((matrix[y] - 1) / 2 + 128) % 256);
                        }
                        else
                        {
                            output[y] = Convert.ToByte((matrix[y] / 2) % 256);
                        }
                    }
                    break;
                case Direction.Backwards:
                    for (int y = 0; y < 64; y++)
                    {
                        if (looping && matrix[y] - 128 > 0)
                        {
                            output[y] = Convert.ToByte(((matrix[y] + 128) * 2 + 1) % 256);
                        }
                        else
                        {
                            output[y] = Convert.ToByte((matrix[y] * 2) % 256);
                        }
                    }
                    break;
            }
            output.CopyTo(matrix, 0);
            if (iterations > 0)
            {
                Shift(direction, looping, iterations - 1);
            }
        }

        public void Flip(Axis axis)
        {
            byte[] output = new byte[matrix.Length];
            if (axis == Axis.X)
            {
                throw new NotImplementedException(); // TODO
            }
            else if (axis == Axis.Y)
            {
                var array2D = new byte[8, 8];
                int counter = 0;
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        array2D[y, x] = matrix[counter];
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
                        array2D[x, y] = matrix[counter];
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
            output.CopyTo(matrix, 0);
        }

        public void Rotate(Orientation orientation, int iterations = 0)
        {
            byte[] output = new byte[matrix.Length];
            if (orientation == Orientation.ClockwiseX)
            {
                throw new NotImplementedException(); // TODO





            } else if (orientation == Orientation.ClockwiseY)
            {
                Rotate(Orientation.CounterclockwiseY, 2 - iterations);
                return;
            } else if (orientation == Orientation.ClockwiseZ)
            {
                throw new NotImplementedException(); // TODO
            } else if (orientation == Orientation.CounterclockwiseX)
            {
                throw new NotImplementedException(); // TODO


            } else if (orientation == Orientation.CounterclockwiseY)
            {
                var array2D = new byte[8, 8];
                int counter = 0;
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        array2D[x, y] = matrix[counter];
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
            } else if (orientation == Orientation.CounterclockwiseZ)
            {
                throw new NotImplementedException(); // TODO
            }
            output.CopyTo(matrix, 0);
            if (iterations > 0)
            {
                Rotate(orientation, iterations - 1);
            }
        }

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