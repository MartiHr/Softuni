using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> ingerdients = new Queue<int>(input1);

            int[] input2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> freshnessLevels = new Stack<int>(input2);

            SortedDictionary<string, int> amountByDishName = new SortedDictionary<string, int>();
            amountByDishName.Add("Lobster", 0);
            amountByDishName.Add("Chocolate cake", 0);
            amountByDishName.Add("Green salad", 0);
            amountByDishName.Add("Dipping sauce", 0);

            while (ingerdients.Count > 0 && freshnessLevels.Count > 0)
            {
                int totalFreshness = ingerdients.Peek() * freshnessLevels.Peek();

                if (ingerdients.Peek() == 0)
                {
                    ingerdients.Dequeue();
                    continue;
                }
                else
                {
                    if (totalFreshness == 150)
                    {
                        amountByDishName["Dipping sauce"]++;

                        ingerdients.Dequeue();
                        freshnessLevels.Pop();
                    }
                    else if (totalFreshness == 250)
                    {
                        amountByDishName["Green salad"]++;

                        ingerdients.Dequeue();
                        freshnessLevels.Pop();
                    }
                    else if (totalFreshness == 300)
                    {
                        amountByDishName["Chocolate cake"]++;

                        ingerdients.Dequeue();
                        freshnessLevels.Pop();
                    }
                    else if (totalFreshness == 400)
                    {
                        amountByDishName["Lobster"]++;

                        ingerdients.Dequeue();
                        freshnessLevels.Pop();
                    }
                    else
                    {
                        freshnessLevels.Pop();
                        ingerdients.Enqueue(ingerdients.Dequeue() + 5);
                    }
                }
            }

            if (amountByDishName["Lobster"] > 0 &&
                amountByDishName["Chocolate cake"] > 0 &&
                amountByDishName["Green salad"] > 0 &&
                amountByDishName["Dipping sauce"] > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingerdients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingerdients.Sum()}");
            }

            foreach (var kvp in amountByDishName.Where(x => x.Value > 0))
            {
                Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
            }
        }
    }
}
