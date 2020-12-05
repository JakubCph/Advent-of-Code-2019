using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class OutputStrategy : IOpCode
    {
        private readonly Queue<int> queue;

        public int InstructionLength => 2;

        public OutputStrategy(Queue<int> queue)
        {
            this.queue = queue;
        }
        public void Execute(int[] opcode, ref int instructionCounter, (ParameterMode, ParameterMode) modes)
        {
            if(modes.Item1 == ParameterMode.Position)
            {
                var address = opcode[instructionCounter + 1];
                queue.Enqueue(opcode[address]);
            }
            else
            {
                var value = opcode[instructionCounter + 1];
                queue.Enqueue(value);
            }

            instructionCounter += InstructionLength;
        }
    }
}
