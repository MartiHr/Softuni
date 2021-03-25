using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            IsTopNumber(number);
        }

        private static void IsTopNumber(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (IsDivisibleByEight(i) && HoldsDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool HoldsDigit(int number)
        {
            while (number > 0)
            {
                int currentDigit = number % 10;
                    
                if (currentDigit % 2 != 0)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }

        private static bool IsDivisibleByEight(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum % 8 != 0)
            {
                return false;
            }

            return true;
        }


    }
}
