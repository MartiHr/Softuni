using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:^| )\+359(-| )2\1\d{3}\1\d{4}\b";

            string phones = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phones, pattern);

            string[] matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
