using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Model
{
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

        // Lighting up back-left-bottom LED:
        // matrix[0] = 1

        // Lighting up back-left-top LED:
        // matrix[7] = 1

        // Lighting up entire row-right-top LED:
        // matrix[63] = 255

        // Lighting up front-right-top LED:
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

        public static Position CoordinatesAt(bool vertical, int coordinates)
        {

            if (vertical = true)
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
                else if (coordinates == 7 ||
                    coordinates == 63 ||
                    coordinates == 62 ||
                    coordinates == 61 ||
                    coordinates == 60 ||
                    coordinates == 59 ||
                    coordinates == 58 ||
                    coordinates == 57)
                {
                    return Position.Right;
                }
            }
            return Position.None;
        }

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
                                if (CoordinatesAt(true, y + z) == Position.Bottom)
                                {
                                    output[y + z] = matrix[y + z + 7];
                                } else
                                {
                                    output[y + z] = matrix[(y + z) - 1];
                                }
                            }
                            else
                            {
                                if (CoordinatesAt(true, y + z) != Position.Bottom)
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
                                if (CoordinatesAt(true, y + z) == Position.Top)
                                {
                                    output[y + z] = matrix[y + z - 7];
                                }
                                else
                                {
                                    output[y + z] = matrix[(y + z) + 1];
                                }
                            }
                            else
                            {
                                if (CoordinatesAt(true, y + z) != Position.Top)
                                {
                                    output[y + z] = matrix[(y + z) + 1];
                                }
                            }
                        }
                    }
                    break;
                case Direction.Leftwards: // TODO fix


                    for (int y = 0; y < 63; y += 8)
                    {
                        for (int z = 0; z < 8; z++)
                        {
                            if (looping)
                            {
                                if (CoordinatesAt(false, y + z) == Position.Left)
                                {
                                    output[y + z] = matrix[y + z + 56];
                                }
                                else
                                {
                                    output[y + z] = matrix[(y + z) + 8];
                                }
                            }
                            else
                            {
                                if (CoordinatesAt(false, y + z) != Position.Right)
                                {
                                    output[y + z] = matrix[(y + z) + 8];
                                }
                            }
                        }
                    }









                    break;
                case Direction.Rightwards:

                    break;
                case Direction.Frontwards:
                    for (int y = 0; y < 64; y++)
                    {
                        if (looping)
                        {
                            // TODO: Figure out forward looping

                            if (output[y] - 128 > 0)
                            {
                                output[y] = Convert.ToByte(((matrix[y] - 127) / 2) % 256);
                            } else
                            {
                                output[y] = Convert.ToByte((matrix[y] / 2) % 256);
                            }


                            
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
                        if (looping)
                        {
                            
                        }
                        else
                        {
                            output[y] = Convert.ToByte((matrix[y] * 2) % 256);
                        }
                    }
                    break;
            }
            if (iterations > 0)
            {
                output.CopyTo(matrix, 0);
                Shift(direction, looping, iterations - 1);
            }
            else
            {
                output.CopyTo(matrix, 0);
            }

        }
    }
}