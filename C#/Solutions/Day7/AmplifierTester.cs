using System;
using System.Collections.Generic;
using Day5;

namespace Day7
{
    internal class AmplifierTester
    {
        internal static ThrusterConfiguration Test(int argAmpNumber, int argPhaseMin, int argPhaseMax, int[] argOpcode)
        {

            var phaseSettingValues = fillPhaseSettings(argPhaseMin, argPhaseMax);

            var combinations = calculateCombinations(phaseSettingValues);

            var resultOutput = new ThrusterConfiguration();
            foreach (var phaseSettings in combinations)
            {
                var ampOutput = 0;
                for (int i = 0; i < argAmpNumber; i++)
                {
                    var opcodeCopy = copyArray(argOpcode);
                    ampOutput = Processor.Process(opcodeCopy, phaseSettings[i], ampOutput);
                }
                if(ampOutput > resultOutput.MaxThrusterSignal)
                {
                    resultOutput.MaxThrusterSignal = ampOutput;
                    resultOutput.MaxPhaseSettings = new List<int>(phaseSettings);
                }
            }
            return resultOutput;
        }

        private static int[] copyArray(int[] sourceArray)
        {
            int[] destinationArray = new int[sourceArray.Length];
            Array.Copy(sourceArray, destinationArray, sourceArray.Length);
            return destinationArray;
        }

        /// <summary>
        /// N! (N factorial) combinations of a given set of values.
        /// </summary>
        private static List<List<int>> calculateCombinations(List<int> set)
        {
            //base case 1
            if (set.Count == 1)
            {
                return new List<List<int>>()
                {
                    {
                        new List<int>(){set[0]}
                    }
                };
            }

            //base case 2
            if (set.Count == 2)
            {
                return new List<List<int>>()
                {
                    new List<int>(){set[0], set[1] },
                    new List<int>(){set[1], set[0] }
                };
            }

            List<List<int>> combinations = new List<List<int>>();
            // choose one number to include in combination
            for (int i = 0; i < set.Count; i++)
            {
                var copySet = new List<int>(set);
                copySet.RemoveAt(i);
                var combinationSubset = new List<List<int>>(calculateCombinations(copySet));
                foreach (var subset in combinationSubset)
                {
                    subset.Insert(0, set[i]);
                }
                combinations.AddRange(combinationSubset);
            }
            return combinations;
        }

        private static List<int> fillPhaseSettings(int min, int max)
        {
            var phaseSettings = new List<int>();
            for (int i = min; i <= max; i++)
            {
                phaseSettings.Add(i);
            }
            return phaseSettings;
        }

    }
}