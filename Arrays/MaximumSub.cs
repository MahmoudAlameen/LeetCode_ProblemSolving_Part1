using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class MaximumSub
    {
        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = 0;
            List<int> subSums = new List<int>();

            for (int index = 1; index < nums.Length; index++)
            {
                if(subSums.Count > 1)
                    subSums.RemoveRange(0, index-2);
                maxSum = nums[index] > maxSum ? nums[index] : maxSum;
                for (int i = subSums.Count -1; i >=0; i--)
                {
                    currentSum = subSums[i] + nums[index];
                    maxSum = currentSum > maxSum ? currentSum : maxSum;
                    subSums.Add(currentSum);
                }
                currentSum = nums[index] + nums[index - 1];
                maxSum = currentSum > maxSum ? currentSum : maxSum;
                subSums.Add(currentSum);
            }
            return maxSum;
        }

        public int MaxSubArrayMoreSumpleCode(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    currentSum += nums[i];
                    maxSum = System.Math.Max(maxSum, currentSum);
                }
            }
            return maxSum;
        }
        public int MaxSubArrayKadenAlgorithm(int[] nums)
        {
            int maxEnding = nums[0];
            int maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                maxEnding = System.Math.Max(maxEnding + nums[i], nums[i]);
                maxSum = System.Math.Max(maxSum, maxEnding);
            }
            return maxSum;
        }

    }
}
