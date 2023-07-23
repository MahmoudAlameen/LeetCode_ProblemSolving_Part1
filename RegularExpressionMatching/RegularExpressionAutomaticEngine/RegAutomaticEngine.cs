using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ProblemSolving_FirstWeek.RegularExpressionMatching.RegularExpressionAutomaticEngine
{
    /*
 steps of solution:-
 1- create method for creating RegAutomaticEngine
 2- create method  that take RegAutomaticEngine and string 
            return true if string matched false other wise
 RegAutomaticEngine has state and arrows
each arrow belong to state and directed to specefic state 
there is base states : -
 start state 
 finite state 
string should take path from start state and arrive to finite state to be acepted as matched 
other wise will be considered as not matched 
 */
    public class RegAutomaticEngine
    {
        private string Pattern { get; set; }
        private State StartState { get; set; }
        private State FiniteState { get; set; }
        public RegAutomaticEngine(string pattern)
        {
            Pattern = pattern;
            BuildRegAutomaticEngine();
        }
        void BuildRegAutomaticEngine()
        {
            StartState = new State('S', new List<TransferPath> { new TransferPath(StartState) });
            FiniteState = new State('F');
            List<TransferPath> backPaths = new List<TransferPath>();
            // add to backPaths list transferPaths of StartState and this is startiing point for our RegAutomaticEngine
            backPaths.AddRange(StartState.TransferPaths);
            State newState;
            for (int index = 0; index < Pattern.Length; index++)
            {
                newState = new State(Pattern[index]);
                LinkStateToEngine(backPaths, newState);
                var newStatePath = new TransferPath(newState);
                newState.TransferPaths.Add(newStatePath);
                if (!IsLetterFollowedByAstrec(Pattern, index))
                {
                    backPaths.Clear();
                    backPaths.AddRange(newState.TransferPaths);
                }
                else
                {
                    var newelyCreatedPaths = AddTransferPath(backPaths.Select(p => p.SourceState).ToList(), null);
                    newState.TransferPaths.Add(new TransferPath(newState, newState));
                    backPaths.Clear();
                    backPaths.AddRange(newelyCreatedPaths);
                    backPaths.Add(newStatePath);
                    index++;
                }
            }
            foreach (var path in backPaths)
                path.DestinationState = FiniteState;
        }
        public bool StartAutomaticEngine(string s)
        {
            State CurrentState = StartState;
            bool charIsMatched = false;
            for(int index = 0; index < s.Length; index++)
            {
                var currentChar = s[index];
                charIsMatched = false;
                foreach (var transferPath in CurrentState.TransferPaths)
                {
                    if (transferPath.DestinationState.Letter == currentChar || transferPath.DestinationState.Letter == '.')
                    {
                        CurrentState = transferPath.DestinationState;
                        charIsMatched = true;
                        break;
                    }
                }
                if(!charIsMatched)
                    return false;
            }
            return CurrentState.TransferPaths.Any(p => p.DestinationState == FiniteState); 
        }
        // check that current letter is folowed by (*) or not 
        bool IsLetterFollowedByAstrec(string pattern, int index)
        {
            return index < pattern.Length - 1 && pattern[index + 1] == '*';
        }
        void LinkStateToEngine(List<TransferPath> backPaths, State state)
        {
            foreach(var transferPath in backPaths)
            {
                transferPath.DestinationState = state;
            }
        }
        List<TransferPath> AddTransferPath(List<State> sourceStates, State destinationState)
        {
            List<TransferPath> newelyCreatedPaths = new List<TransferPath>();
            foreach (var sourceState in sourceStates)
            {
                var transferPath = new TransferPath(sourceState);
                transferPath.DestinationState = destinationState;
                sourceState.TransferPaths.Add(transferPath);
                newelyCreatedPaths.Add(transferPath);
            }
            return newelyCreatedPaths;
        }

    }
}
