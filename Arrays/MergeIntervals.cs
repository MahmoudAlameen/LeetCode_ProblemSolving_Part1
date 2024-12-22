using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            var orderedList = intervals.ToList().OrderBy(x => x[0]);
            intervals = orderedList.ToArray();
            List<int[]> result = new List<int[]>();
            result.Add(intervals[0]);

            for (int index = 1; index < intervals.Length; index++)
            {
                var lastInterval = result[result.Count - 1];
                if (intervals[index][0] >= lastInterval[0] && intervals[index][0] <= lastInterval[1])
                {
                    result[result.Count - 1] = new int[] { lastInterval[0] < intervals[index][0] ? lastInterval[0] : intervals[index][0], lastInterval[1] > intervals[index][1] ? lastInterval[1] : intervals[index][1] };
                }
                else
                {
                    result.Add(intervals[index]);
                }
            }
            return result.ToArray();
        }
    }
}
