using _8x8x8_LED.Model;
using _8x8x8_LED.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED
{
    public static class SerialHelper
    {
        public const byte MONOCHROME_HEADER = 0xF2;
        public static readonly byte[] RGB_HEADER = { 0x00, 0xFF, 0x00, 0x00 };

        public static void SendPacket(CubeType cubeType, SerialPort serialPort, byte[] payload, bool prependHeader = true)
        {
            if (serialPort.IsOpen)
            {

                if (!prependHeader)
                {
                    serialPort.Write(payload, 0, payload.Length);
                    return;
                }

                // Import payload with room for header:
                var dataPacket = new byte[payload.Length + (cubeType == CubeType.Monochrome ? 1 : 6)];

                // Copy header:
                if (cubeType == CubeType.Monochrome)
                    dataPacket[0] = MONOCHROME_HEADER;
                else if (cubeType == CubeType.RGB)
                {
                    dataPacket[0] = RGB_HEADER[0];
                    dataPacket[1] = RGB_HEADER[1];
                    dataPacket[2] = RGB_HEADER[2];
                    dataPacket[3] = RGB_HEADER[3];
                    dataPacket[4] = 0; // Needs to reflect the correct color depth
                    dataPacket[5] = 0; // Needs to reflect the correct Z-Axis layer
                }
                    

                // Copy payload:
                for (int i = (cubeType == CubeType.Monochrome ? 1 : 6); i < dataPacket.Length; i++)
                {
                    dataPacket[i] = payload[i - (cubeType == CubeType.Monochrome ? 1 : 6)];
                }

                // Send bytes:
                serialPort.Write(dataPacket, 0, dataPacket.Length);
            }
        }
        public static void Send(SerialPort serialPort, MonochromeCube cube)
        {
            // Create a new cube, copy the matrix, and perform orientational operations:
            MonochromeCube outputCube = new MonochromeCube(cube.matrix.Length);
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
                    outputCube.Rotate(Rotation.ClockwiseX, 0);
                
                if (cube.OrientationX == 180)
                    outputCube.Rotate(Rotation.ClockwiseX, 1);
                
                if (cube.OrientationX == 270)
                    outputCube.Rotate(Rotation.ClockwiseX, 2);
                
            }
                
            if (cube.OrientationY != 0)
            {
                if (cube.OrientationY == 90)
                    outputCube.Rotate(Rotation.ClockwiseY, 0);
                
                if (cube.OrientationY == 180)
                    outputCube.Rotate(Rotation.ClockwiseY, 1);
                
                if (cube.OrientationY == 270)
                    outputCube.Rotate(Rotation.ClockwiseY, 2);
                
            }
                
            if (cube.OrientationZ != 0)
            {
                if (cube.OrientationZ == 90)
                    outputCube.Rotate(Rotation.ClockwiseZ, 0);
                
                if (cube.OrientationZ == 180)
                    outputCube.Rotate(Rotation.ClockwiseZ, 1);
                
                if (cube.OrientationZ == 270)
                    outputCube.Rotate(Rotation.ClockwiseZ, 2);
                
            }

            if (cube.OffsetX != 0)
                outputCube.Shift(Direction.Forwards, true, Math.Abs(cube.OffsetX) - 1);
            
            if (cube.OffsetY != 0)
                outputCube.Shift(Direction.Leftwards, true, Math.Abs(cube.OffsetY) - 1);
            
            if (cube.OffsetZ != 0)
                outputCube.Shift(Direction.Downwards, true, Math.Abs(cube.OffsetZ) - 1);
            
            SendPacket(CubeType.Monochrome, serialPort, outputCube.matrix);
        }
    }
}
