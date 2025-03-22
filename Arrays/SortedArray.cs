using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class SortedArray
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int nums1Index = m - 1;
            int nums2Index = n - 1;
            int right = m + n - 1;

            while (nums2Index >= 0)
            {
                if (nums1Index >= 0 && nums1[nums1Index] > nums2[nums2Index])
                {
                    nums1[right] = nums1[nums1Index];
                    nums1Index--;
                }
                else
                {
                    nums1[right] = nums2[nums2Index];
                    nums2Index--;
                }
                right--;
            }
            
        }

    }
}
