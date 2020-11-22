using System;

namespace Day4
{
    internal class PasswordCombinator
    {
        const int DIGIT_REPEATED_ONCE = 1;

        /// <summary>
        /// Calculated number of all possible combinations
        /// </summary>
        internal static int CountCombinations(int mIN, int mAX)
        {
            var combinations = 0;
            for (int passPhrase = mIN; passPhrase <= mAX; passPhrase++)
            {
                if (isIncreasing(passPhrase) && hasDouble(passPhrase))
                {
                    combinations++;
                }
            }

            return combinations;
        }

        private static bool hasDouble(int passPhrase)
        {
            var passString = passPhrase.ToString();
            var repeatCounter = 0;
            for (int i = 0; i < passString.Length - 1; i++)
            {
                if(passString[i+1] == passString[i])
                {
                    repeatCounter++;
                }
                else if(repeatCounter == DIGIT_REPEATED_ONCE)
                {
                    return true;
                }
                else// digits different and repeatCounter NOT DIGIT_REPEATED_ONCE
                {
                    repeatCounter = 0;
                }
            }
            return repeatCounter == DIGIT_REPEATED_ONCE;// check if double at the end of passCode
        }

        private static bool isIncreasing(int passPhrase)
        {
            var passString = passPhrase.ToString();
            for (int i = 0; i < passString.Length - 1; i++)
            {
                if (passString[i + 1] < passString[i]) 
                {
                    return false;             
                }
            }

            return true;
        }
    }
}