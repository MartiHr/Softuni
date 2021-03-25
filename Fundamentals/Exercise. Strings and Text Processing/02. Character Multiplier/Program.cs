using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string line1 = input[0];
            string line2 = input[1];

            int result = SumOfCharactersValues(line1, line2);

            Console.WriteLine(result);
        }

        private static int SumOfCharactersValues(string first, string second)
        {
            string shorter = string.Empty;
            string longer = string.Empty;
            
            if (first.Length >= second.Length)
            {
                longer = first;
                shorter = second;
            }
            else
            {
                longer = second;
                shorter = first;
            }

            int sum = 0;

            for (int i = 0; i < shorter.Length; i++)
            {
                sum += longer[i] * shorter[i];
            }

            for (int i = shorter.Length; i < longer.Length; i++)
            {
                sum += longer[i];
            }

            return sum;
        }
    }
}
