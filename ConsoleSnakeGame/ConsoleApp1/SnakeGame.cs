using ConsoleApp1.GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SnakeGame : GameLoop
    {
        /*public SnakeGame(int nSleepTimeMs, BoardInfo boardInfo, SnakeInfo snakeInfo, ColorChar appleInfo)
        {
            int resultMargin = 2;
            Console.CursorVisible = false;
            this.nSleepTimeMs = nSleepTimeMs;
            board = new Board(boardInfo.boardTopLeft, boardInfo.boardBottomRight, boardInfo.cBorder);
            this.appleInfo = appleInfo;
            result = new Result(new Point(
                boardInfo.boardTopLeft.x + resultMargin,
                boardInfo.boardBottomRight.y + resultMargin));
            snake = new Snake(
                snakeInfo.snakeHead,
               snakeInfo.colorHead,
               snakeInfo.colorTail);
        }*/


        public SnakeGame(BoardInfo boardInfo, SnakeInfo snakeInfo, ColorChar appleInfo)
        {
            listGameObjects = new List<IGameObject>();
            m_border = new Border(
                boardInfo.boardTopLeft, 
                boardInfo.boardBottomRight, 
                boardInfo.cBorder);
            m_snake = new Snake(
                snakeInfo.snakeHead,
               snakeInfo.colorHead,
               snakeInfo.colorTail);
            m_apple = new Apple(appleInfo);
            m_results = new Results();
            listGameObjects.Add(m_border);
            listGameObjects.Add(m_apple);
            listGameObjects.Add(m_snake);
            listGameObjects.Add(m_results);
        }

        public override void Draw()
        {
            foreach (IGameObject gameObject in listGameObjects)
            {
                if (gameObject.IsDirty)
                {
                    gameObject.Draw();
                }
            }

            if (m_border.IsDirty)
            {
                // --- do it once because border is is not moving
                m_border.IsDirty = false;//
            }
        }

        public override void HandleUserInputs()
        {
            //todo implement
        }

        public override void Initialize()
        {
            // --- snake and apple position
            // --- add border , snake and apple
            m_border.IsDirty = m_apple.IsDirty = m_snake.IsDirty = true;
        }

        SnakeCollision ? checkCollisionWithSnake()
        {
            SnakeCollision? collision = null;

            /* todo implement
             * check colision of snake with self , snake with border and snake with apple if exist
             */

            return collision;
        }

        public override void Update(GameTime gameTime)
        {
            SnakeCollision ? collision = checkCollisionWithSnake();

            if (collision.HasValue)
            {
                handleCollisionWithSnake(collision.Value);
            }
            else
            {
                foreach (IGameObject gameObject in listGameObjects)
                {
                    gameObject.Update(gameTime);
                }
            }
        }

        private void handleCollisionWithSnake(SnakeCollision value)
        {
            //todo implement
        }

        List<IGameObject> listGameObjects;
        Apple m_apple;
        Snake m_snake;
        Border m_border;
        Results m_results;
    }
}
