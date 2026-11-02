using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Trees
{
    public class BalancedBinaryTree
    {
        public bool IsBalanced(TreeNode root)
        {

            if (root == null)
                return true;

            int leftDepth = CalcDepth(root.left);
            int rightDepth = CalcDepth(root.right);

            int differ = Math.Max(leftDepth, rightDepth) - Math.Min(rightDepth, leftDepth);


            return differ > 1 ? false : IsBalanced(root.left) && IsBalanced(root.right);
        }

        private int CalcDepth(TreeNode node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(CalcDepth(node.left), CalcDepth(node.right));
        }
    }
}
