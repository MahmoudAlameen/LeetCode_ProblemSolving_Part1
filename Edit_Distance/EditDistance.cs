using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Edit_Distance
{
    public class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            if (word1.Length == 0)
                return word2.Length;
            if (word2.Length == 0)
                return word1.Length;

            int[][] matrixDistances = new int[word1.Length][];

            for(int i = 0; i < word1.Length; i++)
                matrixDistances[i] = new int[word2.Length];
            bool ismatchedRows = false;
            bool ismatchedCols = false;
            if (word1[0] == word2[0])
            {
                ismatchedRows = true;
                ismatchedCols = true;
                matrixDistances[0][0] = 0;
            }
            else
            {
                matrixDistances[0][0] = 1;
            }

            for (int row = 1; row < matrixDistances.Length; row++)
            {
                if (!ismatchedRows && word1[row] == word2[0])
                {
                    matrixDistances[row][0] = matrixDistances[row - 1][0];
                    ismatchedRows = true;
                }
                else
                    matrixDistances[row][0] = matrixDistances[row - 1][0] + 1;

            }
            for (int col = 1; col < matrixDistances[0].Length; col++)
            {
                if (!ismatchedCols && word2[col] == word1[0])
                {
                    matrixDistances[0][col] = matrixDistances[0][col - 1];
                    ismatchedCols = true;
                }
                else
                    matrixDistances[0][col] = matrixDistances[0][col - 1] + 1;
            }

            for (int row = 1; row < matrixDistances.Length; row++)
            {
                for (int col = 1; col < matrixDistances[row].Length; col++)
                {
                    matrixDistances[row][col] =  Math.Min(
                        Math.Min(matrixDistances[row - 1][col] + 1, 
                                 matrixDistances[row][col - 1] + 1),
                                 word1[row] == word2[col] ? matrixDistances[row - 1][col - 1] : matrixDistances[row - 1][col - 1] + 1);
                }
            }
            return matrixDistances[word1.Length-1][word2.Length-1];
        }
    }
}
