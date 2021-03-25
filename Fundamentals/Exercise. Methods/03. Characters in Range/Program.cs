using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            char start = first;
            char end = second;

            if (second < first)
            {
                start = second;
                end = first;
            }

            GetTableInterval(start, end);
        }

        private static void GetTableInterval(char start, char end)
        {
            string result = string.Empty;

            for (char i = (char)(start + 1); i < end; i++)
            {
                Console.Write(i + " "); 
            }
        }
    }
}
