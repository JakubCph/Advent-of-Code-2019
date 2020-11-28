namespace Day5
{
    public class LessThanCommand : FourInstructionCommand
    {
        public override void Execute(int[] opcode, ref int instructionPointer)
        {
            base.Execute(opcode, ref instructionPointer);
            opcode[thirdParam] = (firstParam < secondParam) ? 1 : 0;
            instructionPointer += InstructionLength;
        }
    }
}
