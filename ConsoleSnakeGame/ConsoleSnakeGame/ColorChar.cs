using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class ColorChar
    {
        public ColorChar(char text, ConsoleColor color , ConsoleColor backgroundColor)
        {
            this.text = text;
            this.color = color;
            this.backgroundColor = backgroundColor;
        }

        public void Write(Point point)
        {
            Console.SetCursorPosition(point.x, point.y);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public char text { get; set; }
        public ConsoleColor color { get; set; }
        public ConsoleColor backgroundColor { get; set; }
    }
}
