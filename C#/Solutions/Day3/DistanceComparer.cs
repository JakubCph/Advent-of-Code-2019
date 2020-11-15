using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Day3
{
    public class DistanceComparer : Comparer<(Point point, int distance)>
    {
        public override int Compare((Point point, int distance) x, (Point point, int distance) y)
        {
            return x.distance.CompareTo(y.distance);
        }
    }
}
