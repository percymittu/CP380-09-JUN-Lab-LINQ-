using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BenfordLab
{

    public class BenfordLaw
    {
        public static void Main()
        {
            var csvFilePath = "./world-population-by-country.csv";

            foreach (var i in Benford.calculateBenford(csvFilePath))
            {
                Console.WriteLine($"{i.Digit},{i.Count}");
            }
        }
    }
}