using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    class Board
    {
        public Board(Point boardTopLeft, Point boardBottomRight , char cBorder)
        {
            this.BoardTopLeft = boardTopLeft;
            this.BoardBottomRight = boardBottomRight;
            this.cBorder = cBorder;
        }

        public void Write()
        {
            // --- write rows
            Point boardBottomLeft = new Point(BoardTopLeft.x, BoardBottomRight.y);
            int width = BoardBottomRight.x - BoardTopLeft.x + 1;
            writeRow(BoardTopLeft, width);
            writeRow(boardBottomLeft, width);

            // --- write cols
            Point boardTopRight = new Point(BoardBottomRight.x, BoardTopLeft.y);
            int height = BoardBottomRight.y - BoardTopLeft.y + 1;
            writeCol(BoardTopLeft, height);
            writeCol(boardTopRight, height);
        }

        private void writeCol(Point start, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(start.x, start.y+i);
                Console.Write(cBorder);
            }
        }

        private void writeRow(Point start , int length)
        {
            Console.SetCursorPosition(start.x, start.y);
            for (int i = 0; i < length; i++)
            {
                Console.Write(cBorder);
            }
        }

        public Point BoardTopLeft { get; }
        public Point BoardBottomRight { get; }

        char cBorder;

        public bool IsCollision(Point point)
        {
            bool left_or_right_Collision, top_or_bottom_Collision ;

            left_or_right_Collision = (point.x == BoardTopLeft.x || point.x == BoardBottomRight.x) && 
                (point.y >= BoardTopLeft.y && point.y <= BoardBottomRight.y);

            top_or_bottom_Collision = (point.y == BoardTopLeft.y || point.y == BoardBottomRight.y) &&
                (point.x >= BoardTopLeft.x && point.x <= BoardBottomRight.x);

            return (left_or_right_Collision || top_or_bottom_Collision);
        }
    }
}
