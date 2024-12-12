using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class LongestCommonPrefixProblem
    {
        public string LongestCommonPrefix(string[] strs)
        {
            StringBuilder lCP = new StringBuilder(strs[0]);
            string lCPstring = lCP.ToString();

            for (int i = 1; i < strs.Length; i++)
            {

                if (!string.Equals(lCPstring, strs[i].Substring(0, lCPstring.Length)))
                {
                    lCP.Remove(lCP.Length -1, 1);

                    if (lCP.Length == 0)
                        return "";

                    lCPstring = lCP.ToString();
                    i--;
                }
            }
            return lCPstring;
        }
    }
}
