using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public static class Arrays
    {
        public static int RemoveDuplicates(int[] nums)
        {
            int lastUniqueIndex = 0;
            int positionToBeSet = 0;
            int jchecked = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                positionToBeSet = i;

                for (int j = jchecked; j < nums.Length; j++)
                {
                    if (nums[j] > nums[lastUniqueIndex])
                    {
                        Swap(nums, j, positionToBeSet);
                        lastUniqueIndex = i;
                        jchecked = j;
                        break;
                    }
                    if (j == nums.Length - 1)
                        return lastUniqueIndex + 1;
                }
            }
            return lastUniqueIndex + 1;
        }
        private static void Swap(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int lastValid = nums.Length - 1;
            int k = 0;
            for (int i = 0; i <= lastValid; i++)
            {
                if (nums[i] == val)
                {
                    Swap(nums, i, lastValid);
                    lastValid--;
                    i--;
                }
                else
                    k++;
            }
            return k;

        }
        public static int IndexOfTheFirstOccurence(string haystack, string needle)
        {
            int needleIndex = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[needleIndex] && needleIndex == needle.Length - 1)
                {
                    return i - needleIndex;
                }
                if (haystack[i] == needle[needleIndex])
                {
                    needleIndex++;
                }
                else if (haystack[i] != needle[needleIndex] && needleIndex > 0)
                {
                    i = i - needleIndex;
                    needleIndex = 0;
                }


            }
            return -1;
        }
        public static int Search(int[] nums, int target)
        {
            return SearchInRotatedArray(nums, target, 0, nums.Length - 1);
        }

        private static int SearchInRotatedArray(int[] nums, int target, int left, int right)
        {
            if (left > right)
                return -1;
            var isTargetExistsInTheLeft = IsExistsInTheLeft(nums, target);
            var mid = (left + right + 1) / 2;
            if (target == nums[mid])
                return mid;
            if (isTargetExistsInTheLeft)
            {
                if (nums[mid] > target)
                {
                    return SearchInRotatedArray(nums, target, left, mid - 1);
                }
                else
                {
                    if (IsExistsInTheLeft(nums, nums[mid]))
                    {
                        return SearchInRotatedArray(nums, target, mid + 1, right);
                    }
                    else
                    {
                        return SearchInRotatedArray(nums, target, left, mid - 1);
                    }
                }
            }
            else
            {
                if (nums[mid] < target)
                {
                    return SearchInRotatedArray(nums, target, mid + 1, right);
                }
                else
                {
                    if (IsExistsInTheLeft(nums, nums[mid]))
                    {
                        return SearchInRotatedArray(nums, target, mid + 1, right);
                    }
                    else
                    {
                        return SearchInRotatedArray(nums, target, left, mid - 1);
                    }
                }
            }
            return -1;
        }
        private static bool IsExistsInTheLeft(int[] nums, int value)
        {
            return value < nums[0] ? false : true;
        }
    }
}
