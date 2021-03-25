using System;

namespace _8._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            double firstFactorial = CalculateFactorial(first);
            double secondFactorial = CalculateFactorial(second);

            double result = firstFactorial / secondFactorial;
            
            Console.WriteLine($"{result:f2}");
        }

        private static double CalculateFactorial(int number)
        {
            double Fact = 1;

            for (int i = number; i > 0; i--)
            {
                Fact *= i;
            }

            return Fact;
        }

    }
}
