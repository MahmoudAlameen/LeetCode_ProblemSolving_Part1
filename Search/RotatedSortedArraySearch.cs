using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Search
{
    public class RotatedSortedArraySearch
    {
        public bool Search(int[] nums, int target)
        {
            bool isTargetInBigSet = false;
            if (target == nums[0])
                return true;
            if(target > nums[0])
                isTargetInBigSet = true;

            return BinarySearchForRotatedArr(nums, target, isTargetInBigSet, 0, nums.Length - 1);
        }
        private bool BinarySearchForRotatedArr(int[] nums, int target, bool isTargetInBigSet, int left, int right)
        {
            if (left > right)
            {
                return false;
            }
            int mid = (left + right) + 1 / 2;
            if (nums[mid] == target)
                return true;
            bool isMidInBigSet = nums[mid] > nums[0] ? true : false;

            if (isTargetInBigSet == isMidInBigSet)
            {
                if (target > nums[mid])
                {
                    left = mid + 1;
                }
                else
                    right = mid - 1;
            }
            else
            {
                if (isTargetInBigSet)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return BinarySearchForRotatedArr(nums, target, isTargetInBigSet, left, right);
        }
    }
}
