using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class CanJumpProblem
    {
        public bool CanJump(int[] nums)
        {
            return CanJump(nums, nums.Length -2, nums.Length -1);

        }

        private bool CanJump(int[] nums, int sourceIndex, int destIndex)
        {
            if (destIndex == 0)
                return true;
            if (sourceIndex < 0)
                return false;

            int requiredJumps = destIndex - sourceIndex;
            if (nums[sourceIndex] >= requiredJumps)
                return CanJump(nums, sourceIndex - 1, sourceIndex);
            else
                return CanJump(nums, sourceIndex - 1, destIndex);
        }
    }
}
