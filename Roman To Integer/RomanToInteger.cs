using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Roman_To_Integer
{
    public static class RomanToInteger
    {
        public static int RomanToInt(string s)
        {
            Roman[] romanNumerals = new Roman[7];
            romanNumerals[0] = new Roman { Num = 1, RomanNumeral = 'I' };
            romanNumerals[1] = new Roman { Num = 5, RomanNumeral = 'V' };
            romanNumerals[2] = new Roman { Num = 10, RomanNumeral = 'X' };
            romanNumerals[3] = new Roman { Num = 50, RomanNumeral = 'L' };
            romanNumerals[4] = new Roman { Num = 100, RomanNumeral = 'C' };
            romanNumerals[5] = new Roman { Num = 500, RomanNumeral = 'D' };
            romanNumerals[6] = new Roman { Num = 1000, RomanNumeral = 'M' };

            int[] numbers = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                var number = romanNumerals.Where(r => r.RomanNumeral == s[i]).Select(r => r.Num).First();
                numbers[i] = number;
            }
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i+1 < numbers.Length && numbers[i] < numbers[i + 1])
                {
                    result += numbers[i + 1] - numbers[i];
                    i++;
                }       
                else
                    result += numbers[i];
            }
            return result;
        }
    }
    public class Roman
    {
        public int Num { get; set; }
        public char RomanNumeral { get; set; }
    }
}
