using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.PathsProblems
{
    public class MinimumPath
    {
        public int MinPathSum(int[][] grid)
        {
            for (int colIndex = 1; colIndex < grid[0].Length; colIndex++)
            {
                grid[0][colIndex] = grid[0][colIndex - 1] + grid[0][colIndex];
            }

            for (int rowIndex = 1; rowIndex < grid.Length; rowIndex++)
            {
                grid[rowIndex][0] = grid[rowIndex - 1][0] + grid[rowIndex][0];
            }

            for (int rowIndex = 1; rowIndex < grid.Length; rowIndex++)
            {
                for (int colIndex = 1; colIndex < grid[rowIndex].Length; colIndex++)
                {
                    grid[rowIndex][colIndex] = grid[rowIndex][colIndex] + Math.Min(grid[rowIndex - 1][colIndex], grid[rowIndex][colIndex - 1]); 
                }
            }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }
    }
}
