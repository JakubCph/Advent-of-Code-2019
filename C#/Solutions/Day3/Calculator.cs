using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    public static class Calculator
    {
        public static IEnumerable<(Point point, int distance)> Calculate(Func<Point, Point, int> formula, Point origin, IEnumerable<Point> points)
        {
            foreach (var point in points)
            {
                yield return (point ,formula.Invoke(origin,point));
            }

        }
    }

}
