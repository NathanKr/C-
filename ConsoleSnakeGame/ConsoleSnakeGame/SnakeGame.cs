using GameGeneric;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;

namespace ConsoleSnakeGame
{
    public class SnakeGame : GameLoop
    {
        public SnakeGame(
            BoardInfo boardInfo, SnakeInfo snakeInfo, 
            AppleInfo appleInfo , TextOutputInfo textOutputInfo)
        {
            m_listGameObjects = new List<IGameObject>();
            m_userInput = new UserInputComponent();
            m_soundComponent = new SoundComponent();
            m_storageBestResult = new BestResultStorage(Constants.BEST_RESULTS_FILE);


            m_snakeInfo = snakeInfo;//readonly
            m_appleInfo = appleInfo;//readonly
            m_textOutputInfo = textOutputInfo;//readonly
            m_boardInfo = boardInfo;
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
            ConsoleKeyInfo? keyInfo = m_userInput.GetKey();
            if (keyInfo.HasValue)
            {
                m_key = keyInfo.Value.KeyChar;
            }
            
            m_directionSnakeHead = UserInputComponent.GetDirection(keyInfo);

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
            initOnce();
            initBeforeEveryGame();
        }

        private void initBeforeEveryGame()
        {
            Console.Clear();
            m_border = new Border(m_boardInfo);
            m_snake = new Snake(m_snakeInfo);
            m_apple = new Apple(m_appleInfo);
            m_textOutput = new TextOutput(m_textOutputInfo);
            m_listGameObjects.Clear();
            m_listGameObjects.Add(m_border);
            m_listGameObjects.Add(m_apple);
            m_listGameObjects.Add(m_snake);
            // --- result must be at the end so it can handle gameEnd
            m_listGameObjects.Add(m_textOutput);
            m_border.IsDirty = m_apple.IsDirty = m_snake.IsDirty = m_textOutput.IsDirty = true;
            m_textOutput.AddMessage(@"Hit Left\Right\Up\Down arrows to move snake");
            m_gameState = GameState.Playing;
        }

        private void initOnce()
        {
            m_soundEat = m_soundComponent.CreateSoundPlayer();
            m_soundEat.SoundLocation =
                Path.Combine(Constants.SOUND_DIR, Constants.SOUND_EAT_FILE);
            m_soundDeath = m_soundComponent.CreateSoundPlayer();
            m_soundDeath.SoundLocation =
                Path.Combine(Constants.SOUND_DIR, Constants.SOUND_DEATH_FILE);
            List<string> list = m_storageBestResult.Read();
            if (list.Count == 1)
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
            
            if (m_apple.IsCollision(m_snake.GetHead()))
            {
                collision = SnakeCollision.Apple;
            }
            else if (m_border.IsCollision(m_snake.GetHead()))
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
            switch (m_gameState)
            {
                case GameState.Playing:
                    m_snake.Stop = false;
                    m_collision = checkCollisionWithSnakeHead();

                    if (m_collision.HasValue)
                    {
                        m_gameState = GameState.Collision;
                    }
                    break;

                case GameState.Collision:
                    m_snake.Stop = true;
                    handleCollisionWithSnake(m_collision.Value);
                    break;

                case GameState.Finish:
                    m_textOutput.Clear();
                    m_textOutput.AddMessage("Game Finish ! " + getScoreMessage());
                    // -- play sync so we will know when it is finished
                    m_soundDeath.Play();
                    m_textOutput.AddMessage("Do you want to play again : Y/N");
                    m_key = ' ';
                    m_gameState = GameState.WaitForUserInputPlayAgain;
                    break;

                case GameState.WaitForUserInputPlayAgain:
                    if (m_key == 'y')
                    {
                        initBeforeEveryGame();
                        m_soundDeath.Stop();
                    }
                    else if(m_key == 'n')
                    {
                        m_gameState = GameState.End;
                    }
                    break;


                case GameState.End:
                    m_textOutput.Clear();
                    m_textOutput.AddMessage("Game End ! " + getScoreMessage());
                    gameEnd = true;
                    break;

                default:
                    break;
            }

            foreach (IGameObject gameObject in m_listGameObjects)
            {
                gameObject.Update(gameTime);
            }

        }

        string getScoreMessage()
        {
            return $"Best score : {m_nBestApplesScore} , Current score : {m_nCurrentApplesScore}";
        }
        private void handleCollisionWithSnake(SnakeCollision collision)
        {
            switch (collision)
            {
                case SnakeCollision.Apple:
                    m_soundEat.Play();
                    // --- todo notice that new position can be same as snake , fix this !!!!!!
                    Point topLeftInsideBorder =
                        new Point { x = m_border.TopLeft.x + 1, y = m_border.TopLeft.y + 1 };
                    Point bottomRightInsideBorder =
                        new Point {x= m_border.BottomRight.x - 1, y = m_border.BottomRight.y - 1 };
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
                        m_textOutput.AddMessage(getScoreMessage());
                    }
                    m_gameState = GameState.Playing;
                    break;

                case SnakeCollision.Border:
                case SnakeCollision.Snake:
                    m_gameState = GameState.Finish;
                    break;


                default:
                    break;
            }           
        }


        List<IGameObject> m_listGameObjects;
        Apple m_apple;
        Snake m_snake;
        Border m_border;
        private readonly SnakeInfo m_snakeInfo;

        public AppleInfo m_appleInfo { get; }

        private readonly TextOutputInfo m_textOutputInfo;
        private readonly BoardInfo m_boardInfo;
        TextOutput m_textOutput;
        UserInputComponent m_userInput;
        SoundComponent m_soundComponent;
        Direction? m_directionSnakeHead;
        //readonly int resultMargin = 2;
        int m_nCurrentApplesScore;
        int m_nBestApplesScore;
        private SoundPlayer m_soundDeath;
        BestResultStorage m_storageBestResult;
        SoundPlayer m_soundEat;
        GameState m_gameState;
        SnakeCollision? m_collision;
        char m_key;
    }
}
