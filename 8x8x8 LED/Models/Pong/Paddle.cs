namespace _8x8x8_LED.Models.Pong
{
    /// <summary>
    /// Class responsible for handling the paddle in the game Pong.
    /// </summary>
    public class Paddle
    {
        public Location location = new Location(0, 0, 0);

        public Paddle(int x, int y, int z)
        {
            location.SetX(x);
            location.SetY(y);
            location.SetZ(z);
        }

        public void Move(Direction dX, Direction dY, Direction dZ, bool teleport = true)
        {
            switch (dX)
            {
                case Direction.Backwards:
                    location.SetX(location.GetX() - 1);
                    break;
                case Direction.Forwards:
                    location.SetX(location.GetX() + 1);
                    break;
                default:
                    break;
            }
            switch (dY)
            {
                case Direction.Leftwards:
                    location.SetY(location.GetY() - 1);
                    break;
                case Direction.Rightwards:
                    location.SetY(location.GetY() + 1);
                    break;
                default:
                    break;
            }
            switch (dZ)
            {
                case Direction.Downwards:
                    location.SetZ(location.GetZ() - 1);
                    break;
                case Direction.Upwards:
                    location.SetZ(location.GetZ() + 1);
                    break;
                default:
                    break;
            }


            // Handle boundaries:
            if (location.GetX() > 7)
                if (teleport)
                    location.SetX(0);
                else
                    location.SetX(6);
            if (location.GetX() < 0)
                if (teleport)
                    location.SetX(7);
                else
                    location.SetX(1);
            if (location.GetY() > 7)
                if (teleport)
                    location.SetY(0);
                else
                    location.SetY(6);
            if (location.GetY() < 0)
                if (teleport)
                    location.SetY(7);
                else
                    location.SetY(1);
            if (location.GetZ() > 7)
                if (teleport)
                    location.SetZ(0);
                else
                    location.SetZ(6);
            if (location.GetZ() < 0)
                if (teleport)
                    location.SetZ(7);
                else
                    location.SetZ(1);
        }
    }
}
