using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
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

            Stack<int> stack = new Stack<int>(numbers);

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            int smallest = int.MaxValue;

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (var item in stack)
                {
                    if (item < smallest)
                    {
                        smallest = item;
                    }
                }

                Console.WriteLine(smallest);
            }
        }
    }
}
