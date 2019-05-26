using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTicTacToe
{
    class Result
    {
        public Result(Point ioTopLeft)
        {
            this.ioTopLeft = ioTopLeft;
        }

        public void Write(string text)
        {
            Console.SetCursorPosition(ioTopLeft.x, ioTopLeft.y);
            ConsoleColor currentForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = currentForegroundColor;
        }

        Point ioTopLeft;
    }
}
