using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divider = int.Parse(Console.ReadLine());

            Func<int, int, bool> predicate = (n, divider) => n % divider != 0;

            numbers = numbers
                .Reverse()
                .Where(n => predicate(n, divider))
                .ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
