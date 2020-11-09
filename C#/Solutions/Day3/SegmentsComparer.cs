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

            return seg1.Points.Intersect(seg2.Points, new PointsComparer()).ToList().Count() > 0 ? true : false;

        }

        public int GetHashCode([DisallowNull] Segment obj)
        {
            return obj.Beginning.X.GetHashCode() ^ obj.Beginning.Y.GetHashCode() 
                ^ obj.End.X.GetHashCode() ^ obj.End.Y.GetHashCode();
        }
    }
}
