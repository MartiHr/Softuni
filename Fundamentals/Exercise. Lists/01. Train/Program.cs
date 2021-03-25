using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] element = command.Split();

                if (element[0] == "Add")
                {
                    wagons.Add(int.Parse(element[1]));
                }
                else
                {
                    int passengers = int.Parse(element[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int freeSpace = maxCapacity - wagons[i];
                        
                        if (freeSpace >= passengers)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}
