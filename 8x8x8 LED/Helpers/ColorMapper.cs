using _8x8x8_LED.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Helpers
{
    public class ColorMapper
    {
        public static int RaiseNumber(int value)
        {
            if (value == 0)
                return 1;
            if (value == 1)
                return 2;
            if (value == 2)
                return 4;
            if (value == 3)
                return 8;
            if (value == 4)
                return 16;
            if (value == 5)
                return 32;
            if (value == 6)
                return 64;
            if (value == 7)
                return 128;
            return 0;
        }


        // int refers to the y-axis. Each y axis has a variable list of color lines
        // The goal of this method is to convert an image into a list of colors, with their values for each line.
        public static Dictionary<int, Dictionary<Color, int>> UnpackBitmapIntoStrips(Bitmap b)
        {
            Dictionary<int, Dictionary<Color, int>> output = new Dictionary<int, Dictionary<Color,int>>();

            for (int y = 0; y < b.Height; y++)
            {
                Dictionary<Color, int> miniMap = new Dictionary<Color, int>();
                for (int x = 0; x < b.Width; x++)
                {
                    miniMap.Add(b.GetPixel(x, y), RaiseNumber(x));
                    

                }
                output.Add(y, miniMap);
            }



            return null;
        }
        
        
        // Converts 3D array of colors into two 192 byte arrays, ready for sending:
        public static byte[] MatrixToBytes(CubeColor[,,] c)
        {
            byte[] outputArray1 = new byte[192];
            byte[] outputArray2 = new byte[192];

            for (int z = 0; z < c.GetLength(0); z++)
                for (int y = 0; y < c.GetLength(1); y++)
                    for (int x = 0; x < c.GetLength(2); x++)
                    {
                        var r = 4;
                        if (y == 1)
                            r = 5;
                        else if (y == 2)
                            r = 10;
                        else if (y == 3)
                            r = 11;
                        else if (y == 4)
                            r = 16;
                        else if (y == 5)
                            r = 17;
                        else if (y == 6)
                            r = 22;
                        else if (y == 7)
                            r = 23;
                        var g = 0;
                        if (y == 1)
                            g = 1;
                        else if (y == 2)
                            g = 6;
                        else if (y == 3)
                            g = 7;
                        else if (y == 4)
                            g = 12;
                        else if (y == 5)
                            g = 13;
                        else if (y == 6)
                            g = 18;
                        else if (y == 7)
                            g = 19;
                        var b = 2;
                        if (y == 1)
                            b = 3;
                        else if (y == 2)
                            b = 8;
                        else if (y == 3)
                            b = 9;
                        else if (y == 4)
                            b = 14;
                        else if (y == 5)
                            b = 15;
                        else if (y == 6)
                            b = 20;
                        else if (y == 7)
                            b = 21;

                        switch (c[z, y, x])
                        {
                            case CubeColor.White:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.Red:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.Green:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.Blue:
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.Cyan:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.Magenta:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.Yellow:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.DarkRed:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.DarkGreen:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.DarkBlue:
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.DarkCyan:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.DarkMagenta:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.DarkYellow:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.Gray:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.BrightRed:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.BrightGreen:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.BrightBlue:
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.BrightCyan:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.BrightMagenta:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.BrightYellow:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.RedGreen:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.RedBlue:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.RedCyan:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.RedMagenta:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.RedYellow:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.GreenBlue:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.GreenCyan:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.GreenMagenta:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.GreenYellow:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.BlueCyan:
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.BlueMagenta:
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.BlueYellow:
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.CyanMagenta:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[b + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.CyanYellow:
                                outputArray1[g + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                            case CubeColor.MagentaYellow:
                                outputArray1[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray1[b + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[r + 24 * z] += (byte)Math.Pow(2, x);
                                outputArray2[g + 24 * z] += (byte)Math.Pow(2, x);
                                break;
                        }
                    }
            return outputArray1.Concat(outputArray2).ToArray();
        }
    }
}
