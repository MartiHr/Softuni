using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Лятно_облекло
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = int.Parse(Console.ReadLine());
            string timeOfDay= Console.ReadLine();
            string outfit = "";
            string shoes = "";
           

            if (temp>=10&&temp<=18)
            {
                if (timeOfDay=="Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (temp>18&&temp<=24)
            {
                if (timeOfDay == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else 
            {
                if (timeOfDay == "Мorning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if(timeOfDay == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");



        }
    }
}
