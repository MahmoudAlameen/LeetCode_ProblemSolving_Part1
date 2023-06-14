using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Reverse_Integer
{
    public static class ReverseInteger
    {
        public static int Reverse(int x)
        {
            int reverse = 0;
            int modelse;
            int postivenum = x > 0 ? x : x * -1;
            while(postivenum > 0)
            {
                modelse = postivenum % 10;
                if (((long)reverse *10 + (long)modelse) > 2147483647)
                    return 0;
                reverse = reverse * 10 + modelse;
                postivenum = postivenum / 10;
            }

            return x > 0 ? reverse  : reverse * -1;
        }

    }
}
