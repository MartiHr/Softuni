using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"([\#|])(?<name>[a-zA-Z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1");

            MatchCollection items = regex.Matches(text);

            int caloriesSum = 0;

            foreach (Match item in items)
            {
                int calories = int.Parse(item.Groups["calories"].Value);
                caloriesSum += calories;
            }

            Console.WriteLine($"You have food to last you for: {caloriesSum / 2000} days!");

            foreach (Match item in items)
            {
                string name = item.Groups["name"].Value;
                string date = item.Groups["date"].Value;
                string calories = item.Groups["calories"].Value;

                Console.WriteLine($"Item: {name}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
