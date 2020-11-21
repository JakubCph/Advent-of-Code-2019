using System;
using System.Collections.Generic;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashset = new HashSet<Tuple<int,int>>(new Prototype.Comparer());

            for (int i = 0; i < 10; i++)
            {
                hashset.Add(new Tuple<int, int>(0,i));
            }
            foreach (var item in hashset)
            {
                Console.WriteLine($"{item.Item1}:{item.Item2}");

            }
        }
    }
}
