using System;

namespace _4._Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;

            if (minutes>59)
            {
                hour += 1;
                minutes -= 60;
            }

            if (hour>23)
            {
                hour = 0;
            }

            Console.WriteLine($"{hour}:{minutes:d2}");
        }
    }
}
