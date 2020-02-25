namespace FuzzyNameMatch.Matching.Processors
{
    class Trim : IPreProcessor
    {
        public void Process<T>(Matchable<T> input)
        {
            input.MatchData = input.MatchData.Trim();
        }
    }
}
