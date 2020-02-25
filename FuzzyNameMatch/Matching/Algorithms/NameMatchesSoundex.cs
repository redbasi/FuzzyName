using System.Collections.Generic;

namespace FuzzyNameMatch.Matching.Algorithms
{
    public class NameMatchesSoundex : INamePartMatchAlgorithm
    {
        public IEnumerable<Matchable<TY>> Match<TX, TY>(Matchable<TX> toMatch,
            IEnumerable<Matchable<TY>> possibleMatches)
        {
            var nameSoundex = ExternalCode.Soundex.For(toMatch.MatchData);

            foreach (var possibleMatch in possibleMatches)
            {
                if (nameSoundex == ExternalCode.Soundex.For(possibleMatch.MatchData))
                {
                    yield return possibleMatch;
                }
            }
        }
    }
}
