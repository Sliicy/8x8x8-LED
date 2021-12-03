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
        public static CubeColor[,,] Rotate90DegreesClockwiseAroundXAxis(CubeColor[,,] input)
        {
            int inputWidth = input.GetLength(0);
            int inputHeight = input.GetLength(1);
            int inputDepth = input.GetLength(2);

            var output = new CubeColor[inputHeight, inputWidth, inputDepth];
            for (int k = 0; k < inputDepth; k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        output[i, j, k] = input[k, j, i];

            return output;
        }
        public static CubeColor[,,] Rotate90DegreesCounterClockwiseAroundXAxis(CubeColor[,,] input)
        {
            int inputWidth = input.GetLength(0);
            int inputHeight = input.GetLength(1);
            int inputDepth = input.GetLength(2);

            var output = new CubeColor[inputHeight, inputWidth, inputDepth];
            int maxHeight = inputHeight - 1;

            for (int k = 0; k < inputDepth; k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        output[i, j, k] = input[k, j, maxHeight - i];

            return output;
        }
        public static CubeColor[,,] Rotate90DegreesClockwiseAroundYAxis(CubeColor[,,] input)
        {
            int inputWidth = input.GetLength(0);
            int inputHeight = input.GetLength(1);
            int inputDepth = input.GetLength(2);

            var output = new CubeColor[inputHeight, inputWidth, inputDepth];
            int maxHeight = inputHeight - 1;

            for (int k = 0; k < inputDepth; k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        output[i, j, k] = input[i, k, maxHeight - j];

            return output;
        }
        public static CubeColor[,,] Rotate90DegreesCounterClockwiseAroundYAxis(CubeColor[,,] input)
        {
            int inputWidth = input.GetLength(0);
            int inputHeight = input.GetLength(1);
            int inputDepth = input.GetLength(2);

            var output = new CubeColor[inputHeight, inputWidth, inputDepth];
            for (int k = 0; k < inputDepth; k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        output[i, j, k] = input[i, k, j];

            return output;
        }
        public static CubeColor[,,] Rotate90DegreesClockwiseAroundZAxis(CubeColor[,,] input)
        {
            int inputWidth = input.GetLength(0);
            int inputHeight = input.GetLength(1);
            int inputDepth = input.GetLength(2);

            var output = new CubeColor[inputHeight, inputWidth, inputDepth];

            for (int k = 0; k < inputDepth; k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        output[i, j, k] = input[j, i, k];

            return output;
        }
        public static CubeColor[,,] Rotate90DegreesCounterClockwiseAroundZAxis(CubeColor[,,] input)
        {
            int inputWidth = input.GetLength(0);
            int inputHeight = input.GetLength(1);
            int inputDepth = input.GetLength(2);

            var output = new CubeColor[inputHeight, inputWidth, inputDepth];
            int maxHeight = inputHeight - 1;

            for (int k = 0; k < inputDepth; k++)
                for (int j = 0; j < output.GetLength(1); j++)
                    for (int i = 0; i < output.GetLength(0); i++)
                        output[i, j, k] = input[j, maxHeight - i, k];

            return output;
        }
    }
}
