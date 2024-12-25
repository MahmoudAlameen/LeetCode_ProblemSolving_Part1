using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class SpiralMatrix2
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[n];
            }

            int startRow = 0, startCol = 0, endrow = matrix.Length - 1, endCol = matrix[0].Length - 1;
            int num =1;
            while (startRow <= endrow && startCol <= endrow)
            {
                SpiralRounGenerate(matrix, startRow, startCol, endrow, endCol, ref num);
                startRow++;
                startCol++;
                endrow--;
                endCol--;
            }
            return matrix;
        }
        private void SpiralRounGenerate(int[][] matrix, int startRow, int startCol, int endRow, int endCol, ref int num)
        {

            if (startRow == endRow && startCol == endCol)
            {
                matrix[startRow][endCol] = num;
                return;
            }
            //right arrow
            for (int colIndex = startCol; colIndex <= endCol; colIndex++)
            {
                matrix[startRow][colIndex] = num;
                num++;
            }

            //bottom arrow
            for (int rowIndex = startRow + 1; rowIndex <= endRow; rowIndex++)
            {
                matrix[rowIndex][endCol] = num;
                num++;
            }

            // left Arrow
            for (int colIndex = endCol - 1; colIndex >= startCol; colIndex--)
            {
                matrix[endRow][colIndex] = num;
                num++;
            }

            // top Arrow
            for (int rowIndex = endRow - 1; rowIndex > startRow; rowIndex--)
            {
                matrix[rowIndex][startCol] = num;
                num++;
            }
        }
    }
}
