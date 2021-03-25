using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Почивен_или_работен_ден
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOfTheWeek =Console.ReadLine();

            switch (dayOfTheWeek)
            {
                case "Monday":
                    Console.WriteLine("Working day");
                    break;
                case "Tuesday":
                    Console.WriteLine("Working day");
                    break;
                case "Wednesday":
                    Console.WriteLine("Working day");
                    break;
                case "Thursday":
                    Console.WriteLine("Working day");
                    break;
                case "Friday":
                    Console.WriteLine("Working day");
                    break;
                case "Saturday":
                    Console.WriteLine("Weekend");
                    break;
                case "Sunday":
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }


        }
    }
}
