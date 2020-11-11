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
//            var text = @"R75,D30
//D30,R75";
//            var lines = text.Split('\n');
            var wire1 = new Wire(lines[0].Split(','));
            var wire2 = new Wire(lines[1].Split(','));

            var intersections = wire1.Segments.Intersect(wire2.Segments, Segment.Comparer).ToList();

            foreach (var item in intersections)
            {
                Console.WriteLine(item.Beginning.X);
            }

            Console.WriteLine($"intersections has {intersections.Count()} elements.");
        }

    }
}
