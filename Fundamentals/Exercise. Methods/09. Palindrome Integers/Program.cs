using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                int number = int.Parse(input);

                if (IsPalindrome(number))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                input = Console.ReadLine();
            }

        }

        private static bool IsPalindrome(int number)
        {
            string initialLine = number.ToString();
            string reverseLine = String.Empty;

            for (int i = initialLine.Length; i > 0; i--)
            {
                reverseLine += initialLine[i - 1];
            }

            if (initialLine == reverseLine)
            {
                return true;
            }

            return false;
        }
    }
}
