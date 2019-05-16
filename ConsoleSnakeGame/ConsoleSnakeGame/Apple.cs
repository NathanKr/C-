using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class Apple
    {
        public Apple(Point head , char cHead)
        {
            this.cHead = cHead;
            prevHead = null;
            this.head = head;
            Console.SetCursorPosition(head.x, head.y);
        }

        public void Write()
        {
            Console.MoveBufferArea(prevHead.x, prevHead.y, 1, 1, head.x, head.y);
        }

        public void Move(Point newPoint)
        {
            prevHead = head;
            head = newPoint;
        }

        private Point head , prevHead;
        char cHead;
    }
}
