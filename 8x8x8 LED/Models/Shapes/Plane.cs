namespace _8x8x8_LED.Models.Shapes
{
    public class Plane
    {
        public Point3D a, b, c, d = new Point3D(0, 0, 0);

        public Plane(Point3D a, Point3D b, Point3D c, Point3D d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public Plane()
        {

        }
    }
}
