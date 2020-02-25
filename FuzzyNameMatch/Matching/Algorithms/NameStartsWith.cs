using System;
using System.Collections.Generic;

namespace FuzzyNameMatch.Matching.Algorithms
{

    /// <summary>
    /// Matches names that have been truncated
    /// </summary>
    public class NameStartsWith : INamePartMatchAlgorithm
    {
        private StringComparison ComparisonType { get; set; }

        public NameStartsWith(StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            ComparisonType = comparisonType;
        }

        public IEnumerable<Matchable<TY>> Match<TX, TY>(Matchable<TX> toMatch,
            IEnumerable<Matchable<TY>> possibleMatches)
        {
            foreach (var possibleMatch in possibleMatches)
            {
                if (possibleMatch.MatchData.StartsWith(toMatch.MatchData, ComparisonType))
                {
                    yield return possibleMatch;
                }
            }
        }
    }
}
