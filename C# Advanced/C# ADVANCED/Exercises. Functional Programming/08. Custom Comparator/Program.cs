using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> comparator = (number1, number2) =>
            {
                return
                (number1 % 2 == 0 && number2 % 2 != 0) ? -1 :
                (number1 % 2 != 0 && number2 % 2 == 0) ? 1 :
                 number1.CompareTo(number2);
            };

            Array.Sort<int>(numbers, new Comparison<int>(comparator));
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
