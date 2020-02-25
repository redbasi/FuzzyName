using System.Collections.Generic;
using System.Linq;

namespace FuzzyNameMatch.Data
{
    public static class Data
    {
        public static IEnumerable<string> GetNames(string path)
        {
            int counter = 0;

            // Read the file and display it line by line.  
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                    yield return line;
                }

                file.Close();
            }

            System.Console.WriteLine($"There were {counter} names.");
        }

        public static IEnumerable<(string, string[])> GetNicknames(string path)
        {
            int counter = 0;

            // Read the file and display it line by line.  
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                string[] lineArray;

                while ((lineArray = file.ReadLine()?.Split(',')) != null)
                {
                    counter++;
                    yield return (lineArray[0], lineArray.Skip(1).ToArray());
                }

            }
            System.Console.WriteLine($"There were {counter} nicknames.");
        }
    }
}
