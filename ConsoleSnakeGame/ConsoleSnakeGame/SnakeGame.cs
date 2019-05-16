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
        public SnakeGame(int nSleepTimeMs , BoardInfo boardInfo , SnakeInfo snakeInfo , ColorChar appleInfo)
        {
            Console.CursorVisible = false;
            this.nSleepTimeMs = nSleepTimeMs;
            board = new Board(boardInfo.boardTopLeft , boardInfo.boardBottomRight, boardInfo.cBorder);
            this.appleInfo = appleInfo;
            snake = new Snake(
                snakeInfo.snakeHead,
               snakeInfo.colorHead,
               snakeInfo.colorTail);
        }

        public void Start()
        {
            Direction direction = Direction.Right;
            gameIsOver = false;
            apple = null; // may be usefull for restart
            needNewApplePosition = true;

            board.Write();

            while (!gameIsOver)
            {
                Thread.Sleep(nSleepTimeMs);
                snake.Move(direction);
                snake.Write();

                getUserInputDirection(ref direction);

                handleSnakeCollisions();

                handleApple();
            }
        }

        private void handleApple()
        {
            if (needNewApplePosition)
            {
                Point newApplePosition;
                do
                {
                    newApplePosition = Utils.GetRandPoint(board.BoardTopLeft, board.BoardBottomRight);
                } while (snake.IsCollision(newApplePosition));

                if (apple == null)
                {
                    apple = new Apple(newApplePosition, appleInfo);
                }

                apple.Move(newApplePosition);
                apple.Write();

                needNewApplePosition = false;
            }
        }

        private void handleSnakeCollisions()
        {
            SnakeCollision? collision = getSnakeCollisions();

            if (collision.HasValue)
            {
                switch (collision)
                {
                    case SnakeCollision.Apple:
                        needNewApplePosition = true;
                        break;

                    case SnakeCollision.Border:
                        gameIsOver = true;
                        break;

                    default:
                        throw (new Exception($"Unepected collision : {collision}"));
                }
            }
        }

        SnakeCollision ? getSnakeCollisions()
        {
            SnakeCollision? collision;

            if (snakeCollisionWithApple())
            {
                collision = SnakeCollision.Apple;
            }
            else if(snakeCollisionWithBorder())
            {
                collision = SnakeCollision.Border;
            }
            else
            {
                collision = null;
            }

            return collision;
        }

        private bool snakeCollisionWithBorder()
        {
            return board.IsCollision(snake.Head);
        }

        private bool snakeCollisionWithApple()
        {
            return (apple != null) ? snake.IsCollision(apple.Head) : false; 
        }

        void getUserInputDirection(ref Direction direction)
        {
            Direction? input = UserInput.GetDirection();
            if (input.HasValue)
            {
                direction = input.Value;
            }
        }

        private int nSleepTimeMs;
        private Snake snake;
        private Board board;
        private Apple apple;
        private ColorChar appleInfo;
        private bool gameIsOver;
        private bool needNewApplePosition;
    }
}
