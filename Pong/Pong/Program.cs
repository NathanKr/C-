using System;
using System.Threading;

namespace Pong
{
    class Program
    {
        static void Main(string[] args)
        {
            const int nRows = 20, nCols = 40 , nLevel=20 , nGameEnds = 2;
            Game game = new Game(nRows , nCols , nLevel, nGameEnds);
            game.Start();
        }
    }
}
