using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTicTacToe
{
    class Player
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public void ReadFromConsole()
        {
            Console.WriteLine("Please insert player name");
            Name = Console.ReadLine();

            //done->todo handle wrong input , use do while and TryParse
            //Age = int.Parse(Console.ReadLine());
            Age = Utils.ReadIntFromConsole("Please insert age (integer)");
        }
    }
}
