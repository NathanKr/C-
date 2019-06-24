using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool IsEqual(Point p)
        {
            return (p != null) && (x == p.x) && (y == p.y);
        }
        public int x { get; set; }
        public int y { get; set; }
    }

}
