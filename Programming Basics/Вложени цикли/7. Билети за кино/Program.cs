using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();

            double counter = 0;
            int filmCounter = 0;

            int studentCounter = 0;
            int standardCounter = 0;
            int kidCounter = 0;




            while (filmName != "Finish")
            {
                int freeSpaces = int.Parse(Console.ReadLine());
                double help = freeSpaces;

                string ticketType = Console.ReadLine();

                while (ticketType != "End" && freeSpaces != 0)
                {
                    counter++;
                    filmCounter++;
                    freeSpaces--;

                    switch (ticketType)
                    {
                        case "student":
                            studentCounter++;
                            break;
                        case "standard":
                            standardCounter++;
                            break;
                        case "kid":
                            kidCounter++;
                            break;
                    }
                    if (freeSpaces == 0)
                    {
                        continue;
                    }
                    ticketType = Console.ReadLine();

                }
                Console.WriteLine($"{filmName} - {100 * filmCounter / help:f2}% full.");
                filmCounter = 0;

                filmName = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {counter}");
            Console.WriteLine($"{studentCounter * 100 / counter:f2}% student tickets.");
            Console.WriteLine($"{standardCounter * 100 / counter:f2}% standard tickets.");
            Console.WriteLine($"{kidCounter * 100 / counter:f2}% kids tickets.");




        }
    }
}
