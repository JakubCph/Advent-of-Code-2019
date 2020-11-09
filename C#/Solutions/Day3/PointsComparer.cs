using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Day3
{
    public class PointsComparer : IEqualityComparer<Point>
    {
        public bool Equals([AllowNull] Point x, [AllowNull] Point y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return (x.X == y.X) && (x.Y == y.Y);
        }

        public int GetHashCode([DisallowNull] Point obj)
        {
            return obj.X.GetHashCode() ^ obj.Y.GetHashCode();
        }
    }
}
