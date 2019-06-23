using System;

namespace ConsoleTicTacToe
{
    class Board
    {
        public Board(Point topLeft)
        {
            m_nSize = 3;
            m_topLeft = topLeft;
            m_arBoard = new EPlayer?[m_nSize, m_nSize];
        }

        public int Size{
            get{
                return m_nSize;
            }
        }

        bool isPlayerOnBoardPosition(int nRow,int col, EPlayer player)
        {
            return m_arBoard[nRow, col].HasValue && (m_arBoard[nRow, col] == player);
        }

        public bool IsPlayerWin(EPlayer player)
        {
            return checkRowsPlayerWin(player) ||
                   checkColsPlayerWin(player) ||
                   checkDiagonalsPlayerWin(player);
        }

        private bool checkDiagonalsPlayerWin(EPlayer player)
        {
            return checkDiagonal1PlayerWin(player) ||
                   checkDiagonal2PlayerWin(player);
        }

        private bool checkDiagonal1PlayerWin(EPlayer player)
        {
            for (int i = 0; i < m_nSize; i++)
            {
                if (!m_arBoard[i, i].HasValue || m_arBoard[i, i] != player)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkDiagonal2PlayerWin(EPlayer player)
        {
            int col = m_nSize - 1;
            for (int row = 0; row < m_nSize; row++)
            {
                if (!m_arBoard[row, col].HasValue || m_arBoard[row, col] != player)
                {
                    return false;
                }
                col--;
            }
            return true;
        }

        


        bool checkColsPlayerWin(EPlayer player)
        {
            for (int col = 0; col < m_nSize; col++)
            {
                if (checkColPlayerWin(col, player))
                {
                    return true;
                }
            }
            return false;
        }

        bool checkColPlayerWin(int nCol, EPlayer player)
        {
            for (int nRow = 0; nRow < m_nSize; nRow++)
            {
                if (!isPlayerOnBoardPosition(nRow, nCol, player))
                {
                    return false;
                }
            }

            return true;
        }

        bool checkRowsPlayerWin(EPlayer player)
        {
            for (int row = 0; row < m_nSize; row++)
            {
                if(checkRowPlayerWin(row,player))
                {
                    return true;
                }
            }
            return false;
        }

        bool checkRowPlayerWin(int nRow, EPlayer player)
        {
            for (int col = 0; col < m_nSize; col++)
            {
                if(!isPlayerOnBoardPosition(nRow, col, player))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsGameDraw()
        {
            //conservative approach
            for (int i = 0; i < m_nSize; i++)
            {
                for (int j = 0; j < m_nSize; j++)
                {
                    if (!m_arBoard[i, j].HasValue)
                    {
                        return false;
                    }
            
                }
            }
            return true;
        }

        bool checkCol(int nCol, EPlayer player)
        {
            bool bColAll = true;

            for (int row = 0; row < m_nSize; row++)
            {
                if (!isPlayerOnBoardPosition(row, nCol, player))
                {
                    bColAll = false;
                    break;
                }
            }

            return bColAll;
        }


        public void Reset()
        {
            for (int i = 0; i < m_nSize; i++)
            {
                for (int j = 0; j < m_nSize; j++)
                {
                    m_arBoard[i, j] = null;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row">zero based</param>
        /// <param name="col">arBoard</param>
        /// <param name="player"></param>
        public void Set(int row,int col , EPlayer player)
        {
            m_arBoard[row,col] = player;
        }

        public EPlayer ? Get(int row, int col)
        {
            return m_arBoard[row, col];
        }

        public void Write()
        {
            Console.Clear();
            int x = m_topLeft.x , y = m_topLeft.y;
            for (int row = 0; row < m_nSize; row++)
            {
                for (int col = 0; col < m_nSize; col++)
                {
                    Console.SetCursorPosition(x + col, y + row);
                    Console.Write(getPlayerChar(m_arBoard[row, col]));
                }
            }
            Console.WriteLine();
        }

        char getPlayerChar(EPlayer ? player)
        {
            char c;
            switch(player)
            {
                case EPlayer.Player1:
                    c = 'X';
                    break;

                case EPlayer.Player2:
                    c = 'O';
                    break;

                default:
                    c = '-';
                    break;
            }

            return c;
        }

        EPlayer ? [,] m_arBoard;
        int m_nSize;
        private Point m_topLeft;
    }
}