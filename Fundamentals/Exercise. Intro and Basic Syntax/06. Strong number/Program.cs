using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int originalNumber = number;

            int factorialSum = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;

                // 5! = 5*4*3*2*1
                int factorial = 1;
               
                for (int i = lastDigit; i >= 1; i--)
                {
                    factorial *= i;
                }

                factorialSum += factorial;
                number /= 10;
            }

            if (factorialSum == originalNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }


        }
    }
}
