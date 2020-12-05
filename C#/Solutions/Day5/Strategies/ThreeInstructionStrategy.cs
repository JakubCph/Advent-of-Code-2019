using System;

namespace Day5
{
    public abstract class ThreeInstructionStrategy : IOpCode
    {
        public int InstructionLength { get; } = 3;
        protected int firstParam { get; private set; }
        protected int secondParam { get; private set; }

        public virtual void Execute(int[] opcode, ref int instructionPointer, (ParameterMode, ParameterMode) modes)
        {
            firstParam = modes.Item1 == ParameterMode.Immediate ?
                                    opcode[instructionPointer + 1] :
                                    opcode[opcode[instructionPointer + 1]];
            secondParam = modes.Item2 == ParameterMode.Immediate ?
                                    opcode[instructionPointer + 2] :
                                    opcode[opcode[instructionPointer + 2]];

        }
    }
}
