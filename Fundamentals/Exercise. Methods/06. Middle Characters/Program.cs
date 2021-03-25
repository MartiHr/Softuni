using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            string result = FindMiddleCharacter(line);
            
            Console.WriteLine(result);
        }

        private static string FindMiddleCharacter(string input)
        {
            int place = 0;
            string result = string.Empty;

            if (input.Length % 2 != 0)
            {
                place = (input.Length / 2) + 1;

                result += input[place - 1].ToString();
            }
            else
            {
                place = input.Length / 2;
                result += input[place - 1].ToString() + input[place].ToString();
            }

            return result;

        }
    }
}
