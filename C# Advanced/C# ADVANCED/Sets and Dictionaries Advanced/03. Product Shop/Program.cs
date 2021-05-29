using System;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = 
                new SortedDictionary<string, Dictionary<string, double>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] elements = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = elements[0];
                string product = elements[1];
                double price = double.Parse(elements[2]);

                if (shops.ContainsKey(shopName) == false)
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }

                if (shops[shopName].ContainsKey(product) == false)
                {
                    shops[shopName].Add(product, price);
                }
            }

            foreach (var kvp in shops)
            {
                string shopName = kvp.Key;
                Console.WriteLine($"{shopName}->");

                Dictionary<string, double> products = kvp.Value;
                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
