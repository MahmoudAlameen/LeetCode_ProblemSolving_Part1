using LeetCode_ProblemSolving_FirstWeek._1_Longest_Substring;
using LeetCode_ProblemSolving_FirstWeek._2_palindromic_SubString;
using LeetCode_ProblemSolving_FirstWeek.Palindrome_Number;
using LeetCode_ProblemSolving_FirstWeek.RegularExpressionMatching.RegularExpressionAutomaticEngine;
using LeetCode_ProblemSolving_FirstWeek.Reverse_Integer;
using LeetCode_ProblemSolving_FirstWeek.Zigzag_Conversion;
using LeetCode_ProblemSolving_FirstWeek.RegularExpressionMatching;
using System.Collections;

namespace LeetCode_ProblemSolving_FirstWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Console.WriteLine("Hello, World!");
            //  CircularQueue q = new CircularQueue(5);
            // q.PrintQueue();
            // Console.WriteLine("****************");
            // q.Push(5);
            // q.Pop();
            // q.Push(2);
            // q.Push(3);
            // q.Push(7);
            // q.Push(12);
            // q.Pop();
            // q.PrintQueue();
            //Console.WriteLine(q.IfExist(5));
            // Console.WriteLine(q.GetQueueCount());
            // String s = "reifadyqgztixemwswtccodfnchcovrmiooffbbijkecuvlvukecutasfxqcqygltrogrdxlrslbnzktlanycgtniprjlospzhhgdrqcwlukbpsrumxguskubokxcmswjnssbkutdhppsdckuckcbwbxpmcmdicfjxaanoxndlfpqwneytatcbyjmimyawevmgirunvmdvxwdjbiqszwhfhjmrpexfwrbzkipxfowcbqjckaotmmgkrbjvhihgwuszdrdiijkgjoljjdubcbowvxslctleblfmdzmvdkqdxtiylabrwaccikkpnpsgcotxoggdydqnuogmxttcycjorzrtwtcchxrbbknfmxnonbhgbjjypqhbftceduxgrnaswtbytrhuiqnxkivevhprcvhggugrmmxolvfzwadlnzdwbtqbaveoongezoymdrhywxcxvggsewsxckucmncbrljskgsgtehortuvbtrsfisyewchxlmxqccoplhlzwutoqoctgfnrzhqctxaqacmirrqdwsbdpqttmyrmxxawgtjzqjgffqwlxqxwxrkgtzqkgdulbxmfcvxcwoswystiyittdjaqvaijwscqobqlhskhvoktksvmguzfankdigqlegrxxqpoitdtykfltohnzrcgmlnhddcfmawiriiiblwrttveedkxzzagdzpwvriuctvtrvdpqzcdnrkgcnpwjlraaaaskgguxzljktqvzzmruqqslutiipladbcxdwxhmvevsjrdkhdpxcyjkidkoznuagshnvccnkyeflpyjzlcbmhbytxnfzcrnmkyknbmtzwtaceajmnuyjblmdlbjdjxctvqcoqkbaszvrqvjgzdqpvmucerumskjrwhywjkwgligkectzboqbanrsvynxscpxqxtqhthdytfvhzjdcxgckvgfbldsfzxqdozxicrwqyprgnadfxsionkzzegmeynye";
            //String s2 = "ghgkh";
            ////Console.WriteLine( Palindromic.FastLongestPalindrome(s));
            //string s = "AB";
            //Console.WriteLine( zigzagConversion.Convert(s,1));
            //Console.WriteLine( StringToInteger.MyAtoi("-2147483647"));
            //Console.WriteLine(PalindromeNumber.IsPalindrome(5452346));
            //RegAutomaticEngine regEx = new RegAutomaticEngine("ab*c*.cd");
            //Console.WriteLine(regEx.StartAutomaticEngine("ackcd"));
            Console.WriteLine(RegularExpression.IsMatch("ackcd", "ab*c*.cd"));
        }
    }
}