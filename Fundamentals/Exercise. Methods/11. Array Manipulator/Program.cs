using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string line = Console.ReadLine();

            while (line != "end")
            {
                if (line == "")
                {

                }

                string[] parts = line.Split();

                string command = parts[0];

                if (command == "exchange")
                {
                    int idx = int.Parse(parts[1]);
                    Exchange(numbers, idx);
                }

                line = Console.ReadLine();
            }
        }

        private static void Exchange(int[] numbers, int idx)
        {
            if (idx < 0 || idx >= numbers.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            for (int rotation = 0; rotation <= idx; rotation++)
            {
                int firstNumber = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    numbers[i - 1] = i;
                }

                numbers[numbers.Length - 1] = firstNumber;
            }
        }
    }
}
