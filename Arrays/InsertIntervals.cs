using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class InsertIntervals
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> result = new List<int[]>();
            int lastInterval = 0;
            bool merged = false;

            for (int i = 0; i < intervals.Length; i++)
            {
                if (IsOverlaped(newInterval, intervals[i]))
                {
                    newInterval = Merge(newInterval, intervals[i]);
                    merged = true;

                }
                else if (newInterval[1] < intervals[i][1])
                    break;
                else if (merged)
                    break;
                else
                    result.Add(intervals[i]);


                lastInterval++;
            }
            result.Add(newInterval);

            for(int i = lastInterval; i< intervals.Length; i++) 
                result.Add(intervals[i]);   

            return result.ToArray();
        }

        private bool IsOverlaped(int[] interval1, int[] interval2)
        {
            if ((interval1[0] >= interval2[0] && interval1[0] <= interval2[1]) || (interval2[0] >= interval1[0] && interval2[0] <= interval1[1]))
                return true;
            else
                return false;
        }
        private int[] Merge(int[] interval1, int[] interval2)
        {
            return new int[] { Math.Min(interval1[0], interval2[0]), Math.Max(interval1[1], interval2[1]) };
        }
    }
}
