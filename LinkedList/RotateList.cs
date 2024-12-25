using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.LinkedList
{
    public class RotateList
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null)
                return head;
            //steps of the solution
            //1- get length of the linked list 
            ListNode lastNode;
            int NodesCount = GetNodesCount(head, out lastNode);

            // 2- get right moves needed by removing circled ones 
            int actualMovesRequired = k % NodesCount;

            // 3- get position and node we wan to cut from it  
            if (actualMovesRequired == 0)
                return head;
            int movementNodePosition = NodesCount - actualMovesRequired;
            ListNode MovementNode = head;
            while (movementNodePosition > 1)
            {
                MovementNode = MovementNode.next;
                movementNodePosition--;
            }

            // 4- apply cutting process 
            lastNode.next = head;
            head = MovementNode.next;
            MovementNode.next = null;
            return head;
        }
        private int GetNodesCount(ListNode head, out ListNode lastNode)
        {
            lastNode = head;
            if (head == null)
            {
                return 0;
            }
               
            int NodesCount = 0;
            ListNode current = head;
            while (current != null)
            {
                lastNode = current;
                current = current.next;
                NodesCount++;
            }
            return NodesCount;
        }
    }
}
