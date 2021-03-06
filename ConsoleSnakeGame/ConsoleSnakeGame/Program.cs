﻿using System;
using GameGeneric;

namespace ConsoleSnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Snake game by Nathan Krasney 2019 . version : " + UtilsGeneric.Utils.GetAssemblyFileVersion();
            int nBoardOffset = 2;
            ConsoleColor bacgroundColor = ConsoleColor.Black;

            Console.SetWindowSize(
                Constants.BOARD_WIDTH + 2 * nBoardOffset,
                Constants.BOARD_HEIGHT + 2 * nBoardOffset);


            BoardInfo boardInfo = new BoardInfo
            {
                BoardTopLeft = new Point{x=nBoardOffset, y=nBoardOffset},
                BoardBottomRight = new Point
                {
                    x = nBoardOffset + Constants.BOARD_WIDTH - 1,
                    y = nBoardOffset + Constants.BOARD_HEIGHT - 1
                },
                ColorBorder = new ColorChar(
                    '■',
                    ConsoleColor.Blue,
                    bacgroundColor)
            };

            SnakeInfo snakeInfo = new SnakeInfo
            {
                SnakeHead = new Point { 
                    x = (boardInfo.BoardTopLeft.x + boardInfo.BoardBottomRight.x) / 2,
                    y = (boardInfo.BoardTopLeft.y + boardInfo.BoardBottomRight.y) / 2},
                ColorHead = new ColorChar(
                    'Q',
                    ConsoleColor.Red,
                    bacgroundColor),
                ColorTail = new ColorChar(
                    'o',
                    ConsoleColor.Green,
                    bacgroundColor),
                UpdatePeriodSec = 0.1f
            };

            AppleInfo appleInfo = new AppleInfo {
                ColorHead = new ColorChar(
                    '@', 
                    ConsoleColor.Cyan,
                    bacgroundColor),
                Head = new Point { 
                    x = (snakeInfo.SnakeHead.x+ boardInfo.BoardBottomRight.x) /2, 
                    y = snakeInfo.SnakeHead.y}
            };


            TextOutputInfo textOutputInfo = new TextOutputInfo{
                TopLeft = new Point { 
                x=boardInfo.BoardTopLeft.x + nBoardOffset,
                y=boardInfo.BoardTopLeft.y - nBoardOffset
                },
                Color = ConsoleColor.Red,
                BackgroundColor = bacgroundColor
            };


            SnakeGame game = new SnakeGame(
                boardInfo, snakeInfo,  
                appleInfo , textOutputInfo);
                

            game.Run();
            Console.ReadLine();
        }
    }
}
