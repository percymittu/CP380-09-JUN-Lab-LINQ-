using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BenfordLab
{
    public class BenfordData
    {
        public int Digit { get; set; }
        public int Count { get; set; }

        public BenfordData() { }
    }

    public class Benford
    {

        public static BenfordData[] calculateBenford(string csvFilePath)        
        {
            // load the data
            var data = File.ReadAllLines(csvFilePath)
                .Skip(1) // For header
                .Select(s => Regex.Match(s, @"^(.*?),(.*?)$"))
                .Select(data => new
                {
                    Country = data.Groups[1].Value,
                    Population = int.Parse(data.Groups[2].Value)
                });

            var countriesData = data
                                .Select(
                                    countryData => new { 
                                        Country = countryData.Country, 
                                        Digit = FirstDigit.getFirstDigit(countryData.Population) 
                                    })
                                .ToArray();

            var sortCountryWiseCount = countriesData
                                       .GroupBy(country => country.Digit)
                                       .Select(country => (Digit: country.Key, Count: country.Count()))
                                       .OrderByDescending(country => country.Digit).ToArray();

            List<BenfordData> m = new List<BenfordData>();
            foreach (var i in sortCountryWiseCount)
            {
                m.Add(
                    new BenfordData
                    {
                        Digit = i.Digit,
                        Count = i.Count
                    }
                );
            }

            return m.ToArray();
        }
    }
}
