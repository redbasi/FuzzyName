namespace FuzzyNameMatch.Matching
{
    public static class MatchableExtensions
    {
        /// <summary>
        /// Wraps an object so that it can be used for matching
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="matchData">The string data to use for matching</param>
        /// <returns></returns>
        public static Matchable<T> AsMatchableOn<T>(this T item, string matchData)
        {
            return new Matchable<T>(item, matchData);
        }
    }
}