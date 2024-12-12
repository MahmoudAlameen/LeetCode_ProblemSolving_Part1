using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek._4Sum
{
    public class FourSums
    {
        IList<IList<int>> result = new List<IList<int>>();


        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var numsList = nums.ToList();
            numsList.Sort();
            nums =  numsList.ToArray();
            BackTrack(nums, new List<int>(), target);
            return result;  
        }
        private void BackTrack(int[] nums, List<int> track, int target)
        {
            if (track.Count == 4)
            {
                var sum = track.Sum();
                if (sum == target)
                    result.Add(track);
                return;
            }
            if (nums.Length == 0)
                return;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                track.Add(nums[i]);
                BackTrack(nums.Skip(i + 1).ToArray(), CreateNewTrack(track), target);
                track.RemoveAt(track.Count -1);
            }
        }
        private List<int> CreateNewTrack(List<int> track)
        {
            List<int> newTrack = new List<int>();
            foreach (var item in track)
                newTrack.Add(item); 
            return newTrack;
        }

    }
}
