using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Zigzag_Conversion
{
    public class zigzagConversion
    {
        public static string Convert(string s, int numRows)
        {
            string result = "";
            string temp;
            int index = 0, zigzagColumn = 0;
            for ( int currentRow = 0; currentRow < numRows; currentRow++)
            {
                zigzagColumn = currentRow;
                index = zigzagColumn;
                while (index < s.Length)
                {
                    temp = Add(result, s, index);

                    if (string.IsNullOrEmpty(temp))
                        break;
                    result = temp;
                    if(currentRow > 0 && currentRow < numRows-1)
                    {
                        index = zigzagColumn + ((numRows - 1 - currentRow) * 2);
                        temp = Add(result, s, index);

                        if (string.IsNullOrEmpty(temp))
                            break;
                        result = temp;
                    }
                    zigzagColumn += (numRows - 1 - currentRow) * 2 +(currentRow * 2);
                    if (zigzagColumn == index)
                    {
                        index++;
                        zigzagColumn = index;
                    }
                    else
                      index = zigzagColumn;

                }
            }
            return result;
           
        }

        public static  string Add( string result, string source, int index)
        {
            if (index >= source.Length)
                return string.Empty;
            result += source[index].ToString();
            return result;
        }
        private static void BuildZigzagMatrix(string s, char[,] zigzagMatrix, int rows, int column, int index)
        {
            for (int i = 0; i < rows; i++)
            {
                if (index >= s.Length)
                    return;
                zigzagMatrix[i, column] = s[index];
                index++;
            }
            int j = column;
            for (int i = rows - 1; i >= 1; i--)
            {
                if (index >= s.Length)
                    return;
                zigzagMatrix[i - 1, j + 1] = s[index];
                j++;
                index++;
            }
            column += rows - 1;
            BuildZigzagMatrix(s, zigzagMatrix, rows, column, index-1);
        }
        private static string GetConversion(char[,] zigzagMatrix , int rows , int columns)
        {
            string result = "";

            for (int i = 0; i < rows; i++)
            {
                int column = 0;
                while (column < columns)
                {
                    if (column - 1 >= 0 && zigzagMatrix[i, column - 1] != 0)
                        result += zigzagMatrix[i, column - 1];
                    if (zigzagMatrix[i, column] != 0)
                        result += zigzagMatrix[i, column];

                    if (column + 1 < columns && zigzagMatrix[i, column + 1] != 0)
                        result += zigzagMatrix[i, column + 1];
                    column += rows - 1;
                }
            }
            return result;
        }
        //public static string Convert(string s, int numRows)
        //{
        //    List<char> list = new List<char>();
        //    int currentIndex = 0, zigzagIndex = numRows - 2;
        //    for (int i = 0; i < numRows - 1; i++)
        //    {
        //        currentIndex = i;
        //        if (currentIndex < s.Length)
        //            list.Add(s[i]);
        //        else
        //            break;
        //        PickRowvalues(currentIndex, zigzagIndex, numRows - 1 - i, list, s);
        //        zigzagIndex--;
        //    }
        //    string result = "";
        //    for (int i = 0; i < list.Count; i++)
        //        result += list[i].ToString();
        //    return result;
        //}
        private static void PickRowvalues(int currentIndex, int zigzagIndex, int rowsCount, List<char> list , string s)
        {
             currentIndex = currentIndex + rowsCount;
            currentIndex = currentIndex + zigzagIndex+1;
            if (currentIndex < s.Length)
            {
                list.Add(s[currentIndex]);
                PickRowvalues(currentIndex, zigzagIndex, rowsCount, list , s);
            }
            return;
        }
    }

}
