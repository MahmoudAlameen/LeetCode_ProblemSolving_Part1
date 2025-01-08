using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.PlusOneProblem
{
    public class PlusOneProblem
    {
        public int[] PlusOne(int[] digits)
        {
            int? firstDigit = 1;
            int num = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (firstDigit == null)
                {
                    break;
                }
                num = digits[i] + firstDigit.Value;
                if (num > 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i] = num;
                    firstDigit = null;
                }
            }
            if (firstDigit == null)
                return digits;
            int[] newDigits = new int[digits.Length +1];
            newDigits[0] = firstDigit.Value;
            for (int i = 1; i < digits.Length; i++)
            {
                newDigits[i] = digits[i];   
            }
            return newDigits;
        }
    }
}
