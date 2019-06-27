using System;
using System.Collections.Generic;
using System.Text;

namespace GameGeneric
{
    public class GraphicComponent
    {
        public void WriteCol(Point start, int length, char cBorder)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(start.x, start.y + i);
                Console.Write(cBorder);
            }
        }

        public void WriteRow(Point start, int length, char cBorder)
        {
            Console.SetCursorPosition(start.x, start.y);
            for (int i = 0; i < length; i++)
            {
                Console.Write(cBorder);
            }
        }
    }
}
