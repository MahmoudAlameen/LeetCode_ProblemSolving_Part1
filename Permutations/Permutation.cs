using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Permutations
{
    public static class Permutation
    {
        public static void NextPermutation(int[] nums)
        {
            for(int right = nums.Length - 1; right > 0; right--) 
            {
                if (nums[right] > nums[right - 1])
                {
                    var SmallestGreaterThanPivotIndex = getSmallestGreaterThanPivot(nums, nums[right - 1], right);
                    Swap(nums, SmallestGreaterThanPivotIndex, right-1);
                    QuickSort(nums, right, nums.Length - 1);
                    return;
                }
            }
            QuickSort(nums, 0, nums.Length - 1);
            return;

        }
        public static int getSmallestGreaterThanPivot(int[] nums, int pivot, int right)
        {
            int indexOfSmallestGeaterThanPivot = right;
            for (int i = right; i <= nums.Length - 1; i++)
            {
                if (nums[i] < nums[indexOfSmallestGeaterThanPivot] && nums[i] > pivot)
                    indexOfSmallestGeaterThanPivot = i;
            }
            return indexOfSmallestGeaterThanPivot;  
        }
        private static void Swap(int[] nums, int index1, int index2)
        {
            if (index1 > nums.Length - 1 || index2 > nums.Length  - 1)
                return;
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
        private static int Portion(int[] arr, int left, int right)
        {
            int i = left - 1;
            int pivot = arr[right];
            for(int j= left; j<= right-1; j++) 
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, right, i + 1);
            return i + 1;
        }
        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left > right)
                return;
            int pi = Portion(arr, left , right);
            QuickSort(arr, left, pi-1);
            QuickSort(arr, pi + 1, right);
            
        }
    }
}
