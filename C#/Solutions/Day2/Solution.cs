using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Day2
{
    class Solution
    {
        private const string Path = "Input.txt";
        private const int DesiredOutput = 19690720;
        private const int SearchStart = 0;
        private const int SearchStop = 99;
        private const int StartIndex = 0;

        static void Main(string[] args)
        {
            var file = File.ReadAllText(Path);
            var opcode = file.Split(',').Select(s => int.Parse(s)).ToArray();
            var result = searchStartPoint(opcode);
            Console.WriteLine($"Output {DesiredOutput} can be reach with noun {result.noun}" +
                $" and verb {result.verb}. Noun * 100 + verb = {result.noun * 100 + result.verb}");
        }

        private static (int noun, int verb) searchStartPoint(int[] opcode)
        {
            int noun = SearchStart;
            int verb = SearchStart;
            for (noun = SearchStart; noun < SearchStop; noun++)
            {
                for (verb = SearchStart; verb < SearchStop; verb++)
                {
                    var opcodeCopy = new int[opcode.Length];
                    opcode.CopyTo(opcodeCopy, StartIndex);
                    setup(opcodeCopy, verb, noun);
                    var result = Processor.Process(opcodeCopy);
                    var output = result[0];
                    if (output == DesiredOutput)
                    {
                        return (noun, verb);
                    }
                }
            }

            return (-1, -1);
        }

        private static void setup(int[] opcode, int verb, int noun)
        {
            opcode[1] = noun;
            opcode[2] = verb;
        }
    }
}
