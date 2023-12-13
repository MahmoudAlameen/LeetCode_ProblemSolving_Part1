using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Valid_Parentheses
{
    public static class ValidParentheses
    {
        public static bool IsValid(string s)
        {
            List<char> neededCloseBrackets = new List<char>();
            foreach (var bracket in s)
            {
                if (IsOpenBracket(bracket))
                    neededCloseBrackets.Add(GetCorrectCloseBracket(bracket));

                else if (IsCloseBracket(bracket))
                {
                    if (neededCloseBrackets.Count > 0 && neededCloseBrackets[neededCloseBrackets.Count - 1] == bracket)
                        neededCloseBrackets.RemoveAt(neededCloseBrackets.Count - 1);
                    else
                        return false;
                }
                else
                    return false;

            }
            if (neededCloseBrackets.Count > 0)
                return false;
            return true;
        }
        private static char GetCorrectCloseBracket(char openBracket)
        {
            char closeBracket = '}';
            switch (openBracket)
            {
                case '(':
                    closeBracket = ')';
                    break;
                case '{':
                    closeBracket = '}';
                    break;
                case '[':
                    closeBracket = ']';
                    break;
                default:
                    closeBracket = '}';
                    break;
            }
            return closeBracket;
        }
        private static bool IsOpenBracket(char bracket)
        {
            if(bracket == '(' || bracket == '[' || bracket == '{')
                    return true;
            return false;
        }
        private static bool IsCloseBracket(char bracket)
        {
            if (bracket == ')' || bracket == ']' || bracket == '}')
                return true;
            return false;
        }
    }
}
