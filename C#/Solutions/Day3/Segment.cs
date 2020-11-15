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
            if(Beginning.X == End.X && Beginning.Y < End.Y)
            {
                for (int y = Beginning.Y; y <= End.Y; y++)
                {
                    Points.Add(new Point(Beginning.X, y));
                }
            }
            else if (Beginning.X == End.X && Beginning.Y > End.Y)
            {
                for (int y = Beginning.Y; y >= End.Y; y--)
                {
                    Points.Add(new Point(Beginning.X, y));
                }
            }
            else if (Beginning.X < End.X)
            {
                for (int x = Beginning.X; x <= End.X; x++)
                {
                    Points.Add(new Point(x, Beginning.Y));
                }
            }
            else if (Beginning.X > End.X)
            {
                for (int x = Beginning.X; x >= End.X; x--)
                {
                    Points.Add(new Point(x, Beginning.Y));
                }
            }
        }

        public HashSet<Point> Points { get; } = new HashSet<Point>();
        public Point Beginning { get; }
        public Point End { get; }

        public static SegmentsComparer Comparer { get; } = new SegmentsComparer();

    }
}
