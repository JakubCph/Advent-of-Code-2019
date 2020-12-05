using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class Context
    {
        private IOpCode strategy;

        public Context()
            : this(null)
        {
        }
        public Context(IOpCode argStrategy)
        {
            strategy = argStrategy;
        }
        public void setStrategy(IOpCode argStrategy)
        {
            strategy = argStrategy;
        }

        public void executeStrategy(int[] opcode, ref int instructionPointer, (ParameterMode,ParameterMode) modes)
        {
            strategy?.Execute(opcode, ref instructionPointer, modes);
        }

    }
}
