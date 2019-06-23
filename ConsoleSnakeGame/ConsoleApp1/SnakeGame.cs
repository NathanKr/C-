using ConsoleApp1.GameGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SnakeGame : GameLoop
    {
        public SnakeGame()
        {
            lisGameObjects = new List<IGameObject>();
        }

        public override void Draw()
        {
            foreach (IGameObject gameObject in lisGameObjects)
            {
                gameObject.Draw();
            }
        }

        public override void HandleUserInputs()
        {
            
        }

        public override void Initialize()
        {
            
        }

        public override void Update()
        {
            foreach (IGameObject gameObject in lisGameObjects)
            {
                gameObject.Update();
            }
        }

        List<IGameObject> lisGameObjects;
    }
}
