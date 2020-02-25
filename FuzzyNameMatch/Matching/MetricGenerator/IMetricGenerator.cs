namespace FuzzyNameMatch.Matching.MetricGenerator
{
    public interface IMetricGenerator
    {
        int GenerateMetric(IMatchable match, IMatchable original);
    }
}
