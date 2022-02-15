using _8x8x8_LED.Models.Geometry;

namespace _8x8x8_LED.Models.Pong
{
    /// <summary>
    /// Class responsible for emulating a ball in the cube.
    /// Can be used for either the game 'Pong' or for a simple bouncing simulation.
    /// </summary>
    public class Ball
    {
        public Location location = new Location(3, 3, 3);

        public Direction directionX = Direction.None;
        public Direction directionY = Direction.None;
        public Direction directionZ = Direction.None;

        public CubeColor color = CubeColor.DarkBlue;

        public bool outOfBounds = false;

        public void Move(bool teleport = false, Paddle p1 = null, Paddle p2 = null)
        {
            switch (directionX)
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
            switch (directionY)
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
            switch (directionZ)
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

            if (p1 != null && p2 != null) // Handle if paddles are involved:
            {
                if (location.GetY() > 7)
                {
                    if (!BallHitPaddle(location, p2.location))
                        outOfBounds = true;
                    directionY = Direction.Leftwards;
                    location.SetY(6);
                }
                if (location.GetY() < 0)
                {
                    if (!BallHitPaddle(location, p1.location))
                        outOfBounds = true;
                    directionY = Direction.Rightwards;
                    location.SetY(1);
                }
            }
            else // Handle regular Y boundaries:
            {
                if (location.GetY() > 7)
                {
                    if (teleport)
                        location.SetY(0);
                    else
                    {
                        location.SetY(6);
                        directionY = Direction.Leftwards;
                    }
                }
                if (location.GetY() < 0)
                {
                    if (teleport)
                        location.SetY(7);
                    else
                    {
                        location.SetY(1);
                        directionY = Direction.Rightwards;
                    }
                }
            }
            if (location.GetX() > 7)
            {
                if (teleport)
                    location.SetX(0);
                else
                {
                    location.SetX(6);
                    directionX = Direction.Backwards;
                }
            }
            if (location.GetX() < 0)
            {
                if (teleport)
                    location.SetX(7);
                else
                {
                    location.SetX(1);
                    directionX = Direction.Forwards;
                }
            }
            if (location.GetZ() > 7)
            {
                if (teleport)
                    location.SetZ(0);
                else
                {
                    location.SetZ(6);
                    directionZ = Direction.Downwards;
                }
            }
            if (location.GetZ() < 0)
            {
                if (teleport)
                    location.SetZ(7);
                else
                {
                    location.SetZ(1);
                    directionZ = Direction.Upwards;
                }
            }
        }

        private bool BallHitPaddle(Location ballLocation, Location paddleLocation)
        {
            if (ballLocation.GetX() == paddleLocation.GetX())
                directionX = Direction.Forwards;
            else if (ballLocation.GetX() == paddleLocation.GetX() - 2)
                directionX = Direction.Backwards;
            else if (ballLocation.GetX() == paddleLocation.GetX() - 1)
                directionX = Direction.None;

            if (ballLocation.GetZ() == paddleLocation.GetZ())
                directionZ = Direction.Upwards;
            else if (ballLocation.GetZ() == paddleLocation.GetZ() - 2)
                directionZ = Direction.Downwards;
            else if (ballLocation.GetZ() == paddleLocation.GetZ() - 1)
                directionZ = Direction.None;

            if (ballLocation.GetX() == paddleLocation.GetX() ||
                ballLocation.GetX() == paddleLocation.GetX() - 1 ||
                ballLocation.GetX() == paddleLocation.GetX() - 2)
            {
                if (ballLocation.GetZ() == paddleLocation.GetZ() ||
                ballLocation.GetZ() == paddleLocation.GetZ() - 1 ||
                ballLocation.GetZ() == paddleLocation.GetZ() - 2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
