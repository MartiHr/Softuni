using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Travel")
                {
                    break;
                }

                string[] elements = command
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (elements[0] == "Add Stop")
                {
                    int index = int.Parse(elements[1]);
                    string substring = elements[2];

                    if (index >= 0 && index < input.Length)
                    {
                        input = input.Insert(index, substring);
                    }
                    else
                    {
                        continue;
                    }

                    Console.WriteLine(input);
                }
                else if (elements[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(elements[1]);
                    int endIndex = int.Parse(elements[2]);
                    int length = endIndex - startIndex + 1;

                    if (startIndex >= 0 && endIndex < input.Length)
                    {
                        input = input.Remove(startIndex, length);
                    }

                    Console.WriteLine(input);
                }
                else
                {
                    string oldString = elements[1];
                    string newString = elements[2];

                    if (input.Contains(oldString))
                    {
                        input = input.Replace(oldString, newString);
                    }

                    Console.WriteLine(input);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
