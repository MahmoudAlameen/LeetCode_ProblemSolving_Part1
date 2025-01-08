using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.ClimbStairsProblem
{
    public class ClaimpStairs
    {
        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;
            int[] claimbSteps = new int[n + 1];
            claimbSteps[0] = 0;
            claimbSteps[1] = 1;
            claimbSteps[2] = 2;
            for (int index = 3; index < claimbSteps.Length; index++)
            {
                claimbSteps[index] = claimbSteps[index - 1] + claimbSteps[index - 2];
            }
            return claimbSteps[claimbSteps.Length - 1];
        }
    }
}
