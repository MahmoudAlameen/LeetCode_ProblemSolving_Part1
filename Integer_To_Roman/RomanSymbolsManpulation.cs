using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Integer_To_Roman
{
    public class RomanSymbolsManpulation
    {
        public record RomanSymbol(int Value, string Symbol);

        RomanSymbol[] RomanSymbols = new RomanSymbol[] { new (1, "I"), new (5, "V"), new (10, "X"),
        new (50, "L"), new (100, "C"), new (500, "D"), new (1000, "M")};

        RomanSymbol[] SubtractiveForms = new RomanSymbol[] { new(4, "IV"), new (9, "IX"), new (40,"XL"),
        new (90, "XC"), new (400,"CD"), new(900, "CM")};
        public string IntToRoman(int num)
        {
            var numbers = GetNumbersByDecimalPlaces(num);
            numbers.Reverse();
            return ConvertToRoman(numbers);

        }

        private string ConvertToRoman(List<int> numbers)
        {
            StringBuilder roman = new StringBuilder();
            foreach (var number in numbers)
                roman.Append(ConvertToRoman(number));

            return roman.ToString();
        }
        private string ConvertToRoman(int number)
        {
            foreach (var romanSymbol in SubtractiveForms)
            {
                if (number == romanSymbol.Value)
                {
                    return romanSymbol.Symbol;
                }
            }

            foreach (var romanSymbol in RomanSymbols.Reverse().ToList())
            {
                if (number == romanSymbol.Value)
                    return romanSymbol.Symbol;

                if (number > romanSymbol.Value)
                {
                    return romanSymbol.Symbol + ConvertToRoman(number - romanSymbol.Value);
                }
            }
            return "1";
        }

        private List<int> GetNumbersByDecimalPlaces(int num)
        {
            int mod;
            int decimalPlace = 1;
            List<int> numbersResult = new List<int>();
            while (num > 10)
            {
                mod = num % 10;
                if(mod != 0)
                    numbersResult.Add(mod * decimalPlace);

                decimalPlace = decimalPlace * 10;
                num = num / 10;
            }
            numbersResult.Add(num * decimalPlace);
            return numbersResult;
        }
        private int getFirstDigitOnTheLeft(int num)
        {
            while (num > 9)
            {
                num = num / 10;
            }
            return num;
        }
    }
}
