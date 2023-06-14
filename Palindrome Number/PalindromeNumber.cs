using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Palindrome_Number
{
    public class PalindromeNumber
    {
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            int reverse = 0;
            int modeles;
            int num = x;
            while(num>0)
            {
                modeles = num % 10;
                reverse = reverse *10 + modeles;
                num = num / 10;
            }
            if (x == reverse)
                return true;
            else
                return false;

        }
    }
}
