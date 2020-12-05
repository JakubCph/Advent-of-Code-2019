using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class AddStrategy : IOpCode
    {
        public int InstructionLength => 4;

        /// <summary>
        /// Add operation. Modify opcode in place. Gets numbers from locations pointed by the 
        /// opcode value at locations +1 and +2 from current. Writes result at location pointed by 
        /// opcode value at location +3 from current.
        /// </summary>
        public void Execute(int[] opcode, ref int instructionCounter, (ParameterMode, ParameterMode) modes)
        {
            var a = modes.Item1 == ParameterMode.Position ? 
                                        opcode[opcode[instructionCounter + 1]] :
                                        opcode[instructionCounter + 1];
            var b = modes.Item2 == ParameterMode.Position ? 
                                        opcode[opcode[instructionCounter + 2]] :
                                        opcode[instructionCounter + 2];
            opcode[opcode[instructionCounter + 3]] = a + b;

            instructionCounter += InstructionLength;
        }
    }
}
