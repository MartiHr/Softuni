using System;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
             string[] sequences = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            double totalSum = 0;

            foreach (var sequence in sequences)
            {
                char firstLetter = sequence[0];
                char secondLetter = sequence[sequence.Length - 1];
                double number = double.Parse(sequence.Substring(1, sequence.Length - 2));

                if (char.IsUpper(firstLetter))
                {
                    number /= firstLetter - 64;
                }
                else
                {
                    number *= firstLetter - 96;
                }

                if (char.IsUpper(secondLetter))
                {
                    number -= secondLetter - 64;
                }
                else
                {
                    number += secondLetter - 96;
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
