using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Преместване
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght= int.Parse(Console.ReadLine());
            int height= int.Parse(Console.ReadLine());
            
            int freeSpace= width*lenght*height;

            int startingFreeSpace = freeSpace;
            int sum = 0;

            string input = Console.ReadLine();

            while (input!="Done")
            {
                int amount = int.Parse(input);
                freeSpace -= amount;
                sum += amount;
                if (freeSpace<0)
                {
                    Console.WriteLine($"No more free space! You need {sum-startingFreeSpace} Cubic meters more.");
                    break;
                }
          
                input = Console.ReadLine();
            }

            if (freeSpace>0)
            {
                Console.WriteLine($"{startingFreeSpace-sum} Cubic meters left.");
            }




        }
    }
}
