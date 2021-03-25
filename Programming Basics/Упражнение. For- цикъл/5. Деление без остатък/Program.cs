using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Деление_без_остатък
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = int.Parse(Console.ReadLine());

            double count1 = 0;
            double count2 = 0;
            double count3 = 0;



            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num%2==0)
                {
                    count1++;
                }
                if (num%3==0)
                {
                    count2++; 
                }
                if (num%4==0)
                {
                    count3++;
                }

            }

            double p1 = count1 * 100 / n;
            double p2 = count2 * 100 / n;
            double p3 = count3 * 100 / n;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");



        }
    }
}
