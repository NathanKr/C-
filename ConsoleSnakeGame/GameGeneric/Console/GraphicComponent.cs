using System;
using System.Collections.Generic;
using System.Text;

namespace GameGeneric
{
    public class GraphicComponent
    {
        public void WriteCol(Point start, int length, ColorChar colorBorder)
        {
            Console.BackgroundColor = colorBorder.backgroundColor;
            Console.ForegroundColor = colorBorder.color;
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(start.x, start.y + i);
                Console.Write(colorBorder.text);
            }
            Console.ResetColor();
        }

        public void WriteRow(Point start, int length, ColorChar colorBorder)
        {
            Console.SetCursorPosition(start.x, start.y);
            Console.BackgroundColor = colorBorder.backgroundColor;
            Console.ForegroundColor = colorBorder.color;
            for (int i = 0; i < length; i++)
            {
                Console.Write(colorBorder.text);
            }
            Console.ResetColor();
        }
    }
}
