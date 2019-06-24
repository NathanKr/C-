using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BoardInfo
    {
        public BoardInfo(Point boardTopLeft, Point boardBottomRight , char cBorder)
        {
            this.boardBottomRight = boardBottomRight;
            this.boardTopLeft = boardTopLeft;
            this.cBorder = cBorder;
        }

        public Point boardTopLeft { get; set; }
        public char cBorder { get; set; }
        public Point boardBottomRight { get; set; }
    }
}
