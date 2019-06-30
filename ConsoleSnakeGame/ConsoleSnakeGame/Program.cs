using System;
using System.IO;
using GameGeneric;

namespace ConsoleSnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            AppleInfo appleInfo = new AppleInfo {
                ColorHead = new ColorChar(
                    '@', 
                    ConsoleColor.Cyan,
                    ConsoleColor.Black),
                Head = new Point(60,10)};

            BoardInfo boardInfo = new BoardInfo {
                BoardTopLeft = new Point(0, 0),
                BoardBottomRight = new Point(80, 20),
                ColorBorder = new ColorChar(
                    '■', 
                    ConsoleColor.Blue,
                    ConsoleColor.Black) };

            SnakeInfo snakeInfo = new SnakeInfo {
                SnakeHead = new Point(50, 10),
                ColorHead = new ColorChar(
                    'Q',
                    ConsoleColor.Red, 
                    ConsoleColor.Black),
                ColorTail = new ColorChar(
                    'o',
                    ConsoleColor.Green,
                    ConsoleColor.Black),
                UpdatePeriodSec = 0.1f
            };

            SnakeGame game = new SnakeGame(boardInfo, snakeInfo,  appleInfo);
            

            game.Run();
            Console.ReadLine();
        }
    }
}
