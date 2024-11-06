﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Math0
{
    public static class Power
    {
        public static double MyPow(double x, int n)
        {
            if (x == 1)
                return x;
            if (x == -1)
                return 1;
            if (n == 0)
                return 1;
            long pow = n;
            if (n < 0)
            {
                pow = (long)n * -1;
                return 1 / PowWithLoop(x, pow);

            }
            else
            {
                return PowWithLoop(x, pow);
            }
        }

        private static double PowWithLoop(double x, long pow)
        {
            double result = 1;
            while (pow >= 1)
            {
                result *= x;
                pow--;
            }

            return result;
        }
        private static double Pow(double baseNum, double result, int n)
        {
            if (n < 1)
                return result;
            return Pow(baseNum, result * baseNum, n-1);    
        }
        public static double FastPowRun(double x, int n)
        {
            long pow = n;
            if (n < 0)
            {
                pow = (long)n * -1;
                return 1 / FastPow(x, pow);

            }
            else
            {
                return FastPow(x, pow);
            }
        }
        private static double FastPow(double x, long n)
        {
            if (n == 0)
                return 1;

            if (n == 2)
                return x * x;
            if (n % 2 == 0)
                return FastPow(FastPow(x, n / 2), 2);
            return x * FastPow(FastPow(x, n/2), 2);
        }
    }
}
