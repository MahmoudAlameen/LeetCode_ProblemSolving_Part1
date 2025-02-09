using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class SortingColors
    {
        public void SortColors(int[] nums)
        {

            int zeros = 0, ones = 0, twos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    zeros++;
                if (nums[i] == 1)
                    ones++;
                if (nums[i] == 2)
                    twos++;
            }
            int startIndex = 0;
            SetColor(nums, 0, zeros, ref startIndex);
            SetColor(nums, 1, ones, ref startIndex);
            SetColor(nums, 2, twos, ref startIndex);
        }
        private void SetColor(int[] nums, int color, int count, ref int startIndex)
        {
            while (count > 0)
            {
                nums[startIndex] = color;
                count--;
                startIndex++;
            }
            
        }
    }
}
