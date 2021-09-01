using _8x8x8_LED.Model.Pong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8x8x8_LED.Model.Snake
{
    class Snake
    {

        // Body of snake, consisting of points. body[0] represents the head of the snake.
        public List<Location> body = new List<Location>();
        
        // Controls whether the snake is allowed to cross the edge of the boundaries:
        public bool boundedSnake = true;

        public bool alive = true;
        public bool grow = false;

        public Snake(Location headLocation)
        {
            body = new List<Location>
            {
                headLocation
            };
        }

        public Location GetHead()
        {
            return body[0];
        }

        public Location GetTail()
        {
            return body[body.Count - 1];
        }

        public void Crawl(Direction direction)
        {
            switch (direction)
            {
                case Direction.Forwards:
                    body.Insert(0, new Location(body[0].GetX() - 1, body[0].GetY(), body[0].GetZ()));
                    break;
                case Direction.Backwards:
                    body.Insert(0, new Location(body[0].GetX() + 1, body[0].GetY(), body[0].GetZ()));
                    break;
                case Direction.Leftwards:
                    body.Insert(0, new Location(body[0].GetX(), body[0].GetY() - 1, body[0].GetZ()));
                    break;
                case Direction.Rightwards:
                    body.Insert(0, new Location(body[0].GetX(), body[0].GetY() + 1, body[0].GetZ()));
                    break;
                case Direction.Upwards:
                    body.Insert(0, new Location(body[0].GetX(), body[0].GetY(), body[0].GetZ() + 1));
                    break;
                case Direction.Downwards:
                    body.Insert(0, new Location(body[0].GetX(), body[0].GetY(), body[0].GetZ() - 1));
                    break;
            }
            if (boundedSnake)
            {
                if (GetHead().GetX() < 0 || GetHead().GetX() > 7 ||
                    GetHead().GetY() < 0 || GetHead().GetY() > 7 ||
                    GetHead().GetZ() < 0 || GetHead().GetZ() > 7)
                {
                    alive = false;
                }
            }
            
            if (body.Count > 4)
            {
                // Determine if head crashed into body:
                Location decapitatedHead = GetHead();
                body.RemoveAt(0);
                if (body.Contains(GetHead()))
                {
                    alive = false;
                }
                else
                {
                    body.Insert(0, decapitatedHead);
                }
            }
            

            // Remove the last bodypart if not growing:
            if (grow)
            {
                grow = false;
            } else
            {
                body.RemoveAt(body.Count - 1);
            }
                
        }

        public bool AppleConsumed(Location apple)
        {
            if (GetHead().GetX() == apple.GetX() &&
                GetHead().GetY() == apple.GetY() &&
                GetHead().GetZ() == apple.GetZ())
            {
                return true;
            }
            return false;
        }

        public void Grow()
        {
            grow = true;
        }

        public void Reset()
        {
            body.Clear();
            body.Add(new Location(3, 3, 3));
            alive = true;
        }
    }
}
