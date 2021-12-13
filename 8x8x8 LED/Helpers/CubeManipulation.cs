using _8x8x8_LED.Models;
using _8x8x8_LED.Models.Geometry;

namespace _8x8x8_LED.Helpers
{
    public class CubeManipulation
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
                                output[i, j, k] = input[maxHeight - j, i, k];
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

        public static CubeColor[,,] Shift(Direction direction, CubeColor[,,] input, bool repeating = true)
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
                                if (!repeating)
                                    input[i, j, maxHeight] = CubeColor.Black;
                                output[i, j, k] = input[i, j, (k + maxHeight) % output.GetLength(2)];
                                break;
                            case Direction.Downwards:
                                if (!repeating)
                                    input[i, j, 0] = CubeColor.Black;
                                output[i, j, k] = input[i, j, (k + 1) % output.GetLength(2)];
                                break;
                            case Direction.Leftwards:
                                if (!repeating)
                                    input[0, j, k] = CubeColor.Black;
                                output[i, j, k] = input[(i + 1) % output.GetLength(0), j, k];
                                break;
                            case Direction.Rightwards:
                                if (!repeating)
                                    input[maxHeight, j, k] = CubeColor.Black;
                                output[i, j, k] = input[(i + maxHeight) % output.GetLength(0), j, k];
                                break;
                            case Direction.Forwards:
                                if (!repeating)
                                    input[i, 0, k] = CubeColor.Black;
                                output[i, j, k] = input[i, (j + 1) % output.GetLength(1), k];
                                break;
                            case Direction.Backwards:
                                if (!repeating)
                                    input[i, maxHeight, k] = CubeColor.Black;
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
