using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    
    public class MultiplyCommand : IOpCodeCommand
    {
        public int InstructionLength => 4;
        
        /// <summary>
        /// Executes multiply operations on operands at positions indicated by opcode values
        /// at locations +1 and +2 from current. Write to location at position indicated by opcode at current +3.
        /// </summary>
        public void Execute(int[] opcode, ref int current)
        {
            var a = opcode[opcode[current + 1]];
            var b = opcode[opcode[current + 2]];
            opcode[opcode[current + 3]] = a * b;

            current += InstructionLength;
        }
    }
}
