using GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeGame
{
    // must be class because i need it as reference type
    public class SnakeItem
    {
        public Point Current;
        public Point ? Prev; // todo is it possible to do without it and compute on the fly ?
        public bool WasNeverDraw;
    }
}
