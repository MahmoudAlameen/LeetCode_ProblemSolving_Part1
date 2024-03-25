using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Generate_Parentheses
{
    public static class Parentheses
    {
        public static IList<string> GenerateParenthesis(int n)
        {
            if (n == 1)
                return new List<string>() { "()" };

            List<string> parenthesesResult = new List<string>();
            parenthesesResult.Add(GenerateFirstGroup(n));

            for (int j = 1; j < n; j++)
            {
                var groupList = GenerateParenthesis(j);
                foreach (var item in groupList)
                {
                    for (int numRepeated = 1; numRepeated < n; numRepeated++)
                    {
                        for (int k = 0; k < n - j; k++)
                        {
                            parenthesesResult.Add(CreateParenthesesGroup(n - j - numRepeated , item, k, numRepeated));
                        }
                    }
                }
             }
            return parenthesesResult;
        }

        private static string CreateParenthesesGroup(int n, string generatedSubGroup, int index, int numRepeated)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                if (i >= index && i <= numRepeated)
                    result.Append($"({generatedSubGroup})");
                else
                    result.Append("()");
            }
            return result.ToString();
        }
        private static string GenerateFirstGroup(int n)
        {
            StringBuilder firstGroup = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                firstGroup.Append("()");
            }
            return firstGroup.ToString();   
        }
        private static char[] Swap(char[] arr, int index1, int index2)
        {
            var result = new char[arr.Length];
            for(int i = 0; i < arr.Length; i++)
                result[i] = arr[i];
            var temp = result[index1];
            result[index1] = result[index2];
            result[index2] = temp;
            return result;
        }
        private static string getCharsString(char[] chars)
        {
            StringBuilder s = new StringBuilder();
            for(int i=0; i< chars.Length; i++)  
                s.Append(chars[i]); 
            return s.ToString();    
        }
    }
}
