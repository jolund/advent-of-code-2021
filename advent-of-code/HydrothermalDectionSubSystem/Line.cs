using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code.HydrothermalDectionSubSystem
{
    public class Line
    {
        public Point Begin { get; private set; }
        public Point End { get; private set; }

        public Line(Point Begin, Point end)
        {
            this.Begin = Begin;
            End = end;
        }

        public Line(int bx, int by, int ex, int ey)
        {
            Begin = new Point(bx, by);
            End = new Point(ex, ey);
        }

        public bool IsReverse()
        {
            int v1 = End.X - Begin.X;
            int v2 = End.Y - Begin.Y;

            return v1 + v2 < 0;
        }

        public bool IsHorizontalOrVerticalLine()
        {
            return End.X - Begin.X == 0 || End.Y - Begin.Y == 0;
        }

        public string ToString()
        {
            return $"{Begin.X},{Begin.Y} -> {End.X},{End.Y}";
        }
    }
}
