using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    class Comparer :IEqualityComparer<Tuple<int,int>>
    {
            public bool Equals(Tuple<int, int> x, Tuple<int, int> y)
            {
                if (Object.ReferenceEquals(x, y)) return true;

                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                return (x.Item1 == y.Item1);

            }

            public int GetHashCode(Tuple<int, int> obj)
            {
                return obj.Item1.GetHashCode();
            }
    }

}
