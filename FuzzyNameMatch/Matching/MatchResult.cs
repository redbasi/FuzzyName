using FuzzyNameMatch.Matching.MetricGenerator;

namespace FuzzyNameMatch.Matching
{
    public class MatchResult<T>
    {
        public MatchResult(Matchable<T> match)
        {
            Match = match;
            Metric = 0;
        }

        public MatchResult(Matchable<T> match, IMatchable original, IMetricGenerator metricGenerator)
        {
            Match = match;
            Metric = metricGenerator.GenerateMetric(match, original);
        }

        public Matchable<T> Match { get; private set; }

        public int Metric { get; private set; }

        public override string ToString()
        {
            return $"Match: {Match}, Metric: {Metric}";
        }
    }
}