using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> list = new List<string>();

            Regex regex = new Regex(@"([\=\/])(?<location>[A-Z][A-Za-z]{2,})\1");

            MatchCollection locations = regex.Matches(input);

            int travelPoints = 0;

            if (locations.Count > 0)
            {
                foreach (Match location in locations)
                {
                    list.Add(location.Groups["location"].Value);
                    travelPoints += location.Groups["location"].Length;
                }
            }
            
            Console.Write("Destinations: ");

            if (locations.Count > 0)
            {
                Console.WriteLine(String.Join(", ", list));
            }
            else
            {
                Console.WriteLine();
            }
        
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
