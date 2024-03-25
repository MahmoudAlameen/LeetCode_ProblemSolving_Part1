using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek
{
    public static class Search
    {
        public static int SearchInsert(int[] nums, int target)
        {
            return BinarySearch(nums, target, 0, nums.Length - 1);

        }
        private static int BinarySearch(int[] nums, int target, int left, int right)
        {
            if (left >= right)
            {
                if (nums[left] == target)
                    return left;
                else if (target < nums[left])
                    return left;
                else
                    return left + 1;
            }
            int mid = (left + right) / 2;
            if (nums[mid] == target)
                return mid;
            if (nums[mid] > target)
                return BinarySearch(nums, target, left, mid - 1);
            else
                return BinarySearch(nums, target, mid + 1, right);

        }
    }
}
