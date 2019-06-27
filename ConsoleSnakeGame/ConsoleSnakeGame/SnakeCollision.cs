using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeGame
{
    public enum SnakeCollision
    {
        Border, // snake head collide with border
        Apple, // snake head collide with body
        Snake // snake head collide with body
    }
}
