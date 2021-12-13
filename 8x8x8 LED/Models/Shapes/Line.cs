namespace _8x8x8_LED.Models.Shapes
{
    public class Line
    {
        public int x1, y1, z1, x2, y2, z2 = 0;

        public Line(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.z1 = z1;
            this.x2 = x2;
            this.y2 = y2;
            this.z2 = z2;
        }
    }
}
