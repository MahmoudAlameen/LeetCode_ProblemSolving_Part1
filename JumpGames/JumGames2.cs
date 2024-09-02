using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.JumpGames
{
    public class JumGames2
    {
        public static int Jump(int[] nums)
        {
            int[] minJumps = new int[nums.Length];
            minJumps[minJumps.Length - 1] = 0;
            int minPrevJumps = 0;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                minPrevJumps = minJumps[i+1];

                for (int j = i + 1; j <= i + nums[i] && j < minJumps.Length; j++)
                {
                    if (minJumps[j] < minPrevJumps)
                        minPrevJumps = minJumps[j]; 
                }
                minJumps[i] = 1 + minPrevJumps;
            }
            return minJumps[0];

        }
    }
}

