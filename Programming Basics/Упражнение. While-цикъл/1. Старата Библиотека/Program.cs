using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Старата_Библиотека
{
    class Program
    {
        static void Main(string[] args)
        {
          
            string wantedBook =Console.ReadLine();
            
            string book =Console.ReadLine();

            int counter = 0;

            while (book!=wantedBook)
            {
                book = Console.ReadLine();
                counter++;
                
                if (book=="No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
            }
            if (book == wantedBook)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }


        }
    }
}
