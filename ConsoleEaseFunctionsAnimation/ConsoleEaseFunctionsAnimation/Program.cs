using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleEaseFunctionsAnimation
{
    class Program
    {
        const int FPS = 60;
        static void Main(string[] args)
        {
            const int xStart = 5;
            int durationMs = 8000, dx = 80 , x;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.ForegroundColor = ConsoleColor.Red;
            long totalMs = 0;
            Console.Title = "BounceEaseOut animation by Nathan Krasney 2019";

            while (true)
            {
                if (stopWatch.ElapsedMilliseconds / 1000f > 1f / FPS)
                {
                    totalMs += stopWatch.ElapsedMilliseconds;

                    if (totalMs < durationMs)
                    {
                        x = (int)EaseFunctions.BounceEaseOut(totalMs, xStart, dx, durationMs);
                        Console.SetWindowSize(x, 30);
                    }

                    stopWatch.Restart();
                }
            }
        }
    }
}

