using System;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int i = 0; i < n; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double currentPrice = (days * capsulesCount) * pricePerCapsule;
                Console.WriteLine($"The price for the coffee is: ${currentPrice:f2}");

                totalPrice += currentPrice;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
