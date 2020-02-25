namespace FuzzyNameMatch.Matching.MetricGenerator
{
    public class DamerauLevenshteinDistance : IMetricGenerator
    {
        public int GenerateMetric(IMatchable match, IMatchable original)
        {
            return ExternalCode.StringDistance.GetDamerauLevenshteinDistance(original.MatchData, match.MatchData);
        }
    }
}
