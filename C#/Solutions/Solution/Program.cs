using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Solution
{
    class Program
    {
        private const string Path = "Input.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string line;
            int fuel = 0;
            StreamReader file = Reader.OpenStream(Path);

            while ((line = file.ReadLine()) != null)
            {
                if (int.TryParse(line, out var result))
                {
                    fuel += result / 3 - 2;
                }
            }

            Console.WriteLine($"Fuel requirements: {fuel}");
        }

        
    }
}
