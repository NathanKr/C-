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

        public char text { get; set; }
        public ConsoleColor color { get; set; }
        public ConsoleColor backgroundColor { get; set; }
    }
}
