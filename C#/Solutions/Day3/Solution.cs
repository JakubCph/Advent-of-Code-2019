using System;
using System.IO;
using System.Linq;

namespace Day3
{
    class Solution
    {
        private const int Wire1Identifier = 1;
        private const int Wire2Identifier = 2;

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Input.txt");
            var wire1 = new Wire(lines[0].Split(','));
            var wire2 = new Wire(lines[1].Split(','));

            var intersectingPoints = wire1.Points.Intersect(wire2.Points, Point.Comparer).ToList();

            Func<Point, Point, int> manhattanDistanceFormula = (origin, target) => Math.Abs(origin.X - target.X) + Math.Abs(origin.Y - target.Y);
            var pointsWithDistances = Calculator.Calculate(manhattanDistanceFormula, new Point(0,0) ,intersectingPoints).ToList();
            pointsWithDistances.Sort(new DistanceComparer());
            var closestHit = pointsWithDistances?.First();

            if(closestHit.HasValue)
            {
                Console.WriteLine($"Minimum Manhattan distance for point: (x={closestHit.Value.point.X}, y={closestHit.Value.point.Y})");
                Console.WriteLine($"Distance is {closestHit.Value.distance}");

            }
            Console.WriteLine($"intersections has {intersectingPoints.Count()} elements.");
        }

    }
}
