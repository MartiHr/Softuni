using System;

namespace _7._Theatre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayType = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            int price = 0;

            if (dayType=="weekday")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    price = 12;
                }
                else if (age > 18 && age <= 64)
                {
                    price = 18;
                }
            }
       
            if (dayType == "weekend")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    price = 15;
                }
                else if (age > 18 && age <= 64)
                {
                    price = 20;
                }
            }

            if (dayType == "holiday")
            {
                if (age >= 0 && age <= 18 )
                {
                    price = 5;
                }
                else if (age > 64 && age <= 122)
                {
                    price = 10; 
                }
                else if (age > 18 && age <= 64)
                {
                    price = 12;
                }

            }

            if (age >= 0 && age <= 122)
            {
                Console.WriteLine(price + "$");
            }
            else
            {
                Console.WriteLine("Error!");
            }

        }
    }
}
