using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Пирамида_от_числа
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int currentNum = 1;
            int count = 0;
            bool currentNumIsBiggerThanTheFirst = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int columns = 1; columns <= rows; columns++)
                {
                    if (currentNum > n)
                    {
                        currentNumIsBiggerThanTheFirst = true;
                        break;
                    }
                    Console.Write(currentNum + " ");
                    currentNum++;
                }
                if (currentNumIsBiggerThanTheFirst)
                {
                    break;
                }
                Console.WriteLine();
            }







        }
    }
}
