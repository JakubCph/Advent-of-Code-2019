using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class InputStrategy : IOpCode
    {
        private readonly Queue<int> queue;

        public int InstructionLength => 2;

        public InputStrategy(Queue<int> queue)
        {
            this.queue = queue;
        }
        public void Execute(int[] opcode, ref int instructionPointer, (ParameterMode, ParameterMode) modes)
        {
            Console.WriteLine("Input: ");
            var value = queue.Dequeue();
            opcode[opcode[instructionPointer + 1]] = value;

            instructionPointer += InstructionLength;
        }
    }
}
