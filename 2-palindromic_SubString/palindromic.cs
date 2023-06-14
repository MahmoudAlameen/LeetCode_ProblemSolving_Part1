using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek._2_palindromic_SubString
{
    public  class Palindromic
    {
        public static string LongestPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            int subCount = 1;
            string palindromic;
            for (int i = s.Length - 1; i > 0; i--)
            {
                start = 0;
                end = i;
                subCount = (s.Length - 1) - i + 1;
                while (subCount > 0)
                {
                    palindromic = s.Substring(start, end - start+1);
                    if (ISPalindromic(palindromic))
                    {
                        Console.WriteLine(palindromic);
                        return palindromic;
                    }
                        
                    subCount--;
                    start++;
                    end++;
                }
            }
            Console.WriteLine(s.Substring(0, 1));
            return s.Substring(0, 1);

        }
        private static bool ISPalindromic(string word)
        {
            int subWordLength = word.Length / 2;
            string sub1 = word.Substring(0, subWordLength);
            string sub2 = word.Substring(word.Length  - subWordLength, subWordLength);
            var chars = sub2.ToCharArray();
            Array.Reverse(chars);
            sub2 = new string(chars);
            if (sub1 == sub2)
                return true;
            else
                return false;
        }
        public static string FastLongestPalindrome(string s)
        {
            int len = s.Length;
            bool[,] state = new bool[len,len];
            int start =0, end =0;
            int startIndex = 0, endIndex =0;
            for (int i = 0; i < len; i++)
                state[i, i] = true;
            for (int i = 1; i < len; i++)
            {
                start = -1;
                end = i;
                for (int j = i; j < len; j++)
                {
                    start++;
                    end = j;
                    state[start, end] = (s[start] == s[end] && (end == start + 1 ? true : state[start + 1, end - 1]));
                    if (state[start, end])
                    {
                        startIndex = start;
                        endIndex = end; 
                    }    
                } 
            }
            return s.Substring(startIndex, endIndex - startIndex + 1);
        }

    }
}
