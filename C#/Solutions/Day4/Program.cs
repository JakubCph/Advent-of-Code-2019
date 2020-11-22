using System;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MIN = 256310;
            const int MAX = 732736;


            var count = PasswordCombinator.CountCombinations(MIN, MAX);

            Console.WriteLine($"Number of all combinations is: {count}.");
        }
    }
}
