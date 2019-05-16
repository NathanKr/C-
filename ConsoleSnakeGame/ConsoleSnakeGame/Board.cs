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
            this.boardTopLeft = boardTopLeft;
            this.boardBottomRight = boardBottomRight;
            this.cBorder = cBorder;
        }

        public void Write()
        {
            // --- write rows
            Point boardBottomLeft = new Point(boardTopLeft.x, boardBottomRight.y);
            int width = boardBottomRight.x - boardTopLeft.x + 1;
            writeRow(boardTopLeft, width);
            writeRow(boardBottomLeft, width);

            // --- write cols
            Point boardTopRight = new Point(boardBottomRight.x, boardTopLeft.y);
            int height = boardBottomRight.y - boardTopLeft.y + 1;
            writeCol(boardTopLeft, height);
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

        Point boardTopLeft, boardBottomRight;
        char cBorder;
    }
}
