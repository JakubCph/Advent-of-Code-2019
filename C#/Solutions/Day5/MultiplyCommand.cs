namespace Day5
{

    public class MultiplyCommand : IOpCodeCommand, IParameterMode
    {
        public int InstructionLength => 4;

        public ParameterMode[] Modes { get; set; } = null;

        /// <summary>
        /// Executes multiply operations on operands at positions indicated by opcode values
        /// at locations +1 and +2 from current. Write to location at position indicated by opcode at current +3.
        /// </summary>
        public void Execute(int[] opcode, ref int instructionCounter)
        {
            if(Modes is null)
            {
                return;
            }

            var a = Modes[0] == ParameterMode.Position ? 
                                        opcode[opcode[instructionCounter + 1]] :
                                        opcode[instructionCounter + 1];
            var b = Modes[1] == ParameterMode.Position ? 
                                        opcode[opcode[instructionCounter + 2]] :
                                        opcode[instructionCounter + 2];
            opcode[opcode[instructionCounter + 3]] = a * b;

            instructionCounter += InstructionLength;
        }
    }
}
