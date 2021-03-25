using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Нов_дом
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;

            switch (flowerType)
            {
                case "Roses":
                    if (count>80)
                    {
                        price = 5 *count*0.90;
                        if (price<=budget)
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {difference:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);

                            Console.WriteLine($"Not enough money, you need {difference:f2} leva more.");

                        }
                    }
                    else
                    {
                        price = 5 * count;
                        if (price <= budget)
                        {
                            double difference = budget - price;
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {difference:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Not enough money, you need {difference:f2} leva more.");
                        }
                    }
                    break;

                case "Dahlias":
                    if (count > 90)
                    {
                        price = 3.80 * count * 0.85;
                        if (price <= budget)
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {difference:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Not enough money, you need {difference:f2} leva more.");
                        }
                    }
                    else
                    {
                        price = 3.80* count;
                        if (price <= budget)
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {difference:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Not enough money, you need {difference:f2} leva more.");
                        }
                    }
                    break;

                case "Tulips":
                    if (count > 80)
                    {
                        price = 2.80* count * 0.85;
                        if (price <= budget)
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {difference:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Not enough money, you need {difference:f2} leva more.");
                        }
                    }
                    else
                    {
                        price = 2.80 * count;
                        if (price <= budget)
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {difference:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Not enough money, you need {difference:f2} leva more.");
                        }
                    }
                    break;

                case "Narcissus":
                    if (count < 120)
                    {
                        price = 3 * count * 1.15;
                        if (price <= budget)
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {difference:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Not enough money, you need {difference:f2} leva more.");
                        }
                    }
                    else
                    {
                        price = 3 * count;
                        if (price <= budget)
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {difference:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Not enough money, you need {difference:f2} leva more.");
                        }
                    }
                    break;

                case "Gladiolus":
                    if (count < 80)
                    {
                        price = 2.50 * count * 1.20;
                        if (price <= budget)
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {budget - price:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Not enough money, you need {difference:f2} leva more.");
                        }
                    }
                    else
                    {
                        price = 2.50 * count;
                        if (price <= budget)
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Hey, you have a great garden with {count} {flowerType} and {difference:f2} leva left.");
                        }
                        else
                        {
                            double difference = Math.Abs(budget - price);
                            Console.WriteLine( $"Not enough money, you need {difference:f2} leva more.");
                        }
                    }
                    break;
            }
        }
    }
}
