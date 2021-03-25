using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Train_the_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int gradesCount = int.Parse(Console.ReadLine());
          
            string presentationName = Console.ReadLine();
            
            double sumOfGrades = 0;
            double presentationGrade = 0;

            double presentationsCount = 0;
            double sumOfPresentations = 0;
            
            while (presentationName!="Finish")
            {
            
                for (int i = 1; i <= gradesCount; i++)
                {
                    sumOfGrades += double.Parse(Console.ReadLine());
                }
                
                presentationGrade = sumOfGrades / gradesCount;
               
                presentationsCount++;
                
                sumOfPresentations += presentationGrade;
               
                Console.WriteLine($"{presentationName} - {presentationGrade:f2}.");
                sumOfGrades = 0;
              
                presentationName = Console.ReadLine();

            }

            Console.WriteLine($"Student's final assessment is {sumOfPresentations / presentationsCount:f2}.");


        }
    }
}
