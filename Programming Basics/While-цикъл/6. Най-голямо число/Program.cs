using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Най_голямо_число
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxNumber = int.MinValue;


            while (input != "Stop")
            {
                int num = int.Parse(input);
                if (num > maxNumber)
                {
                    maxNumber = num;
                }

                input = Console.ReadLine();


            }
            Console.WriteLine(maxNumber);



        }
    }
}
