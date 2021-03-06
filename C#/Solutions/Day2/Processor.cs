﻿using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Day2
{
    public class Processor
    {
        private const int Stop = 99;
        private const int Add = 1;
        private const int Multiply = 2;
        private const int Step = 4;

        public static int[] Process(int[] opcode)
        {
            int instructionPointer = 0;
            while(instructionPointer < opcode.Length && opcode[instructionPointer] != Stop)
            {
                if(opcode[instructionPointer] == Add)
                {
                    executeAdd(opcode, instructionPointer);
                }
                if(opcode[instructionPointer] == Multiply)
                {
                    executeMultiply(opcode,instructionPointer);
                }

                instructionPointer += Step;
            }

            return opcode;
        }

        /// <summary>
        /// Execute multiply operations on operands at positions indicated by opcode values
        /// at locations +1 and +2 from current. Write to location at position indicated by opcode at current +3.
        /// </summary>
        private static void executeMultiply(int[] opcode, int current)
        {
            var a = opcode[opcode[current + 1]];
            var b = opcode[opcode[current + 2]];
            opcode[opcode[current + 3]] = a * b;
        }

        /// <summary>
        /// Add operation. Modify opcode in place. Gets numbers from locations pointed by the 
        /// opcode value at locations +1 and +2 from current. Writes result at location pointed by 
        /// opcode value at location +3 from current.
        /// </summary>
        private static void executeAdd(int[] opcode, int current)
        {
            var a = opcode[opcode[current + 1]];
            var b = opcode[opcode[current + 2]];
            opcode[opcode[current + 3]] = a + b;
        }
    }
}