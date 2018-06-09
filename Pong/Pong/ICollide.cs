using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    interface ICollide
    {
        Collide DoesCollide(int X, int Y);
    }
}
