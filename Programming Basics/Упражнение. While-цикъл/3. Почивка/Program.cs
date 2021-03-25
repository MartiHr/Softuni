using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Почивка
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int spendingCounter = 0;
            int daysCounter = 0;

            while (availableMoney < moneyNeeded && spendingCounter < 5)
            {
                string action = Console.ReadLine();
                double actionMoney = double.Parse(Console.ReadLine());

                daysCounter++;

                if (action == "save")
                {
                    spendingCounter = 0;
                    availableMoney =availableMoney+ actionMoney;
                    if (availableMoney >= moneyNeeded)
                    {
                        Console.WriteLine($"You saved the money for {daysCounter} days.");
                        break;
                    }
                }
                else if (action == "spend")
                {
                    spendingCounter++;
                    if (spendingCounter == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{spendingCounter}");
                        break;
                    }
                    if (actionMoney > availableMoney)
                    {
                        availableMoney = 0;
                    }
                    else
                    {
                        availableMoney =availableMoney- actionMoney;
                    }
                }
            }
            
           
        }
    }
}
