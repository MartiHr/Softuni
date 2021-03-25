using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Стъпки
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;

            while (input != "Going home")
            {
                int steps = int.Parse(input);
                sum += steps;
                if (sum >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{sum - 10000} steps over the goal!");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input =="Going home")
            {
                int lastSteps = int.Parse(Console.ReadLine());
                sum += lastSteps;
                if (sum>10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{sum - 10000} steps over the goal!");
                }
                else
                {
                    Console.WriteLine($"{10000-sum} more steps to reach goal.");
                }
            }



        }
    }
}
