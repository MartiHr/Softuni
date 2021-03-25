using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n >= 0)
                .Reverse()
                .ToList();

            if (numbers.Count > 0)
            {
                Console.WriteLine(String.Join(" ", numbers)); 
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
