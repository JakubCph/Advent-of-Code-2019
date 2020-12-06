using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day5;

namespace Day7
{
    class Program
    {
        static readonly int AMPLIFIER_NUMBER = 5;
        static readonly int PHASE_SETTING_MIN = 0;
        static readonly int PHASE_SETTING_MAX = 4;

        static void Main(string[] args)
        {
            var opcode = File.ReadAllText("Input.txt").Split(',').Select(s => int.Parse(s)).ToArray();
            //var opcode = ("3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0").Split(',').Select(s => int.Parse(s)).ToArray();

            var maxOutput = AmplifierTester.Test(AMPLIFIER_NUMBER, PHASE_SETTING_MIN, PHASE_SETTING_MAX, opcode);
            Console.Write($"{maxOutput}");
        }

        
    }
}
