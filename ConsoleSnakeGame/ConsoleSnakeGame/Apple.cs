using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class Apple
    {
        public Apple(Point head, ColorChar colorHead)
        {
            this.colorHead = colorHead;
            this.Head = head;
            prevHead = head;
            colorHead.Write(head);
        }

        public void Write()
        {
            colorHead.Write(Head);
        }

        public void Move(Point newPoint)
        {
            prevHead = Head;
            Head = newPoint;
        }

        public Point Head { get; private set; }
        private Point prevHead;
        private ColorChar colorHead;
    }
}
