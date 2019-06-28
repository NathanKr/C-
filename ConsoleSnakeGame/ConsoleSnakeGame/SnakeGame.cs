using GameGeneric;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleSnakeGame
{
    public class SnakeGame : GameLoop
    {
        public SnakeGame(BoardInfo boardInfo, SnakeInfo snakeInfo, AppleInfo appleInfo)
        {
            m_listGameObjects = new List<IGameObject>();

            m_border = new Border(boardInfo);

            m_snake = new Snake(snakeInfo);

            m_apple = new Apple(appleInfo);

            m_textOutput = new TextOutput(new Point(
                boardInfo.BoardTopLeft.x + resultMargin,
                boardInfo.BoardBottomRight.y + resultMargin));

            m_listGameObjects.Add(m_border);
            m_listGameObjects.Add(m_apple);
            m_listGameObjects.Add(m_snake);
            // --- result must be at the end so it can handle gameEnd
            m_listGameObjects.Add(m_textOutput);

            userInput = new UserInputComponent();

            m_soundComponent = new SoundComponent();
            m_soundComponent.SoundPlayer.SoundLocation =
                Path.Combine(Constants.SOUND_DIR, Constants.SOUND_FILE);

            m_storageBestResult = new BestResultStorage(Constants.BEST_RESULTS_FILE); ;
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

            if (    (m_snake.HeadDirection == null) && 
                    (m_directionSnakeHead != null))
            {
                //first time user click on arrows so clear instructions
                m_textOutput.Clear();  
            } 
            if (m_directionSnakeHead.HasValue)
            {
                // --- direty is handled inside
                m_snake.HeadDirection = m_directionSnakeHead.Value;
            }
        }

        public override void Initialize()
        {
            m_border.IsDirty = m_apple.IsDirty = m_snake.IsDirty = true;
            m_textOutput.AddMessage(@"Hit Left\Right\Up\Down arrows to move snake");
            m_textOutput.IsDirty = true;
            List<string> list = m_storageBestResult.Read();
            if(list.Count == 1)
            {
                m_nBestApplesScore = int.Parse(list[0]);
            }
        }

        bool isCollision(Point point)
        {
            return checkCollisionWithSnakeHead().HasValue;
        }

        SnakeCollision ? checkCollisionWithSnakeHead()
        {
            SnakeCollision ? collision = null;
            
            if (m_apple.IsCollision(m_snake.Head))
            {
                collision = SnakeCollision.Apple;
            }
            else if (m_border.IsCollision(m_snake.Head))
            {
                collision = SnakeCollision.Border;
            }
            else if (m_snake.IsCollisionWithHead())
            {
                collision = SnakeCollision.Snake;
            }

            return collision;
        }

        public override void Update(GameTime gameTime)
        {
            SnakeCollision ? collision = checkCollisionWithSnakeHead();

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
                    m_soundComponent.SoundPlayer.Play();

                    // --- todo notice that new position can be same as snake , fix this !!!!!!
                    Point topLeftInsideBorder =
                        new Point(m_border.TopLeft.x + 1, m_border.TopLeft.y + 1);
                    Point bottomRightInsideBorder =
                        new Point(m_border.BottomRight.x - 1, m_border.BottomRight.y - 1);
                    m_apple.Head = Utils.GetRandPoint(topLeftInsideBorder, bottomRightInsideBorder);
                    m_apple.IsDirty = true;
                    Point possibleSnakeTailPoint = m_snake.Grow();
                    if (!isCollision(possibleSnakeTailPoint))
                    {
                        m_snake.AddToTail(possibleSnakeTailPoint);
                        m_nCurrentApplesScore += 10;
                        m_snake.CurrentUpdatePeriodSec = 
                            m_snake.CurrentUpdatePeriodSec * (1-Constants.GROW_PERCENT/100f);
                        if (m_nCurrentApplesScore > m_nBestApplesScore)
                        {
                            m_storageBestResult.Write(m_nCurrentApplesScore);
                            m_nBestApplesScore = m_nCurrentApplesScore;
                        }
                        m_textOutput.Clear();
                        m_textOutput.AddMessage($"Best score : {m_nBestApplesScore} , Current score : {m_nCurrentApplesScore}");
                    }

                    break;

                case SnakeCollision.Border:
                case SnakeCollision.Snake:
                    gameEnd = true;
                    m_textOutput.AddMessage($"Collision with {collision}");
                    m_textOutput.AddMessage("Game end");
                    m_textOutput.IsDirty = true;
                    break;



                default:
                    break;
            }           
        }

        List<IGameObject> m_listGameObjects;
        Apple m_apple;
        Snake m_snake;
        Border m_border;
        TextOutput m_textOutput;
        UserInputComponent userInput;
        SoundComponent m_soundComponent;
        Direction? m_directionSnakeHead;
        readonly int resultMargin = 2;
        int m_nCurrentApplesScore;
        int m_nBestApplesScore;
        BestResultStorage m_storageBestResult;
    }
}
