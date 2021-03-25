using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split(' ');

            Dictionary<string, int> occurences = new Dictionary<string, int>();
  
            foreach (var key in words)
            {
                if (occurences.ContainsKey(key))
                {
                    occurences[key]++;
                }
                else
                {
                    occurences.Add(key, 1);
                }
            }

            foreach (var occurance in occurences)
            {
                if (occurance.Value % 2 != 0)
                {
                    Console.Write(occurance.Key + " ");
                }
            }
        }
    }
}
