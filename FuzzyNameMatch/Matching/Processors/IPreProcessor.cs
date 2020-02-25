namespace FuzzyNameMatch.Matching.Processors
{
    public interface IPreProcessor
    {
        void Process<T>(Matchable<T> input);
    }
}
