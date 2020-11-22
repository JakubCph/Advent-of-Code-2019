using System;

namespace Day4
{
    internal class PasswordCombinator
    {
        /// <summary>
        /// Calculated number of all possible combinations
        /// </summary>
        internal static int CountCombinations(int mIN, int mAX)
        {
            var combinations = 0;
            for (int passPhrase = mIN; passPhrase <= mAX; passPhrase++)
            {
                if (isIncreasing(passPhrase) && has2AdjacentDigits(passPhrase))
                {
                    combinations++;
                }
            }

            return combinations;
        }

        private static bool has2AdjacentDigits(int passPhrase)
        {
            var passString = passPhrase.ToString();
            for (int i = 0; i < passString.Length - 1; i++)
            {
                if(passString[i+1] == passString[i])
                {
                    return true;
                }
            }
            return false;
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