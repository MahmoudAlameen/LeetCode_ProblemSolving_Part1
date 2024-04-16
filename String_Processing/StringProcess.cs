using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.String_Processing
{
    public class StringProcess
    {
        public int LengthOfLastWord(string s)
        {
            s = s.Trim();
            int length = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                    return length;

                length++;
            }
            return length;
        }
    }
}
