using System;

namespace Day5
{
    public abstract class ThreeInstructionCommand : IOpCodeCommand, IParameterMode
    {
        public int InstructionLength { get; } = 3;

        public ParameterMode[] Modes { get; set; } = null;
        protected int firstParam { get; private set; }
        protected int secondParam { get; private set; }

        public virtual void Execute(int[] opcode, ref int instructionPointer)
        {
            if (Modes is null)
                throw new NotImplementedException();

            firstParam = Modes[0] == ParameterMode.Immediate ?
                                    opcode[instructionPointer + 1] :
                                    opcode[opcode[instructionPointer + 1]];
            secondParam = Modes[1] == ParameterMode.Immediate ?
                                    opcode[instructionPointer + 2] :
                                    opcode[opcode[instructionPointer + 2]];

        }
    }
}
