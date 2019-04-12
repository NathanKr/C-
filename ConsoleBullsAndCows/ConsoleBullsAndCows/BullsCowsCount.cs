using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBullsAndCows
{
    class BullsCowsCount
    {
        public BullsCowsCount(int bulls,int cows)
        {
            this.bulls = bulls;
            this.cows = cows;
        }

        public int GetBulls()
        {
            return bulls;
        }

        public int GetCows()
        {
            return cows;
        }

        int bulls;
        int cows;
    }
}
