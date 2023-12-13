using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek._3SumsClosest
{
    public static class SumClosest
    {
        public static  int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int closestSum = nums[0] + nums[1] + nums[nums.Length - 1];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (closestSum == target)
                    return closestSum;

                var entireTarget = target - nums[i];// Subtract(target, nums[i]);
                var entireClosestSum = nums[i + 1] + nums[nums.Length - 1];
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    var entireSum = nums[left] + nums[right];
                    if (Subtract(entireTarget, entireSum) < Subtract(entireTarget, entireClosestSum))
                    {
                        entireClosestSum = entireSum;
                    }
                    if (entireSum == entireTarget)
                        break;
                    if (entireSum > entireTarget)
                        right--;
                    if (entireSum < entireTarget)
                        left++;

                }
                var tempSum = nums[i] + entireClosestSum;
                if(Subtract(target , tempSum) < Subtract(target, closestSum))
                    closestSum = tempSum;
            }
            return closestSum;

        }
        public static int Subtract(int x, int y)
        {
            if (x > y)
                return x - y;
            else
                return y - x;
        }
    }
}
