using _8x8x8_LED.Models;
using System;
using System.Drawing;
using System.Linq;

namespace _8x8x8_LED.Helpers
{
    /// <summary>
    /// Provides commonly used operations for colors.
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// Convert 3D CubeColor array into bytes.
        /// </summary>
        /// <param name="c">3-dimensional array of colors.</param>
        /// <returns>Two concatenated 192 byte arrays.</returns>
        public static byte[] MatrixToBytes(CubeColor[,,] c)
        {
            byte[] outputArray1 = new byte[192];
            byte[] outputArray2 = new byte[192];

            for (int x = 0; x < c.GetLength(0); x++)
                for (int y = 0; y < c.GetLength(1); y++)
                    for (int z = 0; z < c.GetLength(2); z++)
                    {
                        int r = 4;
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
                        int g = 0;
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
                        int b = 2;
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

                        byte X = (byte)Math.Pow(2, x);
                        switch (c[x, y, z])
                        {
                            case CubeColor.White:
                                outputArray1[r + 24 * z] += X;
                                outputArray1[g + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.Red:
                                outputArray1[r + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                break;
                            case CubeColor.Green:
                                outputArray1[g + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                break;
                            case CubeColor.Blue:
                                outputArray1[b + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.Cyan:
                                outputArray1[g + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.Magenta:
                                outputArray1[r + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.Yellow:
                                outputArray1[r + 24 * z] += X;
                                outputArray1[g + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                break;
                            case CubeColor.DarkRed:
                                outputArray1[r + 24 * z] += X;
                                break;
                            case CubeColor.DarkGreen:
                                outputArray1[g + 24 * z] += X;
                                break;
                            case CubeColor.DarkBlue:
                                outputArray1[b + 24 * z] += X;
                                break;
                            case CubeColor.DarkCyan:
                                outputArray1[g + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                break;
                            case CubeColor.DarkMagenta:
                                outputArray1[r + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                break;
                            case CubeColor.DarkYellow:
                                outputArray1[r + 24 * z] += X;
                                outputArray1[g + 24 * z] += X;
                                break;
                            case CubeColor.Gray:
                                outputArray1[r + 24 * z] += X;
                                outputArray1[g + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                break;
                            case CubeColor.BrightRed:
                                outputArray1[r + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.BrightGreen:
                                outputArray1[g + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.BrightBlue:
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.BrightCyan:
                                outputArray1[g + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.BrightMagenta:
                                outputArray1[r + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.BrightYellow:
                                outputArray1[r + 24 * z] += X;
                                outputArray1[g + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.RedGreen:
                                outputArray1[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                break;
                            case CubeColor.RedBlue:
                                outputArray1[r + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.RedCyan:
                                outputArray1[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.RedMagenta:
                                outputArray1[r + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.RedYellow:
                                outputArray1[r + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                break;
                            case CubeColor.GreenBlue:
                                outputArray1[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.GreenCyan:
                                outputArray1[g + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.GreenMagenta:
                                outputArray1[g + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.GreenYellow:
                                outputArray1[g + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                break;
                            case CubeColor.BlueCyan:
                                outputArray1[b + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.BlueMagenta:
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.BlueYellow:
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                break;
                            case CubeColor.CyanMagenta:
                                outputArray1[g + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[b + 24 * z] += X;
                                break;
                            case CubeColor.CyanYellow:
                                outputArray1[g + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                break;
                            case CubeColor.MagentaYellow:
                                outputArray1[r + 24 * z] += X;
                                outputArray1[b + 24 * z] += X;
                                outputArray2[r + 24 * z] += X;
                                outputArray2[g + 24 * z] += X;
                                break;
                        }
                    }
            return outputArray1.Concat(outputArray2).ToArray();
        }

        /// <summary>
        /// Convert RGB color to CubeColor.
        /// </summary>
        /// <param name="c">RGB Color</param>
        /// <returns>CubeColor representation of RGB.</returns>
        public static CubeColor GetColorFromRGB(Color c)
        {
            switch (c.R)
            {
                case 255 when c.G == 255 && c.B == 255:
                    return CubeColor.White;
                case 255 when c.G == 0 && c.B == 0:
                    return CubeColor.Red;
                case 0 when c.G == 255 && c.B == 0:
                    return CubeColor.Green;
                case 0 when c.G == 0 && c.B == 255:
                    return CubeColor.Blue;
                case 0 when c.G == 255 && c.B == 255:
                    return CubeColor.Cyan;
                case 255 when c.G == 0 && c.B == 255:
                    return CubeColor.Magenta;
                case 255 when c.G == 255 && c.B == 0:
                    return CubeColor.Yellow;
                case 128 when c.G == 0 && c.B == 0:
                    return CubeColor.DarkRed;
                case 0 when c.G == 128 && c.B == 0:
                    return CubeColor.DarkGreen;
                case 0 when c.G == 0 && c.B == 128:
                    return CubeColor.DarkBlue;
                case 0 when c.G == 128 && c.B == 128:
                    return CubeColor.DarkCyan;
                case 128 when c.G == 0 && c.B == 128:
                    return CubeColor.DarkMagenta;
                case 128 when c.G == 128 && c.B == 0:
                    return CubeColor.DarkYellow;
                case 128 when c.G == 128 && c.B == 128:
                    return CubeColor.Gray;
                case 255 when c.G == 128 && c.B == 128:
                    return CubeColor.BrightRed;
                case 128 when c.G == 255 && c.B == 128:
                    return CubeColor.BrightGreen;
                case 128 when c.G == 128 && c.B == 255:
                    return CubeColor.BrightBlue;
                case 128 when c.G == 255 && c.B == 255:
                    return CubeColor.BrightCyan;
                case 255 when c.G == 128 && c.B == 255:
                    return CubeColor.BrightMagenta;
                case 255 when c.G == 255 && c.B == 128:
                    return CubeColor.BrightYellow;
                case 200 when c.G == 255 && c.B == 0:
                    return CubeColor.RedGreen;
                case 255 when c.G == 0 && c.B == 175:
                    return CubeColor.RedBlue;
                case 155 when c.G == 230 && c.B == 255:
                    return CubeColor.RedCyan;
                case 255 when c.G == 100 && c.B == 190:
                    return CubeColor.RedMagenta;
                case 255 when c.G == 200 && c.B == 30:
                    return CubeColor.RedYellow;
                case 0 when c.G == 236 && c.B == 230:
                    return CubeColor.GreenBlue;
                case 30 when c.G == 255 && c.B == 200:
                    return CubeColor.GreenCyan;
                case 200 when c.G == 238 && c.B == 255:
                    return CubeColor.GreenMagenta;
                case 236 when c.G == 255 && c.B == 0:
                    return CubeColor.GreenYellow;
                case 0 when c.G == 145 && c.B == 255:
                    return CubeColor.BlueCyan;
                case 210 when c.G == 100 && c.B == 255:
                    return CubeColor.BlueMagenta;
                case 220 when c.G == 255 && c.B == 225:
                    return CubeColor.BlueYellow;
                case 221 when c.G == 231 && c.B == 255:
                    return CubeColor.CyanMagenta;
                case 111 when c.G == 255 && c.B == 172:
                    return CubeColor.CyanYellow;
                case 255 when c.G == 193 && c.B == 225:
                    return CubeColor.MagentaYellow;
                default:
                    return CubeColor.Black;
            }
        }

        /// <summary>
        /// Convert CubeColor to RGB color.
        /// </summary>
        /// <param name="c">CubeColor</param>
        /// <returns>Color from CubeColor.</returns>
        public static Color GetRGB(CubeColor c)
        {
            switch (c)
            {
                case CubeColor.White:
                    return Color.FromArgb(255, 255, 255);
                case CubeColor.Red:
                    return Color.FromArgb(255, 0, 0);
                case CubeColor.Green:
                    return Color.FromArgb(0, 255, 0);
                case CubeColor.Blue:
                    return Color.FromArgb(0, 0, 255);
                case CubeColor.Cyan:
                    return Color.FromArgb(0, 255, 255);
                case CubeColor.Magenta:
                    return Color.FromArgb(255, 0, 255);
                case CubeColor.Yellow:
                    return Color.FromArgb(255, 255, 0);
                case CubeColor.DarkRed:
                    return Color.FromArgb(128, 0, 0);
                case CubeColor.DarkGreen:
                    return Color.FromArgb(0, 128, 0);
                case CubeColor.DarkBlue:
                    return Color.FromArgb(0, 0, 128);
                case CubeColor.DarkCyan:
                    return Color.FromArgb(0, 128, 128);
                case CubeColor.DarkMagenta:
                    return Color.FromArgb(128, 0, 128);
                case CubeColor.DarkYellow:
                    return Color.FromArgb(128, 128, 0);
                case CubeColor.Gray:
                    return Color.FromArgb(128, 128, 128);
                case CubeColor.BrightRed:
                    return Color.FromArgb(255, 128, 128);
                case CubeColor.BrightGreen:
                    return Color.FromArgb(128, 255, 128);
                case CubeColor.BrightBlue:
                    return Color.FromArgb(128, 128, 255);
                case CubeColor.BrightCyan:
                    return Color.FromArgb(128, 255, 255);
                case CubeColor.BrightMagenta:
                    return Color.FromArgb(255, 128, 255);
                case CubeColor.BrightYellow:
                    return Color.FromArgb(255, 255, 128);
                case CubeColor.RedGreen:
                    return Color.FromArgb(200, 255, 0);
                case CubeColor.RedBlue:
                    return Color.FromArgb(255, 0, 175);
                case CubeColor.RedCyan:
                    return Color.FromArgb(155, 230, 255);
                case CubeColor.RedMagenta:
                    return Color.FromArgb(255, 100, 190);
                case CubeColor.RedYellow:
                    return Color.FromArgb(255, 200, 30);
                case CubeColor.GreenBlue:
                    return Color.FromArgb(0, 236, 230);
                case CubeColor.GreenCyan:
                    return Color.FromArgb(30, 255, 200);
                case CubeColor.GreenMagenta:
                    return Color.FromArgb(200, 238, 255);
                case CubeColor.GreenYellow:
                    return Color.FromArgb(236, 255, 0);
                case CubeColor.BlueCyan:
                    return Color.FromArgb(0, 145, 255);
                case CubeColor.BlueMagenta:
                    return Color.FromArgb(210, 100, 255);
                case CubeColor.BlueYellow:
                    return Color.FromArgb(220, 255, 225);
                case CubeColor.CyanMagenta:
                    return Color.FromArgb(221, 231, 255);
                case CubeColor.CyanYellow:
                    return Color.FromArgb(111, 255, 172);
                case CubeColor.MagentaYellow:
                    return Color.FromArgb(255, 193, 225);
                default:
                    return Color.FromArgb(0, 0, 0);
            }
        }

        /// <summary>
        /// Generate a random CubeColor.
        /// </summary>
        /// <param name="includeBlack">Boolean to determine whether black is included as a color.</param>
        /// <returns>Random CubeColor.</returns>
        public static CubeColor RandomColor(bool includeBlack = false)
        {
            Random random = new Random();
            Array enums = Enum.GetValues(typeof(CubeColor));
            CubeColor newColor = (CubeColor)enums.GetValue(random.Next(enums.Length));
            if (!includeBlack)
            {
                while (newColor == CubeColor.Black)
                    newColor = (CubeColor)enums.GetValue(random.Next(enums.Length));
            }
            return newColor;
        }

        /// <summary>
        /// Generate a random dark CubeColor.
        /// </summary>
        /// <param name="includeBlack">Boolean to determine whether black is included as a color.</param>
        /// <returns>Random dark CubeColor.</returns>
        public static CubeColor RandomDarkColor(bool includeBlack = false)
        {
            CubeColor newColor = RandomColor(includeBlack);
            while (!newColor.ToString().Contains("Dark"))
                newColor = RandomColor(includeBlack);
            return newColor;
        }
    }
}
