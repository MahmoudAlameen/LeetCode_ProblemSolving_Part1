using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Letter_Combinations_of_a_Phone_Number
{
    public static class LetterCompinationPhoneNumber
    {
        public static IList<string> LetterCombinations(string digits)
        {
            var phoneLetters = new string[10] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            List<string> newCompinations = CreateNewCompinations(null, digits.Length > 0 ?  phoneLetters[int.Parse(digits[0].ToString())]  : "");

            for (int i = 1; i < digits.Length; i++)
            {
                newCompinations = CreateNewCompinations(newCompinations, phoneLetters[int.Parse(digits[i].ToString())]);
            }
            return newCompinations;
        }
        private static List<string> CreateNewCompinations(List<string> lastCompinations, string digitLetters)
        {
            List<string> newCompinations = new List<string>();

            if (lastCompinations == null || lastCompinations.Count == 0)
            {
                return digitLetters.Select(l => l.ToString()).ToList();
                
            }

            for (int i = 0; i < lastCompinations.Count; i++)
            {
                foreach (var letter in digitLetters)
                {
                    newCompinations.Add(lastCompinations[i] + letter);
                }
            }
            return newCompinations;
        }
    }
}
