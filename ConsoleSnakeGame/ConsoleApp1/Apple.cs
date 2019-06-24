using ConsoleApp1.GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Apple : IGameObject 
    {
        public Apple(ColorChar colorHead)
        {
            this.colorHead = colorHead;
            //this.Head = head;
            //prevHead = head;
            //colorHead.Write(head);
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
            colorHead.Write(Head);
        }


        public void Update(GameTime gameTime)
        {
            //todo implement
        }

        private bool m_bIsDirty;
        public Point Head { get; set; }
        private Point prevHead;
        private ColorChar colorHead;
    }
}
