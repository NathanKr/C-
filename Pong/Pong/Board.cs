using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Board
    {
        PlayerHuman m_humanPlayer;
        PlayerAuto m_autoPlayer;
        Ball m_ball;
        uint m_nHorizontalCycles;
        Results m_results;
        private readonly int m_nGameEnds;

        public Ball Ball {
            get
            {
                return m_ball;
            }
        }

        public Player HumanPlayer
        {
            get
            {
                return m_humanPlayer;
            }
        }
        void setPlayerY(Shape player , int nRow , int height)
        {
            player.Y = nRow / 2 - height / 2;
        }

        public Board(int nRows , int nCols, int nGameEnds , Results results)
        {
            m_results = results;
            m_nGameEnds = nGameEnds;
            int nPlayerWidth = 2, nPlayerHeight = nRows / 3, nPlayerDistanceX = 2;
            m_nHorizontalCycles = (uint)Math.Round((float)nCols / nRows);// try to get better angle

            m_nRows = nRows;
            m_nCols = nCols;
            m_arBoard = new char[nRows, nCols];

            m_Shapes = new List<Shape>();
            m_Shapes.Add(new CleanBoard(m_arBoard));//must be first
            m_Shapes.Add(new Border(m_arBoard, nCols , nRows));
            m_humanPlayer = new PlayerHuman(m_arBoard);
            setPlayer(nRows, nPlayerWidth, nPlayerHeight, nPlayerDistanceX, m_humanPlayer);
            m_Shapes.Add(m_humanPlayer);
            m_autoPlayer = new PlayerAuto(m_arBoard);
            setPlayer(nRows, nPlayerWidth, nPlayerHeight, 
                nCols - nPlayerDistanceX- nPlayerWidth, m_autoPlayer);
            m_Shapes.Add(m_autoPlayer);
            m_ball = new Ball (m_arBoard) { X = nCols / 2, Y = nRows / 2  };
            m_Shapes.Add(m_ball);
        }

        private void setPlayer( int nRow, int nPlayerWidth, int nPlayerHeight,
                                int nPlayerDistanceX, Player human)
        {
            human.Width = nPlayerWidth;
            human.Height = nPlayerHeight;
            human.X = nPlayerDistanceX;
            setPlayerY(human, nRow, human.Height);
        }

        public void HandleLogic(out bool bGameHasFinished)
        {
            Collide collide = Collide.none;
            bGameHasFinished = false;


            foreach (Shape shape in m_Shapes)
            {
                if(shape is ICollide)
                {
                    collide = ((ICollide)shape).DoesCollide(m_ball.X,m_ball.Y);
                    if(collide != Collide.none)
                    {
                        break;
                    }
                }
            }

            switch (collide)
            {
                // --- first is more probable to happen
                case Collide.none:
                    // do nothing here
                    break;

                case Collide.player_top:
                    Ball.BounceHorizontal();
                    Ball.Vertical = DirectionVertical.Up;
                    break;

                case Collide.player_bottom:
                    Ball.BounceHorizontal();
                    Ball.Vertical = DirectionVertical.Down;
                    break;

                case Collide.player_middle:
                    Ball.BounceHorizontal();
                    Ball.Vertical = DirectionVertical.None;
                    break;


                case Collide.border_left:
                    // --- assume auto is on right
                    m_results.PlayerAutoScore++;
                    Console.Beep();
                    Ball.BounceHorizontal();
                    if (m_results.PlayerAutoScore == m_nGameEnds)
                    {
                        bGameHasFinished = true;
                    }
                    break;

                case Collide.border_right:
                    // --- assume human is on left
                    m_results.PlayerHumanScore++;
                    Console.Beep();
                    Ball.BounceHorizontal();
                    if (m_results.PlayerHumanScore == m_nGameEnds)
                    {
                        bGameHasFinished = true;
                    }
                    break;

                case Collide.border_top_or_bottom:
                    Ball.BounceVertical();
                    break;

                default:
                    // do nothing here
                    break;
            }

            moveBall(1, m_nHorizontalCycles);
            movePlayerAuto();
        }

        private void movePlayerAuto()
        {
            // --- strategy is to keep center in same level as ball
            int centerAutoPlayerY = m_autoPlayer.Y + m_autoPlayer.Height / 2;
            if(centerAutoPlayerY < m_ball.Y)
            {
                if (m_autoPlayer.AllowMoveDown())
                {
                    m_autoPlayer.MoveDown();
                }
            }
            else if (centerAutoPlayerY > m_ball.Y)
            {
                if (m_autoPlayer.AllowMoveUp())
                {
                    m_autoPlayer.MoveUp();
                }
            }
        }

        void moveBall(uint nVerticalCycles, uint nHorizontalCycles)
        {
            switch (Ball.Vertical)
            {
                case DirectionVertical.Up:
                    for (int i = 0; i < nVerticalCycles; i++)
                    {
                        if(Ball.Y == 0){
                            break;// --- do not allow access outside of array
                        }
                        Ball.MoveUp();
                    }
                    break;

                case DirectionVertical.Down:
                    for (int i = 0; i < nVerticalCycles; i++)
                    {
                        if (Ball.Y == (m_nRows - 1)){
                            break;// --- do not allow access outside of array
                        }
                        Ball.MoveDown();
                    }
                    break;

                default:
                    // do nothing
                    break;
            }

            switch (Ball.Horizontal)
            {
                case DirectionHorizontal.Left:
                    for (int i = 0; i < nHorizontalCycles; i++)
                    {
                        if (Ball.X == 0){
                            break;// --- do not allow access outside of array
                        }
                        Ball.MoveLeft();
                    }
                    break;

                case DirectionHorizontal.Right:
                    for (int i = 0; i < nHorizontalCycles; i++)
                    {
                        if (Ball.X == (m_nCols - 1)){
                            break;// --- do not allow access outside of array
                        }
                        Ball.MoveRight();
                    }
                    break;

                default:
                    break;
            }
        }


        public void Draw()
        {
            foreach (Shape shape in m_Shapes)
            {
                shape.SetOnBoard();
            }

            for (int i_row = 0; i_row < m_nRows; i_row++)
            {
                for (int i_col = 0; i_col < m_nCols; i_col++)
                {
                    Console.SetCursorPosition(i_col, i_row);
                    Console.Write(m_arBoard[i_row, i_col]);
                }
            }
        }


        

        readonly int m_nRows, m_nCols;
        char[,] m_arBoard;
        List<Shape>  m_Shapes;
    }
}
