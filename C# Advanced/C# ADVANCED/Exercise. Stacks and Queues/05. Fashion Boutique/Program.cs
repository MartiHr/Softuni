using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> box = new Stack<int>(values);
            int capacity = int.Parse(Console.ReadLine());

            int sum = 0;
            int rackNumber = 1;

            while (box.Any())
            {
                sum += box.Peek();
                
                if (sum <= capacity)
                {
                    box.Pop();
                }
                else
                {
                    rackNumber++;
                    sum = 0;
                }
            }

            Console.WriteLine(rackNumber);
        }
    }
}
