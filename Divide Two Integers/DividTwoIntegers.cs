using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Divide_Two_Integers
{
    public static class DividTwoIntegers
    {

        public static int DivideDirector(int dividend, int divisor)
        {
            if (divisor >= 24409858 || divisor <= -24409858)
                return DivideUsingSum(dividend, divisor);
            else
                return DivideUsingBitWiseOPerator(dividend, divisor);

        }
        public static int DivideUsingSum(int dividend, int divisor)
        {
            int minValue = int.MinValue;
            int maxValue = int.MaxValue;

            int postiveDividend = dividend < 0 ? dividend <= minValue ? maxValue : -dividend : dividend >= maxValue ?  maxValue : dividend;
            int postiveDivisor = divisor < 0 ? divisor <= minValue ? maxValue :   -divisor : divisor >= maxValue ? maxValue : divisor;
            if (divisor == 1)
                return dividend < 0 ? dividend <= minValue? minValue :  dividend : dividend >= maxValue ? maxValue :dividend;
            if (divisor == -1)
                return dividend > 0 ? dividend >= maxValue ? minValue : -dividend : dividend <= minValue ? maxValue : -dividend;
            int sum = postiveDivisor;
            int divisioResult = 0;
            while (sum <= postiveDividend)
            {
                sum =  sum + postiveDivisor < 0 ? int.MaxValue : sum + postiveDivisor;
                divisioResult++;
            }
            return (dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0) ? -divisioResult : divisioResult;

        }
        public static int DivideUsingBitWiseOPerator(int dividend, int divisor)
         {
            int positiveDividend = Absolute(dividend);
            int positiveDivisor = Absolute(divisor);
            if ((dividend > 0 && divisor < 0) ? dividend <  (-1 * (long)divisor) : (dividend < 0 && divisor > 0) ?  (-1 * (long)dividend) < divisor : (dividend<0 && divisor <0)? (-1 *(long)dividend) < (-1 * (long)divisor) :   dividend < divisor)
                return 0;
            if((dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0)? dividend == -divisor : dividend == divisor)
                return (dividend >0 && divisor < 0) || (dividend < 0 && divisor > 0) ? -1 : 1;
            if (dividend >= int.MaxValue)
            {
                var firstPart = DivideUsingBitWiseOPerator(dividend - Absolute(divisor), divisor);
                var secondPart = DivideUsingBitWiseOPerator(Absolute(divisor), divisor);
                if (firstPart > 0 && secondPart > 0)
                {
                    return (long)firstPart + (long)secondPart >= int.MaxValue ? int.MaxValue : firstPart + secondPart;
                }
                else if (firstPart < 0 && secondPart < 0)
                {
                    return (long)firstPart + (long)secondPart <= int.MinValue ? int.MinValue : firstPart + secondPart;
                }
                else
                    return firstPart + secondPart;
            }
            if (dividend <= int.MinValue)
            {
                var firstPart = DivideUsingBitWiseOPerator(dividend + Absolute(divisor), divisor);
                var secondPart = DivideUsingBitWiseOPerator((-1)*Absolute(divisor), divisor);
                if (firstPart > 0 && secondPart > 0)
                {
                    return ((long)firstPart + (long)secondPart) >= int.MaxValue ? int.MaxValue : firstPart + secondPart;
                }
                else if (firstPart < 0 && secondPart < 0)
                {
                    return ((long)firstPart + (long)secondPart) <= int.MinValue ? int.MinValue : firstPart + secondPart;
                }
                else
                    return firstPart + secondPart;
            }
            
            int qoutient = 0;
            int shift;
   
            for (int i = 31; i > -1 ; i--)
            {
                shift = (long) positiveDivisor << i >= int.MaxValue ? int.MaxValue : positiveDivisor << i;
                if (shift <= positiveDividend)
                {
                    positiveDividend -= shift;
                    qoutient +=  1 << i > 0 ? 1 << i : int.MaxValue;
                }
            }
            return (dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0) ? -qoutient : qoutient;
        }
        private static int Absolute(int num)
        {
            return num < 0 ? num <= int.MinValue? int.MaxValue :  -num : num >= int.MaxValue? int.MaxValue :  num;
        }
        private static int Limit(int num)
        {
            if (num >= int.MaxValue)
                return int.MaxValue;
            if (num <= int.MinValue)
                return int.MinValue;
            return num;
        }
    }
}
