using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    enum GameState
    {
        Playing,
        Collision,
        Finish,
        WaitForUserInputPlayAgain,
        End
    }
}
