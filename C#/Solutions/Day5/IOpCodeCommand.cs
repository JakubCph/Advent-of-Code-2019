namespace Day5
{
    public interface IOpCodeCommand
    {
        int InstructionLength { get;}
        void Execute(int[] opcode, ref int instructionPointer);
    }
}