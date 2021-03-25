using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Лява_и_дясна_сума
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
          

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < n; i++)
            {
                int a1 = int.Parse(Console.ReadLine());
                sum1 = sum1 +a1;
            }
            for (int i = 0; i < n; i++)
            {
                int a2 = int.Parse(Console.ReadLine());
                sum2 = sum2+ a2;
            }

            if (sum1==sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sum1 - sum2)}");
            }


        }
    }
}
