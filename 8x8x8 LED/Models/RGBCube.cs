namespace _8x8x8_LED.Models
{
    public class RGBCube : Cube
    {
        //public CubeColor[,,] matrix = new CubeColor[height, length, width];

        public RGBCube(int x = 8, int y = 8, int z = 8)
        {
            width = x;
            length = y;
            height = z;
            matrix = new CubeColor[width, length, height];
        }

        //public void Rotate(Rotation rotation)
        //{
        //    var output = Geometry.Rotate(rotation, matrix);
        //    // Copy new cube to old cube:
        //    for (int i = 0; i < length; i++)
        //        for (int j = 0; j < width; j++)
        //            for (int k = 0; k < height; k++)
        //                matrix[i, j, k] = output[i, j, k];
        //}
    }
}
