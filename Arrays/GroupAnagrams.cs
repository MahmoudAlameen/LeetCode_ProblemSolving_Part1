using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Arrays
{
    public static class GroupAnagram
    {
        //public static IList<IList<string>> GroupAnagrams(string[] strs)
        //{
        //    IList<IList<string>> anagramsGroups = new List<IList<string>>();
        //    List<string> groupsCharsFrequency = new List<string>();

        //    bool isAddedToAnagramGroup = false;
        //    for (int i = 0; i < strs.Length; i++)
        //    {
        //        isAddedToAnagramGroup = false;
        //        string strCharsFrequency = GetCharsFrequency(strs[i]);
        //        for (int groupIndex = 0; groupIndex < anagramsGroups.Count; groupIndex++)
        //        {
        //            if (IsTwoStringsAnagrams(strCharsFrequency, groupsCharsFrequency[groupIndex]))
        //            {
        //                anagramsGroups[groupIndex].Add(strs[i]);
        //                isAddedToAnagramGroup = true;
        //                break;
        //            }
        //        }

        //        if (!isAddedToAnagramGroup)
        //        {
        //            anagramsGroups.Add(new List<string> { strs[i] });
        //            groupsCharsFrequency.Add(GetCharsFrequency(strs[i]));
        //        }
        //    }
        //    return anagramsGroups;
        //}
        //public static long GetStrAssicMultiply(List<int> primeNumbers, string str)
        //{
        //    long result = 1;
        //    int prime;
        //    int assci;
            
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        assci = str[i];
        //        prime = primeNumbers[assci - 97];
        //        result *= prime;
        //    }
        //    return result;
        //}
        //private static bool IsTwoStringsAnagrams(string firstCharsFrequency, string secondCharsFrequency)
        //{
        //    return firstCharsFrequency == secondCharsFrequency;
        //}
        //private static  string GetCharsFrequency(string str)
        //{
        //    int[] firstCharsFrequency = new int[26];

        //    foreach (var c in str)
        //    {
        //        int assci = c;
        //        firstCharsFrequency[assci - 97]++;
        //    }
        //    StringBuilder result = new StringBuilder();
        //    foreach (var item in firstCharsFrequency)
        //    {
        //        result.Append(item);
        //        result.Append(",");
        //    }
        //    return result.ToString();
        //}
        //private static List<int> GetFirstNPrimes(int n)
        //{
        //    List<int> primes = new List<int>();
        //    int number = 2; // Start with the first prime number

        //    while (primes.Count < n)
        //    {
        //        if (IsPrime(number))
        //        {
        //            primes.Add(number);
        //        }
        //        number++;
        //    }

        //    return primes;
        //}

        //private static bool IsPrime(int num)
        //{
        //    if (num <= 1)
        //        return false;
        //    if (num == 2)
        //        return true;
        //    if (num % 2 == 0)
        //        return false;

        //    int boundary = (int)Math.Floor(Math.Sqrt(num));

        //    for (int i = 3; i <= boundary; i += 2)
        //    {
        //        if (num % i == 0)
        //            return false;
        //    }

        //    return true;
        //}
    }
}
