using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Най_малко_число
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNumber = int.MaxValue;

            while (input!="Stop")
            {
                int n = int.Parse(input);
                if (n<minNumber)
                {
                    minNumber = n;
                }


                input = Console.ReadLine();
            }
            Console.WriteLine(minNumber);




        }
    }
}
