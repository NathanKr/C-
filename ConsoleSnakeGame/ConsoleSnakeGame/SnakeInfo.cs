using GameGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    public struct SnakeInfo 
    {
        public Point SnakeHead;
        public ColorChar ColorHead;
        public ColorChar ColorTail;
        public float UpdatePeriodSec;
    }
}
