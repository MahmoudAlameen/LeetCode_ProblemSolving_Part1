using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.LinkedList
{
    public class PartitionList
    {
        public ListNode Partition(ListNode head, int x)
        {
            ListNode small = null, big = null, current, smallCurrent = null, bigCurrent = null;
            current = head;

            while (current != null)
            {
                if (current.val < x)
                {
                    if (small == null)
                    {
                        small = new ListNode(current.val);
                        smallCurrent = small;
                    }
                    else
                    {
                        smallCurrent.next = new ListNode(current.val);
                        smallCurrent = smallCurrent.next;
                    }
                }
                else
                {
                    if (big == null)
                    {
                        big = new ListNode(current.val);
                        bigCurrent = big;
                    }
                    else
                    {
                        bigCurrent.next = new ListNode(current.val);
                        bigCurrent = bigCurrent.next;
                    }
                }
                current = current.next;
            }
            if (big == null || small == null)
                return head;

            smallCurrent.next = big;
            return small;
        }
    }
}
