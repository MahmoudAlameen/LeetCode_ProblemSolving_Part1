using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Remove_Nth_Node_From_End_of_List
{
    public class RemovenNodeFromEnd
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int nodesCount = 1;
            ListNode listNode = head;
            // get nodes count
            while (true)
            {
                if (listNode.next == null)
                    break;
                nodesCount++;
                listNode = listNode.next;   
            }
            if (nodesCount == n)
                return head.next;

            int targetNodeIndex = nodesCount - n-1;
            if (targetNodeIndex < 0)
                return null;
            var leftNode = head;
            while (targetNodeIndex > 0)
            {
                targetNodeIndex--;
                leftNode = leftNode.next;             
            }
            var rightNode = leftNode.next;
            if( rightNode != null)
                rightNode = rightNode.next;

            leftNode.next = rightNode;
            return head;

        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
