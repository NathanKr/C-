using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTicTacToe
{
    class Utils
    {
        public static int ReadIntFromConsole(string message)
        {
            bool bIsValid;
            int value;
            do
            {
                Console.WriteLine(message);
                bIsValid = int.TryParse(Console.ReadLine(), out value);
            } while (!bIsValid);

            return value;
        }

        public static char ReadCharFromConsole(string message)
        {
            bool bIsValid;
            char value;
            do
            {
                Console.WriteLine(message);
                bIsValid = char.TryParse(Console.ReadLine(), out value);
            } while (!bIsValid);

            return value;
        }
    }
}
