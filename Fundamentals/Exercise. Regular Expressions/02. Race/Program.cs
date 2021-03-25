using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> competitors = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, x => 0);

            Regex textRegex = new Regex(@"[A-Za-z]+");
            Regex numbersRegex = new Regex(@"[0-9]");

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of race")
                {
                    break;
                }

                MatchCollection textMatch = textRegex.Matches(line);
                MatchCollection numbersMatch = numbersRegex.Matches(line);

                string name = string.Empty;
                int sum = 0;

                foreach (Match letter in textMatch)
                {
                    name += letter.Value;
                }

                foreach (Match number in numbersMatch)
                {
                    sum += int.Parse(number.Value);
                }

                if (competitors.ContainsKey(name))
                {
                    competitors[name] += sum;
                }
            }

            string[] winners = competitors
                .OrderByDescending(c => c.Value)
                .Take(3)
                .Select(c => c.Key)
                .ToArray();

            Console.WriteLine($"1st place: {winners[0]}");
            Console.WriteLine($"2nd place: {winners[1]}");
            Console.WriteLine($"3rd place: {winners[2]}");
        }
    }
}
