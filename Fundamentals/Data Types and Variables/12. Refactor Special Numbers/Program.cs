using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                int digitsSum = 0;
                int digit = num;

                while (digit > 0)
                {
                    digitsSum += digit % 10;
                    digit = digit / 10;
                }

                if (digitsSum == 5 || digitsSum == 7 || digitsSum == 11)
                {
                    Console.WriteLine($"{num} -> True");
                }
                else
                {
                    Console.WriteLine($"{num} -> False");
                }
            }
        }
    }
}
