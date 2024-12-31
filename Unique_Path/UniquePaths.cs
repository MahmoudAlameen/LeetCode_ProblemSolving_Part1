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
    }
}
