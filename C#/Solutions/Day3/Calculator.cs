using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    public static class Calculator
    {
        private static Func<Point, Point, int> formula = (origin, target) => Math.Abs(origin.X - target.X) + Math.Abs(origin.Y - target.Y); 
        public static IEnumerable<(Point point, int distance)> CalculateManhattanDistance(Point origin, IEnumerable<Point> points)
        {
            foreach (var point in points)
            {
                yield return (point ,formula.Invoke(origin,point));
            }

        }
    }

}
