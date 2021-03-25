using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Торта
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int cakeArea = width * lenght;
            int help = cakeArea;
            string input = Console.ReadLine();
            int piecesSum = 0;

            while (input!="STOP")
            {
                int piece = int.Parse(input);
                cakeArea -= piece;
                piecesSum += piece;
                if (cakeArea < 0)
                {
                    Console.WriteLine($"No more cake left! You need {piecesSum - help} pieces more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "STOP" && cakeArea > 0)
            {
                Console.WriteLine($"{help - piecesSum} pieces are left.");
                
            }

        }
    }
}
