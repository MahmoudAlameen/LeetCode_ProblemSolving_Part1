using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek._3Sums
{
    /// <summary>
    /// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

    ///Notice that the solution set must not contain duplicate triplets.
    /// </summary>
    public static class ThreeSums
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<int> postiveNums = new List<int>();
            List<int> negativeNums = new List<int>();
            IList<IList<int>> result = new List<IList<int>>();
            int zeros = 0;

            // get postive numsbers , negative numbers , zero if it is exist 
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    postiveNums.Add(nums[i]);
                if (nums[i] < 0)
                    negativeNums.Add(nums[i]);
                if (nums[i] == 0)
                    zeros++;
            }

            postiveNums.Sort();
            negativeNums.Sort();

            var notRepeatedPostive = new List<int>();
            if(postiveNums.Count > 0)  
                  notRepeatedPostive.Add(postiveNums[0]);
            for (int i = 1; i < postiveNums.Count; i++)
            {
                if (postiveNums[i] == postiveNums[i - 1])
                    continue;
                notRepeatedPostive.Add(postiveNums[i]);
            }
            var notRepeatedNegative = new List<int>();

            if(negativeNums.Count > 0)   
                notRepeatedNegative.Add(negativeNums[0]);

            for (int i = 1; i < negativeNums.Count; i++)
            {
                if (negativeNums[i] == negativeNums[i - 1])
                    continue;
                notRepeatedNegative.Add(negativeNums[i]);
            }

            int postiveIndex = 0;
            int negativeIndex = notRepeatedNegative.Count - 1;
            while (zeros > 0 && postiveIndex < notRepeatedPostive.Count && negativeIndex >= 0)
            {
                if (notRepeatedPostive[postiveIndex] == notRepeatedNegative[negativeIndex] * -1)
                {
                    result.Add(new List<int> { 0, notRepeatedPostive[postiveIndex], notRepeatedNegative[negativeIndex] });
                    postiveIndex++;
                    negativeIndex--;
                    continue;
                }
                if (notRepeatedPostive[postiveIndex] < notRepeatedNegative[negativeIndex] * -1)
                {
                    postiveIndex++;
                    continue;
                }
                if (notRepeatedPostive[postiveIndex] > notRepeatedNegative[negativeIndex] * -1)
                    negativeIndex--;
            }

            if (zeros > 2)
                result.Add(new List<int> { 0, 0, 0 });

            var tempResultPostive = new List<List<int>>();

            int left = 0;
            int right = postiveNums.Count - 1;
            int nextRight = right;
            bool isNextRightSet = false;
            foreach (var negativeNum in notRepeatedNegative)
            {
                var NegativeNumReversed = negativeNum * -1;
                left = 0;
                 right = nextRight;
                isNextRightSet = false;

                while (left < right)
                {
                    int sumTwoNums = postiveNums[left] + postiveNums[right];
                    if (sumTwoNums == NegativeNumReversed)
                    {
                        if(!IsExist(tempResultPostive, new List<int> { negativeNum, postiveNums[left], postiveNums[right] }))
                            tempResultPostive.Add(new List<int> { negativeNum, postiveNums[left], postiveNums[right] });
                        if (!isNextRightSet)
                        {
                            nextRight = right;
                            isNextRightSet = true;
                        }
                        right--;
                        left++;

                    }
                    if (sumTwoNums < NegativeNumReversed)
                    {
                        left++;
                        //if (!isNextRightSet)
                        //{
                        //    nextRight = right;
                        //    isNextRightSet = true;
                        //}

                    }
                    if (sumTwoNums > NegativeNumReversed)
                    {
                        right--;
                        if (!isNextRightSet)
                            nextRight = right;
                    }
                }
            }
            var tempResultNegative = new List<List<int>>();

            left = 0;
            right = negativeNums.Count - 1;
            nextRight = right;
            notRepeatedPostive.Reverse();
            foreach(var postiveNum in notRepeatedPostive) 
            {
                isNextRightSet = false;
                var postiveNumReversed = postiveNum * -1;
                right = nextRight;
                left = 0;

                while (left < right)
                {
                    int sumTwoNums = negativeNums[left] + negativeNums[right];
                    if (sumTwoNums == postiveNumReversed)
                    {
                        if(!IsExist(tempResultNegative, new List<int> { postiveNum, negativeNums[left], negativeNums[right] })) 
                           tempResultNegative.Add(new List<int> { postiveNum, negativeNums[left], negativeNums[right] });
                        if (!isNextRightSet)
                        {
                            isNextRightSet = true;
                            right = nextRight;
                        }
                        right--;
                        left++;
                       
                    }
                    if (sumTwoNums < postiveNumReversed)
                    {

                        left++;
                        //if (!isNextRightSet)
                        //{
                        //    nextRight = right;
                        //    isNextRightSet = true;
                        //}
                    }

                    if (sumTwoNums > postiveNumReversed)
                    {
                        right--;
                        if (!isNextRightSet)
                            nextRight = right;
                    }

                }
            }

            foreach (var item in tempResultNegative)
                result.Add(item);
            foreach (var item in tempResultPostive)
                result.Add(item);
            return result;

        }
        public static bool IsExist(List<List<int>> tempResult, List<int> item)
        {
            foreach (var l in tempResult)
            {
                if (item.All(i => l.Contains(i)))
                    return true;
            }
            return false;
        }
        public static IList<IList<int>> chatgptsolution(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                // Skip duplicates for the fixed element
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int currentSum = nums[i] + nums[left] + nums[right];

                    if (currentSum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // Skip duplicates for left and right pointers
                        while (left < right && nums[left] == nums[left + 1])
                            left++;
                        while (left < right && nums[right] == nums[right - 1])
                            right--;

                        left++;
                        right--;
                    }
                    else if (currentSum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }

    }
}
