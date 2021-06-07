using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> charByCount = new SortedDictionary<char, int>();

            foreach (var character in text)
            {
                if (charByCount.ContainsKey(character) == false)
                {
                    charByCount.Add(character, 0);
                }

                charByCount[character]++; 
            }

            foreach (var kvp in charByCount)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
