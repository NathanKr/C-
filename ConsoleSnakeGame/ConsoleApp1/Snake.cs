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
            m_listSnakeItems = new List<SnakeItem>();
            m_snakeHeadPrev = null;
            m_listSnakeItems.Add(new SnakeItem { Point = snakeHead , WasNeverDraw = true});
            Head = m_listSnakeItems[0].Point;
            m_colorHead = colorHead;
            m_colorTail = colorTail;
            //m_bAddedTailWasHandled = false;
            //m_bTailWasAdded = false;
            //m_bHeadWasDrawFirstTime = false;
        }


        public bool IsDirty { get; set; }


        public void Draw()
        {
            // --- order IS IMPORTANT , start from head
            //drawHead();
            //drawBody();
            SnakeItem snakeItem;
            for (int i = 0; i < m_listSnakeItems.Count ; i++)
            {
                snakeItem = m_listSnakeItems[i];
                if (snakeItem.WasNeverDraw)
                {
                    if (i == 0)
                    {
                        m_colorHead.Write(snakeItem.Point);
                    }
                    else
                    {
                        m_colorTail.Write(snakeItem.Point);
                    }
                    snakeItem.WasNeverDraw = false;
                }
                else
                {
                    if (i == 0)
                    {
                        Console.MoveBufferArea(
                            m_snakeHeadPrev.x, m_snakeHeadPrev.y,
                            1, 1,
                            Head.x, Head.y);
                    }
                    else
                    {
                        Console.MoveBufferArea(
                            m_listSnakeItems[i].Point.x, m_listSnakeItems[i].Point.y,
                            1, 1,
                            m_listSnakeItems[i - 1].Point.x, m_listSnakeItems[i - 1].Point.y);
                    }
                }
            }
        }

        //private void drawBody()
        //{
        //    int count = m_listSnakeItems.Count;
        //    if (m_bTailWasAdded && !m_bAddedTailWasHandled)
        //    {
        //        m_colorTail.Write(getLastOnBody());
        //        m_bTailWasAdded = false;
        //        m_bAddedTailWasHandled = true;
        //        count--;//because it is handled here
        //    }

        //    for (int i = 1; i < count; i++)
        //    {
        //        Console.MoveBufferArea(
        //            m_listSnakeItems[i].Point.x, m_listSnakeItems[i].Point.y,
        //            1, 1,
        //            m_listSnakeItems[i - 1].Point.x, m_listSnakeItems[i - 1].Point.y);
        //    }
        //}

        //private void drawHead()
        //{
        //    if (!m_bHeadWasDrawFirstTime)
        //    {
        //        m_colorHead.Write(Head);
        //        m_bHeadWasDrawFirstTime = true;
        //    }
        //    else
        //    {
        //        Console.MoveBufferArea(
        //            m_snakeHeadPrev.x, m_snakeHeadPrev.y,
        //            1, 1,
        //            Head.x, Head.y);
        //    }
        //}

        public void Update(GameTime gameTime)
        {
            if(m_snakeHeadPrev == null)
            {
                m_snakeHeadPrev = new Point(Head.x, Head.y);
            }
        }

        Point getLastOnBody()
        {
            return m_listSnakeItems[m_listSnakeItems.Count - 1].Point;
        }

        public void AddToTail(Point point)
        {
            m_listSnakeItems.Add(new SnakeItem {Point = point , WasNeverDraw = true});
            //m_bTailWasAdded = true;
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

        public Direction Direction
        {
            get
            {
                return m_direction;
            }
            set
            {
                m_direction = value;
                IsDirty = true;// --- changed on default
                switch (m_direction)
                {
                    case Direction.Down:
                        updateHeadPrev();
                        foreach (var item in m_listSnakeItems)
                        {
                            item.Point.y++;
                        }
                        break;

                    case Direction.Up:
                        updateHeadPrev();
                        foreach (var item in m_listSnakeItems)
                        {
                            item.Point.y--;
                        }
                        break;

                    case Direction.Left:
                        updateHeadPrev();
                        foreach (var item in m_listSnakeItems)
                        {
                            item.Point.x--;
                        }
                        break;

                    case Direction.Right:
                        updateHeadPrev();
                        foreach (var item in m_listSnakeItems)
                        {
                            item.Point.x++;
                        }
                        break;

                    default:
                        IsDirty = false;
                        break;
                }
            }
        }

        private void updateHeadPrev()
        {
            m_snakeHeadPrev.x = Head.x;
            m_snakeHeadPrev.y = Head.y;
        }

        private List<SnakeItem> m_listSnakeItems;
        public Point Head { get; private set; }
        private Point m_snakeHeadPrev;
        private ColorChar m_colorHead, m_colorTail;
        Direction m_direction;
//        bool m_bTailWasAdded;
  //      private bool m_bHeadWasDrawFirstTime;
    //    bool m_bAddedTailWasHandled;

    }
}
