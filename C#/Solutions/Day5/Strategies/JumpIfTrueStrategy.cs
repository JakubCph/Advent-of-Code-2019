namespace Day5
{
    public class JumpIfTrueStrategy : ThreeInstructionStrategy
    {
        public override void Execute(int[] opcode, ref int instructionPointer, (ParameterMode, ParameterMode) modes)
        {
            base.Execute(opcode, ref instructionPointer, modes);
            System.Console.Write($"Jump-if-true: {firstParam} != 0({firstParam != 0}). Pointer at {instructionPointer}. ");
            if (firstParam != 0) 
            {
                instructionPointer = secondParam;
            }
            else
            {
                instructionPointer += InstructionLength;
            }
            System.Console.Write($"Pointer moved to {instructionPointer}");
            System.Console.WriteLine();
        }
    }
}
