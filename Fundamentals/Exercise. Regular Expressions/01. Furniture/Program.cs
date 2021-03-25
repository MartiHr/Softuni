using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<furniture>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)"); 

            List<string> furniturePieces = new List<string>();
            double total = 0.0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string furniture = match.Groups["furniture"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);
                    
                furniturePieces.Add(furniture);
                total += price * quantity;
            }

            Console.WriteLine("Bought furniture:");

            foreach (string furniture in furniturePieces)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
