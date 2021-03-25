using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            bool isEqual = false;

            for (int currentElement = 0; currentElement < array.Length; currentElement++)
            {
                int leftSum = 0;
                for (int i = currentElement - 1; i >= 0; i--)
                {
                    leftSum += array[i];
                }

                int rightSum = 0;
                for (int j = currentElement + 1; j < array.Length; j++)
                {
                    rightSum += array[j];
                }
               
                if (leftSum == rightSum)
                {
                    Console.WriteLine(currentElement);
                    isEqual = true;
                    break;
                }
            }
            
            if (!isEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}
