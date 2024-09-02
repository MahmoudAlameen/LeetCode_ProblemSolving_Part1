using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.MultiplyStrings
{
    public static class MultiplyStrings
    {
        public static string Multiply(string num1, string num2)
        {
            List<string> multipliedByDigitList = new List<string>();
            string num1Reversed = num1.Reverse();
            string num2Reversed = num2.Reverse();    
            foreach (var digit in num1Reversed)
                multipliedByDigitList.Add(MultipliedByDigit(digit.ConvertToInt(), num2Reversed));

            return SumMultiplicants(multipliedByDigitList).Reverse().RemoveZeroz();
        }
        private static string MultipliedByDigit(int multiplier , string multiplicant)
        {
            int multiplyReminder = 0;
            StringBuilder result = new StringBuilder();
            for(int i=0; i<multiplicant.Length; i++)
            {
                var digit = multiplicant[i];
                int digitsMultiplyResult = multiplier * digit.ConvertToInt() + multiplyReminder;


                var firstDigitOnTheRight = digitsMultiplyResult.GetFirstDigitOnTheRight();
                var secondDigitOnTheRight = digitsMultiplyResult.GetAllDigitsExcepttheMostRightOne();

                if (i >= multiplicant.Length - 1)
                {
                    result.Append(firstDigitOnTheRight);
                    if (secondDigitOnTheRight > 0)
                        result.Append(secondDigitOnTheRight);
                    return result.ToString();
                }
                result = result.Append(firstDigitOnTheRight);
                multiplyReminder = secondDigitOnTheRight;
            }
            return result.ToString();
        }
        public static int ConvertToInt(this char digit)
        {
            return (int) digit -48;
        }
        private static int GetFirstDigitOnTheRight(this int num)
        {
            num = num < 0 ? num * -1 : num;
            int modules;
            while (num > 0)
            {
                modules = num % 10;
                if(modules / 10 == 0)
                    return modules;
                num = modules % 10;
            }
            return num;
        }
        private static int GetSecondDigitOnTheRight(this int num)
        {
            int division = num / 10;
            if (division <= 0)
                return 0;
            return division % 10;
        }
        private static int GetAllDigitsExcepttheMostRightOne(this int num)
        {
            return num / 10;
        }
        public static string SumMultiplicants(List<string> multiplications)
        {
            int reminder = 0;
            StringBuilder result = new StringBuilder();
            PrepareMultiplicationsForSum(multiplications);
            for (int digitIndex = 0; digitIndex < multiplications[multiplications.Count -1].Length; digitIndex++)
            {
                int digitResult = 0;
                for (int multiplicantIndex = 0; multiplicantIndex < multiplications.Count; multiplicantIndex++)
                {
                    if (digitIndex < multiplications[multiplicantIndex].Length)
                    {
                        digitResult += multiplications[multiplicantIndex][digitIndex].ConvertToInt(); 
                    }
                }
                digitResult += reminder;
                var firstDigit = digitResult.GetFirstDigitOnTheRight();
                var secondDigit = digitResult.GetAllDigitsExcepttheMostRightOne();

                if (digitIndex >= multiplications[multiplications.Count - 1].Length - 1)
                {
                    result.Append(firstDigit);

                    if (secondDigit > 0)
                        result.Append(secondDigit);
                    return result.ToString();
                }
                result = result.Append(firstDigit);
                reminder = secondDigit <= 0 ? 0 : secondDigit;
            }
            return result.ToString();
        }
        public static void PrepareMultiplicationsForSum(List<string> list)
        {
            int addedZerosCount = 1;
            for (int i = 1; i < list.Count; i++)
            {
                for (int zerosIndex = 0; zerosIndex < addedZerosCount; zerosIndex++)
                {
                    list[i]= '0' + list[i];
                }
                addedZerosCount++;
                
            }
        }
        private static string Reverse(this string num)
        {
            StringBuilder result = new StringBuilder();
            for (int i = num.Length - 1; i >= 0; i--)
            {
                result.Append(num[i]);
            }
            return result.ToString();
        }
        public static string RemoveZeroz(this string num)
        {
            while (num.Length > 1)
            {
                if (num[0] == '0')
                    num = num.Remove(0, 1);
                else
                    return num;
            }
            return num;
        }
    }
}
