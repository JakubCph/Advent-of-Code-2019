namespace Day5
{
    public class EqualsStrategy : FourInstructionStrategy
    {
        public override void Execute(int[] opcode, ref int instructionPointer, (ParameterMode, ParameterMode) modes)
        {
            base.Execute(opcode, ref instructionPointer, modes);

            opcode[thirdParam] = (firstParam == secondParam) ? 1 : 0;
            instructionPointer += InstructionLength;
        }
    }
}
