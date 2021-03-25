using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Квартално_магазинче
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
          
            switch (product)
            {
                case "coffee":
                    switch (city)
                    {
                        case "Sofia": Console.WriteLine(0.50 * amount); break;
                       case "Plovdiv": Console.WriteLine(0.40 * amount); break;
                        case "Varna": Console.WriteLine(0.45 * amount); break;
                    }
                    break;
                case "water":
                    switch (city)
                    {
                        case "Sofia": Console.WriteLine(0.80 * amount); break;
                        case "Plovdiv": Console.WriteLine(0.70 * amount); break;
                        case "Varna": Console.WriteLine(0.70 * amount); break;
                    }
                    break;
                case "beer":
                    switch (city)
                    {
                        case "Sofia": Console.WriteLine(1.20 * amount); break;
                        case "Plovdiv": Console.WriteLine(1.15 * amount); break;
                        case "Varna": Console.WriteLine(1.10 * amount); break;
                    }
                    break;
                case "sweets":
                    switch (city)
                    {
                        case "Sofia": Console.WriteLine(1.45 * amount); break;
                        case "Plovdiv": Console.WriteLine(1.30 * amount); break;
                        case "Varna": Console.WriteLine(1.35 * amount); break;
                    }
                    break;
                case "peanuts":
                    switch (city)
                    {
                        case "Sofia": Console.WriteLine(1.60 * amount); break;
                        case "Plovdiv": Console.WriteLine(1.50 * amount); break;
                        case "Varna": Console.WriteLine(1.55 * amount); break;
                    }
                    break;
            }





        }
    }
}
