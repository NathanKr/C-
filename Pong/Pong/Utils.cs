using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Utils
    {
        public static int GetRows(char [,] array)
        {
            return array.GetLength(0);
        }

        public static int GetCols(char[,] array)
        {
            return array.GetLength(1);
        }

        
    }
}
