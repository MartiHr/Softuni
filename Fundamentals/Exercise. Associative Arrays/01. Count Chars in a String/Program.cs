using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            string word = Console.ReadLine();
               

            foreach (char letter in word)
            {
                if (letter == ' ')
                {
                    continue;
                }

                if (occurrences.ContainsKey(letter))
                {
                    occurrences[letter]++;
                }
                else
                {
                    occurrences.Add(letter, 1);
                }
            }

            foreach (var occurance in occurrences)
            {
                Console.WriteLine($"{occurance.Key} -> {occurance.Value}");
            }
        }
    }
}
