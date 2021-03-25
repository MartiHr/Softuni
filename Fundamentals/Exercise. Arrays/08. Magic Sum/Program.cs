using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int comparisonNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];
                
                for (int j = i + 1; j < array.Length; j++)
                {
                    int rightNumber = array[j];

                    if (currentNumber + rightNumber == comparisonNumber)
                    {
                        Console.WriteLine($"{currentNumber} {rightNumber}");
                    }
                }
            }
        }
    }
}
