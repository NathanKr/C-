using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            AppleInfo appleInfo = new AppleInfo (
                new ColorChar('@', ConsoleColor.Red, ConsoleColor.DarkYellow),
                new Point(80,10));

            BoardInfo boardInfo = new BoardInfo(new Point(0, 0), new Point(100, 20), '.');

            SnakeInfo snakeInfo = new SnakeInfo(
                new Point(50, 10),
                new ColorChar('O', ConsoleColor.Blue, ConsoleColor.Cyan),
                new ColorChar('x', ConsoleColor.DarkGreen, ConsoleColor.Red));

            SnakeGame game = new SnakeGame(boardInfo, snakeInfo,  appleInfo);

            game.Run();
            Console.ReadLine();
        }
    }
}
