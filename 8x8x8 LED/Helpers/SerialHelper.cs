using _8x8x8_LED.Helpers;
using _8x8x8_LED.Model;
using _8x8x8_LED.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED
{
    public static class SerialHelper
    {
        public static readonly byte[] MONOCHROME_HEADER = { 0xF2 };
        public static readonly byte[] RGB_HEADER = { 0x00, 0xFF, 0x00, 0x00 };
        public static readonly byte[] RGB_COLOR_LAYER = { 0x00 };
        public static readonly int RGB_Delay = 24;

        public static void SendPacket(CubeType cubeType, SerialPort serialPort, byte[] payload, bool prependHeader = true)
        {
            if (serialPort.IsOpen)
            {

                if (!prependHeader)
                {
                    serialPort.Write(payload, 0, payload.Length);
                    return;
                }

                byte[] outputPayload;

                switch (cubeType)
                {
                    case CubeType.Monochrome:
                        outputPayload = new byte[payload.Length + MONOCHROME_HEADER.Length];
                        outputPayload[0] = MONOCHROME_HEADER[0];

                        // Copy payload:
                        for (int i = MONOCHROME_HEADER.Length; i < payload.Length + MONOCHROME_HEADER.Length; i++)
                        {
                            outputPayload[i] = payload[i - MONOCHROME_HEADER.Length];
                        }

                        // Send bytes:
                        serialPort.Write(outputPayload, 0, outputPayload.Length);
                        break;
                    case CubeType.RGB:

                        // Add space for 2x Headers and 2 destination color depths:
                        outputPayload = new byte[payload.Length + (RGB_HEADER.Length + RGB_COLOR_LAYER.Length) * 2];
                        outputPayload[0] = RGB_HEADER[0];
                        outputPayload[1] = RGB_HEADER[1];
                        outputPayload[2] = RGB_HEADER[2];
                        outputPayload[3] = RGB_HEADER[3];
                        outputPayload[4] = 0;
                        outputPayload[192 + 5] = RGB_HEADER[0];
                        outputPayload[193 + 5] = RGB_HEADER[1];
                        outputPayload[194 + 5] = RGB_HEADER[2];
                        outputPayload[195 + 5] = RGB_HEADER[3];
                        outputPayload[196 + 5] = 1;

                        // Copy 1st payload:
                        for (int i = RGB_HEADER.Length + RGB_COLOR_LAYER.Length;
                            i < (payload.Length / 2) + RGB_HEADER.Length + RGB_COLOR_LAYER.Length;
                            i++)
                        {
                            outputPayload[i] = payload[i - (RGB_HEADER.Length + RGB_COLOR_LAYER.Length)];
                        }
                        
                        // Copy 2nd payload:
                        for (int i = payload.Length / 2 + (RGB_HEADER.Length + RGB_COLOR_LAYER.Length) * 2;
                            i < payload.Length + (RGB_HEADER.Length + RGB_COLOR_LAYER.Length) * 2;
                            i++)
                        {
                            outputPayload[i] = payload[i - (RGB_HEADER.Length + RGB_COLOR_LAYER.Length) * 2];
                        }
                        
                        // Send 1st bytes:
                        serialPort.Write(outputPayload.Take(outputPayload.Length / 2).ToArray(), 0, outputPayload.Length / 2);
                        System.Threading.Thread.Sleep(RGB_Delay);

                        // Send 2nd bytes:
                        serialPort.Write(outputPayload.Skip(outputPayload.Length / 2).ToArray(), 0, outputPayload.Length / 2);
                        System.Threading.Thread.Sleep(RGB_Delay);
                        break;
                    default:
                        throw new ArgumentNullException("Cube Type must be specified.");
                }
            }
        }
        public static void Send(SerialPort serialPort, Cube cube)
        {
            // TODO: Update this method to only support matrix[,,], not matrix[64].
            // Create a new cube, copy the matrix, and perform orientational operations:
            MonochromeCube outputCube = new MonochromeCube(cube.matrix_legacy.Length);
            cube.matrix_legacy.CopyTo(outputCube.matrix_legacy, 0);
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

            if (cube.GetType().ToString().Contains("MonochromeCube"))
            {
                switch (cube.type)
                {
                    case CubeType.Monochrome:
                        //MonochromeCube mc = RGBToMonochromeDriver(cube);
                        SendPacket(CubeType.Monochrome, serialPort, cube.matrix_legacy);
                        break;
                    case CubeType.RGB:
                        RGBCube outputRGBCube = MonochromeToRGBDriver(cube);
                        SendPacket(CubeType.RGB, serialPort, ColorMapper.MatrixToBytes(outputRGBCube.matrix));

                        //SendPacket(CubeType.RGB, serialPort, ColorMapper.MatrixToBytes(cube.matrix));
                        break;
                }

                
            }
            else if (cube.GetType().ToString().Contains("RGBCube"))
            {
                switch (cube.type)
                {
                    case CubeType.Monochrome:
                        MonochromeCube mc = RGBToMonochromeDriver(cube);
                        SendPacket(CubeType.Monochrome, serialPort, mc.matrix_legacy);
                        break;
                    case CubeType.RGB:
                        SendPacket(CubeType.RGB, serialPort, ColorMapper.MatrixToBytes(cube.matrix));
                        break;
                }
            }
        }

        public static RGBCube MonochromeToRGBDriver(Cube mc)
        {
            RGBCube output = new RGBCube(8, 8, 8);

            for (int i = 0; i < mc.matrix_legacy.Length; i++)
            {
                BitArray b = new BitArray(new int[] { mc.matrix_legacy[i] });
                
                if (b[0] == true)
                {
                    output.matrix[0, i / 8, i % 8] = CubeColor.White;
                }
                if (b[1] == true)
                {
                    output.matrix[1, i / 8, i % 8] = CubeColor.White;
                }
                if (b[2] == true)
                {
                    output.matrix[2, i / 8, i % 8] = CubeColor.White;
                }
                if (b[3] == true)
                {
                    output.matrix[3, i / 8, i % 8] = CubeColor.White;
                }
                if (b[4] == true)
                {
                    output.matrix[4, i / 8, i % 8] = CubeColor.White;
                }
                if (b[5] == true)
                {
                    output.matrix[5, i / 8, i % 8] = CubeColor.White;
                }
                if (b[6] == true)
                {
                    output.matrix[6, i / 8, i % 8] = CubeColor.White;
                }
                if (b[7] == true)
                {
                    output.matrix[7, i / 8, i % 8] = CubeColor.White;
                }
            }
            output.OffsetX = mc.OffsetX;
            output.OffsetY = mc.OffsetY;
            output.OffsetZ = mc.OffsetZ;
            
            output.FlippedX = mc.FlippedX;
            output.FlippedY = mc.FlippedY;
            output.FlippedZ = mc.FlippedZ;

            output.OrientationX = mc.OrientationX;
            output.OrientationY = mc.OrientationY;
            output.OrientationZ = mc.OrientationZ;

            return output;
        }

        public static MonochromeCube RGBToMonochromeDriver(Cube rgbCube)
        {
            MonochromeCube output = new MonochromeCube(64);
            for (int x = 0; x < rgbCube.width; x++)
                for (int y = 0; y < rgbCube.length; y++)
                    for (int z = 0; z < rgbCube.height; z++)
                    {
                        if (rgbCube.matrix[x, y, z] != CubeColor.Black)
                        {
                            output.matrix_legacy[y + z * 8] += (byte)Math.Pow(2, x);
                        }
                    }
            output.Rotate(Rotation.CounterclockwiseY);
            return output;
        }
    }
}
