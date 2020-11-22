using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class AddCommand : IOpCodeCommand
    {
        public int InstructionLength => 4;

        /// <summary>
        /// Add operation. Modify opcode in place. Gets numbers from locations pointed by the 
        /// opcode value at locations +1 and +2 from current. Writes result at location pointed by 
        /// opcode value at location +3 from current.
        /// </summary>
        public void Execute(int[] opcode, ref int current)
        {
            var a = opcode[opcode[current + 1]];
            var b = opcode[opcode[current + 2]];
            opcode[opcode[current + 3]] = a + b;

            current += InstructionLength;
        }
    }
}
