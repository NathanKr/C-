using GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeGame
{
    // --- put here final , result , time , ....
    // --- todo , move to game generic ?? or ui common ??
    public class TextOutput : IGameObject
    {
        public TextOutput(TextOutputInfo info)
        {
            TopLeft = info.TopLeft;
            m_backgroundColor = info.BackgroundColor;
            m_color = info.Color;

            m_listMessages = new List<string>();
        }


        public bool IsDirty  { get; set; }

        public void Draw()
        {
            int x= TopLeft.x, y = TopLeft.y;
            Console.BackgroundColor = m_backgroundColor;
            Console.ForegroundColor = m_color;
            foreach (string message in m_listMessages)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(message);
                y++;
            }
            Console.ResetColor();
        }

        public void AddMessage(string strMessage)
        {
            m_listMessages.Add(strMessage);
            IsDirty = true;
        }

        public void Clear()
        {
            int x = TopLeft.x, y = TopLeft.y;
            Console.BackgroundColor = m_backgroundColor;
            Console.ForegroundColor = m_color;
            foreach (string message in m_listMessages)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(new string(' ', message.Length));
                y++;
            }
            Console.ResetColor();
            m_listMessages.Clear();
            IsDirty = true;
        }

        public void Update(GameTime gameTime)
        {
            //nothing to do
        }

        Point TopLeft;
        private ConsoleColor m_backgroundColor;
        private ConsoleColor m_color;
        List<string> m_listMessages;
    }
}
