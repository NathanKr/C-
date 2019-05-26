using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Point topLeft = new Point(5,5);
            //topLeft.x = 3;
            //topLeft.y = 3;
            TicTacToe game = new TicTacToe(topLeft);
            game.Start();
        }
    }
}
