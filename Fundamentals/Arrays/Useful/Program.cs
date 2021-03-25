using System;

namespace Useful
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Two methods for array from string!
             
            1. Using for-cycle
           
            string line = Console.ReadLine();
            string[] arr = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int[] arrNums = new int[arr.Length];

            for (int i = 0; i < arrNums.Length; i++)
            {
                arrNums[i] = int.Parse(arr[i]);
            }

            2. With only one line
             
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
             */
        }
    }
}
