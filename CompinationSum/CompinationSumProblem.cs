using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.CompinationSum
{
    public static class CompinationSumProblem
    {
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            candidates = candidates.OrderBy(x => x).ToArray();
            List<CandidateNode> candidateNodes = new List<CandidateNode>();
            foreach (var candidate in candidates)
            {
                var newTarget = target - candidate;
                if (newTarget >= 0)
                    candidateNodes.Add(new CandidateNode
                    {
                        Target = newTarget,
                        Candidate = candidate
                    });
            }
            return GetCombinationSum(candidates, candidateNodes);
        }
        public static IList<IList<int>> GetCombinationSum(int[] candidates, List<CandidateNode> CandidatesNodes)
        {
            IList<IList<int>> compinations = new List<IList<int>>();

            for (int nodeIndex = 0; nodeIndex < CandidatesNodes.Count; nodeIndex++)
            {
                var candidateNode = CandidatesNodes[nodeIndex];

                // base case for one node in list 
                if (candidateNode.Target == 0)
                {
                    compinations.Add(ExtractCompinationsFromNodes(candidateNode));
                    continue;
                }

                var newCandidatesNodes = new List<CandidateNode>();
                for (int candidateIndex = nodeIndex; candidateIndex < candidates.Length; candidateIndex++)
                {
                    var newTarget = candidateNode.Target - candidates[candidateIndex];
                    if (newTarget >= 0)
                    {
                        var newNode = new CandidateNode
                        {
                            Candidate = candidates[candidateIndex],
                            Target = newTarget,
                            Previous = candidateNode,
                        };
                        candidateNode.NextNodes.Add(newNode);
                    }
                    else
                        break;
                }

                if (candidateNode.NextNodes == null || candidateNode.NextNodes.Count == 0)
                    continue;

                var compinationList = GetCombinationSum(candidates.Skip(nodeIndex).ToArray(), candidateNode.NextNodes);
                foreach (var compination in compinationList)
                {
                    compinations.Add(compination);
                }
            }
            return compinations;
        }

        public static IList<IList<int>> CombinationSumWithoutCandidatesDuplication(int[] candidates, int target)
        {
            candidates = candidates.OrderBy(x => x).ToArray();
            List<CandidateNode> candidateNodes = new List<CandidateNode>();
            for (int candidateIndex = 0; candidateIndex < candidates.Length; candidateIndex++)
            {
                if (candidateIndex > 0 && candidates[candidateIndex] == candidates[candidateIndex -1])
                    continue;
                var newTarget = target - candidates[candidateIndex];
                if (newTarget >= 0)
                    candidateNodes.Add(new CandidateNode
                    {
                        Target = newTarget,
                        Candidate = candidates[candidateIndex],
                        CandidateIndex = candidateIndex
                    });
            }
            return GetCombinationSumWithoutDuplicatiion(candidates, candidateNodes);
        }

        public static IList<IList<int>> GetCombinationSumWithoutDuplicatiion(int[] candidates, List<CandidateNode> CandidatesNodes)
        {
            IList<IList<int>> compinations = new List<IList<int>>();

            for (int nodeIndex = 0; nodeIndex < CandidatesNodes.Count; nodeIndex++)
            {
                if (nodeIndex > 0 && CandidatesNodes[nodeIndex].Candidate == CandidatesNodes[nodeIndex - 1].Candidate)
                    continue;
                var candidateNode = CandidatesNodes[nodeIndex];

                // base case for one node in list 
                if (candidateNode.Target == 0)
                {
                    compinations.Add(ExtractCompinationsFromNodes(candidateNode));
                    continue;
                }

                var newCandidatesNodes = new List<CandidateNode>();
                for (int candidateIndex = candidateNode.CandidateIndex.Value +1; candidateIndex < candidates.Length; candidateIndex++)
                {
                    var newTarget = candidateNode.Target - candidates[candidateIndex];
                    if (newTarget >= 0)
                    {
                        var newNode = new CandidateNode
                        {
                            Candidate = candidates[candidateIndex],
                            Target = newTarget,
                            Previous = candidateNode,
                            CandidateIndex = candidateIndex
                        };
                        candidateNode.NextNodes.Add(newNode);
                    }
                    else
                        break;
                }

                if (candidateNode.NextNodes == null || candidateNode.NextNodes.Count == 0)
                    continue;

                var compinationList = GetCombinationSumWithoutDuplicatiion(candidates.Skip(candidateNode.CandidateIndex.Value).ToArray(), candidateNode.NextNodes);
                foreach (var compination in compinationList)
                {
                    compinations.Add(compination);
                }
            }
            return compinations;
        }
        public static List<int> ExtractCompinationsFromNodes(CandidateNode candidateNode)
        {
            List<int> compination = new List<int>();
            compination.Add(candidateNode.Candidate);

            while (candidateNode.Previous != null)
            {
                candidateNode = candidateNode.Previous; 
                compination.Add(candidateNode.Candidate);
            }
            return compination;
        }



        // Combination Sum ||
        public static IList<IList<int>> CompinationSum2(int[] candidates, int target)
        {
            candidates = candidates.OrderBy(x => x).ToArray();
            IList<IList<int>> compinations= new List<IList<int>>();

            for (int i = 0; i < candidates.Length; i++)
            {
                var candidate = candidates[i];
                var newTarget = target - candidate;
                if (i > 0 && candidate == candidates[i - 1])
                    continue;
                if (newTarget == 0)
                {
                    compinations.Add(new List<int> { candidate });
                    continue;
                }
                if (newTarget < 0)
                    break;
                if(newTarget > 0)
                {
                    var compinationsResult = CompinationSum2(candidates.Skip(i + 1).ToArray(), newTarget);
                    if(compinationsResult == null || compinationsResult.Count == 0)
                        continue;

                    AddCandidateToCompinations(candidate, compinationsResult);
                    foreach(var compination in compinationsResult)
                        compinations.Add(compination);

                }
            }

            return compinations;
        }
        private static void AddCandidateToCompinations(int candidate , IList<IList<int>> compinations)
        {

            foreach (var compination in compinations)
            {
                compination.Add(candidate);
            }
        }
    }
}

