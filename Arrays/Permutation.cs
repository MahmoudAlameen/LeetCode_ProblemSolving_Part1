using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public static class Permutation
    {
        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<IList<int>>> permutations = new List<IList<IList<int>>>();
            permutations.Add(new List<IList<int>> { new List<int> { nums[0] } });
            IList<IList<int>> lastPermutations = new List<IList<int>>();   
            for (int numsIndex = 1; numsIndex < nums.Length; numsIndex++)
            {
                lastPermutations = permutations[numsIndex - 1];
                IList<IList<int>> newPermutations = new List<IList<int>>();

                for (int lastPermutationsIndex = 0; lastPermutationsIndex < lastPermutations.Count; lastPermutationsIndex++)
                {
                    var indexedPermutation = lastPermutations[lastPermutationsIndex];

                    for (int indexedPermuteNum = 0; indexedPermuteNum < indexedPermutation.Count +1; indexedPermuteNum++)
                    {
                        newPermutations.Add(InsertNum(indexedPermutation, nums[numsIndex], indexedPermuteNum));
                    }
                }
                permutations.Add(newPermutations);
            }
            return permutations[permutations.Count - 1];    
        }

        public static IList<IList<int>> Result = new List<IList<int>>(); 
        public static IList<IList<int>> PermuteUsingBackTrackAlgorithm(int[] nums)
        {
            IList<int> track = new List<int>();
            BackTrack(track, nums);
            return Result;
        }
        private static void BackTrack(IList<int> track, int[] choices)
        {
            if (choices.Length == 0)
            {
                Result.Add(track);
            }
            for(int i = 0; i < choices.Length; i++)
            {
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

        private static List<int> InsertNum(IList<int> list, int num, int index)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(list[i]);
            }
            result.Insert(index, num);
            return result;
        }
    }
}
