using GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SnakeGame : GameLoop
    {
        public SnakeGame(BoardInfo boardInfo, SnakeInfo snakeInfo, AppleInfo appleInfo)
        {
            m_listGameObjects = new List<IGameObject>();

            m_border = new Border(
                boardInfo.BoardTopLeft, 
                boardInfo.BoardBottomRight, 
                boardInfo.BorderSymbol);

            m_snake = new Snake(
                snakeInfo.SnakeHead,
               snakeInfo.ColorHead,
               snakeInfo.ColorTail);

            m_apple = new Apple(appleInfo.Head , appleInfo.ColorHead);

            m_results = new Results(new Point(
                boardInfo.BoardTopLeft.x + resultMargin,
                boardInfo.BoardBottomRight.y + resultMargin));

            m_listGameObjects.Add(m_border);
            m_listGameObjects.Add(m_apple);
            m_listGameObjects.Add(m_snake);
            // --- result must be at the end so it can handle gameEnd
            m_listGameObjects.Add(m_results);

            userInput = new UserInputComponent();
        }

        public override void Draw()
        {
            foreach (IGameObject gameObject in m_listGameObjects)
            {
                if (gameObject.IsDirty)
                {
                    gameObject.Draw();
                    gameObject.IsDirty = false;
                }
            }
        }

        public override void HandleUserInputs()
        {
            m_directionSnakeHead = userInput.GetDirection();
            if (m_directionSnakeHead.HasValue)
            {
                // --- direty is handled inside
                m_snake.Direction = m_directionSnakeHead.Value;
            }
        }

        public override void Initialize()
        {
            m_border.IsDirty = m_apple.IsDirty = m_snake.IsDirty = true;
        }

        bool isCollision(Point point)
        {
            return checkCollision(point).HasValue;
        }

        SnakeCollision ? checkCollision(Point point)
        {
            SnakeCollision ? collision = null;
            if (m_apple.IsCollision(point))
            {
                collision = SnakeCollision.Apple;
            }
            else if (m_border.IsCollision(point))
            {
                collision = SnakeCollision.Border;
            }
            /* todo implement
             * check colision of snake with self , snake with border and snake with apple if exist
             */

            return collision;
        }

        public override void Update(GameTime gameTime)
        {
            SnakeCollision ? collision = checkCollision(m_snake.Head);

            if (collision.HasValue)
            {
                handleCollisionWithSnake(collision.Value);
            }
            else
            {
                foreach (IGameObject gameObject in m_listGameObjects)
                {
                    gameObject.Update(gameTime);
                }
            }
        }

        private void handleCollisionWithSnake(SnakeCollision collision)
        {
            switch (collision)
            {
                case SnakeCollision.Apple:
                    // --- todo notice that new position can be same as snake , fix this !!!!!!
                    Point topLeftInsideBorder =
                        new Point(m_border.TopLeft.x + 1, m_border.TopLeft.y + 1);
                    Point bottomRightInsideBorder =
                        new Point(m_border.BottomRight.x - 1, m_border.BottomRight.y - 1);
                    m_apple.Head = Utils.GetRandPoint(topLeftInsideBorder, bottomRightInsideBorder);
                    m_apple.IsDirty = true;//todo do inside ???
                    Point possibleSnakeTailPoint = m_snake.Grow();
                    if (!isCollision(possibleSnakeTailPoint))
                    {
                        // --- dirty is changed inside
                        m_snake.AddToTail(possibleSnakeTailPoint);
                    }

                    break;

                case SnakeCollision.Border:
                    gameEnd = true;
                    m_results.AddMessage("Collision with Border");
                    m_results.AddMessage("Game end");
                    m_results.IsDirty = true;
                    break;

                case SnakeCollision.Snake:

                    break;

                default:
                    break;
            }           
        }

        List<IGameObject> m_listGameObjects;
        Apple m_apple;
        Snake m_snake;
        Border m_border;
        Results m_results;
        UserInputComponent userInput;
        Direction? m_directionSnakeHead;
        readonly int resultMargin = 2;
    }
}
