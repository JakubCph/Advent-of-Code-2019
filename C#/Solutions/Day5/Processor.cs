using System;

namespace Day5
{
    public class Processor
    {
        private const int STOP = 99;
        private const int ADD = 1;
        private const int MULTIPLY = 2;
        private const int INPUT = 3;
        private const int OUTPUT = 4;
        private const int JUMP_IF_TRUE = 5;
        private const int JUMP_IF_FALSE = 6;
        private const int LESS_THAN = 7;
        private const int EQUALS = 8;


        private static readonly IOpCodeCommand MultiplyCmd = new MultiplyCommand();
        private static readonly IOpCodeCommand AddCmd = new AddCommand();
        private static readonly IOpCodeCommand InpCmd = new InputCommand();
        private static readonly IOpCodeCommand OutCmd = new OutputCommand();
        private static readonly IOpCodeCommand JumpIfTrueCmd = new JumpIfTrueCommand();
        private static readonly IOpCodeCommand JumpIfFalseCmd = new JumpIfFalseCommand();
        private static readonly IOpCodeCommand LessThanCmd = new LessThanCommand();
        private static readonly IOpCodeCommand EqualsCmd = new EqualsCommand();

        public static void Process(int[] opcode)
        {
            int instructionCounter = 0;
            while(instructionCounter < opcode.Length && opcode[instructionCounter] != STOP)
            {
                Tuple<ParameterMode[], int> currentInstruction = DecomposeOpCode(opcode[instructionCounter]);
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
                    case JUMP_IF_TRUE:
                        (JumpIfTrueCmd as JumpIfTrueCommand).Modes = currentInstruction.Item1;
                        execute(JumpIfTrueCmd, opcode, ref instructionCounter);
                        break;
                    case JUMP_IF_FALSE:
                        (JumpIfFalseCmd as JumpIfFalseCommand).Modes = currentInstruction.Item1;
                        execute(JumpIfFalseCmd, opcode, ref instructionCounter);
                        break;
                    case LESS_THAN:
                        (LessThanCmd as LessThanCommand).Modes = currentInstruction.Item1;
                        execute(LessThanCmd, opcode, ref instructionCounter);
                        break;
                    case EQUALS:
                        (EqualsCmd as EqualsCommand).Modes = currentInstruction.Item1;
                        execute(EqualsCmd, opcode, ref instructionCounter);
                        break;
                    default:
                        break;
                }
            }
        }

        public static Tuple<ParameterMode[], int> DecomposeOpCode(int value)
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