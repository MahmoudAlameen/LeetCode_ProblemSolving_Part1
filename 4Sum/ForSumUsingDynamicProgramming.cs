using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek._4Sum
{
    public class ForSumUsingDynamicProgramming
    {
        IList<IList<int>> result = new List<IList<int>>();
        public record TwoSum(int index1, int index2, int value);
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var allTwoSums = GetAllTwoSums(nums);
            SumTwoSums(allTwoSums, nums, target);
            return result;
        }
        public TwoSum[][] GetAllTwoSums(int[] nums)
        {
            TwoSum[][] result = new TwoSum[nums.Length-1][];
            for (int i = 0; i < nums.Length -1; i++)
            {
                result[i] = new TwoSum[result.Length - i];
                int c = 0;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    result[i][c] = new(i, j, nums[i] + nums[j]);
                    c++;
                }
            }
            return result;
        }

        public void SumTwoSums(TwoSum[][] matrix, int[] nums, int target)
        {
            for (int outRow = 0; outRow < matrix.Length - 1; outRow++)
            {
                for (int outCol = 0; outCol < matrix[outRow].Length; outCol++)
                {
                    var outPoint = matrix[outRow][outCol];  
                    for(int inRow = outRow + 1; inRow < matrix.Length; inRow++)
                    {
                        if (outPoint.index2 == matrix[inRow][0].index1)
                            continue;

                        for (int inCol = 0; inCol < matrix[inRow].Length; inCol++)
                        {
                            var inPoint = matrix[inRow][inCol];
                            if (IsIntercepted(outPoint, inPoint))
                                continue;

                            AddSum(outPoint, inPoint, nums, target);
                        }
                    }
                }
            }
        }

        private void AddSum(TwoSum point1, TwoSum point2, int[] nums,  int target)
        {
            var sum = point1.value + point2.value;
            if (sum == target)
                result.Add(new List<int> { nums[point1.index1], nums[point1.index2], nums[point2.index1], nums[point2.index2]});
        }

        private bool IsIntercepted(TwoSum sum1, TwoSum sum2)
        {
            if (sum1.index1 == sum2.index1 || sum1.index1 == sum2.index2)
                return true;
            if (sum1.index2 == sum2.index1 || sum1.index1 == sum2.index2)
                return true;
            return false;
        }

    }
   
}
