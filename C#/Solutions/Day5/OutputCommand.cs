using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class OutputCommand : IOpCodeCommand
    {
        public int InstructionLength => 2;

        public void Execute(int[] opcode, ref int instructionPointer)
        {
            var address = opcode[instructionPointer + 1];
            Console.WriteLine(opcode[address]);
        }
    }
}
