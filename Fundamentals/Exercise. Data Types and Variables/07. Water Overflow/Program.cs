using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int waterTank = 255;
            int pourSum = 0;

            for (int i = 0; i < n; i++)
            {
                int pour = int.Parse(Console.ReadLine());
                
                if (pour <= waterTank)
                {
                    waterTank -= pour;
                    pourSum += pour;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            
            Console.WriteLine(pourSum);
        }
    }
}
