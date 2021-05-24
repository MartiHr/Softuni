using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            
            for (int i = 0; i < n; i++)
            {
                int[] elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int command = elements[0];
                
                if (command == 1)
                {
                    int x = elements[1];

                    stack.Push(x);
                }
                else if (stack.Any())
                {
                    if (command == 2)
                    {
                        stack.Pop();
                    }
                    else if (command == 3)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}
