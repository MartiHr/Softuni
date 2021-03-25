using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double saberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());
     

            double payPrice = (Math.Ceiling(studentsCount * 1.1) * saberPrice) + (studentsCount * robePrice) + 
                (beltPrice * (studentsCount - (studentsCount/6)));
            
            if (money >= payPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {payPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {payPrice-money:f2}lv more.");
            }

        }
    }
}
