using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Сума_от_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstN = int.Parse(Console.ReadLine());
           

            int sum = 0;

            while (sum<firstN)
            {

                int n = int.Parse(Console.ReadLine());
                sum += n;
            }
            Console.WriteLine(sum);



        }
    }
}
