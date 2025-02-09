using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Set_Matrix_Zeroes
{
    public class Set_Matrix__Zeroes
    {
        public void SetZeroes(int[][] matrix)
        {
            HashSet<int> rows = new HashSet<int>();
            HashSet<int> columns = new HashSet<int>();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        rows.Add(row);
                        columns.Add(col);
                    }
                }
            }
            foreach(int row in rows)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = 0;
                }
            }
            foreach (int col in columns)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    matrix[row][col] = 0;
                }
            }

        }
        public void SetZerosUsingEscapByRecursion(int[][] matrix)
        {
            for(int row = 0;  row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        SetZerosForRows(matrix, row);
                        break;
                    }
                }
            }
            
        }
        public void SetZerosForColumns(int[][] matrix, int columnIndex, int rowIndex)
        {
            for (int row = rowIndex; row < matrix.Length; row++)
            {
                if (matrix[row][columnIndex] == 0)
                    SetZerosForRows(matrix, row);
                else
                    matrix[row][columnIndex] = 0;
            }
        }
        public void SetZerosForRows(int[][] matrix, int rowIndex)
        {
            for (int col = 0; col < matrix[rowIndex].Length; col++)
            {
                if (matrix[rowIndex][col] == 0)
                    SetZerosForColumns(matrix, col, rowIndex +1);
                else
                    matrix[rowIndex][col] = 0;
            }
            
        }
    }
}
