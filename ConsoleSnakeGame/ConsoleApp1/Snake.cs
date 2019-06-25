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
            m_body = new List<Point>();
            Head = snakeHead;
            m_snakeHeadPrev = null;
            m_body.Add(snakeHead);
            m_colorHead = colorHead;
            m_colorTail = colorTail;
        }


        public bool IsDirty { get; set; }


        public void Draw()
        {
            if (m_snakeHeadPrev == null)
            {
                m_colorHead.Write(Head);
                m_snakeHeadPrev = new Point(Head.x, Head.y);
            }
            else
            {
                Console.MoveBufferArea(
                    m_snakeHeadPrev.x, m_snakeHeadPrev.y,
                    1, 1,
                    Head.x, Head.y);

                //todo i dont like that draw has logic !!!!!!!!
                m_snakeHeadPrev.x = Head.x;
                m_snakeHeadPrev.y = Head.y;
            }
        }


        public void Update(GameTime gameTime)
        {
            //do nothing
        }

        Point getLastOnBody()
        {
            return m_body[m_body.Count - 1];
        }

        public void AddToTail(Point point)
        {
            m_body.Add(point);
            IsDirty = true;
        }

        public Point Grow()
        {
            Point possibleNewPoint = null;
            switch (Direction)
            {
                case Direction.Up:
                    possibleNewPoint = new Point(getLastOnBody().x, getLastOnBody().y+1);
                    break;

                case Direction.Down:
                    possibleNewPoint = new Point(getLastOnBody().x, getLastOnBody().y-1);
                    break;


                case Direction.Left:
                    possibleNewPoint = new Point(getLastOnBody().x+1, getLastOnBody().y);
                    break;

                case Direction.Right:
                    possibleNewPoint = new Point(getLastOnBody().x-1, getLastOnBody().y);
                    break;

                default:
                    throw new Exception($"Unexpected direction : {Direction}");
            }

            return possibleNewPoint;
        }

        private List<Point> m_body;
        public Point Head { get; private set; }
        private Point m_snakeHeadPrev;
        private ColorChar m_colorHead, m_colorTail;
        public Direction Direction
        {
            get
            {
                return m_direction;
            }
            set
            {
                IsDirty = true;// --- changed on default
                switch (value)
                {
                    case Direction.Down:
                        Head.y++;
                        break;

                    case Direction.Up:
                        Head.y--;
                        break;

                    case Direction.Left:
                        Head.x--;
                        break;

                    case Direction.Right:
                        Head.x++;
                        break;

                    default:
                        IsDirty = false;
                        break;
                }
            }
        }
        Direction m_direction;

    }
}
