using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBound = elements[0];
            int upperBound = elements[1];


            string command = Console.ReadLine();
          
            Predicate<int> evenOrOdd = command == "odd"
                ? new Predicate<int>(number => number % 2 != 0)
                : new Predicate<int>(number => number % 2 == 0);

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (evenOrOdd(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
