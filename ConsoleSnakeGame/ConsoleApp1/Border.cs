using ConsoleApp1.GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Border : IGameObject
    {
        bool m_bIsDirty;
        private GraphicComponent m_graphics;
        public Point BoardTopLeft { get; }//todo  need public
        public Point BoardBottomRight { get; }//todo  need public

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

        char cBorder;

        public Border(Point boardTopLeft, Point boardBottomRight, char cBorder)
        {
            this.BoardTopLeft = boardTopLeft;
            this.BoardBottomRight = boardBottomRight;
            this.cBorder = cBorder;
            m_graphics = new GraphicComponent();
        }

        public void Draw()
        {
            // --- write rows
            Point boardBottomLeft = new Point(BoardTopLeft.x, BoardBottomRight.y);
            int width = BoardBottomRight.x - BoardTopLeft.x + 1;
            m_graphics.WriteRow(BoardTopLeft, width, cBorder);
            m_graphics.WriteRow(boardBottomLeft, width, cBorder);

            // --- write cols
            Point boardTopRight = new Point(BoardBottomRight.x, BoardTopLeft.y);
            int height = BoardBottomRight.y - BoardTopLeft.y + 1;
            m_graphics.WriteCol(BoardTopLeft, height, cBorder);
            m_graphics.WriteCol(boardTopRight, height, cBorder);

        }


        public void Update(GameTime gameTime)
        {
            //todo implement
        }
    }
}
