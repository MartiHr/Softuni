using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Пътешествие
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double moneySpent = 0;

            if (budget<=100)
            {
                if (season=="summer")
                {
                    moneySpent = budget * 0.30;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {moneySpent:f2}");
                }
                else
                {
                    moneySpent = budget * 0.70;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {moneySpent:f2}");
                }
            }
            else if (budget >100&& budget<=1000)
            {
                if (season == "summer")
                {
                    moneySpent = budget * 0.40;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {moneySpent:f2}");
                }
                else
                {
                    moneySpent = budget * 0.80;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {moneySpent:f2}");
                }
            }
            else
            {
                
                    moneySpent = budget * 0.90;
                    Console.WriteLine("Somewhere in Europe");
                    Console.WriteLine($"Hotel - {moneySpent:f2}");
               
            }




        }
    }
}
