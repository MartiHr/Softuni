using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Суми_прости_и_непрости_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int primeSum = 0;
            int nonPrimeSum = 0;

            int count = 0;

            while (input!="stop")
            {
                int num = int.Parse(input);
           
                if (num<0)
                {
                    Console.WriteLine("Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }
                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        count++;
                    }
                }
                if (count <= 2)
                {
                    primeSum += num;
                }
                else
                {
                    nonPrimeSum += num;
                }
                
                count = 0;
                input = Console.ReadLine();

            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
