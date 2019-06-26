using GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // must be class because i need it as reference type
    class SnakeItem
    {
        public Point Current;
        public Point Prev;
        public bool WasNeverDraw;
    }
}
