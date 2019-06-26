﻿using GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Border : IGameObject
    {
        public bool IsCollision(Point point)
        {
            bool left_or_right_Collision, top_or_bottom_Collision;

            left_or_right_Collision = (point.x == TopLeft.x || point.x == BottomRight.x) &&
                (point.y >= TopLeft.y && point.y <= BottomRight.y);

            top_or_bottom_Collision = (point.y == TopLeft.y || point.y == BottomRight.y) &&
                (point.x >= TopLeft.x && point.x <= BottomRight.x);

            return (left_or_right_Collision || top_or_bottom_Collision);

        }

        public bool IsDirty { set; get; }


        public Border(Point boardTopLeft, Point boardBottomRight, char cBorder)
        {
            this.TopLeft = boardTopLeft;
            this.BottomRight = boardBottomRight;
            this.cBorder = cBorder;
            m_graphics = new GraphicComponent();
        }

        public void Draw()
        {
            // --- write rows
            Point boardBottomLeft = new Point(TopLeft.x, BottomRight.y);
            int width = BottomRight.x - TopLeft.x + 1;
            m_graphics.WriteRow(TopLeft, width, cBorder);
            m_graphics.WriteRow(boardBottomLeft, width, cBorder);

            // --- write cols
            Point boardTopRight = new Point(BottomRight.x, TopLeft.y);
            int height = BottomRight.y - TopLeft.y + 1;
            m_graphics.WriteCol(TopLeft, height, cBorder);
            m_graphics.WriteCol(boardTopRight, height, cBorder);

        }


        public void Update(GameTime gameTime)
        {
            //todo implement
        }

        private GraphicComponent m_graphics;
        public Point TopLeft { get; }
        public Point BottomRight { get; }
        char cBorder;

    }
}