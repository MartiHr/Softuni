using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Четни_степени_на_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            for (int i = 0; i <= n; i+=2)
            {
                double result = Math.Pow(2, i);
                Console.WriteLine(result);

            }






        }
    }
}
