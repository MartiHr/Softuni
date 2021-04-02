using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> rarityByPlant = new Dictionary<string, int>();
            SortedDictionary<string, List<double>> ratingByPlant = new SortedDictionary<string, List<double>>();
            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split("<->");

                string plant= elements[0];
                int rarity = int.Parse(elements[1]);

                if (rarityByPlant.ContainsKey(plant))
                {
                    rarityByPlant[plant] = rarity;
                }
                else
                {
                    rarityByPlant.Add(plant, rarity);
                    ratingByPlant.Add(plant, new List<double> { 0.0 });
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Exhibition")
                {
                    break;
                }

                string[] elements = command
                    .Split(new char[]{ ':', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (elements[0] == "Rate")
                {
                    string plant = elements[1];
                    double rating = double.Parse(elements[2]);

                    List<double> currentList = ratingByPlant[plant];
                    ratingByPlant[plant].Add(rating);
                }
                else if (elements[0] == "Update")
                {
                    string plant = elements[1];
                    int newRarity = int.Parse(elements[2]);

                    rarityByPlant[plant] = newRarity;
                }
                else if (elements[0] == "Reset")
                {
                    string plant = elements[1];

                    ratingByPlant[plant] = new List<double> { 0.0 };
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            rarityByPlant = rarityByPlant
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Plants for the exhibition:");

            foreach (var kvp in rarityByPlant)
            {
                string plant = kvp.Key;
                int currentRarity = kvp.Value;

                double ratingSum = 0;
                
                List<double> currentList = ratingByPlant[plant];
                
                foreach (var rating in currentList)
                {
                    ratingSum += rating;
                }

                int count = ratingByPlant[plant].Count - 1;
                double averageRating = 1;

                if (!(count == 0 && ratingSum == 0))
                {
                    averageRating = ratingSum / count;
                }
                else
                {
                    averageRating = 0;
                }

                Console.WriteLine($"- {plant}; Rarity: {currentRarity}; Rating: {averageRating:f2}");
            }
        }
    }
}
