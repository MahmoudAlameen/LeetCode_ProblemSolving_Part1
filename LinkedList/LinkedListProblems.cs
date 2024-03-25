using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Remove_Nth_Node_From_End_of_List
{
    public static class LinkedListProblems
    {
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
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

            int targetNodeIndex = nodesCount - n - 1;
            if (targetNodeIndex < 0)
                return null;
            var leftNode = head;
            while (targetNodeIndex > 0)
            {
                targetNodeIndex--;
                leftNode = leftNode.next;
            }
            var rightNode = leftNode.next;
            if (rightNode != null)
                rightNode = rightNode.next;

            leftNode.next = rightNode;
            return head;

        }
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode resultNode = null;
            ListNode result = resultNode;

            while (list1 != null || list2 != null)
            {
                resultNode = resultNode == null ? result = new ListNode() : resultNode.next = new ListNode(); 
                if (list1 == null)
                {
                    resultNode.val = list2.val;
                    list2 = list2.next;
                }
                else if (list2 == null)
                {
                    resultNode.val = list1.val;
                    list1 = list1.next;
                }
                else if (list1.val < list2.val)
                {
                    resultNode.val = list1.val;
                    list1 = list1.next;
                }
                else
                {
                    resultNode.val = list2.val;
                    list2 = list2.next;
                }

            }
            return result;
        }
        public static ListNode SwapPairs(ListNode head)
        {
            ListNode First = head;
            ListNode Second = First?.next;
            ListNode temp;
            ListNode newHead = null;
            ListNode prev = null;
            while (First != null && Second != null)
            {
                temp = Second.next;
                Second.next = First;
                First.next = temp;
                if (prev  != null)
                    prev.next = Second;

                if (newHead == null)
                {
                    newHead = Second;
                }
                prev = First;
                First = First?.next;
                Second = First?.next;
            }
            return newHead == null ? ( head == null ?  null : head ) : newHead;

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

