namespace FuzzyNameMatch.Matching
{
    public class Matchable<T> : IMatchable
    {
        public Matchable(T value, string matchData)
        {
            Value = value;
            MatchData = matchData;
        }

        public T Value { get; private set; }

        public string MatchData { get; set; }
    }
}
