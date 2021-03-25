using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Заплата
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

          
            for (int i = 0; i < n; i++)
            {
                string siteName = Console.ReadLine();

                if (siteName == "Facebook")
                {
                    salary = salary - 150;
                }
                else if (siteName == "Instagram")
                {
                    salary = salary - 100;
                }
                else if (siteName == "Reddit")
                {
                    salary = salary - 50;
                }

                if (salary<=0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }    
            }
            if (salary>0)
            {
                Console.WriteLine(salary);

            }
            



        }
    }
}
