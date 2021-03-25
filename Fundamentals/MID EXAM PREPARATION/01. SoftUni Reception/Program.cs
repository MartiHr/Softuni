using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployerCapacity = int.Parse(Console.ReadLine());
            int secomdEmployerCapacity = int.Parse(Console.ReadLine());
            int thirdEmployerCapacity = int.Parse(Console.ReadLine());

            int count = int.Parse(Console.ReadLine());

            int hoursNeeded = 0;
            int combinedCapacity = firstEmployerCapacity + secomdEmployerCapacity + thirdEmployerCapacity;

            while (count > 0)
            {
                count -= combinedCapacity;
                hoursNeeded++;

                if (hoursNeeded % 4 == 0)
                {
                    hoursNeeded++;
                }
            }

            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
