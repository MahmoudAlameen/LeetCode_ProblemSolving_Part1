using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.CountAndSay
{
    public static class CountAndSayAlgorithm
    {
        public static string CountAndSayRun(int n)
        {
            if (n == 1)
                return "1";

            return RunLengthEncoding(CountAndSayRun(n - 1));
        }
        public static string RunLengthEncoding(string word)
        {
            int counter = 0;
            char letter = word[0];
            string RLEResult = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != letter)
                {
                    RLEResult += counter.ToString() + letter;
                    counter = 1;
                    letter = word[i];
                }
                else
                {
                    counter++;
                }
            }
            RLEResult += counter.ToString() + letter;
            return RLEResult;
        }
    }
}
