using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Ball : Shape
    {
        readonly char m_char = '*';
        char[,] m_board;
        public Ball(char[,] board)
        {
            Vertical = DirectionVertical.None;
            Horizontal = DirectionHorizontal.Left;
            m_board = board;
        }

        /// <summary>
        /// used after collision
        /// </summary>
        public void BounceVertical()
        {
            if (Vertical == DirectionVertical.Up)
            {
                Vertical = DirectionVertical.Down;
            }
            else if (Vertical == DirectionVertical.Down)
            {
                Vertical = DirectionVertical.Up;
            }
        }

        public void BounceHorizontal()
        {
            if(Horizontal == DirectionHorizontal.Left)
            {
                Horizontal = DirectionHorizontal.Right;
            }
            else if (Horizontal == DirectionHorizontal.Right)
            {
                Horizontal = DirectionHorizontal.Left;
            }
        }

        
        public DirectionVertical Vertical { get; set; }
        public DirectionHorizontal Horizontal { get; set; }


        public override void SetOnBoard()
        {
            m_board[Y , X] = m_char; 
        }
    }
}
