using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Сума_от_две_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNumber = int.Parse(Console.ReadLine());
            int finalNumber = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());

            bool magic = false;

            int combinationCounter = 0;

            for (int i = startingNumber; i <= finalNumber; i++)
            {
                for (int j = startingNumber; j <= finalNumber; j++)
                {
                    combinationCounter++;
                    if (i+j==magicalNumber)
                    {
                        Console.WriteLine($"Combination N:{combinationCounter} ({i} + {j} = {magicalNumber})");
                        magic = true;
                        break;
                    }
                }
                if (magic==true)
                {
                    break;
                }
            }
            if (magic==false)
            {
                Console.WriteLine($"{combinationCounter} combinations - neither equals {magicalNumber}");
            }
            

        }
    }
}
