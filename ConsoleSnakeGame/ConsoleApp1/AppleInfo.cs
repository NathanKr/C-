using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class AppleInfo
    {
        public AppleInfo(ColorChar colorHead , Point head)
        {
            ColorHead = colorHead;
            Head = head;
        }
        public ColorChar ColorHead { get; set; }
        public Point Head { get; set; }
    }
}
