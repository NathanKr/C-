using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class PlayerAuto : Player, ICollide
    {
        public PlayerAuto(char[,] arBoard) : base(arBoard)
        {

        }

        public Collide DoesCollide(int X, int Y)
        {
            return DoesCollideWithBall(X, Y);
        }
    }
}
