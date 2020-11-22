using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Day5
{
    public class Processor
    {
        private const int STOP = 99;
        private const int ADD = 1;
        private const int MULTIPLY = 2;
        private const int INPUT = 3;
        private const int OUTPUT = 4;

        private static readonly IOpCodeCommand MultiplyCmd = new MultiplyCommand();
        private static readonly IOpCodeCommand AddCmd = new AddCommand();
        private static readonly IOpCodeCommand InpCmd = new InputCommand();
        private static readonly IOpCodeCommand OutCmd = new OutputCommand();

        public static int[] Process(int[] opcode)
        {
            int instructionPointer = 0;
            while(instructionPointer < opcode.Length && opcode[instructionPointer] != STOP)
            {
                switch (opcode[instructionPointer])
                {
                    case ADD:
                        execute(AddCmd, opcode, ref instructionPointer);
                        break;
                    case MULTIPLY:
                        execute(MultiplyCmd, opcode, ref instructionPointer);
                        break;
                    case INPUT:
                        execute(InpCmd, opcode, ref instructionPointer);
                        break;
                    case OUTPUT:
                        execute(OutCmd, opcode, ref instructionPointer);
                        break;  
                    default:
                        break;
                }
            }

            return opcode;
        }
        private static void execute(IOpCodeCommand command, int[] opcode, ref int instructionPointer)
        {
            command.Execute(opcode, ref instructionPointer);
        }
    }
}