using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1
{
    abstract class GameLoop
    {
        protected bool gameEnd = false;
        public const int TARGET_FPS = 60;
        public const float TIME_UNTIL_UPDATE_SEC = 1f / TARGET_FPS;

        public void Run()
        {
            Initialize();
            Stopwatch stopWatch = new Stopwatch();
            float totalTimeBeforeUpdateSec;

            stopWatch.Start();
            while (!gameEnd)
            {
                HandleUserInputs();
                totalTimeBeforeUpdateSec = (float)stopWatch.ElapsedMilliseconds / 1000;
                if (totalTimeBeforeUpdateSec > TIME_UNTIL_UPDATE_SEC)
                {
                    Console.WriteLine(totalTimeBeforeUpdateSec);
                    stopWatch.Restart();
                    Update();
                    Draw();
                }
            }
        }
        public abstract void Initialize();

        public abstract void HandleUserInputs();

        public abstract void Update();

        public abstract void Draw();
    }
}
