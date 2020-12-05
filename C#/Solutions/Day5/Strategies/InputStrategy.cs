using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class InputStrategy : IOpCode
    {
        public int InstructionLength => 2;

        public void Execute(int[] opcode, ref int instructionPointer, (ParameterMode, ParameterMode) modes)
        {
            Console.WriteLine("Input: ");
            var value = int.Parse(Console.ReadLine());
            opcode[opcode[instructionPointer + 1]] = value;

            instructionPointer += InstructionLength;
        }
    }
}
