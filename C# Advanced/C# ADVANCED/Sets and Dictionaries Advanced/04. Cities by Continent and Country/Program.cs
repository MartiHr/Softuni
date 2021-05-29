using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> citiesByContinentAndCountry = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = elements[0];
                string country = elements[1];
                string city = elements[2];

                if (!citiesByContinentAndCountry.ContainsKey(continent))
                {
                    citiesByContinentAndCountry.Add(continent, new Dictionary<string, List<string>>()); 
                }

                if (!citiesByContinentAndCountry[continent].ContainsKey(country))
                {
                    citiesByContinentAndCountry[continent].Add(country, new List<string>());
                }

                citiesByContinentAndCountry[continent][country].Add(city);
            }

            foreach (var continent in citiesByContinentAndCountry)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
