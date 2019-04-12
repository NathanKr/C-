using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBullsAndCows
{
    enum GuessStatus
    {
        Ok,
        Wrong_Number_Of_Letters,
        Only_Lowercase_Letters_Allowed,
        Letter_Is_Not_Unique
    };
}
