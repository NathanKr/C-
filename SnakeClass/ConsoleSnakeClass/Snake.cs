using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeClass
{
    class Snake
    {
        public Snake(Point snakeHead , Point boardTopLeft , Point boardBottomRight , char head , char tail)
        {
            body = new List<Point>();
            body.Add(snakeHead);
            this.boardTopLeft = boardTopLeft;
            this.boardBottomRight = boardBottomRight;
            this.head = head;
            this.tail = tail;
        }

        public void Grow()
        {
            /*
             * * TODO - implement this !!!!
             * add logic to grow snake by one
             * 
             */
        }

        public void Write()
        {
            /*
             * * TODO - implement this !!!!
             * go over the body and write to console according to its x,y position
             * 
             * you can implement this nicely using Console.MoveBufferArea without the need for clear screen
             */


        }



        /// <summary>
        /// Move one step in this direction
        /// </summary>
        /// <param name="Direction"></param>
        public void Move(Direction Direction)
        {
            /* 
             * TODO - implement this !!!!
             * move head in this direction but you need also logic for moving all other points in the body 
             * according to boardTopLeft , boardBottomRight
             */
        }

        private List<Point> body; // head and tail
        Point   boardTopLeft, // --- top left point of board so snake can not be left or above it
                boardBottomRight; // --- bottom , right point of board so snake can not be right or below it
        private char head; // head is this char
        private char tail; // all tail parts are like this chat
    }
}
