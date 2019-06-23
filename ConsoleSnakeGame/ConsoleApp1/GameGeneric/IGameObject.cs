using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.GameGeneric
{
    interface IGameObject
    {
        /// <summary>
        /// Logic
        /// </summary>
        void Update();
        /// <summary>
        /// Render
        /// </summary>
        void Draw();
    }
}
