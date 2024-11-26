using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public static class Permutation2
    {

        public static IList<IList<int>> Result = new List<IList<int>>();
        public static IList<IList<int>> PermuteUniqueUsingBackTrackAlgorithm(int[] nums)
        {
            IList<int> track = new List<int>();
            var numsList = nums.ToList();
            numsList.Sort();
            nums = numsList.ToArray();
            BackTrack(track, nums);
            return Result;
        }
        private static void BackTrack(IList<int> track, int[] choices)
        {
            if (choices.Length == 0)
            {
                Result.Add(track);
            }
            for (int i = 0; i < choices.Length; i++)
            {
                if (i != 0 && choices[i] == choices[i - 1])
                    continue;
                track.Add(choices[i]);
                var nextChoices = BuildChoices(choices, i);
                var separatedTrack = BuildSeparatedTrack(track);
                BackTrack(separatedTrack, nextChoices);

                track.RemoveAt(track.Count - 1);
            }
        }

        private static int[] BuildChoices(int[] nums, int removedIndex)
        {
            int[] choices = new int[nums.Length - 1];
            int c = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == removedIndex)
                    continue;
                choices[c] = nums[i];
                c++;
            }
            return choices;
        }
        private static IList<int> BuildSeparatedTrack(IList<int> track)
        {
            List<int> separatedTrack = new List<int>();
            foreach (var path in track)
            {
                separatedTrack.Add(path);
            }
            return separatedTrack;
        }
    }
}
