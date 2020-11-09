using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Day3
{
    public class Segment
    {
        public Segment(Point beginning, Point end )
        {
            Beginning = beginning;
            End = end;

            fillPoints();
        }

        private void fillPoints()
        {
            if(Beginning.X == End.X)
            {
                for (int y = Beginning.Y; y != End.Y; y += (End.Y-Beginning.Y) > 0 ? 1 : -1)
                {
                    Points.Add(new Point(Beginning.X, y));
                }
            }
            else
            {
                for (int x = Beginning.X; x != End.X; x += (End.X - Beginning.X) > 0 ? 1 : -1)
                {
                    Points.Add(new Point(x, Beginning.Y));
                }
            }
        }

        public HashSet<Point> Points { get; } = new HashSet<Point>();
        public Point Beginning { get; }
        public Point End { get; }

    }
}
