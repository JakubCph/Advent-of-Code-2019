using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Day3
{
    /// <summary>
    /// Compares only the Points.
    /// </summary>
    public class PointDistanceComparer : IEqualityComparer<Tuple<Point, int>>
    {
        public bool Equals([AllowNull] Tuple<Point, int> x, [AllowNull] Tuple<Point, int> y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return (x.Item1.X == y.Item1.X) && (x.Item1.Y == y.Item1.Y);

        }

        public int GetHashCode([DisallowNull] Tuple<Point, int> obj)
        {
            return 242483945 * obj.Item1.X.GetHashCode() ^ 347384738 * obj.Item1.Y.GetHashCode();
        }
    }
}
