using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Хотелска_стая
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceAp = 0;
            double priceStudio = 0;

            if (month=="May"||month=="October")
            {
               
                if (nights>7&&nights<=14)
                {   
                    priceStudio =nights*50*0.95;
                    priceAp = nights * 65;
                }
                else if(nights>14)
                {
                    priceStudio = nights * 50 *0.70;
                    priceAp = nights * 65*0.90;
                }
                else
                {
                    priceStudio = nights * 50;
                    priceAp = nights * 65;
                }
            }
            else if (month == "June" || month == "September")
            {
                if (nights>14)
                {
                    priceStudio = nights * 75.20 * 0.80;
                    priceAp = nights * 68.70 * 0.90;
                }
                else
                {
                    priceStudio = nights * 75.20;
                    priceAp = nights * 68.70;
                }
            }
            else
            {
                if (nights>14)
                {
                    priceStudio = nights * 76;
                    priceAp = nights * 77 * 0.90;
                }
                else
                {
                    priceStudio = nights * 76 ;
                    priceAp = nights * 77 ;
                }
            }
            Console.WriteLine($"Apartment: {priceAp:f2} lv.");
            Console.WriteLine($"Studio: {priceStudio:f2} lv.");


        }
    }
}
