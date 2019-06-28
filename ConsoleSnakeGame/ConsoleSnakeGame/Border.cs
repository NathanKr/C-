using GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeGame
{
    public class Border : IGameObject
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


        public Border(BoardInfo info)
        {
            TopLeft = info.BoardTopLeft;
            BottomRight = info.BoardBottomRight;
            ColorBorder = info.ColorBorder;
            m_graphics = new GraphicComponent();
        }

        public void Draw()
        {
            // --- write rows
            Point boardBottomLeft = new Point(TopLeft.x, BottomRight.y);
            int width = BottomRight.x - TopLeft.x + 1;
            m_graphics.WriteRow(TopLeft, width, ColorBorder);
            m_graphics.WriteRow(boardBottomLeft, width, ColorBorder);

            // --- write cols
            Point boardTopRight = new Point(BottomRight.x, TopLeft.y);
            int height = BottomRight.y - TopLeft.y + 1;
            m_graphics.WriteCol(TopLeft, height, ColorBorder);
            m_graphics.WriteCol(boardTopRight, height, ColorBorder);

        }


        public void Update(GameTime gameTime)
        {
            //nothing to do
        }

        private GraphicComponent m_graphics;
        public Point TopLeft { get; }
        public Point BottomRight { get; }
        ColorChar ColorBorder;

    }
}
