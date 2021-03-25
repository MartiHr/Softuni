using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Обръщение_според_възраст_и_пол
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
           
            if (gender=="f")
            {
                if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }
            else if (gender == "m")
            {
                if (age>=16)
                {
                    Console.WriteLine("Mr.");
                }
                else 
                {
                    Console.WriteLine("Master");
                }
            }


        }
    }
}
