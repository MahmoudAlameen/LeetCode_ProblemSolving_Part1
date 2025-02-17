using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Compinations
{
    public class SubSet
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result  = new List<IList<int>>();
            result.Add(new List<int> { });
            result.Add(new List<int> { nums[0] });
            var addedOne = new List<int>();
            int currentResultLength = result.Count;
            for (int i = 1; i < nums.Length; i++)
            {
                currentResultLength = result.Count;
                for(int resultIndex = 0; resultIndex < currentResultLength; resultIndex++)
                {
                    addedOne = new List<int>();
                    addedOne.AddRange(result[resultIndex]);
                    addedOne.Add(nums[i]);
                    result.Add(addedOne);
                }
            }
            return result;
        }
    }
}
