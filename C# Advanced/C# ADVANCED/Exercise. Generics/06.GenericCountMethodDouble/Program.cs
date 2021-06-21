using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> elements = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                elements.Add(element);
            }

            Box<double> box = new Box<double>(elements);

            double comparisonElement = double.Parse(Console.ReadLine());

            Console.WriteLine(box.ComparisonByValue(elements, comparisonElement));
        }
    }
}
