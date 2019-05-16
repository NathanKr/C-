using System;
using System.Threading;
namespace ConsoleSnakeGame
{
    class Program
    {
        static void testSnakeClass()
        {
            Snake snake = new Snake(
                new Point(5, 5),
                new Point(0, 0),
                new Point(10, 10),
                'O',
                'x');

            snake.Write();
            Sleep();


            snake.Move(Direction.Right);
            snake.Write();
            Sleep();

            snake.Move(Direction.Left);
            snake.Write();
            Sleep();

            snake.Move(Direction.Up);
            snake.Write();
            Sleep();

            snake.Move(Direction.Down);
            snake.Write();
            Sleep();
        }

        static void Sleep()
        {
            Thread.Sleep(1000);
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            testSnakeClass();
        }
    }
}
