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

        public static void WriteCol(Point start, int length , char cBorder)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(start.x, start.y + i);
                Console.Write(cBorder);
            }
        }

        public static void WriteRow(Point start, int length ,  char cBorder)
        {
            Console.SetCursorPosition(start.x, start.y);
            for (int i = 0; i < length; i++)
            {
                Console.Write(cBorder);
            }
        }

    }
}
