using GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Snake : IGameObject 
    {
        public Snake(SnakeInfo info)
        {
            m_listSnakeItems = new List<SnakeItem>();
            m_listSnakeItems.Add(new SnakeItem {
                Current = info.SnakeHead,
                    WasNeverDraw = true});
            Head = m_listSnakeItems[0].Current;
            m_colorHead = info.ColorHead;
            m_colorTail = info.ColorTail;
            m_UpdatePeriodSec = info.UpdatePeriodSec;
        }


        public bool IsDirty { get; set; }


        public void Draw()
        {
            SnakeItem snakeItem;
            for (int i = 0; i < m_listSnakeItems.Count ; i++)
            {
                snakeItem = m_listSnakeItems[i];
                if (snakeItem.WasNeverDraw)
                {
                    if (i == 0)
                    {
                        m_colorHead.Write(snakeItem.Current);
                    }
                    else
                    {
                        m_colorTail.Write(snakeItem.Current);
                    }
                    snakeItem.WasNeverDraw = false;
                }
                else
                {
                    Console.MoveBufferArea(
                        getSnakeItemPrevPosition(i).x, getSnakeItemPrevPosition(i).y,
                        1, 1,
                        getSnakeItemCurrentPosition(i).x, getSnakeItemCurrentPosition(i).y);
                }
            }
        }


        Point getSnakeItemCurrentPosition(int i)
        {
            return m_listSnakeItems[i].Current;
        }

        Point getSnakeItemPrevPosition(int i)
        {
            return m_listSnakeItems[i].Prev;
        }

        public bool IsCollision(Point point)
        {
            for (int i = 0; i < m_listSnakeItems.Count; i++)
            {
                if(getSnakeItemCurrentPosition(i).IsEqual(point))
                {
                    return true;
                }
            }

            return false;
        }

        bool timeToUpdate()
        {
            return m_computedUpdatePeriodSec > m_UpdatePeriodSec; 
        }
        
        public void Update(GameTime gameTime)
        {
            m_computedUpdatePeriodSec += gameTime.ElaspedSienceLastUpdateSec;

            if (HeadDirection.HasValue && timeToUpdate())
            {
                m_computedUpdatePeriodSec = 0;
                IsDirty = true;

                updatePositions();

                switch (HeadDirection.Value)
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
                        // do nothing
                        break;
                }
            }
        }

        Point lastOnBody{
            get { return m_listSnakeItems[m_listSnakeItems.Count - 1].Current; }
        }

        public void AddToTail(Point point)
        {
            m_listSnakeItems.Add(new SnakeItem {Current = point , WasNeverDraw = true});
        }

        Point getPossiblePointOnDirection(Direction direction)
        {
            Point possibleNewPoint = null;
            switch (direction)
            {
                case Direction.Up:
                    possibleNewPoint = new Point(lastOnBody.x, lastOnBody.y + 1);
                    break;

                case Direction.Down:
                    possibleNewPoint = new Point(lastOnBody.x, lastOnBody.y - 1);
                    break;


                case Direction.Left:
                    possibleNewPoint = new Point(lastOnBody.x + 1, lastOnBody.y);
                    break;

                case Direction.Right:
                    possibleNewPoint = new Point(lastOnBody.x - 1, lastOnBody.y);
                    break;

                default:
                    break;
            }

            return possibleNewPoint;
        }
        public Point Grow()
        {
            return getPossiblePointOnDirection(HeadDirection.Value);
        }



        public Direction? HeadDirection
        {
            get { return m_headDirection; }
            set{
                if(value.HasValue)
                {
                    Point possiblePoint = getPossiblePointOnDirection(value.Value);
                    // --- check collision with self
                    if (!IsCollision(possiblePoint))
                    {
                        m_headDirection = value;
                    }
                }
                else
                {
                    m_headDirection = null;
                }
            }
        }


        void updatePositions()
        {
            foreach (SnakeItem snakeItem in m_listSnakeItems)
            {
                if(snakeItem.Prev == null)
                {
                    snakeItem.Prev = new Point();
                }
                snakeItem.Prev.x = snakeItem.Current.x;
                snakeItem.Prev.y = snakeItem.Current.y;
            }

            // --- order is important , start from last
            for (int i = m_listSnakeItems.Count -1 ; i > 0  ; i--)
            {
                getSnakeItemCurrentPosition(i).x = getSnakeItemCurrentPosition(i - 1).x;
                getSnakeItemCurrentPosition(i).y = getSnakeItemCurrentPosition(i - 1).y;
            }
        }

        private List<SnakeItem> m_listSnakeItems;
        public Point Head { get; private set; }
        private ColorChar m_colorHead, m_colorTail;
        readonly private float m_UpdatePeriodSec;
        float m_computedUpdatePeriodSec;
        Direction ? m_headDirection;
    }
}
