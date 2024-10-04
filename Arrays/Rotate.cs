using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public class Rotate
    {
        public void Rotates(int[][] matrix)
        {
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(matrix.Length-1, matrix[0].Length -1);   
            RotateImage(matrix, startPoint, endPoint, matrix.Length-1);
        }
        public void RotateImage(int[][] matrix, Point startPoint, Point endPoint, int moves)
        {
            if (startPoint.Row >= endPoint.Row && startPoint.Column >= endPoint.Column)
                return;

            // loop on the current Rotate for start cylcling 
            for (int i = startPoint.Column; i < endPoint.Column; i++)
            {
                MoveRightBottom(matrix, startPoint, endPoint, i, moves);
            }
            startPoint.Increment();
            endPoint.Decrement();
            RotateImage(matrix, startPoint, endPoint, moves - 2);
        }
        private void MoveRightBottom(int[][] matrix, Point startPoint, Point endPoint, int cycleIndexCol, int moves)
        {
            Point destPoint = new Point();
            destPoint.Column = endPoint.Column;
            destPoint.Row = startPoint.Row + ConvertToPositive((endPoint.Column - cycleIndexCol) - moves);
            var sourceValue = matrix[startPoint.Row][cycleIndexCol];
            MoveBottomLeft(matrix, startPoint, endPoint, destPoint.Row, moves);
            matrix[destPoint.Row][destPoint.Column] = sourceValue;
            
        }
        private void MoveBottomLeft(int[][] matrix, Point startPoint, Point endPoint,int cycleIndexRow, int moves)
        {
            Point destPoint = new Point();
            destPoint.Column = endPoint.Column - (ConvertToPositive((endPoint.Row - cycleIndexRow) - moves));
            destPoint.Row = endPoint.Row;
            var sourceValue = matrix[cycleIndexRow][endPoint.Column];
            MoveLeftTop(matrix, startPoint, endPoint, destPoint.Column, moves);
            matrix[destPoint.Row][destPoint.Column] = sourceValue;
        }
        private void MoveLeftTop(int[][] matrix, Point startPoint, Point endPoint, int cycleIndexCol, int moves)
        {
            Point destPoint = new Point();
            destPoint.Column = startPoint.Column;
            destPoint.Row = endPoint.Row - ConvertToPositive((cycleIndexCol - startPoint.Column) - moves);  
            var sourceValue = matrix[endPoint.Row][cycleIndexCol];
            MoveTopRight(matrix, startPoint, endPoint, destPoint.Row, moves);
            matrix[destPoint.Row][destPoint.Column] = sourceValue;
        }
        private void MoveTopRight(int[][] matrix, Point startPoint, Point endPoint, int cycleIndexRow, int moves)
        {
            Point destPoint = new Point();
            destPoint.Row = startPoint.Row;
            destPoint.Column = startPoint.Column + ConvertToPositive((cycleIndexRow - startPoint.Row) - moves);
            var sourceValue = matrix[cycleIndexRow][startPoint.Column];
            matrix[destPoint.Row][destPoint.Column] = sourceValue;
        }
        private int ConvertToPositive(int x)
        {
            if (x < 0)
            {
                return x * -1;
            }
            return x;
        }
    }

    public class Point
    {
        public Point()
        { 
        }

        public Point(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }
        public int Row { get; set; }
        public int Column { get; set; }

        public void Increment()
        {
            this.Row++;
            this.Column++;
        }
        public void Decrement()
        {
            this.Row--;
            this.Column--;
        }
    }
}
