using System;
using System.Collections.Generic;

namespace Day5
{
    public class Processor
    {
        private static Dictionary<int, IOpCode> strategies = new Dictionary<int, IOpCode>() 
            {
                {ADD, new AddStrategy() },
                {MULTIPLY, new MultiplyStrategy()},
                {INPUT, new InputStrategy() },
                {OUTPUT, new OutputStrategy() },
                {JUMP_IF_TRUE, new JumpIfTrueStrategy() },
                {JUMP_IF_FALSE, new JumpIfFalseStrategy() },
                {LESS_THAN, new LessThanStrategy() },
                {EQUALS, new EqualsStrategy() }
            };

        private const int STOP = 99;
        private const int ADD = 1;
        private const int MULTIPLY = 2;
        private const int INPUT = 3;
        private const int OUTPUT = 4;
        private const int JUMP_IF_TRUE = 5;
        private const int JUMP_IF_FALSE = 6;
        private const int LESS_THAN = 7;
        private const int EQUALS = 8;

        public static void Process(int[] opcode)
        {
            var context = new Context();
            int instructionCounter = 0;
            while(instructionCounter < opcode.Length && opcode[instructionCounter] != STOP)
            {
                var currentInstruction = DecomposeOpCode(opcode[instructionCounter]);
                switch (currentInstruction.Item2)
                {
                    case ADD:
                        context.setStrategy(strategies[ADD]);
                        break;
                    case MULTIPLY:
                        context.setStrategy(strategies[MULTIPLY]);
                        break;
                    case INPUT:
                        context.setStrategy(strategies[INPUT]);
                        break;
                    case OUTPUT:
                        context.setStrategy(strategies[OUTPUT]);
                        break;
                    case JUMP_IF_TRUE:
                        context.setStrategy(strategies[JUMP_IF_TRUE]);
                        break;
                    case JUMP_IF_FALSE:
                        context.setStrategy(strategies[JUMP_IF_FALSE]);
                        break;
                    case LESS_THAN:
                        context.setStrategy(strategies[LESS_THAN]);
                        break;
                    case EQUALS:
                        context.setStrategy(strategies[EQUALS]);
                        break;
                    default:
                        break;
                }

                context.executeStrategy(opcode, ref instructionCounter, currentInstruction.Item1);
            }
        }

        public static Tuple<(ParameterMode, ParameterMode), int> DecomposeOpCode(int value)
        {
            var valueString = value.ToString("D4");
            var opcode = int.Parse(valueString.Substring(valueString.Length - 2));
            var mode1 = (ParameterMode)int.Parse(valueString.Substring(valueString.Length - 3,1));
            var mode2 = (ParameterMode)int.Parse(valueString.Substring(valueString.Length - 4, 1));
            var parameterModes = ( mode1, mode2 );

            return new Tuple<(ParameterMode,ParameterMode), int>(parameterModes, opcode);
        }
    }
}