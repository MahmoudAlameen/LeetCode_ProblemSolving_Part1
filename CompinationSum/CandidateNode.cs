using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.CompinationSum
{
    public class CandidateNode
    {
        public CandidateNode()
        {
            NextNodes = new List<CandidateNode>();  
        }
        public int Candidate { get; set; }
        public int Target { get; set; }
        public List<CandidateNode> NextNodes { get; set; }
        public CandidateNode Previous { get; set; }
        public int? CandidateIndex { get; set; }

    }
}
