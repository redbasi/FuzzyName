using System.Text.RegularExpressions;

namespace FuzzyNameMatch.Matching.Processors
{
    class RemoveNonPrintingChars : IPreProcessor
    {
        public void Process<T>(Matchable<T> input)
        {
            input.MatchData = Regex.Replace(input.MatchData, @"\p{C}+", string.Empty);
        }
    }
}
