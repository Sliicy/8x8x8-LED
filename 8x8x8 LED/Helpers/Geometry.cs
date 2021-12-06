using _8x8x8_LED.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Helpers
{
    public class Geometry
    {
        public static CubeColor[,,] Rotate(Rotation rotation, CubeColor[,,] input)
        {
            int inputLength = input.GetLength(0);
            int inputWidth = input.GetLength(1);
            int inputHeight = input.GetLength(2);

            var output = new CubeColor[inputWidth, inputLength, inputHeight];
            int maxHeight = inputWidth - 1;

            for (int k = 0; k < output.GetLength(2); k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        switch (rotation)
                        {
                            case Rotation.ClockwiseX:
                                output[i, j, k] = input[maxHeight - k, j, i];
                                break;
                            case Rotation.ClockwiseY:
                                output[i, j, k] = input[i, k, maxHeight - j];
                                break;
                            case Rotation.ClockwiseZ:
                                output[i, j, k] = input[maxHeight - j,  i, k];
                                break;
                            case Rotation.CounterclockwiseX:
                                output[i, j, k] = input[k, j, maxHeight - i];
                                break;
                            case Rotation.CounterclockwiseY:
                                output[i, j, k] = input[i, k, maxHeight - j];
                                break;
                            case Rotation.CounterclockwiseZ:
                                output[i, j, k] = input[j, maxHeight - i, k];
                                break;
                            default:
                                output[i, j, k] = input[i, j, k];
                                break;
                        }
            return output;
        }

        public static CubeColor[,,] Shift(Direction direction, CubeColor[,,] input)
        {
            int inputLength = input.GetLength(0);
            int inputWidth = input.GetLength(1);
            int inputHeight = input.GetLength(2);
            int maxHeight = inputWidth - 1;

            var output = new CubeColor[inputWidth, inputLength, inputHeight];

            for (int k = 0; k < output.GetLength(2); k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        switch (direction)
                        {
                            case Direction.Upwards:
                                output[i, j, k] = input[i, j, (k + maxHeight) % output.GetLength(2)];
                                break;
                            case Direction.Downwards:
                                output[i, j, k] = input[i, j, (k + 1) % output.GetLength(2)];
                                break;
                            case Direction.Leftwards:
                                output[i, j, k] = input[(i + 1) % output.GetLength(0), j, k];
                                break;
                            case Direction.Rightwards:
                                output[i, j, k] = input[(i + maxHeight) % output.GetLength(0), j, k];
                                break;
                            case Direction.Forwards:
                                output[i, j, k] = input[i, (j + 1) % output.GetLength(1), k];
                                break;
                            case Direction.Backwards:
                                output[i, j, k] = input[i, (j + maxHeight) % output.GetLength(1), k];
                                break;
                            default:
                                output[i, j, k] = input[i, j, k];
                                break;
                        }
            return output;
        }

        public static CubeColor[,,] Flip(Axis axis, CubeColor[,,] input)
        {
            int inputLength = input.GetLength(0);
            int inputWidth = input.GetLength(1);
            int inputHeight = input.GetLength(2);

            var output = new CubeColor[inputWidth, inputLength, inputHeight];
            int maxHeight = inputWidth - 1;

            for (int k = 0; k < output.GetLength(2); k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        switch (axis)
                        {
                            case Axis.X:
                                output[i, j, k] = input[maxHeight - i, j, k];
                                break;
                            case Axis.Y:
                                output[i, j, k] = input[i, maxHeight - j, k];
                                break;
                            case Axis.Z:
                                output[i, j, k] = input[i, j, maxHeight - k];
                                break;
                            default:
                                output[i, j, k] = input[i, j, k];
                                break;
                        }
            return output;
        }
    }
}
