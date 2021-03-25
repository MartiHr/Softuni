using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryMaterials = new Dictionary<string, int>()
            {
                { "shards", 0},
                { "fragments", 0},
                { "motes", 0}
            };

            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();

            string winningMaterial = string.Empty;
            bool isRunning = true;

            while (isRunning)
            {
                string[] elements = Console.ReadLine()
                    .Split();

                // i i + 1
                // 2 motes 3 ores 15 stones

                for (int i = 0; i < elements.Length; i+= 2)
                {
                    int quantity = int.Parse(elements[i]);
                    string material = elements[i + 1].ToLower();

                    if (legendaryMaterials.ContainsKey(material))
                    {
                        legendaryMaterials[material] += quantity;

                        if (legendaryMaterials[material] >= 250)
                        {
                            winningMaterial = material;
                            legendaryMaterials[material] -= 250;
                            isRunning = false;
                            break;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] += quantity;
                        }
                        else
                        {
                            junkMaterials.Add(material, quantity);
                        }
                    }
                }
            }

            if (winningMaterial == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (winningMaterial == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            legendaryMaterials = legendaryMaterials
                .OrderByDescending(material => material.Value)
                .ThenBy(material => material.Key)
                .ToDictionary(material => material.Key, material => material.Value);

            foreach (var material in legendaryMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in junkMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
