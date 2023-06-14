using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek._1_Longest_Substring
{
    public static class LongestSubString
    {
        public static int[] FillInLettersNumbers(string word)
        {
            int[] arr = new int[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                arr[i] = (int)word[i];
            }
            return arr;
        }
        public static int LengthOfLongestSubstring(string s)
        {
            int longestSize = 1;
            int[] arr = FillInLettersNumbers(s);
            if (arr.Length == 0)
                return 0;
            CircularQueue queue = new CircularQueue(arr.Length);
            queue.Push(arr[0]);
            longestSize = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (!queue.IfExist(arr[i]))
                {
                    queue.Push(arr[i]);
                    continue;
                }
                if (queue.GetQueueCount() > longestSize)
                    longestSize = queue.GetQueueCount();
                int removed = queue.Pop();
                while (removed != arr[i])
                    removed = queue.Pop();
                queue.Push(arr[i]);

            }
            if(queue.GetQueueCount() > longestSize)
                    longestSize = queue.GetQueueCount();
            Console.WriteLine(longestSize);

            return longestSize;

        }
    }
}
