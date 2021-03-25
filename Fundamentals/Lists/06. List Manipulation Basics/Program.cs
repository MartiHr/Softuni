using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {

                string[] elements = command.Split();
                
                switch (elements[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(elements[1]));
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(elements[1]));
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(elements[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(elements[2]), int.Parse(elements[1]));
                        break;
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
