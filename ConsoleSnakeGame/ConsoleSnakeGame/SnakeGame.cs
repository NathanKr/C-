using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class SnakeGame
    {
        public SnakeGame(int nSleepTimeMs , BoardInfo boardInfo , SnakeInfo snakeInfo)
        {
            Console.CursorVisible = false;
            this.nSleepTimeMs = nSleepTimeMs;
            board = new Board(boardInfo.boardTopLeft , boardInfo.boardBottomRight, boardInfo.cBorder);

            snake = new Snake(
                snakeInfo.snakeHead,
               snakeInfo.colorHead,
               snakeInfo.colorTail);
        }

        public void Start()
        {
            Direction direction = Direction.Right;
            Direction? input;

            board.Write();

            while (true)
            {
                Thread.Sleep(nSleepTimeMs);
                snake.Move(direction);
                snake.Write();
                input = UserInput.GetDirection();

                if (input.HasValue)
                {
                    direction = input.Value;
                }
            }
        }

        private int nSleepTimeMs;
        Snake snake;
        Board board;
    }
}
