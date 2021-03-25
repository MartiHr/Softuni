using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numberLine = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < numberLine.Count - 1; i++)
            {
                if (numberLine[i] == numberLine[i + 1])
                {
                    numberLine[i] += numberLine[i + 1];
                    numberLine.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(String.Join(" ", numberLine));
        }
    }
}
