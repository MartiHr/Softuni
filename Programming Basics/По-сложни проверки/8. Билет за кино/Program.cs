using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Билет_за_кино
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayOfTheWeek = Console.ReadLine();

            switch (dayOfTheWeek)
            {
                case "Monday":
                    Console.WriteLine(12);
                    break;
                case "Tuesday":
                    Console.WriteLine(12);
                    break;
                case "Wednesday":
                    Console.WriteLine(14);
                    break;
                case "Thursday":
                    Console.WriteLine(14);
                    break;
                case "Friday":
                    Console.WriteLine(12);
                    break;
                case "Saturday":
                    Console.WriteLine(16);
                    break;
                case "Sunday":
                    Console.WriteLine(16);
                    break;

               
            }




        }
    }
}
