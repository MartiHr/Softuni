using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] currentPump = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(currentPump);
            }

            int index = 0;

            while (true)
            {
                int total = 0;

                foreach (var pump in pumps)
                {
                    int petrol = pump[0];
                    int distance = pump[1];

                    total += petrol - distance;

                    if (total < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        index++;
                        break;
                    }
                }

                if (total >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
