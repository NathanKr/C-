using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class PlayerHuman : Player , ICollide
    {
        public PlayerHuman(char[,] arBoard) : base(arBoard)
        {

        }
    public Collide DoesCollide(int X, int Y)
        {
            return DoesCollideWithBall(X, Y);
        }
    }
}
