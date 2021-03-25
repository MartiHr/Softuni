using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int firstNumber = numbers[0];
                int secondNumber = numbers[1];

                if (i % 2 == 0)
                {
                    arr1[i] += firstNumber;
                    arr2[i] += secondNumber;
                }
                else
                {
                    arr1[i] += secondNumber;
                    arr2[i] += firstNumber;
                }
            }

            Console.WriteLine(string.Join(' ', arr1));
            Console.WriteLine(string.Join(' ', arr2));
        }
    }
}
