using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Day3
{
    public class SegmentsComparer : IEqualityComparer<Segment>
    {
        public bool Equals([AllowNull] Segment seg1, [AllowNull] Segment seg2)
        {
            if (Object.ReferenceEquals(seg1, seg2)) return true;

            if (Object.ReferenceEquals(seg1, null) || Object.ReferenceEquals(seg2, null)) 
                return false;

            return seg1.Points.Intersect(seg2.Points, Point.Comparer).ToList().Any() ? true : false;

        }

        public int GetHashCode([DisallowNull] Segment obj)
        {
            return obj.Points.GetHashCode() ^ obj.Points.GetHashCode();
        }
    }
}
