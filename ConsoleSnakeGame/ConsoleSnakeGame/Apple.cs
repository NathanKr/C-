using System;
using System.Collections.Generic;
using System.Text;
using GameGeneric;

namespace ConsoleSnakeGame
{
    public class Apple : IGameObject 
    {
        public Apple(AppleInfo info)
        {
            this.colorHead = info.ColorHead;
            Head = info.Head;
        }

        public bool IsCollision(Point point)
        {
             return Head.IsEqual(point);
        }

        public bool IsDirty { set; get; }


        public void Draw()
        {
            colorHead.Write(Head);
        }


        public void Update(GameTime gameTime)
        {
            // nothing to do
        }

        public Point Head { get; set; }
        private ColorChar colorHead;
    }
}
