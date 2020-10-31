using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Solution
    {
        private const string Path = "Input.txt";

        static void Main(string[] args)
        {
            var file = File.ReadAllText(Path);
            var opcode = file.Split(',').Select(s => int.Parse(s)).ToArray();

            setup(opcode);

            var result = Processor.Process(opcode);

            Console.WriteLine($"Value at [0]: {opcode[0]}");
        }

        private static void setup(int[] opcode)
        {
            opcode[1] = 12;
            opcode[2] = 2;
        }
    }
}
