﻿namespace Day5
{
    public class JumpIfTrueCommand : ThreeInstructionCommand
    {
        public override void Execute(int[] opcode, ref int instructionPointer)
        {
            base.Execute(opcode, ref instructionPointer);
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
