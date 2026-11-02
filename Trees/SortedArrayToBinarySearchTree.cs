using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Trees
{
    public class SortedArrayToBinarySearchTree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return GenerateBinarySearchTree(nums, 0, nums.Length - 1);
        }

        private TreeNode GenerateBinarySearchTree(int[] nums, int left, int right)
        {
            if (left > right)
                return null;

            int mid = left + (right - left) / 2;

            TreeNode node = new TreeNode(nums[mid]);
            node.left = GenerateBinarySearchTree(nums, left, mid - 1);
            node.right = GenerateBinarySearchTree(nums, mid + 1, right);
            return node;
        } 
    }
}
