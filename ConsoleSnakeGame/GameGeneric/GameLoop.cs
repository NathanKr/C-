using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameGeneric
{
    public abstract class GameLoop
    {
        protected bool gameEnd = false;
        public const int TARGET_FPS = 60;
        public const float TIME_UNTIL_UPDATE_SEC = 1f / TARGET_FPS;
        GameTime gameTime = new GameTime();

        public void Run()
        {
            Initialize();
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            while (!gameEnd)
            {
                HandleUserInputs();
                gameTime.ElaspedSienceLastUpdateSec = (float)stopWatch.ElapsedMilliseconds / 1000;
                gameTime.TotalTimeSec += gameTime.ElaspedSienceLastUpdateSec;
                if (gameTime.ElaspedSienceLastUpdateSec > TIME_UNTIL_UPDATE_SEC)
                {
                    stopWatch.Restart();
                    Update(gameTime);
                    Draw();
                }
            }
        }
        public abstract void Initialize();

        public abstract void HandleUserInputs();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw();
    }
}
