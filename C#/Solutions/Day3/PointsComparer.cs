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

        /// <summary>
        /// We use weighted hashcode to differentiate between (-1,0) and (0,-1). 
        /// </summary>
        public int GetHashCode([DisallowNull] Point obj)
        {
            return 242483945 * obj.X.GetHashCode() ^ 347384738 * obj.Y.GetHashCode();
        }
    }
}
