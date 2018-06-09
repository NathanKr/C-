using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Border : Shape , ICollide
    {
        readonly char m_char = 'x';
        readonly int m_nWidth, m_nHeight;
        char[,] m_board;

        public Border(char[,] board , int nWidth , int nHeight)
        {
            m_board = board;
            m_nWidth = nWidth;
            m_nHeight = nHeight;
        }

        public Collide DoesCollide(int X, int Y)
        {
            Collide collide = Collide.none;

            if(((Y <= this.Y) || (Y >= (this.Y + m_nHeight - 1))) &&
               (X >= this.X) && (X <= (this.X+m_nWidth-1)))
            {
                // --- collide with top or bottom 
                collide = Collide.border_top_or_bottom;
            }
            else if (( (X <= this.X) || (X >= (this.Y + m_nWidth - 1))) && 
                     (Y >= this.Y) && (Y <= (this.Y + m_nHeight - 1)))
            {
                // --- collide with left or right
                collide = (X < (m_nWidth / 2)) ? Collide.border_left : Collide.border_right;
            }

            return collide;
        }

        void setRow(int iRow)
        {
            for (int j = X; j < Utils.GetCols(m_board); j++)
            {
                m_board[iRow, j] = m_char;
            }
        }

        void setCol(int iCol)
        {
            for (int j = Y; j < Utils.GetRows(m_board); j++)
            {
                m_board[j,iCol] = m_char;
            }
        }

        public override void SetOnBoard()
        {
            setRow( 0);
            setRow(Utils.GetRows(m_board) - 1);
            setCol(0);
            setCol(Utils.GetCols(m_board) -1);
        }
    }
}
