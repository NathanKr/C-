using System;
using System.Diagnostics;

namespace ConsoleSnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int nSleepTimeMs = 200;
            ColorChar appleInfo = new ColorChar('@', ConsoleColor.Red, ConsoleColor.DarkYellow);
            BoardInfo boardInfo = new BoardInfo(new Point(0, 0) , new Point(100, 20),'.');
            SnakeInfo snakeInfo = new SnakeInfo(
                new Point(5, 5), 
                new ColorChar('O',ConsoleColor.Blue,ConsoleColor.Cyan), 
                new ColorChar('x',ConsoleColor.DarkGreen,ConsoleColor.Red));
            SnakeGame game = new SnakeGame(nSleepTimeMs, boardInfo, snakeInfo, appleInfo);

            game.Start();
        }
    }
}
