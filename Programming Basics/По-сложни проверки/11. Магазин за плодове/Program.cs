using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Магазин_за_плодове
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            if (dayOfTheWeek!="Sunday"&& dayOfTheWeek != "Saturday")
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine(Math.Round(2.50*amount,2));
                        break;
                    case "apple":
                        Console.WriteLine(Math.Round(1.20 * amount, 2));
                        break;
                    case "orange":
                        double price = 0.85 * amount;
                        Console.WriteLine(Math.Round(price, 2));
                        break;
                    case "grapefruit":
                        Console.WriteLine(Math.Round(1.45 * amount, 2));
                        break;
                    case "kiwi":
                        Console.WriteLine(Math.Round(2.70 * amount, 2));
                        break;
                    case "pineapple":
                        Console.WriteLine(Math.Round(5.50 * amount, 2));
                        break;
                    case "grapes":
                        Console.WriteLine(Math.Round(3.85 * amount, 2));
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }

            }
            else
            {
                switch (fruit)
                {
                    case "banana":
                        Console.WriteLine(Math.Round(2.70 * amount, 2));
                        break;
                    case "apple":
                        Console.WriteLine(Math.Round(1.25 * amount, 2));
                        break;
                    case "orange":
                        double price = 0.90 * amount;
                        Console.WriteLine(Math.Round(price, 2));
                        break;
                    case "grapefruit":
                        Console.WriteLine(Math.Round(1.60 * amount, 2));
                        break;
                    case "kiwi":
                        Console.WriteLine(Math.Round(3.00 * amount, 2));
                        break;
                    case "pineapple":
                        Console.WriteLine(Math.Round(5.60 * amount, 2));
                        break;
                    case "grapes":
                        Console.WriteLine(Math.Round(4.20 * amount, 2));
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }




        }
    }
}
