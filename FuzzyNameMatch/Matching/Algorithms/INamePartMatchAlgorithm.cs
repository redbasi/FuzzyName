using System.Collections.Generic;

namespace FuzzyNameMatch.Matching.Algorithms
{
    public interface INamePartMatchAlgorithm
    {
        IEnumerable<Matchable<TY>> Match<TX, TY>(Matchable<TX> toMatch, IEnumerable<Matchable<TY>> possibleMatches);
    }
}
