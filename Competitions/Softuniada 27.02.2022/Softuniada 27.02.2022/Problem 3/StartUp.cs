using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 1; i < n; i += 2)
            {
                int firstElement = arr[i - 1];
                int secondElement = arr[i];
                int thirdElement = int.MinValue;

                if (arr.Length - 1 >= i + 1)
                {
                    thirdElement = arr[i + 1];
                }

                if (firstElement < secondElement)
                {
                    int temp = secondElement;
                    secondElement = firstElement;
                    firstElement = temp;
                }
                if (thirdElement < secondElement && n > i + 1)
                {
                    int temp = secondElement;
                    secondElement = thirdElement;
                    thirdElement = temp;
                }

                arr[i - 1] = firstElement;
                arr[i] = secondElement;
                if (arr.Length - 1 >= i + 1)
                {
                    arr[i + 1] = thirdElement;
                }
            }

            Console.WriteLine(string.Join(' ', arr));
        }
    }
}