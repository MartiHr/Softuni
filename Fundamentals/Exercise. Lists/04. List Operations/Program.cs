using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
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

            while (command != "End")
            {
                string[] elements = command.Split();

                if (elements[0] == "Add")
                {
                    int number = int.Parse(elements[1]);
                    list.Add(number);
                }
                else if (elements[0] == "Insert")
                {
                    int number = int.Parse(elements[1]);
                    int index = int.Parse(elements[2]);

                    if (!IsValid(index, list))
                    {
                        Console.WriteLine("Invalid index");
                    }

                    list.Insert(index, number);
                }
                else if (elements[0] == "Remove")
                {
                    int index = int.Parse(elements[1]);
                    if (!IsValid(index, list))
                    {
                        Console.WriteLine("Invalid index");
                    }

                    list.RemoveAt(index);
                }
                else if (elements[0] == "Shift")
                {
                    int count = int.Parse(elements[2]);

                    if (elements[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstNum = list[0];

                            list.Add(firstNum);
                            list.RemoveAt(0);
                        }
                    }
                    else if (elements[1] == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastNum = list[list.Count - 1];

                            list.RemoveAt(list.Count - 1);
                            list.Insert(0, lastNum);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", list));
        }

        static bool IsValid(int index, List<int> list)
        {
            return index < 0 || index > list.Count - 1;
        }
    }
}
