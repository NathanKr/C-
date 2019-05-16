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
            gameIsOver = false;

            board.Write();

            while (!gameIsOver)
            {
                Thread.Sleep(nSleepTimeMs);
                snake.Move(direction);
                snake.Write();

                // todo implement and remove remark handleApple();

                getUserInputDirection(ref direction);

                // todo implement and remove remark handleSnakeCollisions();
            }
        }

        private void handleApple()
        {
            throw new NotImplementedException();
        }

        private void handleSnakeCollisions()
        {
           throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        private bool snakeCollisionWithApple()
        {
            throw new NotImplementedException();
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
        private bool gameIsOver;
    }
}
