using System.Collections.Generic;
using System.Linq;

namespace FuzzyNameMatch.Matching.Algorithms
{
    /// <summary>
    /// This algorithm is used to match an inputed name to a nickname
    /// </summary>
    public class NameIsNickname : INamePartMatchAlgorithm
    {
        public Dictionary<string, string[]> Nicknames { get; private set; }

        public NameIsNickname(Dictionary<string, string[]> nicknames)
        {
            Nicknames = nicknames;
        }

        public IEnumerable<Matchable<TY>> Match<TX, TY>(Matchable<TX> toMatch,
            IEnumerable<Matchable<TY>> possibleMatches)
        {
            var possibleNames = Nicknames.Where(x => x.Value.Contains(toMatch.MatchData)).Select(x => x.Key).ToList();

            foreach (var possibleMatch in possibleMatches)
            {
                if (possibleNames.Contains(possibleMatch.MatchData, Nicknames.Comparer))
                {
                    yield return possibleMatch;
                }
            }
        }


        public class Nickname
        {
            public Nickname(string name, string[] altNames)
            {
                Name = name;
                AltNames = altNames;
            }

            public string Name { get; set; }

            public string[] AltNames { get; set; }
        }
    }
}
