using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            double sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            double average = sum / numbers.Count;

            numbers.RemoveAll(x => x <= average);
            numbers.Sort();
            numbers.Reverse();

            if (numbers.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }
           
            if (numbers.Count > 5)
            {
                numbers.RemoveRange(5, numbers.Count - 5);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
