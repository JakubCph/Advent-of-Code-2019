using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class OutputCommand : IOpCodeCommand
    {
        public int InstructionLength => 2;
        public ParameterMode[] Modes { get; set; } = null;

        public void Execute(int[] opcode, ref int instructionCounter)
        {
            if (Modes is null)
            {
                return;
            }

            if(Modes[0] == ParameterMode.Position)
            {
                var address = opcode[instructionCounter + 1];
                Console.WriteLine(opcode[address]);
            }
            else
            {
                var value = opcode[instructionCounter + 1];
                Console.WriteLine(value);
            }

            instructionCounter += InstructionLength;
        }
    }
}
