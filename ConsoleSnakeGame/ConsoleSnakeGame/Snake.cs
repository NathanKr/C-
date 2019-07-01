using GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeGame
{
    public class Snake : IGameObject 
    {
        public Snake(SnakeInfo info)
        {
            m_listSnakeItems = new List<SnakeItem>();
            m_listSnakeItems.Add(new SnakeItem {
                    Current = info.SnakeHead,
                    WasNeverDraw = true});
            for (int i = 0; i < Constants.INITIAL_SNAKE_BODY_COUNT; i++)
            {
                m_listSnakeItems.Add(new SnakeItem
                {
                    // add to the left
                    Current = getPossiblePointOnDirection(Direction.Right) ,
                    WasNeverDraw = true
                });
            }
            //Head = m_listSnakeItems[0].Current;
            m_colorHead = info.ColorHead;
            m_colorTail = info.ColorTail;
            CurrentUpdatePeriodSec = m_OriginalUpdatePeriodSec = info.UpdatePeriodSec;
            Stop = false;
        }

        public Point GetHead()
        {
            return m_listSnakeItems[0].Current;
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
                    //todo nath does it always has value
                    Console.MoveBufferArea(
                        getSnakeItemPrevPosition(i).Value.x, getSnakeItemPrevPosition(i).Value.y,
                        1, 1,
                        getSnakeItemCurrentPosition(i).x, getSnakeItemCurrentPosition(i).y);
                }
            }
        }


        Point getSnakeItemCurrentPosition(int i)
        {
            return m_listSnakeItems[i].Current;
        }

        Point ? getSnakeItemPrevPosition(int i)
        {
            return m_listSnakeItems[i].Prev;
        }

        
        public bool IsCollisionWithHead()
        {
            // --- head is in 0 
            for (int i = 1; i < m_listSnakeItems.Count; i++)
            {
                if(getSnakeItemCurrentPosition(i).IsEqual(GetHead()))
                {
                    return true;
                }
            }

            return false;
        }

        bool timeToUpdate()
        {
            return m_accumulatedUpdatePeriodSec > CurrentUpdatePeriodSec; 
        }


        public bool Stop { get; set; }

        public void Update(GameTime gameTime)
        {
            m_accumulatedUpdatePeriodSec += gameTime.ElaspedSienceLastUpdateSec;

            if (HeadDirection.HasValue && timeToUpdate() && !Stop)
            {
                m_accumulatedUpdatePeriodSec = 0;
                IsDirty = true;// snake is dirty on every time to update

                updatePositions();

                switch (HeadDirection.Value)
                {
                    case Direction.Down:
                        m_listSnakeItems[0].Current.y++;
                        break;

                    case Direction.Up:
                        m_listSnakeItems[0].Current.y--;
                        break;

                    case Direction.Left:
                        m_listSnakeItems[0].Current.x--;
                        break;

                    case Direction.Right:
                        m_listSnakeItems[0].Current.x++;
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

        Point  getPossiblePointOnDirection(Direction direction)
        {
            Point possibleNewPoint;
            switch (direction)
            {
                case Direction.Up:
                    possibleNewPoint = new Point { x = lastOnBody.x, y = lastOnBody.y + 1 };
                    break;

                case Direction.Down:
                    possibleNewPoint = new Point { x = lastOnBody.x, y = lastOnBody.y - 1 };
                    break;


                case Direction.Left:
                    possibleNewPoint = new Point { x = lastOnBody.x + 1, y = lastOnBody.y };
                    break;

                case Direction.Right:
                default:
                    possibleNewPoint = new Point { x = lastOnBody.x - 1, y=lastOnBody.y };
                    break;
            }

            return possibleNewPoint;
        }
        public Point Grow()
        {
            return getPossiblePointOnDirection(HeadDirection.Value);
        }


        Direction getOppositeDirection(Direction direction)
        {
            Direction oppositeDirection;
            switch (direction)
            {
                case Direction.Left:
                    oppositeDirection = Direction.Right;
                    break;

                case Direction.Right:
                    oppositeDirection = Direction.Left;
                    break;

                case Direction.Up:
                    oppositeDirection = Direction.Down;
                    break;

                case Direction.Down:
                default:
                    oppositeDirection = Direction.Up;
                    break;
            }

            return oppositeDirection;
        }

        public Direction ? HeadDirection
        {
            get { return m_headDirection; }
            set{
                if( (m_headDirection == null) ||
                    (m_listSnakeItems.Count == 1) || 
                    (getOppositeDirection(m_headDirection.Value) != value.Value))
                {
                    // do not allow going in opposite direction because it will go over the snake
                    m_headDirection = value;
                }
            }
        }


        void updatePositions()
        {
            foreach (SnakeItem snakeItem in m_listSnakeItems)
            {
                //todo nath , why can not set ??
                snakeItem.Prev = new Point { x = snakeItem.Current.x, y = snakeItem.Current.y };
            }

            // --- order is important , start from last
            for (int i = m_listSnakeItems.Count -1 ; i > 0  ; i--)
            {
                m_listSnakeItems[i].Current.x = getSnakeItemCurrentPosition(i - 1).x;
                m_listSnakeItems[i].Current.y = getSnakeItemCurrentPosition(i - 1).y;
            }
        }


        private List<SnakeItem> m_listSnakeItems;
        //public Point Head { get; private set; }
        private ColorChar m_colorHead, m_colorTail;
        readonly private float m_OriginalUpdatePeriodSec;
        public float CurrentUpdatePeriodSec { get; set; }
        float m_accumulatedUpdatePeriodSec;
        Direction ? m_headDirection;
    }
}
