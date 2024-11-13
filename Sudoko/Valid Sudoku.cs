using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Sudoko
{
    public  class Valid_Sudoku
    {
        public  int[] Switches = new int[9];
        public bool IsValidSudoku(char[][] board)
        {
            // validate Rows
            for (int rowIndex = 0; rowIndex < board.Length; rowIndex++)
            {
                if (!IsValidRow(board, rowIndex))
                    return false;

            }
            // validate columns
            for (int colIndex = 0; colIndex < board[0].Length; colIndex++)
            {
                if (!IsValidColumn(board, colIndex))
                    return false;
            }
            // validate matrixws 
            for (int rowIndex = 0; rowIndex < board.Length; rowIndex+=3)
            {
                for (int colIndex = 0; colIndex < board[rowIndex].Length; colIndex+=3)
                {
                    if (!IsValidMatrix(board, rowIndex, colIndex))
                        return false;
                }
            }
            return true;
        }

        private bool IsValidRow(char[][] board, int rowIndex)
        {
            PrepareSwitches();
            char num;
            int value;
            for (int colIndex = 0; colIndex < board[rowIndex].Length; colIndex++)
            {
                if (!int.TryParse(board[rowIndex][colIndex].ToString(), out value))
                    continue;
                if (Switches[value - 1] == 1)
                    return false;
                Switches[value - 1] = 1;
            }
            return true;
        }
        private bool IsValidColumn(char[][] board, int colIndex)
        {
            PrepareSwitches();
            char num;
            int value;
            for (int rowIndex = 0; rowIndex < board.Length; rowIndex++)
            {
                if (!int.TryParse(board[rowIndex][colIndex].ToString(), out value))
                    continue;

                if (Switches[value - 1] == 1)
                    return false;

                Switches[value - 1] = 1;
            }
            return true;
        }
        private bool IsValidMatrix(char[][] board, int startRow, int startCol)
        {
            PrepareSwitches();
            char num;
            int value;

            for (int rowIndex = startRow; rowIndex < startRow + 3; rowIndex++)
            {
                for (int colIndex = startCol; colIndex < startCol + 3; colIndex++)
                {
                    if (!int.TryParse(board[rowIndex][colIndex].ToString(), out value))
                        continue;

                    if (Switches[value - 1] == 1)
                        return false;

                    Switches[value - 1] = 1;
                }
            }
            return true;
        }

        private void PrepareSwitches()
        {
            for (int i = 0; i < Switches.Length; i++)
                Switches[i] = 0;

        }
    }
}
