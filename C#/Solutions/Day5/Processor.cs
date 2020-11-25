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
            int instructionCounter = 0;
            while(instructionCounter < opcode.Length && opcode[instructionCounter] != STOP)
            {
                var parameterModes = new int[2];
                Tuple<ParameterMode[], int> currentInstruction = decomposeOpCode(opcode[instructionCounter]);
                switch (currentInstruction.Item2)
                {
                    case ADD:
                        (AddCmd as AddCommand).Modes = currentInstruction.Item1;
                        execute(AddCmd, opcode, ref instructionCounter);
                        break;
                    case MULTIPLY:
                        (MultiplyCmd as MultiplyCommand).Modes = currentInstruction.Item1;
                        execute(MultiplyCmd, opcode, ref instructionCounter);
                        break;
                    case INPUT:
                        execute(InpCmd, opcode, ref instructionCounter);
                        break;
                    case OUTPUT:
                        (OutCmd as OutputCommand).Modes = currentInstruction.Item1;
                        execute(OutCmd, opcode, ref instructionCounter);
                        break;  
                    default:
                        break;
                }
            }

            return opcode;
        }

        private static Tuple<ParameterMode[], int> decomposeOpCode(int value)
        {
            var valueString = value.ToString("D4");
            var opcode = int.Parse(valueString.Substring(valueString.Length - 2));
            var mode1 = (ParameterMode)int.Parse(valueString.Substring(valueString.Length - 3,1));
            var mode2 = (ParameterMode)int.Parse(valueString.Substring(valueString.Length - 4, 1));
            var parameterModes = new ParameterMode[] { mode1, mode2 };

            return new Tuple<ParameterMode[], int>(parameterModes, opcode);
        }

        private static void execute(IOpCodeCommand command, int[] opcode, ref int instructionPointer)
        {
            command.Execute(opcode, ref instructionPointer);
        }
    }
}