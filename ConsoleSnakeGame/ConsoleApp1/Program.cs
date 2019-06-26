using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            AppleInfo appleInfo = new AppleInfo {
                ColorHead = new ColorChar('@', ConsoleColor.Red, ConsoleColor.DarkYellow),
                Head = new Point(80,10)};

            BoardInfo boardInfo = new BoardInfo {
                BoardTopLeft = new Point(0, 0),
                BoardBottomRight = new Point(100, 20),
                BorderSymbol = '.' };

            SnakeInfo snakeInfo = new SnakeInfo {
                SnakeHead = new Point(50, 10),
                ColorHead = new ColorChar('O', ConsoleColor.Blue, ConsoleColor.Cyan),
                ColorTail = new ColorChar('x', ConsoleColor.DarkGreen, ConsoleColor.Red)};

            SnakeGame game = new SnakeGame(boardInfo, snakeInfo,  appleInfo);

            game.Run();
            Console.ReadLine();
        }
    }
}
