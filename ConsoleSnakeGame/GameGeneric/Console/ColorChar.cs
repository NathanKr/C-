using System;
using System.Collections.Generic;
using System.Text;

namespace GameGeneric
{
    public class ColorChar
    {
        public ColorChar(char text, ConsoleColor color, ConsoleColor backgroundColor)
        {
            this.text = text;
            this.color = color;
            this.backgroundColor = backgroundColor;
        }

        public void Write(Point point)
        {
            Utils.Write(text.ToString(), point, backgroundColor, color);
        }

        public char text { get; set; }
        public ConsoleColor color { get; set; }
        public ConsoleColor backgroundColor { get; set; }
    }

}
