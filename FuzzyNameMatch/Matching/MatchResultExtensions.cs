using FuzzyNameMatch.Matching.MetricGenerator;
using System.Collections.Generic;

namespace FuzzyNameMatch.Matching
{
    public static class MatchResultExtensions
    {
        public static IEnumerable<MatchResult<T>> GetMatchResults<T>(this IEnumerable<Matchable<T>> matches)
        {
            foreach (var match in matches)
            {
                yield return new MatchResult<T>(match);
            }
        }

        public static IEnumerable<MatchResult<TY>> GetMatchResults<TX, TY>(this IEnumerable<Matchable<TY>> matches,
            Matchable<TX> original, IMetricGenerator metricGenerator)
        {
            foreach (var match in matches)
            {
                yield return new MatchResult<TY>(match, original, metricGenerator);
            }
        }
    }
}
