using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(number));
        }

        private static int Factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
