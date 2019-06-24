using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SnakeInfo
    {
        public SnakeInfo(Point snakeHead , ColorChar colorHead , ColorChar colorTail)
        {
            this.snakeHead = snakeHead;
            this.colorHead = colorHead;
            this.colorTail = colorTail;
        }

        public Point snakeHead { get; set; }
        public ColorChar colorHead { get; set; }
        public ColorChar colorTail { get; set; }
    }
}
