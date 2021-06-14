using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> print = n => Console.WriteLine(string.Join(" ", n));

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = ApplyFunction(numbers, n => ++n);
                        break;
                    case "multiply":
                        numbers = ApplyFunction(numbers, n => n *= 2);
                        break;
                    case "subtract":
                        numbers = ApplyFunction(numbers, n => --n);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }

        public static int[] ApplyFunction(int[] numbers, Func<int, int> func)
        {
            numbers = numbers
                .Select(n => func(n))
                .ToArray();

            return numbers;
        }
    }
}
