using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Баланс_по_сметка
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;

            string input = Console.ReadLine();

            while (input!="NoMoreMoney")
            {
                double give = double.Parse(input);
                
                if (give>=0)
                {
                    Console.WriteLine($"Increase: {give:f2}");
                    sum += give;
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {sum:f2}");


        }
    }
}
