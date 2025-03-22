using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Trees
{
    public class Traversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            return TraverseInorder(root);
        }
        public IList<int> TraverseInorder(TreeNode node)
        {
            List<int> result = new List<int>();
            if (node == null)
                return result;

            var  leftList = TraverseInorder(node.left);
            var rightList = TraverseInorder(node.right);

            result.AddRange(leftList);
            result.Add(node.val);
            result.AddRange(rightList);
            return result;
        }
    }
}
