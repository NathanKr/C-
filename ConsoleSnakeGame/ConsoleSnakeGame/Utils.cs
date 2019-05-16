using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class Utils
    {
        public static Point GetRandPoint(Point boardTopLeft, Point boardBottomRight)
        {
            Random rnd = new Random();
            int x = rnd.Next(boardTopLeft.x+1, boardBottomRight.x);
            int y = rnd.Next(boardTopLeft.y + 1, boardBottomRight.y);
            return new Point(x, y);
        }
    }
}
