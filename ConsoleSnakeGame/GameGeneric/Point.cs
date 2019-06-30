using System;
using System.Collections.Generic;
using System.Text;

namespace GameGeneric
{
    // struct is best for Point
    public struct Point 
    {
        public bool IsEqual(Point point)
        {
            return (point.x == x) && (point.y == y);
        }

        public int x;
        public int y;
    }

}
