using ConsoleApp1.GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // --- put here final , result , time , ....
    class Results : IGameObject
    {
        public Results(Point pointTopLeft)
        {
            TopLeft = pointTopLeft;
            m_listMessages = new List<string>();
        }


        public bool IsDirty  { get; set; }

        public void Draw()
        {
            int x= TopLeft.x, y = TopLeft.y;
            foreach (string message in m_listMessages)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(message);
                y++;
            }
        }

        public void AddMessage(string strMessage)
        {
            m_listMessages.Add(strMessage);
        }

        public void Clear()
        {
            m_listMessages.Clear();
        }

        public void Update(GameTime gameTime)
        {
            // do noting
        }

        Point TopLeft;
        List<string> m_listMessages;
    }
}
