using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CsvDemo
{
    static class Helpers
    {
        /// <summary>
        /// Print data to Console with optional header
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="bannerText"></param>
        public static void PrintData<T>(IEnumerable<T> data, string bannerText = null)
        {
            if (bannerText != null)
            {
                Console.WriteLine($"=== {bannerText} ===");
            }
            foreach (var line in data)
            {
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Get records from file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<T> GetRecords<T>(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<T>().ToList();
        }

        /// <summary>
        /// Write records to file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="records"></param>
        /// <param name="path"></param>
        public static void WriteRecords<T>(IEnumerable<T> records, string path)
        {
            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
        }
    }
}
