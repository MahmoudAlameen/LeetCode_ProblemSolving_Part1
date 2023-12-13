using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Container_With_Most_Water
{
    public static class ContainerWithMostWater
    {
        public static int MaxAreaForwardAlgorithm(int[] height)
        {
            int maxArea = 0;
            var currentMax = 0;
            for (int i = 0; i < height.Length - 1; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    currentMax = Math.Min(height[i], height[j]) * (j - i);
                    if (currentMax > maxArea)
                        maxArea = currentMax;

                }
            }
            return maxArea;
        }
        public static int MaxAreaSpeedAlgorithm(int[] height)
        {
            if (height.Length < 3)
                return Math.Min(height[0], height[1]);
            // get max length 
            int maxLength = height[0];
            int maxArea = 0;
            for (int i = 1; i < height.Length; i++)
            {
                if (height[i] > maxLength)
                    maxLength = height[i];  
            }
            // create list indexed with  the length
            List<int>[] indexedLengthList = new List<int>[maxLength+1];
            for (int i = 0; i < height.Length; i++)
            {
                if (indexedLengthList[height[i]] == null)
                {
                    indexedLengthList[height[i]] = new List<int>();
                }
                indexedLengthList[height[i]].Add(i + 1);
            }

            //// caculate for each length area  using it with fartthest and bigger length than it 
            ///
            // create list contain length and bool flag indicate that this length is area with nearest  length and bigger than it 
            Point[] PointsList = new Point[height.Length];

            for (int i = 0; i < height.Length; i++)
            {
                PointsList[i] = new Point
                {
                    Length = height[i],
                    Position = i+1,
                    IsCalculated = false
                };
            }

            for (int l = 0; l < indexedLengthList.Length; l++)
            {
                if (indexedLengthList[l] == null)
                    continue;
                for (int j = 0; j < indexedLengthList[l].Count; j++)
                {

                    Point currentPoint = PointsList[indexedLengthList[l][j] - 1];
                    Point farthestRightPoint = PointsList[PointsList.Length - 1];
                    Point farthestLeftPoint = PointsList[0];
                    Point farthestPoint = null;

                    int rightFar = 0;
                    int leftFar = 0;

                    for (int i = PointsList.Length - 1; i > currentPoint.Position - 1; i--)
                    {
                        if (PointsList[i].IsCalculated)
                            continue;
                        rightFar = (PointsList[i].Position) - (indexedLengthList[l][j]);
                        farthestRightPoint = PointsList[i];
                        break;
                    }

                    for (int i = 0; i < indexedLengthList[l][j] - 1; i++)
                    {
                        if (PointsList[i].IsCalculated)
                            continue;
                        leftFar = indexedLengthList[l][j] - PointsList[i].Position;
                        farthestLeftPoint = PointsList[i];
                        break;
                    }

                    if (rightFar > leftFar)
                        farthestPoint = farthestRightPoint;
                    if (leftFar >= rightFar)
                        farthestPoint = farthestLeftPoint;
                    if (leftFar == 0 && rightFar == 0)
                        farthestPoint = null;

                    var area = farthestPoint == null ? 0 : Math.Min(currentPoint.Length, farthestPoint.Length) * (currentPoint.Position > farthestPoint.Position == true ? currentPoint.Position - farthestPoint.Position : farthestPoint.Position - currentPoint.Position);
                    if (area > maxArea)
                        maxArea = area;
                    currentPoint.IsCalculated = true;
                }
            }
            return maxArea;
        }
    }
    public class Point
    { 
        public int Length { get; set; }
        public int Position { get; set; }
        public bool IsCalculated { get; set; }
    }
}
