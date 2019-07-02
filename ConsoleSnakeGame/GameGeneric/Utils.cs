using System;
using System.Collections.Generic;
using System.Text;

namespace GameGeneric
{
    public class Utils
    {
        public static Point GetRandPoint(Point rectTopLeft, Point reactBottomRight , Point point)
        {
            Point newpoint = new Point();
            Random rnd = new Random();

            do
            {
                newpoint.x = rnd.Next(rectTopLeft.x, reactBottomRight.x + 1);
                newpoint.y = rnd.Next(rectTopLeft.y, reactBottomRight.y + 1);
            } while (newpoint.IsEqual(point));

            return newpoint;
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
