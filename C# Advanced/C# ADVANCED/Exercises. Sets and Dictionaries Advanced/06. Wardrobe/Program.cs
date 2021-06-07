using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothesByColor = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];
                string[] clothes = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (clothesByColor.ContainsKey(color) == false)
                {
                    clothesByColor.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {
                    if (clothesByColor[color].ContainsKey(cloth) == false)
                    {
                        clothesByColor[color].Add(cloth, 0);
                    }

                    clothesByColor[color][cloth]++;
                }
            }

            string[] pieceToFind = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorToFind = pieceToFind[0];
            string clothToFind = pieceToFind[1];

            foreach (var kvp in clothesByColor)
            {
                string currentColor = kvp.Key;
                Dictionary<string, int> currentClothes = kvp.Value;

                Console.WriteLine($"{currentColor} clothes:");

                foreach (var cloth in currentClothes)
                {
                    if (currentColor == colorToFind && cloth.Key == clothToFind)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
