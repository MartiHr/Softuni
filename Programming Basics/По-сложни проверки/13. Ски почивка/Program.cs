using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Ски_почивка
{
    class Program
    {
        static void Main(string[] args)
        {

                int days = int.Parse(Console.ReadLine());
            int nights = days - 1;
            string roomType = Console.ReadLine();
            string grade = Console.ReadLine();
            double price = 0;


            if (grade == "positive")
            {
                switch (roomType)
                {
                    case "room for one person":
                        price = nights * 18 * 1.25;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "apartment":
                        if (days < 10)
                        {
                            price = nights * 25 * 0.70 * 1.25;
                            Console.WriteLine($"{price:f2}");
                        }
                        else if (days >= 10 && days <= 15)
                        {
                            price = nights * 25 * 0.65 * 1.25;
                            Console.WriteLine($"{price:f2}");
                        }
                        else
                        {
                            price = nights * 25 * 0.50 * 1.25;
                            Console.WriteLine($"{price:f2}");
                        }
                        break;
                    case "president apartment":
                        if (days < 10)
                        {
                            price = nights * 35 * 0.90 * 1.25;
                            Console.WriteLine($"{price:f2}");
                        }
                        else if (days >= 10 && days <= 15)
                        {
                            price = nights * 35 * 0.85 * 1.25;
                            Console.WriteLine($"{price:f2}");
                        }
                        else
                        {
                            price = nights * 35 * 0.80 * 1.25;
                            Console.WriteLine($"{price:f2}");
                        }
                        break;


                }
            }
            else
            {
                switch (roomType)
                {
                    case "room for one person":
                        price = nights * 18 * 0.90;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "apartment":
                        if (days < 10)
                        {
                            price = nights * 25 * 0.70 * 0.90;
                            Console.WriteLine($"{price:f2}");
                        }
                        else if (days >= 10 && days <= 15)
                        {
                            price = nights * 25 * 0.65 * 0.90;
                            Console.WriteLine($"{price:f2}");
                        }
                        else
                        {
                            price = nights *25 * 0.50 * 0.90;
                            Console.WriteLine($"{price:f2}");
                        }
                        break;
                    case "president apartment":
                        if (days < 10)
                        {
                            price = nights * 35 * 0.90 * 0.90;
                            Console.WriteLine($"{price:f2}");
                        }
                        else if (days >= 10 && days <= 15)
                        {
                            price = nights *35 * 0.85 * 0.90;
                            Console.WriteLine($"{price:f2}");
                        }
                        else
                        {
                            price = nights * 35 * 0.80 * 0.90;
                            Console.WriteLine($"{price:f2}");
                        }
                        break;
                }

            }

        }
    }
}
