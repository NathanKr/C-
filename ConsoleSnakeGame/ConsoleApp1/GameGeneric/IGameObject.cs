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
        void Update(GameTime gameTime);
        /// <summary>
        /// Render
        /// </summary>
        void Draw();

        /// <summary>
        /// true means that position is changes
        /// false means that position is not changes
        /// </summary>
        bool IsDirty { get; set; }
    }
}
