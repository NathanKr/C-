using System;
using System.Collections.Generic;
using System.Text;

namespace GameGeneric
{
    public class Utils
    {
        public static Point GetRandPoint(Point rectTopLeft, Point reactBottomRight)
        {
            Random rnd = new Random();
            int x = rnd.Next(rectTopLeft.x, reactBottomRight.x+1);
            int y = rnd.Next(rectTopLeft.y, reactBottomRight.y+1);
            return new Point { x = x, y = y };
        }

        public static void Write(string text , Point point , ConsoleColor backgroundColor, ConsoleColor color)
        {
            Console.SetCursorPosition(point.x, point.y);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
