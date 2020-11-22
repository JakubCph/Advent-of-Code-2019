﻿using System;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        private const string Path = "Input.txt";

        static void Main(string[] args)
        {
            var instructions = File.ReadAllText(Path).Split(',').Select(s => int.Parse(s)).ToArray();
            Processor.Process(instructions);
        }
    }
}
