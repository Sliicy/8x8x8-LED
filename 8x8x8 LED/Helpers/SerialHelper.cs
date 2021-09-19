using _8x8x8_LED.Model;
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
        public static void SendPacket(SerialPort serialPort, byte[] payload, bool prependHeader = true)
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
                for (int i = 1; i < dataPacket.Length; i++)
                {
                    dataPacket[i] = payload[i - 1];
                }

                // Send bytes:
                serialPort.Write(dataPacket, 0, dataPacket.Length);
            }
        }
        public static void Send(SerialPort serialPort, Cube cube)
        {
            // Create a new cube, copy the matrix, and perform orientational operations:
            Cube outputCube = new Cube(cube.matrix.Length);
            cube.matrix.CopyTo(outputCube.matrix, 0);
            if (cube.FlippedX)
                outputCube.Flip(Axis.X);
            if (cube.FlippedY)
                outputCube.Flip(Axis.Y);
            if (cube.FlippedZ)
                outputCube.Flip(Axis.Z);

            if (cube.OrientationX != 0)
            {

                if (cube.OrientationX == 90)
                {
                    outputCube.Rotate(Orientation.ClockwiseX, 0);
                }
                if (cube.OrientationX == 180)
                {
                    outputCube.Rotate(Orientation.ClockwiseX, 1);
                }
                if (cube.OrientationX == 270)
                {
                    outputCube.Rotate(Orientation.ClockwiseX, 2);
                }

            }
                
            if (cube.OrientationY != 0)
            {
                if (cube.OrientationY == 90)
                {
                    outputCube.Rotate(Orientation.ClockwiseY, 0);
                }
                if (cube.OrientationY == 180)
                {
                    outputCube.Rotate(Orientation.ClockwiseY, 1);
                }
                if (cube.OrientationY == 270)
                {
                    outputCube.Rotate(Orientation.ClockwiseY, 2);
                }
            }
                
            if (cube.OrientationZ != 0)
            {
                if (cube.OrientationZ == 90)
                {
                    outputCube.Rotate(Orientation.ClockwiseZ, 0);
                }
                if (cube.OrientationZ == 180)
                {
                    outputCube.Rotate(Orientation.ClockwiseZ, 1);
                }
                if (cube.OrientationZ == 270)
                {
                    outputCube.Rotate(Orientation.ClockwiseZ, 2);
                }
            }
            SendPacket(serialPort, outputCube.matrix);
        }
    }
}
