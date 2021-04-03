using System;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                
                string[] elements = command.Split();
                
                if (elements[0] == "Translate")
                {
                    char oldChar = char.Parse(elements[1]);
                    char newChar = char.Parse(elements[2]);

                    input = input.Replace(oldChar, newChar);

                    Console.WriteLine(input);
                }
                else if (elements[0] == "Includes")
                {
                    string substring = elements[1];

                    if (input.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (elements[0] == "Start")
                {
                    string substring = elements[1];

                    if (input.StartsWith(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (elements[0] == "Lowercase")
                {
                    input = input.ToLower();

                    Console.WriteLine(input);
                }
                else if (elements[0] == "FindIndex")
                {
                    char character = char.Parse(elements[1]);

                    Console.WriteLine(input.LastIndexOf(character));
                }
                else if(elements[0] == "Remove")
                {
                    int startIndex = int.Parse(elements[1]);
                    int count = int.Parse(elements[2]);

                    input = input.Remove(startIndex, count);

                    Console.WriteLine(input);
                }
            }
        }
    }
}
