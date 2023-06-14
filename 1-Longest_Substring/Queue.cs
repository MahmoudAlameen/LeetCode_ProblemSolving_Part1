using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek._1_Longest_Substring
{
    public class CircularQueue
    {
        private int[] arr;
        private int size;
        private int count;
        private int queueStart;
        private int end;
        public CircularQueue(int s)
        {
            size = s;
            count = 0;
            end = -1;
            queueStart = -1;
            arr = new int[size]; 
        }
        public void Push(int value)
        {
            if (count == size)
                return;
            
            end = (end + 1) % size;
            if (queueStart == -1)
                queueStart++;
            arr[end] = value;
            count++;
        }
        public int Pop()
        {
            if (count == 0)
                return -1;
            int result = arr[queueStart];
            queueStart = (queueStart + 1) % size;
            count--;
            return result;
        }
        public int GetQueueCount()
        {
            return count;
        }
        public void PrintQueue()
        {
            if (count == 0)
                Console.WriteLine("Queue is empty");
            for (int i = queueStart , j= 0; j < count; j++)
            {
                Console.WriteLine(arr[i]);
                i = (i + 1) % size; 
            }
        }
        public bool IfExist(int value)
        {
            if (count == 0)
                return false;
            for (int i = queueStart, j = 0; j < count; j++)
            {
                if (arr[i] == value)
                    return true;
                i = (i + 1) % size;
            }
            return false;
        }
    }
}
