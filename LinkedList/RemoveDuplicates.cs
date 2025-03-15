using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.LinkedList
{
    public class RemoveDuplicates
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode current = head;

            ListNode Prev = head;
            int? value = null;

            while(current != null)
            {
                if (current.val == value)
                {
                    Prev.next = current.next;
                }
                else
                {
                    value = current.val;
                    Prev = current;
                }
                current = current.next;
            }
            return head;
        }
    }
}
