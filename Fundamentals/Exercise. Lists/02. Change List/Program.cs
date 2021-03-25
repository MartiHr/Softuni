using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] elements = command.Split();

                if (elements[0] == "Delete")
                {
                    list.RemoveAll(n => n == int.Parse(elements[1]));
                }
                else if (elements[0] == "Insert")
                {
                    list.Insert(int.Parse(elements[2]), int.Parse(elements[1]));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", list));
        }
    }
}
