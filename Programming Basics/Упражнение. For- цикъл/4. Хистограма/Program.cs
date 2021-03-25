using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Хистограма
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            double count1 = 0;
            double count2 = 0;
            double count3 = 0;
            double count4 = 0;
            double count5 = 0;


            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    count1++;
                }
                else if (num >= 200 && num <= 399)
                {
                    count2++;
                }
                else if (num >= 400 && num <= 599)
                {
                    count3++;
                }
                else if (num >= 600 && num <= 799)
                {
                    count4++;
                }
                else
                {
                    count5++;
                }

            }

            double p1 = count1 / n * 100;
            double p2 = count2 / n * 100;
            double p3 = count3 / n * 100;
            double p4 = count4 / n * 100;
            double p5 = count5 / n * 100;


            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");





        }
    }
}
