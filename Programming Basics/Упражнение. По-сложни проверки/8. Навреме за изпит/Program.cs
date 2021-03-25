using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Навреме_за_изпит
{
    class Program
    {
        static void Main(string[] args)
        {

            int examHour = int.Parse(Console.ReadLine());
            int examMinute= int.Parse(Console.ReadLine());
            int examTime = examHour * 60 + examMinute;
            int arrivalHour= int.Parse(Console.ReadLine()); 
            int arrivalMinute= int.Parse(Console.ReadLine());
            int arrivalTime = arrivalHour * 60 + arrivalMinute;


            if (arrivalTime>examTime)
            {
                Console.WriteLine("Late");
            }
            else if (arrivalTime<=examTime&&arrivalTime>=examTime-30)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("Early");
            }

            if (examTime!=arrivalTime)
            {
                if (examTime-arrivalTime<60)
                {
                    Console.WriteLine($"{Math.Abs(examTime-arrivalTime)} minutes before the start");
                }
                else if (examTime - arrivalTime >= 60)
                {
                    
                    Console.WriteLine($"{examHour-arrivalHour}:{Math.Abs(examMinute-arrivalMinute)} hours before the start");
                }
                else if (examTime - arrivalTime < 60)
                {
                    Console.WriteLine($"{Math.Abs(examTime - arrivalTime)} minutes after the start");
                }
                else if(examTime - arrivalTime <= 60)
                {
                    Console.WriteLine($"{arrivalHour - examHour}:{Math.Abs(arrivalMinute-examMinute)} hours after the start");
                }
            }
            




        }
    }
}
