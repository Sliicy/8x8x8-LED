using _8x8x8_LED.Core.Models;
using System;
using System.Drawing;
using System.Linq;

namespace _8x8x8_LED.Core.Helpers
{
    /// <summary>
    /// Provides commonly used color/<see cref="CubeColor"/> operations.
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// Converts 3D <see cref="CubeColor"/> array into <see cref="List{T}"/> of <see cref="Byte"/>.
        /// </summary>
        /// <param name="c">3-dimensional array of <see cref="CubeColor"/>.</param>
        /// <returns>Two concatenated 192 <see cref="byte"/> arrays.</returns>
        public static byte[] MatrixToBytes(CubeColor[,,] c)
        {
            byte[] outputArray1 = new byte[192];
            byte[] outputArray2 = new byte[192];

            for (int x = 0; x < c.GetLength(0); x++)
                for (int y = 0; y < c.GetLength(1); y++)
                    for (int z = 0; z < c.GetLength(2); z++)
                    {
                        int red = 4;
                        if (y == 1)
                            red = 5;
                        else if (y == 2)
                            red = 10;
                        else if (y == 3)
                            red = 11;
                        else if (y == 4)
                            red = 16;
                        else if (y == 5)
                            red = 17;
                        else if (y == 6)
                            red = 22;
                        else if (y == 7)
                            red = 23;
                        int green = 0;
                        if (y == 1)
                            green = 1;
                        else if (y == 2)
                            green = 6;
                        else if (y == 3)
                            green = 7;
                        else if (y == 4)
                            green = 12;
                        else if (y == 5)
                            green = 13;
                        else if (y == 6)
                            green = 18;
                        else if (y == 7)
                            green = 19;
                        int blue = 2;
                        if (y == 1)
                            blue = 3;
                        else if (y == 2)
                            blue = 8;
                        else if (y == 3)
                            blue = 9;
                        else if (y == 4)
                            blue = 14;
                        else if (y == 5)
                            blue = 15;
                        else if (y == 6)
                            blue = 20;
                        else if (y == 7)
                            blue = 21;

                        byte X = (byte)Math.Pow(2, x);
                        switch (c[x, y, z])
                        {
                            case CubeColor.White:
                                outputArray1[red + 24 * z] += X;
                                outputArray1[green + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.Red:
                                outputArray1[red + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                break;
                            case CubeColor.Green:
                                outputArray1[green + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                break;
                            case CubeColor.Blue:
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.Cyan:
                                outputArray1[green + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.Magenta:
                                outputArray1[red + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.Yellow:
                                outputArray1[red + 24 * z] += X;
                                outputArray1[green + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                break;
                            case CubeColor.DarkRed:
                                outputArray1[red + 24 * z] += X;
                                break;
                            case CubeColor.DarkGreen:
                                outputArray1[green + 24 * z] += X;
                                break;
                            case CubeColor.DarkBlue:
                                outputArray1[blue + 24 * z] += X;
                                break;
                            case CubeColor.DarkCyan:
                                outputArray1[green + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                break;
                            case CubeColor.DarkMagenta:
                                outputArray1[red + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                break;
                            case CubeColor.DarkYellow:
                                outputArray1[red + 24 * z] += X;
                                outputArray1[green + 24 * z] += X;
                                break;
                            case CubeColor.Gray:
                                outputArray1[red + 24 * z] += X;
                                outputArray1[green + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                break;
                            case CubeColor.BrightRed:
                                outputArray1[red + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.BrightGreen:
                                outputArray1[green + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.BrightBlue:
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.BrightCyan:
                                outputArray1[green + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.BrightMagenta:
                                outputArray1[red + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.BrightYellow:
                                outputArray1[red + 24 * z] += X;
                                outputArray1[green + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.RedGreen:
                                outputArray1[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                break;
                            case CubeColor.RedBlue:
                                outputArray1[red + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.RedCyan:
                                outputArray1[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.RedMagenta:
                                outputArray1[red + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.RedYellow:
                                outputArray1[red + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                break;
                            case CubeColor.GreenBlue:
                                outputArray1[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.GreenCyan:
                                outputArray1[green + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.GreenMagenta:
                                outputArray1[green + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.GreenYellow:
                                outputArray1[green + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                break;
                            case CubeColor.BlueCyan:
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.BlueMagenta:
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.BlueYellow:
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                break;
                            case CubeColor.CyanMagenta:
                                outputArray1[green + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[blue + 24 * z] += X;
                                break;
                            case CubeColor.CyanYellow:
                                outputArray1[green + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                break;
                            case CubeColor.MagentaYellow:
                                outputArray1[red + 24 * z] += X;
                                outputArray1[blue + 24 * z] += X;
                                outputArray2[red + 24 * z] += X;
                                outputArray2[green + 24 * z] += X;
                                break;
                        }
                    }
            return [.. outputArray1, .. outputArray2];
        }

        /// <summary>
        /// Converts <see cref="Color"/> to <see cref="CubeColor"/>.
        /// </summary>
        /// <param name="c">RGB input <see cref="Color"/>.</param>
        /// <returns><see cref="CubeColor"/> representation of RGB.</returns>
        public static CubeColor GetColorFromRGB(Color c)
        {
            return c.R switch
            {
                255 when c.G == 255 && c.B == 255 => CubeColor.White,
                255 when c.G == 0 && c.B == 0 => CubeColor.Red,
                0 when c.G == 255 && c.B == 0 => CubeColor.Green,
                0 when c.G == 0 && c.B == 255 => CubeColor.Blue,
                0 when c.G == 255 && c.B == 255 => CubeColor.Cyan,
                255 when c.G == 0 && c.B == 255 => CubeColor.Magenta,
                255 when c.G == 255 && c.B == 0 => CubeColor.Yellow,
                128 when c.G == 0 && c.B == 0 => CubeColor.DarkRed,
                0 when c.G == 128 && c.B == 0 => CubeColor.DarkGreen,
                0 when c.G == 0 && c.B == 128 => CubeColor.DarkBlue,
                0 when c.G == 128 && c.B == 128 => CubeColor.DarkCyan,
                128 when c.G == 0 && c.B == 128 => CubeColor.DarkMagenta,
                128 when c.G == 128 && c.B == 0 => CubeColor.DarkYellow,
                128 when c.G == 128 && c.B == 128 => CubeColor.Gray,
                255 when c.G == 128 && c.B == 128 => CubeColor.BrightRed,
                128 when c.G == 255 && c.B == 128 => CubeColor.BrightGreen,
                128 when c.G == 128 && c.B == 255 => CubeColor.BrightBlue,
                128 when c.G == 255 && c.B == 255 => CubeColor.BrightCyan,
                255 when c.G == 128 && c.B == 255 => CubeColor.BrightMagenta,
                255 when c.G == 255 && c.B == 128 => CubeColor.BrightYellow,
                200 when c.G == 255 && c.B == 0 => CubeColor.RedGreen,
                255 when c.G == 0 && c.B == 175 => CubeColor.RedBlue,
                155 when c.G == 230 && c.B == 255 => CubeColor.RedCyan,
                255 when c.G == 100 && c.B == 190 => CubeColor.RedMagenta,
                255 when c.G == 200 && c.B == 30 => CubeColor.RedYellow,
                0 when c.G == 236 && c.B == 230 => CubeColor.GreenBlue,
                30 when c.G == 255 && c.B == 200 => CubeColor.GreenCyan,
                200 when c.G == 238 && c.B == 255 => CubeColor.GreenMagenta,
                236 when c.G == 255 && c.B == 0 => CubeColor.GreenYellow,
                0 when c.G == 145 && c.B == 255 => CubeColor.BlueCyan,
                210 when c.G == 100 && c.B == 255 => CubeColor.BlueMagenta,
                220 when c.G == 255 && c.B == 225 => CubeColor.BlueYellow,
                221 when c.G == 231 && c.B == 255 => CubeColor.CyanMagenta,
                111 when c.G == 255 && c.B == 172 => CubeColor.CyanYellow,
                255 when c.G == 193 && c.B == 225 => CubeColor.MagentaYellow,
                _ => CubeColor.Black,
            };
        }

        /// <summary>
        /// Converts <see cref="CubeColor"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="c"><see cref="CubeColor"/> input.</param>
        /// <returns><see cref="Color"/> from <see cref="CubeColor"/>.</returns>
        public static Color GetRGB(CubeColor c)
        {
            return c switch
            {
                CubeColor.White => Color.FromArgb(255, 255, 255),
                CubeColor.Red => Color.FromArgb(255, 0, 0),
                CubeColor.Green => Color.FromArgb(0, 255, 0),
                CubeColor.Blue => Color.FromArgb(0, 0, 255),
                CubeColor.Cyan => Color.FromArgb(0, 255, 255),
                CubeColor.Magenta => Color.FromArgb(255, 0, 255),
                CubeColor.Yellow => Color.FromArgb(255, 255, 0),
                CubeColor.DarkRed => Color.FromArgb(128, 0, 0),
                CubeColor.DarkGreen => Color.FromArgb(0, 128, 0),
                CubeColor.DarkBlue => Color.FromArgb(0, 0, 128),
                CubeColor.DarkCyan => Color.FromArgb(0, 128, 128),
                CubeColor.DarkMagenta => Color.FromArgb(128, 0, 128),
                CubeColor.DarkYellow => Color.FromArgb(128, 128, 0),
                CubeColor.Gray => Color.FromArgb(128, 128, 128),
                CubeColor.BrightRed => Color.FromArgb(255, 128, 128),
                CubeColor.BrightGreen => Color.FromArgb(128, 255, 128),
                CubeColor.BrightBlue => Color.FromArgb(128, 128, 255),
                CubeColor.BrightCyan => Color.FromArgb(128, 255, 255),
                CubeColor.BrightMagenta => Color.FromArgb(255, 128, 255),
                CubeColor.BrightYellow => Color.FromArgb(255, 255, 128),
                CubeColor.RedGreen => Color.FromArgb(200, 255, 0),
                CubeColor.RedBlue => Color.FromArgb(255, 0, 175),
                CubeColor.RedCyan => Color.FromArgb(155, 230, 255),
                CubeColor.RedMagenta => Color.FromArgb(255, 100, 190),
                CubeColor.RedYellow => Color.FromArgb(255, 200, 30),
                CubeColor.GreenBlue => Color.FromArgb(0, 236, 230),
                CubeColor.GreenCyan => Color.FromArgb(30, 255, 200),
                CubeColor.GreenMagenta => Color.FromArgb(200, 238, 255),
                CubeColor.GreenYellow => Color.FromArgb(236, 255, 0),
                CubeColor.BlueCyan => Color.FromArgb(0, 145, 255),
                CubeColor.BlueMagenta => Color.FromArgb(210, 100, 255),
                CubeColor.BlueYellow => Color.FromArgb(220, 255, 225),
                CubeColor.CyanMagenta => Color.FromArgb(221, 231, 255),
                CubeColor.CyanYellow => Color.FromArgb(111, 255, 172),
                CubeColor.MagentaYellow => Color.FromArgb(255, 193, 225),
                _ => Color.FromArgb(0, 0, 0),
            };
        }

        /// <summary>
        /// Returns a random <see cref="CubeColor"/>.
        /// </summary>
        /// <param name="includeBlack"><see cref="bool"/> to determine whether black should be included in selection.</param>
        /// <returns>Random <see cref="CubeColor"/>.</returns>
        public static CubeColor RandomColor(bool includeBlack = false)
        {
            Random random = new();
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
        /// Returns a random dark <see cref="CubeColor"/>.
        /// </summary>
        /// <param name="includeBlack"><see cref="bool"/> to determine whether black should be included in selection.</param>
        /// <returns>Random dark <see cref="CubeColor"/>.</returns>
        public static CubeColor RandomDarkColor(bool includeBlack = false)
        {
            CubeColor newColor = RandomColor(includeBlack);
            while (!newColor.ToString().Contains("Dark"))
                newColor = RandomColor(includeBlack);
            return newColor;
        }
    }
}
