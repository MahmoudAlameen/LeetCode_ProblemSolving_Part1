using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Unique_Path
{
    public class UniquePath
    {
        public int UniquePaths(int m, int n)
        {
            int[][] matrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new int[n]; 
            }

            for (int rowIndex = 0; rowIndex < m; rowIndex++)
            {
                matrix[rowIndex][0] = 1;
            }
            for (int colIndex = 0; colIndex < n; colIndex++)
            {
                matrix[0][colIndex] = 1;
            }

            for (int rowIndex = 1; rowIndex < m; rowIndex++)
            {
                for (int colIndex = 1; colIndex < n; colIndex++)
                {
                    matrix[rowIndex][colIndex] = matrix[rowIndex - 1][colIndex] + matrix[rowIndex][colIndex - 1];
                }
            }
            return matrix[m - 1][n - 1];
        }
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid[obstacleGrid.Length - 1][obstacleGrid[obstacleGrid.Length - 1].Length - 1] == 1)
                return 0;
            
            int[][] uniquePaths = new int[obstacleGrid.Length][];
            for (int i = 0; i < uniquePaths.Length; i++)
                uniquePaths[i] = new int[obstacleGrid[i].Length];
            uniquePaths[0][0] = obstacleGrid[0][0] == 1 ? -1 : 1;

            for (int colIndex = 1; colIndex < uniquePaths[0].Length; colIndex++)
            {
                uniquePaths[0][colIndex] = obstacleGrid[0][colIndex] == 0 ? uniquePaths[0][colIndex -1] == -1 ? 0 : uniquePaths[0][colIndex -1] : -1;
            }

            for (int rowIndex = 1; rowIndex < uniquePaths.Length; rowIndex++)
            {
                uniquePaths[rowIndex][0] = obstacleGrid[rowIndex][0] == 0 ? uniquePaths[rowIndex -1][0] == -1 ? 0 : uniquePaths[rowIndex -1][0] : -1;
            }

            for (int rowIndex = 1; rowIndex < uniquePaths.Length; rowIndex++)
            {
                for (int colIndex = 1; colIndex < uniquePaths[rowIndex].Length; colIndex++)
                {
                    if (obstacleGrid[rowIndex][colIndex] == 0)
                    {
                        int sumPathsFromTop = uniquePaths[rowIndex - 1][colIndex] == -1 ? 0 : uniquePaths[rowIndex - 1][colIndex];
                        int sumPathsFromRight = uniquePaths[rowIndex][colIndex - 1] == -1 ? 0 : uniquePaths[rowIndex][colIndex - 1];
                        uniquePaths[rowIndex][colIndex] = sumPathsFromTop + sumPathsFromRight;
                    }
                    else
                        uniquePaths[rowIndex][colIndex] = -1;
                }
            }
            return uniquePaths[uniquePaths.Length - 1][uniquePaths[uniquePaths.Length - 1].Length - 1];
        }

    }
}
