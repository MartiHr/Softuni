using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            int lastIndex = input.LastIndexOf("\\");

            string substring = input.Substring(lastIndex + 1);

            string[] part = substring.Split(".");

            Console.WriteLine($"File name: {part[0]}");
            Console.WriteLine($"File extension: {part[1]}");
        }
    }
} 
