using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result = RepeatLine(line, count);
            Console.WriteLine(result);
        }

        static string RepeatLine(string line, int count)
        {
            string builder = " ";

            for (int i = 0; i < count; i++)
            {
                builder += line;
            }

            return builder + " ";
        }
    }
}
