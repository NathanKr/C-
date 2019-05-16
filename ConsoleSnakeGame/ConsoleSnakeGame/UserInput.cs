using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class UserInput
    {
        /// <summary>
        /// non blocking
        /// </summary>
        /// <returns></returns>
        public static Direction ? GetDirection()
        {
            Direction ? direction = null;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        direction = Direction.Left;
                        break;

                    case ConsoleKey.RightArrow:
                        direction = Direction.Right;
                        break;

                    case ConsoleKey.UpArrow:
                        direction = Direction.Up;
                        break;

                    case ConsoleKey.DownArrow:
                        direction = Direction.Down;
                        break;

                    default:
                        direction = null;
                        break;
                }
            }

            return direction;
        }
    }
}
