using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class OutputStrategy : IOpCode
    {
        public int InstructionLength => 2;
       
        public void Execute(int[] opcode, ref int instructionCounter, (ParameterMode, ParameterMode) modes)
        {
            if(modes.Item1 == ParameterMode.Position)
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
