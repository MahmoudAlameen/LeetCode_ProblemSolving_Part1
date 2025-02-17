using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.Compinations
{
    public class Compinations
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> Result = new List<IList<int>>();
            BackTrack(1, n, k, new List<int>(), Result);
            return Result;
        }
        public void BackTrack(int start, int n, int k, IList<int> track, IList<IList<int>> Result)
        {
            if (track != null && track.Count >= k)
            {
                Result.Add(track);
                return;
            }   

            List<int> tempTrack = new List<int>();
            for (int i = start; i <= n; i++)
            {
                track.Add(i);
                tempTrack = new List<int>();
                tempTrack.AddRange(track);
                BackTrack(i + 1, n, k, tempTrack, Result);
                track.RemoveAt(track.Count -1);
            }
        }
    }
}
