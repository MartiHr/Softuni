using System;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Predicate<int> isDivisible = number =>
            {
                for (int i = 0; i < dividers.Length; i++)
                {
                    if (number % dividers[i] != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            int[] divisibleNumbers = Enumerable.Range(1, n)
                .Where(n => isDivisible(n))
                .ToArray();

            Console.WriteLine(string.Join(" ", divisibleNumbers));
        }
    }
}
