using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Reverse_Integer
{
    public static class StringToInteger
    {
        public static int MyAtoi(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            int number = 0;
            s = s.Trim();
            if (string.IsNullOrEmpty(s))
                return 0;
            bool isPositive = true;
            if (s[0] == '+')
            {
                isPositive = true;
                s = s.Substring(1, s.Length - 1);
            }
            else if (s[0] == '-')
            {
                isPositive = false;
                s = s.Substring(1, s.Length - 1);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (!isDigit(s[i]))
                    break;
                if (((long)number * 10 + int.Parse(s[i].ToString())) > int.MaxValue)
                    return isPositive == true ? int.MaxValue : int.MinValue;
                number = number * 10 + int.Parse(s[i].ToString());
            }
            if (!isPositive)
                number *= -1; 
            return number;

        }

        public static bool isDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
