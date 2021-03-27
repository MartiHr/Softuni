using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> populationByCity = new Dictionary<string, int>();
            Dictionary<string, int> goldByCity = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Sail")
                {
                    break;
                }

                string[] elements = command
                    .Split("||");

                string city = elements[0];
                int population = int.Parse(elements[1]);
                int gold = int.Parse(elements[2]);

                if (populationByCity.ContainsKey(city))
                {
                    populationByCity[city] += population;
                    goldByCity[city] += gold;
                }
                else
                {
                    populationByCity.Add(city, population);
                    goldByCity.Add(city, gold);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] elements = command
                    .Split("=>");

                if (elements[0] == "Plunder")
                {
                    string city = elements[1];
                    int people = int.Parse(elements[2]);
                    int gold = int.Parse(elements[3]);

                    goldByCity[city] -= gold;
                    populationByCity[city] -= people;

                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (goldByCity[city] == 0 || populationByCity[city] == 0)
                    {
                        goldByCity.Remove(city);
                        populationByCity.Remove(city);

                        Console.WriteLine($"{city} has been wiped off the map!");
                    }
                }
                else
                {
                    string city = elements[1];
                    int gold = int.Parse(elements[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    goldByCity[city] += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {goldByCity[city]} gold.");

                }
            }

            if (goldByCity.Count > 0)
            {
                goldByCity = goldByCity
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"Ahoy, Captain! There are {goldByCity.Count} wealthy settlements to go to:");

                foreach (var city in goldByCity)
                {
                    Console.WriteLine($"{city.Key} -> Population: {populationByCity[city.Key]} citizens, Gold: {city.Value} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
}
