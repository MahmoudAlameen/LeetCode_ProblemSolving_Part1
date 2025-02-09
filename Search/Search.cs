using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Search
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


        /*
         * You are given an m x n integer matrix matrix with the following two properties:

Each row is sorted in non-decreasing order.
The first integer of each row is greater than the last integer of the previous row.
Given an integer target, return true if target is in matrix or false otherwise.

You must write a solution in O(log(m * n)) time complexity.
         * **/
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            return BinarySearchTwoDimensional(matrix, target, 0, matrix.Length - 1);

        }

        public static bool BinarySearchTwoDimensional(int[][] matrix, int target, int leftRow, int rightRow)
        {
            if (leftRow > rightRow)
                return false;

            int midRow = (leftRow + rightRow) / 2;

            if (target < matrix[midRow][0])
                return BinarySearchTwoDimensional(matrix, target, leftRow, midRow - 1);
            else if (target > matrix[midRow][matrix[midRow].Length - 1])
                return BinarySearchTwoDimensional(matrix, target, midRow + 1, rightRow);
            else
                return BinarySearchOneDimension(matrix[midRow], target, 0, matrix[midRow].Length - 1);
        }
        public static bool BinarySearchOneDimension(int[] nums, int target, int left, int right)
        {
            if (left > right)
                return false;

            int mid = (left + right) / 2;

            if (nums[mid] == target)
                return true;
            else if (target < nums[mid])
                return BinarySearchOneDimension(nums, target, left, mid - 1);
            else
                return BinarySearchOneDimension(nums, target, mid + 1, right);
        }
    }
 }
