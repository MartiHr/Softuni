using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double balance = 0;


            while (input != "Start")
            {
                double currentCoin = double.Parse(input);
               
                switch (currentCoin)
                {
                    case 0.1:
                        balance += 0.1;
                        break;
                    case 0.2:
                        balance += 0.2;
                        break;
                    case 0.5:
                        balance += 0.5;
                        break;
                    case 1:
                        balance += 1;
                        break;
                    case 2:
                        balance += 2;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {currentCoin}");
                        break;
                }

                input = Console.ReadLine();
            }

            string productType = Console.ReadLine();
            double price = 0;

            while (productType != "End")
            {
                
                    if (productType == "Nuts")
                    {
                        balance -= 2;
                        if (balance>=0)
                        {
                            Console.WriteLine($"Purchased {productType.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            balance += 2;
                        }
                    }
                    else if (productType == "Water")
                    {
                        balance -= 0.7;

                        if (balance >= 0)
                        {
                            Console.WriteLine($"Purchased {productType.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            balance += 0.7;
                        }
                    }
                    else if (productType == "Crisps")
                    {
                        balance -= 1.5;

                        if (balance >= 0)
                        {
                            Console.WriteLine($"Purchased {productType.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            balance += 1.5;
                        }
                    }
                    else if (productType == "Soda")
                    {
                        balance -= 0.8;

                        if (balance >= 0)
                        {
                            Console.WriteLine($"Purchased {productType.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        balance += 0.8;
                        }
                    }
                    else if (productType == "Coke")
                    {
                        balance -= 1;

                        if (balance >= 0)
                        {
                            Console.WriteLine($"Purchased {productType.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                            balance += 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid product");
                    }

                productType = Console.ReadLine();
            
            }

            Console.WriteLine($"Change: {balance:f2}");

        }
    }
}
