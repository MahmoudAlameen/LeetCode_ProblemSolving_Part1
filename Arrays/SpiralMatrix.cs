using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> spiral = new List<int>();
            int startRow = 0;
            int startColumn = 0;
            int endColumn = matrix[0].Length -1;
            int endRow = matrix.Length -1;

            while (startRow <= endRow && startColumn <= endColumn)
            {
                spiral.AddRange(SpiralRound(matrix, startRow, endRow, startColumn, endColumn));
                startRow++;
                startColumn++;
                endRow--;
                endColumn--;
            }
            return spiral;
        }
        public IList<int> SpiralRound(int[][] matrix, int startRow, int endRow, int startColumn, int endColumn)
        {
            List<int> round = new List<int>();
            
            //right arrow
            for (int columnIndex = startColumn; columnIndex <= endColumn; columnIndex++)
            {
                round.Add(matrix[startRow][columnIndex]);
            }

            // bottom arrow
            for (int rowIndex = startRow + 1; rowIndex <= endRow; rowIndex++)
            {
                round.Add(matrix[rowIndex][endColumn]);
            }

            // left arrow
            if (startRow != endRow)
            {
                for (int columnIndex = endColumn - 1; columnIndex >= startColumn; columnIndex--)
                {
                    round.Add(matrix[endRow][columnIndex]);
                }
            }

            // top arrow
            if (startColumn != endColumn && startRow +1 != endRow)
            {
                for (int rowIndex = endRow - 1; rowIndex > startRow; rowIndex--)
                {
                    round.Add(matrix[rowIndex][startColumn]);
                }
            }
            return round;


        }
    }
}
