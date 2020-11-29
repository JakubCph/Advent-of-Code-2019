using System;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var orbitMap = new Tree("COM");
            var lines = File.ReadAllLines("Input.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                var nodePair = lines[i].Split(')');
                foreach (var node in nodePair)
                {
                    orbitMap.CreateNodeIfNotExists(node);
                }
                orbitMap.ConnectNodes(nodePair[0], nodePair[1]);
            }

            Console.WriteLine($"Total orbits: {orbitMap.CalculateTotalOrbits()}.");
        }
    }
}
