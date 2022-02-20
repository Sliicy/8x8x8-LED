using System;

namespace _8x8x8_LED.Core.Models
{
    /// <summary>
    /// Cube that has LEDs which can only be either on or off.
    /// </summary>
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

        public byte[] matrixBytes = new byte[64];

        public MonochromeCube(int size)
        {
            matrixBytes = new byte[size];
        }

        public void Clear()
        {
            for (int i = 0; i < matrixBytes.Length; i++)
                matrixBytes[i] = 0;
        }
    }
}