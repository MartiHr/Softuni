using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Умната_Лили
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double machinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());
            
            double savedMoney = 0;
            double moneyFromToys = 0;
            double moneyFromMoney = 0;

            double total = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += 10;
                    moneyFromMoney = moneyFromMoney + savedMoney - 1;
                }
                else
                {
                    moneyFromToys += toysPrice;
                }
            }
            total = moneyFromMoney + moneyFromToys;


            if (total>=machinePrice)
            {
                Console.WriteLine($"Yes! {total-machinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {machinePrice-total:f2}");
            }





        }
    }
}
