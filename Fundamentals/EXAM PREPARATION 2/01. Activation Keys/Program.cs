using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Generate")
                {
                    break;
                }

                string[] elements = command
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                if (elements[0] == "Contains")
                {
                    string substring = elements[1];

                    if (rawKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (elements[0] == "Flip")
                {
                    if (elements[1] == "Upper")
                    {
                        int startIndex = int.Parse(elements[2]);
                        int endIndex = int.Parse(elements[3]);
                        int length = endIndex - startIndex;
                        
                        string substring = rawKey.Substring(startIndex, length);

                        rawKey = rawKey.Replace(substring, substring.ToUpper());

                        Console.WriteLine(rawKey);
                    }
                    else
                    {
                        int startIndex = int.Parse(elements[2]);
                        int endIndex = int.Parse(elements[3]);
                        int length = endIndex - startIndex;

                        string substring = rawKey.Substring(startIndex, length);

                        rawKey = rawKey.Replace(substring, substring.ToLower());
                        
                        Console.WriteLine(rawKey);
                    }
                }
                else
                {
                    int startIndex = int.Parse(elements[1]);
                    int endIndex = int.Parse(elements[2]);
                    int length = endIndex - startIndex;
                    
                    rawKey = rawKey.Remove(startIndex, length);

                    Console.WriteLine(rawKey);
                }
            }

            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
