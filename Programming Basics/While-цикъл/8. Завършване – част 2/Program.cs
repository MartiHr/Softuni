using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Завършване___част_2
{
    class Program
    {
        static void Main(string[] args)
        {   
            string name = Console.ReadLine();
            int i = 1;
            int badCounter = 0;
           
            double averageGrade = 0;
            
            while (i<=12)
            {
                double grade = double.Parse(Console.ReadLine());
                
                if (grade>=4&&badCounter<2)
                {
                    averageGrade += grade;
                    i++;
                    continue;   
                }
                else
                {
                    badCounter++;
                }
                if (badCounter==2)
                {
                    Console.WriteLine($"{name} has been excluded at {i} grade");
                    break;
                }
            }
            if (badCounter!=2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade / 12:f2}");
            }
            



        }
    }
}
