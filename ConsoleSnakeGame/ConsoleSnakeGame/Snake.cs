using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class Snake
    {
        public Snake(
            Point snakeHead,
            ColorChar colorHead,
            ColorChar colorTail)
        {
            body = new List<Point>();
            body.Add(snakeHead);
            this.colorHead = colorHead;
            this.colorTail = colorTail;

            colorHead.Write(snakeHead);
        }

        public void Grow()
        {

        }

        public bool IsCollision(Point point)
        {
            bool isPlaceUsed = false;
            // ---- go over body
            foreach (Point item in body)
            {
                // --- this is NOT same as == because this is an object
                if (item.Equals(point))
                {
                    isPlaceUsed = true;
                    break;
                }
            }

            return isPlaceUsed;
        }

        public void Write()
        {
            //todo nath handle also tail
            int sourceLeft = body[0].x,
                sourceTop = body[0].y,
                sourceWidth = 1,
                sourceHeight = 1;


            switch (newDirection)
            {
                case Direction.Down:
                    body[0].y++;
                    break;

                case Direction.Left:
                    body[0].x--;
                    break;

                case Direction.Right:
                    body[0].x++;
                    break;

                case Direction.Up:
                    body[0].y--;
                    break;

                default:
                    throw (new Exception($"Unexpected direction : {newDirection}"));
            }

            Console.MoveBufferArea(
                sourceLeft, sourceTop,
                sourceWidth, sourceHeight,
                body[0].x, body[0].y);
        }

        public void Move(Direction direction)
        {
            newDirection = direction;
        }

        public Point Head { get { return body[0]; } }

        private List<Point> body;
        private ColorChar colorHead, colorTail;
        Direction newDirection;
    }
}
