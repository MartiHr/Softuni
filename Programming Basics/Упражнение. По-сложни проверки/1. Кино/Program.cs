using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Упражнение.По_сложни_проверки
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows= int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            double money = 0;

            if (type== "Premiere")
            {
                 money = rows * columns * 12;
            }
            else if (type == "Normal")
            {
                money = rows * columns * 7.50;
            }
            else
            {
                money = rows * columns * 5;
            }
            Console.WriteLine($"{money:f2}");
        }
    }
}
