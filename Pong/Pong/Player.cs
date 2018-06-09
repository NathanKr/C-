using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Player : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        readonly char m_char = '.';
        char[,] m_board;

        public Player (char[,] board)
        {
            m_board = board;
        }

        public override void SetOnBoard()
        {
            for (int i_row = 0; i_row < Height; i_row++)
            {
                for (int i_col = 0; i_col < Width; i_col++)
                {
                    m_board[i_row+Y, i_col+X] = m_char;
                }
            }
        }


        public bool AllowMoveUp()
        {
            // --- assume border width is 1
            return Y > 1;
        }

        public bool AllowMoveDown()
        {
            // --- assume border width is 1
            return (Y + Height) < (Utils.GetRows(m_board) - 1);
        }

        public Collide DoesCollideWithBall(int X, int Y)
        {
            Collide collide = Collide.none;

            if ((X >= this.X) && (X <= (this.X + Width - 1)) &&
                (Y >= this.Y) && (Y <= (this.Y + Height - 1))){
                float slice = (float)(Y - this.Y) / Height;
                if(slice < 0.33)
                {
                    collide = Collide.player_top;
                }
                else if (slice > 0.67)
                {
                    collide = Collide.player_bottom;
                }
                else
                {
                    collide = Collide.player_middle;
                }
            }

            return collide;
        }
    }
}
