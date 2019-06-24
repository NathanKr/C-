using ConsoleApp1.GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Snake : IGameObject 
    {
        public Snake(
            Point snakeHead,
            ColorChar colorHead,
            ColorChar colorTail)
        {
            body = new List<Point>();
            this.snakeHead = snakeHead;
            snakeHeadPrev = null;
            body.Add(snakeHead);
            this.colorHead = colorHead;
            this.colorTail = colorTail;
        }


        public bool IsDirty
        {
            get
            {
                return m_bIsDirty;
            }
            set
            {
                m_bIsDirty = value;
            }
        }


        public void Draw()
        {
            if (snakeHeadPrev == null)
            {
                colorHead.Write(snakeHead);
                snakeHeadPrev = new Point(snakeHead.x, snakeHead.y);
            }
            else
            {
                //MoveBufferArea

                snakeHeadPrev.x = snakeHead.x;
                snakeHeadPrev.y = snakeHead.y;
            }
        }


        public void Update(GameTime gameTime)
        {
            IsDirty = !snakeHead.IsEqual(snakeHeadPrev);

        }

        private bool m_bIsDirty;
        private List<Point> body;
        private Point snakeHead;
        private Point snakeHeadPrev;
        private ColorChar colorHead, colorTail;
    }
}
