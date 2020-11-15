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
            //var lines = File.ReadAllLines("Input.txt");
            var text = @"R2,D1
D1,R2";
            var lines = text.Split('\n');
            var wire1 = new Wire(lines[0].Split(','));
            var wire2 = new Wire(lines[1].Split(','));

            var intersectingSegments = wire1.Segments.Intersect(wire2.Segments, Segment.Comparer).ToList();

            Console.WriteLine($"intersections has {intersectingSegments.Count()} elements.");
        }

    }
}
