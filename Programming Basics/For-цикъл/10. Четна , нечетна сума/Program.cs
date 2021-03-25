using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Четна___нечетна_сума
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;


            for (int i = 1; i <=n; i++) 
            {
                if (i%2==0)
                {
                    int a1 = int.Parse(Console.ReadLine());
                    sum1 = sum1 + a1;
                }
                else
                {
                    int a2 = int.Parse(Console.ReadLine());
                    sum2 = sum2 + a2;
                }
            }
            if (sum1==sum2)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum1}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sum1-sum2)}");
            }



        }
    }
}
