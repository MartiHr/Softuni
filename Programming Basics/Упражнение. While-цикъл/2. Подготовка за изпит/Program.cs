using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Подготовка_за_изпит
{
    class Program
    {
        static void Main(string[] args)
        {

            int maxBadGrades = int.Parse(Console.ReadLine());

            string problemName = Console.ReadLine();
            string solve = Console.ReadLine();

            string lastProblem = "";
            int counter = 0;
            double sum = 0;

            bool kicked = false;
            int badGradeCounter = 0;

            while (problemName!="Enough")
            {
                double grade = double.Parse(solve);
                sum += grade;
                counter++;
                if (problemName!="Enough")
                {
                    lastProblem = problemName;
                }
                problemName = Console.ReadLine();
                if (problemName=="Enough")
                {
                    continue;
                }

                if (grade<=4)
                {
                    badGradeCounter++;
                }
                if (badGradeCounter==maxBadGrades)
                {
                    kicked = true;
                    break;
                }
                solve = Console.ReadLine();
            }
            if (kicked)
            {
                Console.WriteLine($"You need a break, {badGradeCounter} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {sum/counter:f2}");
                Console.WriteLine($"Number of problems: {counter}"); 
                Console.WriteLine($"Last problem: {lastProblem}");
            }

        }
    }
}
