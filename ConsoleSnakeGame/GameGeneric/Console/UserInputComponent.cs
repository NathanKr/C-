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
        public ConsoleKeyInfo ? GetKey()
        {
            if (Console.KeyAvailable)
            {
                bool notDisplayPressedKey = true;
                return Console.ReadKey(notDisplayPressedKey);
            }

            return null;
        }

        /// <summary>
        /// non blocking
        /// </summary>
        /// <returns></returns>
        public static Direction ? GetDirection(ConsoleKeyInfo? keyInfo)
        {
            Direction? direction = null;

            if (keyInfo.HasValue)
            {
                switch (keyInfo.Value.Key)
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
