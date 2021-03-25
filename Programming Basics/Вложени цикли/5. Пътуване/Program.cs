using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Пътуване
{
    class Program
    {
        static void Main(string[] args)
        {

            string destination = Console.ReadLine();

            while (destination != "End")
            {
                
                int moneyNeeded = int.Parse(Console.ReadLine());
             
                int savedMoney = 0;

                while (savedMoney<moneyNeeded)
                {
                    savedMoney += int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");

                destination = Console.ReadLine();

            }






        }
    }
}
