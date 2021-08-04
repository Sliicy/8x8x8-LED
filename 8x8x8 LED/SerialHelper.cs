using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED
{
    static class SerialHelper
    {
        const byte HEADER = 0xF2;
        public static void Send(SerialPort serialPort, byte[] payload, bool prependHeader = true)
        {
            if (serialPort.IsOpen)
            {

                if (!prependHeader)
                {
                    serialPort.Write(payload, 0, payload.Length);
                    return;
                }

                // Import payload with room for header:
                var dataPacket = new byte[payload.Length + 1];

                // Copy header:
                dataPacket[0] = HEADER;

                // Copy payload:
                for (int i = 1; i < dataPacket.Length - 1; i++)
                {
                    dataPacket[i] = payload[i - 1];
                }

                // Send bytes:
                serialPort.Write(dataPacket, 0, dataPacket.Length);
            }
        }

        private static byte[,] RotateMatrixCounterClockwise(byte[,] oldMatrix)
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

        //var array2D = new byte[8, 8];
        //int counter = 0;
        //for (int x = 0; x < 8; x++)
        //{
        //    for (int y = 0; y < 8; y++)
        //    {
        //        array2D[x, y] = bytesToSend[counter];
        //        counter++;
        //    }
        //}
        //
        //var output2DArray = RotateMatrixCounterClockwise(RotateMatrixCounterClockwise(array2D));
        //counter = 0;
        //for (int x = 0; x < 8; x++)
        //{
        //    for (int y = 0; y < 8; y++)
        //    {
        //        bytesToSend[counter] = output2DArray[x, y];
        //        counter++;
        //    }
        //}
    }
}
