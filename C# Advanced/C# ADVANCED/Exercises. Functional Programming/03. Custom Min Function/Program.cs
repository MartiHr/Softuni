using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = x =>
            {
                int smallest = int.MaxValue;

                foreach (var item in x)
                {
                    if (item < smallest)
                    {
                        smallest = item;
                    }
                }

                return smallest;
            };

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minNumber(numbers));
        }
    }
}
