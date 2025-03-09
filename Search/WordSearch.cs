using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Search
{
    public class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            Queue<Sequential> sequentionsQueue = new Queue<Sequential>();

            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                    if (board[row][col] == word[0])
                        sequentionsQueue.Enqueue(CreateEmptySequention(board.Length, board[row].Length, row, col));
            }

            for (int index = 1; index < word.Length; index++)
            {
                if (sequentionsQueue.Count <= 0)
                    return false;
                int currentQueueCount = sequentionsQueue.Count;
                for (int i = 0; i < currentQueueCount; i++)
                {
                   Sequential sequention = sequentionsQueue.Dequeue();
                    Point point = sequention.Head;

                    // check horizental
                    if (point.Column - 1 >= 0 && board[point.Row][point.Column -1] == word[index] && !sequention.Sequention[point.Row][point.Column -1])
                        sequentionsQueue.Enqueue(CreateNewSequention(sequention.Sequention, point.Row, point.Column - 1));

                    if (point.Column + 1 < board[point.Row].Length && board[point.Row][point.Column + 1] == word[index] && !sequention.Sequention[point.Row][point.Column + 1])
                        sequentionsQueue.Enqueue(CreateNewSequention(sequention.Sequention, point.Row, point.Column + 1));

                    // check vertical 
                    if (point.Row - 1 >= 0 && board[point.Row - 1][point.Column] == word[index] && !sequention.Sequention[point.Row - 1] [point.Column])
                        sequentionsQueue.Enqueue(CreateNewSequention(sequention.Sequention, point.Row - 1, point.Column));

                    if (point.Row + 1 < board.Length && board[point.Row + 1][point.Column] == word[index] && !sequention.Sequention[point.Row + 1][ point.Column])
                        sequentionsQueue.Enqueue(CreateNewSequention(sequention.Sequention, point.Row + 1, point.Column));
                }
            }
            if (sequentionsQueue.Count > 0)
                return true;

            return false;
        }
        private Sequential CreateNewSequention(bool[][] currentSequention, int row, int column)
        {
            bool[][] newSequention = new bool[currentSequention.Length][];

            for (int i = 0; i < currentSequention.Length; i++)
            {
                newSequention[i] = new bool[currentSequention[row].Length];
                for (int j = 0; j < currentSequention[i].Length; j++)
                {
                    newSequention[i][j] = currentSequention[i][j];
                }
            }
            newSequention[row][column] = true;
            return new Sequential(new Point(row, column), newSequention);
        }

        private Sequential CreateEmptySequention(int rowsLength, int columnsLength, int row, int column)
        {
            bool[][] sequention = new bool[rowsLength][];
            for (int i = 0; i < rowsLength; i++)
            {
                sequention[i] = new bool[columnsLength];  
            }
            sequention[row][column] = true;
            return new Sequential(new Point(row, column), sequention);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Exists(char[][] board, string word)
        {
            for (int bRow = 0; bRow < board.Length; bRow++)
            {
                for (int bCol = 0; bCol < board[bRow].Length; bCol++)
                {
                    if (word[0] == board[bRow][bCol])
                    {
                        bool[][] sequenceCheck = new bool[board.Length][];
                        for (int i = 0; i < sequenceCheck.Length; i++)
                        {
                            sequenceCheck[i] = new bool[board[i].Length];
                        }
                        sequenceCheck[bRow][bCol] = true;   
                        if (CheckNeighboars(board, word, 1, bRow, bCol, sequenceCheck))
                            return true;
                    }
                }
            }
            return false;   
        }

        private bool CheckNeighboars(char[][] board, string word, int wordIndex, int bRow, int bCol, bool[][] SequenceCheck)
        {
            if (wordIndex == word.Length)
                return true;


            // check horizental
            if (bCol - 1 >= 0 && board[bRow][bCol - 1] == word[wordIndex] && !SequenceCheck[bRow][bCol - 1])
            {
                SequenceCheck[bRow][bCol - 1] = true;
                if (CheckNeighboars(board, word, wordIndex + 1, bRow, bCol - 1, SequenceCheck))
                    return true;

                SequenceCheck[bRow][bCol - 1] = false;
            }

            if (bCol + 1 < board[bRow].Length && board[bRow][bCol + 1] == word[wordIndex] && !SequenceCheck[bRow][bCol + 1])
            {
                SequenceCheck[bRow][bCol + 1] = true;
                if (CheckNeighboars(board, word, wordIndex + 1, bRow, bCol + 1, SequenceCheck))
                    return true;

                SequenceCheck[bRow][bCol + 1] = false;
            }


            // check vertical 
            if (bRow - 1 >= 0 && board[bRow - 1][bCol] == word[wordIndex] && !SequenceCheck[bRow - 1][bCol])
            {
                SequenceCheck[bRow -1][bCol] = true;
                if (CheckNeighboars(board, word, wordIndex + 1, bRow -1, bCol, SequenceCheck))
                    return true;

                SequenceCheck[bRow -1][bCol] = false;
            }


            if (bRow + 1 < board.Length && board[bRow + 1][bCol] == word[wordIndex] && !SequenceCheck[bRow + 1][bCol])
            {
                SequenceCheck[bRow + 1][bCol] = true;
                if (CheckNeighboars(board, word, wordIndex + 1, bRow + 1, bCol, SequenceCheck))
                    return true;

                SequenceCheck[bRow + 1][bCol] = false;
            }

            return false;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
    public class Sequential
    {
        public Sequential(Point head, bool[][] sequention)
        {
            Head = head;
            Sequention = sequention;
        }
        public Point Head { get; set; }
        public bool[][] Sequention { get; set; }
    }
    public record Point(int Row, int Column);
}
