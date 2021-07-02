using System;
using System.Linq;

namespace _07.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numberToFind = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, numberToFind));
        }

        public static int BinarySearch(int[] items, int itemToFind)
        {
            int start = 0;
            int end = items.Length - 1;
            
            while (start <= end)
            {
                int index = (start + end) / 2;
                int item = items[index];

                if (item == itemToFind)
                {
                    return index;
                }

                if (item < itemToFind)
                {
                    start = index + 1;
                }

                if (item > itemToFind)
                {
                    end = index - 1;
                }
            }

            return -1;
        }
    }
}
