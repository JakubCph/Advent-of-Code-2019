namespace Day5
{
    public interface IOpCode
    {
        int InstructionLength { get;}
        void Execute(int[] opcode, ref int instructionPointer, (ParameterMode,ParameterMode) modes);
    }
}