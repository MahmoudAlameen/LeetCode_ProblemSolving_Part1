using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Binary
{
    public class BinaryOperations
    {
        public static List<int> CountOnes(int num)
        {
            var binary = ConverToBinary(num);
            List<int> list = new List<int>();
            list.Add(0);
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    list[i]++;
                    list.Add(i+1);
                }
            }
            return list;
        }
        public static string ConverToBinary(int num)
        {
            StringBuilder binary = new StringBuilder();
            int mod = 0;
            while (num > 0)
            {
                mod = num % 2;
                binary.Insert(0, Convert.ToString(mod));
                num = num / 2;
            }
            return binary.ToString();
        }

        public int[] GetPrefixXOR(int[] arr)
        {
            int[] prefixXOR = new int[arr.Length];
            prefixXOR[0] = arr[0];

            for (int i = 1; i < prefixXOR.Length; i++)
            {
                prefixXOR[i] = prefixXOR[i - 1] ^ arr[i];
            }
            return prefixXOR;
        }

        public int[] GetOriginalArrayFormPXOR(int[] pXOR)
        {
            int[] arr = new int[pXOR.Length]; 
            arr[0] = pXOR[0];

            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = pXOR[i] ^ arr[i - 1];
            }
            return arr;
        }
    }
}
