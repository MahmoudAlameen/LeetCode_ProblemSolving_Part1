using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.LinkedList
{
    public class RemoveDuplicatedItems
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;


            // set head 
            head = RemoveDuplicatedHead(head);
            int? needToBeRemoved = null;
            ListNode baseNode = head;
            ListNode indexer = head?.next;

            while (indexer != null)
            {
                if (needToBeRemoved == null)
                {
                    if (indexer.next != null && indexer.val == indexer.next.val)
                    {
                        needToBeRemoved = indexer.val;
                    }
                    else
                        baseNode = indexer;
                    indexer = indexer.next;
                }
                else
                {
                    if (indexer.val != needToBeRemoved)
                    {
                        RemoveAndConcatNodes(baseNode, indexer);
                        needToBeRemoved = null;
                    }
                    else
                        indexer = indexer.next;
                }
            }
            if (needToBeRemoved != null)
                baseNode.next = null;

            return head;
        }
        private void RemoveAndConcatNodes(ListNode node1, ListNode node2)
        {
            node1.next = node2;
        }
        private ListNode RemoveDuplicatedHead(ListNode head)
        {
            if (head == null)
                return head;

            int? val = head?.val;
            if (head.next == null || head.next.val != val)
                return head;
            while (head.next != null && head.next.val == val)
            {
                head = head.next;
            }
            return RemoveDuplicatedHead(head.next);
        }
    }
}
