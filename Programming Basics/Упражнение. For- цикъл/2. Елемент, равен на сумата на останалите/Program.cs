using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Елемент__равен_на_сумата_на_останалите
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max =int.MinValue;

            int sum = 0;


            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());

                sum = sum+ a;

                if (a>max)
                {
                    max = a;
                }

            }

            if (max==sum-max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(max-(sum-max))} ");
            }



        }
    }
}
