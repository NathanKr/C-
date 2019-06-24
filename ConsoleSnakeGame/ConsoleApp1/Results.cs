using ConsoleApp1.GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // --- put here final , result , time , ....
    class Results : IGameObject
    {
        private bool m_bIsDirty;

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
            //todo nath
        }

        public void Update(GameTime gameTime)
        {
            //todo nath
        }
    }
}
