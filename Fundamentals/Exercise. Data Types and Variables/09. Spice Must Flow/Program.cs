using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            bool isProfitable = true;
            int days = 0;
            int spicesSum = 0;

            if (startingYield >= 100 )
            {
                while (isProfitable)
                {
                    if (startingYield < 100)
                    {
                        spicesSum -= 26;
                        isProfitable = false;
                    }
                    else
                    {
                        spicesSum += startingYield - 26;
                        days++;
                    }

                    startingYield -= 10;
                }
            }

            Console.WriteLine(days);
            Console.WriteLine(spicesSum);
        }
    }
}
