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
                            case Rotation.ClockwiseX: // TODO: Fix
                                output[i, j, k] = input[k, j, i];
                                break;
                            case Rotation.ClockwiseY:
                                output[i, j, k] = input[i, k, maxHeight - j];
                                break;
                            case Rotation.ClockwiseZ: // TODO: Fix
                                output[i, j, k] = input[j, i, k];
                                break;
                            case Rotation.CounterclockwiseX:
                                output[i, j, k] = input[k, j, maxHeight - i];
                                break;
                            case Rotation.CounterclockwiseY: // TODO: Fix
                                output[i, j, k] = input[i, k, j];
                                break;
                            case Rotation.CounterclockwiseZ:
                                output[i, j, k] = input[j, maxHeight - i, k];
                                break;
                            case Rotation.None:
                                output[i, j, k] = input[i, j, k];
                                break;
                        }
            return output;
        }

        public static CubeColor[,,] Shift(Direction d)
        {
            throw new NotImplementedException(); // TODO: Implement Shifting method.
        }
    }
}
