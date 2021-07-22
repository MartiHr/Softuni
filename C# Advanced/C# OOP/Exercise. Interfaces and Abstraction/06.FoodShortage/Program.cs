using System;
using System.Collections.Generic;

namespace _06.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ");

                if (elements.Length == 4)
                {
                    IBuyer currentCitizen = new Citizen(elements[0], int.Parse(elements[1]), elements[2], elements[3]);
                    buyers.Add(currentCitizen);
                }
                else
                {
                    IBuyer currentRebel = new Rebel(elements[0], int.Parse(elements[1]), elements[2]);
                    buyers.Add(currentRebel);
                }
            }

            string command = string.Empty;


            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var buyer in buyers)
                {
                    if (buyer.Name == command)
                    {
                        buyer.BuyFood();
                    }
                }
            }

            int total = 0;

            foreach (var buyer in buyers)
            {
                total += buyer.Food;
            }

            Console.WriteLine(total);
        }
    }
}
