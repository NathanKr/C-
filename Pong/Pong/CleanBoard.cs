using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class CleanBoard : Shape
    {
        readonly char m_char = ' ';
        char[,] m_board;
        public CleanBoard( char[,] board)
        {
            m_board = board;
        }

        public override void SetOnBoard()
        {
            for (int i_row = Y; i_row < Utils.GetRows(m_board); i_row++)
            {
                for (int i_col = X; i_col < Utils.GetCols(m_board); i_col++)
                {
                    m_board[i_row, i_col] = m_char;
                }
            }
        }
    }
}
