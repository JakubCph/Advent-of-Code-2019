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

        /// <summary>
        /// Return always constant hashcode for any segment passed because at this
        /// point we don't know if segments are equal. We need to compare their points.
        /// To force the intersect method to check all combinations we return teh same hashcode.
        /// </summary>
        public int GetHashCode([DisallowNull] Segment obj)
        {
            return base.GetHashCode();

        }
    }
}
