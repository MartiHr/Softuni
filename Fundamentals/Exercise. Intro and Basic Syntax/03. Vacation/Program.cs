using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;

            if (groupType == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                }
                else if (day == "Saturday")
                {
                    price = 9.80;
                }
                else
                {
                    price = 10.46;
                }
            }
            else if (groupType == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                }
                else if (day == "Saturday")
                {
                    price = 15.60;
                }
                else
                {
                    price = 16;
                }
            }
            else 
            {
                if (day == "Friday")
                {
                    price = 15;
                }
                else if (day == "Saturday")
                {
                    price = 20;
                }
                else
                {
                    price = 22.50;
                }
            }

            double totalPrice = count * price;

            if (groupType == "Students" && count >= 30)
            {
                totalPrice *= 0.85;
            }
            else if (groupType == "Business" && count >= 100)
            {
                totalPrice = (count - 10) * price;
            }
            else if (groupType == "Regular" && (count >= 10 && count <= 20))
            {
                totalPrice *= 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");

        }
    }
}
