using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class Result
    {
        //todo implement
        // grade , game over , ....
        public Result(Point pointTopLeft)
        {
            this.pointTopLeft = pointTopLeft;
        }

        public void Show(string strMessage)
        {
            Console.SetCursorPosition(pointTopLeft.x, pointTopLeft.y);
            Console.WriteLine(strMessage);
        }

        Point pointTopLeft;
    }
}
