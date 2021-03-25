using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            char comparisonSymbol = '\0';

            foreach (var character in input)
            {
                if (character != comparisonSymbol)
                {
                    sb.Append(character);
                    comparisonSymbol = character;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
