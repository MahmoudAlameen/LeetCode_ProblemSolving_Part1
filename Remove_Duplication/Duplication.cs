using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Remove_Duplication
{
    public class Duplication
    {
        public int RemoveDuplicates(int[] nums)
        {
            int incomingPosition = 1;
            int value = nums[0];
            int occurenceCount = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == value && occurenceCount < 2)
                {
                    nums[incomingPosition] = nums[i];
                    occurenceCount++;
                    incomingPosition++;

                }
                if (nums[i] != value)
                {
                    nums[incomingPosition] = nums[i];
                    occurenceCount = 1;
                    incomingPosition++;
                    value = nums[i];
                }
            }
            return incomingPosition;
        }
    }
}
