using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Results
    {
        public int PlayerAutoScore { get; set; }
        public int PlayerHumanScore { get; set; }
        public string ShowCurrent()
        {
            return string.Format("PlayerAuto  {0} : PlayerHuman  {1}", 
                PlayerAutoScore , PlayerHumanScore);
        }
        public string ShowFinal()
        {
            string strFinal;

            if(PlayerAutoScore > PlayerHumanScore)
            {
                strFinal = "Winner is PlayerAuto";
            }
            else if(PlayerHumanScore < PlayerAutoScore)
            {
                strFinal = "Winner is PlayerAuman";
            }
            else
            {
                strFinal = "Game is draw";
            }
            return strFinal;
        }
    }
}
