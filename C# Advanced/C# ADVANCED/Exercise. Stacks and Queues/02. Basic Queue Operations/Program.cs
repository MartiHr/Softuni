using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Any())
            {
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
