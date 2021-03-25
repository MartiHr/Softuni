using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex
                (@"%(?<customer>[A-Z][a-z]+)%[^%.$|]*<(?<product>\w+)>[^%.$|]*\|(?<count>\d+)\|[^%.$|\d]*(?<price>\d+.?\d*)\$");

            double totalPrice = 0.0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string customer = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                int count = int.Parse(match.Groups["count"].Value);
                double price = double.Parse(match.Groups["price"].Value);

                totalPrice += price * count;

                Console.WriteLine($"{customer}: {product} - {price * count:f2}");
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}
