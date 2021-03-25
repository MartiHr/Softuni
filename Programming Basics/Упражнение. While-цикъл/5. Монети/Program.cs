using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Монети
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2.00, 1.00, 0.50, 0.20, 0.10, 0.05, 0.02, 0.01
            
            double change = double.Parse(Console.ReadLine());
            double stotinki =Math.Floor(change * 100);
            int coins = 0;

            while (stotinki>0)
            {
                if (stotinki-200>=0)
                {
                    coins++;
                    stotinki -= 200;
                }
                else if(stotinki-100>=0)
                {
                    coins++;
                    stotinki -= 100;
                }
                else if (stotinki - 50 >= 0)
                {
                    coins++;
                    stotinki -= 50;
                }
                else if (stotinki - 20>= 0)
                {
                    coins++;
                    stotinki -= 20;
                }
                else if (stotinki - 10>= 0)
                {
                    coins++;
                    stotinki -= 10;
                }
                else if (stotinki - 5>= 0)
                {
                    coins++;
                    stotinki -= 5;
                }
                else if (stotinki - 2>= 0)
                {
                    coins++;
                    stotinki -= 2;
                }
                else if (stotinki - 1>= 0)
                {
                    coins++;
                    stotinki -= 1;
                }
            }

            Console.WriteLine(coins);


        }
    }
}
