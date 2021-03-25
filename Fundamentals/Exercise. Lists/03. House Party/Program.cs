using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            List<string> list = new List<string>(commandsCount);

            for (int i = 0; i < commandsCount; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split();
               
                string name = elements[0];

                if (elements[2] == "going!")
                {
                    if (isInTheList(list, name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        list.Add(name);
                    }
                }
                else
                {
                    if (isInTheList(list, name))
                    {
                        list.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            foreach (var name in list)
            {
                Console.WriteLine(name);
            }
        }

        static bool isInTheList(List<string> list, string name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (name == list[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
