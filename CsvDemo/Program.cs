using FuzzyNameMatch.Matching;
using System;
using System.Collections.Generic;
using System.Linq;
using static CsvDemo.Helpers;


namespace CsvDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the CSV Demo for FuzzyNameMatch!");

            //Default data locations
            string dirtyFilePath = args.ElementAtOrDefault(0) ?? "TestData/dirty.csv";
            string cleanFilePath = args.ElementAtOrDefault(1) ?? "TestData/clean.csv";
            string outputFilePath = args.ElementAtOrDefault(2) ?? "out.csv";

            var dirtyDataPeople = GetRecords<DirtyPerson>(dirtyFilePath);  //Get records from the "Dirty" file
            var cleanDataPeople = GetRecords<CleanPerson>(cleanFilePath);  //Get records from the "Clean" reference file

            PrintData(dirtyDataPeople, "Dirty Data");
            PrintData(cleanDataPeople, "Clean Data");

            //var nicknameDictionary = FuzzyNameMatch.Data.GetNicknames().ToDictionary(x => x.Item1, x => x.Item2, StringComparer.InvariantCultureIgnoreCase);
            //var matcher = new FuzzyNameMatch.Matching.Algorithms.NameIsNickname(nicknameDictionary);

            var matcher = new FuzzyNameMatch.Matching.Algorithms.NameMatchesSoundex();
            var metricGenerator = new FuzzyNameMatch.Matching.MetricGenerator.DamerauLevenshteinDistance();

            var matchedPeople = MatchedPeople(dirtyDataPeople, cleanDataPeople, matcher, metricGenerator).ToList();

            PrintData(matchedPeople, "Output Data");

            WriteRecords(matchedPeople, outputFilePath);
            Console.WriteLine("Records Written to file...");
        }

        private static IEnumerable<OutputPerson> MatchedPeople(List<DirtyPerson> dirtyDataPeople, List<CleanPerson> cleanDataPeople, FuzzyNameMatch.Matching.Algorithms.NameMatchesSoundex matcher, FuzzyNameMatch.Matching.MetricGenerator.DamerauLevenshteinDistance metricGenerator)
        {
            foreach (var cleanDataPerson in cleanDataPeople)
            {
                var toMatch = cleanDataPerson.AsMatchableOn(cleanDataPerson.Name);
                var potentialMatches = dirtyDataPeople.Select(x => x.AsMatchableOn(x.Name));

                var matchResults = matcher
                    .Match(toMatch, potentialMatches)
                    .GetMatchResults(toMatch, metricGenerator)
                    .ToList();

                if (matchResults.Any())
                {
                    var bestMatch = matchResults.OrderBy(x => x.Metric).First().Match.Value;

                    yield return new OutputPerson()
                    {
                        Name = cleanDataPerson.Name,
                        ExistingData = cleanDataPerson.ExistingData,
                        NewData = bestMatch.NewData
                    };
                }
                else
                {
                    yield return new OutputPerson()
                    {
                        Name = cleanDataPerson.Name,
                        ExistingData = cleanDataPerson.ExistingData,
                        NewData = null
                    };
                }
            }
        }
    }
}
