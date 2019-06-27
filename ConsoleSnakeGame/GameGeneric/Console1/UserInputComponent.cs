using System;
using System.Collections.Generic;
using System.Text;

namespace GameGeneric
{
    // --- put here user input e.g. keyboard
    public class UserInputComponent
    {
        /// <summary>
        /// non blocking
        /// </summary>
        /// <returns></returns>
        public Direction? GetDirection()
        {
            Direction? direction = null;

            if (Console.KeyAvailable)
            {
                bool notDisplayPressedKey = true;
                ConsoleKeyInfo info = Console.ReadKey(notDisplayPressedKey);
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
