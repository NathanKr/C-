using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.GameGeneric
{
    class Utils
    {
        public static Point GetRandPoint(Point rectTopLeft, Point reactBottomRight)
        {
            Random rnd = new Random();
            int x = rnd.Next(rectTopLeft.x, reactBottomRight.x+1);
            int y = rnd.Next(rectTopLeft.y, reactBottomRight.y+1);
            return new Point(x, y);
        }
    }
}
