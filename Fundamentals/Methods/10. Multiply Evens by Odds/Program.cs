using System;
using System.Linq;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int result = GetMultipliedEvenAndOdds(GetSumOfEvenDigits(number), GetSumOfOddDigits(number));

            Console.WriteLine(result);
        }
        
        static int GetMultipliedEvenAndOdds(int evenSum, int oddSum)
        {
            int result = evenSum * oddSum;
            return result;
        }
       
        static int GetSumOfEvenDigits(int number)
        {
            int evenSum = 0;

            while (number > 0)
            {
                int currentDigit = number % 10;
                number /= 10;

                if (currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }
            }

            return evenSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;

            while (number > 0)
            {
                int currentDigit = number % 10;
                number /= 10;

                if (currentDigit % 2 != 0)
                {
                    oddSum += currentDigit;
                }
            }

            return oddSum;
        }

    }
}
