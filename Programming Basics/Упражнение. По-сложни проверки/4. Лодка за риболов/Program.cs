using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Лодка_за_риболов
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            double price = 0;
            double difference = 0;
            
            if (season=="Spring")
            {
                
                if (count % 2 == 0)
                {
                    if (count <= 6)
                    {
                        price =3000* 0.90 * 0.95;
                        
                        difference = Math.Abs(budget - price);
                        if (budget>=price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else if (count > 6 && count <= 11)
                    {
                        price = 3000*0.85 * 0.95;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else
                    {
                        price =3000* 0.75 * 0.95;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                }
                else
                {
                    if (count <= 6)
                    {
                        price =3000* 0.90;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else if (count > 6 && count <= 11)
                    {
                        price =3000* 0.85;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else
                    {
                        price =3000* 0.75;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                }
            }
            else if(season=="Summer")
            {
                
                if (count % 2 == 0)
                {
                    if (count <= 6)
                    {
                        price = 4200*0.90 * 0.95;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else if (count > 6 && count <= 11)
                    {
                        price = 4200* 0.85 * 0.95;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else
                    {
                        price = 4200* 0.75 * 0.95;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                }
                else
                {
                    if (count <= 6)
                    {
                        price = 4200*0.90;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else if (count > 6 && count <= 11)
                    {
                        price = 4200* 0.85;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else
                    {
                        price = 4200* 0.75;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                }
            }
            else if (season == "Autumn")
            {
                price = 4200;
                
                
                    if (count <= 6)
                    {
                        price = 4200* 0.90;


                    difference = Math.Abs(budget - price);
                    if (budget >= price)
                    {
                        Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                    }
                }
                    else if (count > 6 && count <= 11)
                    {
                        price = 4200* 0.85;

                    difference = Math.Abs(budget - price);
                    if (budget >= price)
                    {
                        Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                    }
                }
                    else
                    {
                        price = 4200* 0.75;

                    difference = Math.Abs(budget - price);
                    if (budget >= price)
                    {
                        Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                    }
                }
                
            }
            else
            {
                price = 2600;
                if (count % 2 == 0)
                {
                    if (count <= 6)
                    {
                        price = 2600 * 0.90 *0.95;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else if (count > 6 && count <= 11)
                    {
                        price = 2600 * 0.85 *0.95;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else
                    {
                        price = 2600 * 0.75 * 0.95;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                }
                else
                {
                    if (count <= 6)
                    {
                        price = 2600 * 0.90;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else if (count > 6 && count <= 11)
                    {
                        price = 2600 * 0.85;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                    else
                    {
                        price = 2600 * 0.75;

                        difference = Math.Abs(budget - price);
                        if (budget >= price)
                        {
                            Console.WriteLine($"Yes! You have {difference:f2} leva left.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough money! You need {difference:f2} leva.");
                        }
                    }
                }
            }
        }
    }
}
