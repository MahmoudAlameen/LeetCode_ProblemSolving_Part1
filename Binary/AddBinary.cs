using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Binary
{
    public class BinaryMath
    {
        public string AddBinary(string a, string b)
        {
            int l = a.Length > b.Length ? a.Length : b.Length;
            int aIndex = a.Length - 1;
            int bIndex = b.Length - 1;
            StringBuilder result = new StringBuilder();
            char? carry = null;
            while (aIndex >= 0 || bIndex >= 0)
            {
                char b1 = aIndex >= 0 ? a[aIndex] : '0';
                char b2 = bIndex >= 0 ? b[bIndex] : '0';
                result.Insert(0,AddTwoBinaryDigits(b1, b2, ref carry));
                aIndex--;
                bIndex--;
            }
            if (carry != null)
                result.Insert(0,carry);

            return result.ToString(); 
        }
        private char AddTwoBinaryDigits(char b1, char b2, ref char? Carry)
        {
            if (b1 == 'n' && b2 == 'n')
                return 'n';

            if (Carry.HasValue)
            {
                if (b1 == '0' && b2 == '0')
                {
                    Carry = null;
                    return AddTwoBinaryDigits('0', '1', ref Carry);
                }
                if (b1 == '1' && b2 == '1')
                {
                    return '1';
                }
                return '0';
            }
            else
            {
                if (b1 == '0' && b2 == '0')
                    return '0';
                if (b1 == '1' && b2 == '1')
                {
                    Carry = '1';
                    return '0';
                }
                return '1';
            }

        }
    }
}
