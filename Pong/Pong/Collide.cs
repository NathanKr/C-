using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    enum Collide
    {
        none,
        border_left,
        border_right,
        border_top_or_bottom,
        player_top,
        player_bottom,
        player_middle
    }
}
