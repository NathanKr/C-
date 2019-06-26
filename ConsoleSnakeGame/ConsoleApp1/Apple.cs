using System;
using System.Collections.Generic;
using System.Text;
using GameGeneric;

namespace ConsoleApp1
{
    class Apple : IGameObject 
    {
        public Apple(Point head, ColorChar colorHead)
        {
            this.colorHead = colorHead;
            Head = head;
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
            //todo implement
        }

        public Point Head { get; set; }
        private ColorChar colorHead;
    }
}
