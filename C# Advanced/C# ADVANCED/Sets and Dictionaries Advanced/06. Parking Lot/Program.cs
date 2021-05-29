using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            HashSet<string> set = new HashSet<string>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] elements = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = elements[0];
                string carNumber = elements[1];

                if (direction == "IN")
                {
                    set.Add(carNumber);
                }
                else
                {
                    set.Remove(carNumber);
                }
            }

            if (set.Count > 0)
            {
                foreach (var item in set)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
