using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string command = Console.ReadLine().ToUpper();

            while (command != "END")
            {
                string[] elements = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (elements[0] == "ADD")
                {
                    int firstNum = int.Parse(elements[1]);
                    int secondNum = int.Parse(elements[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else
                {
                    int count = int.Parse(elements[1]);

                    if (stack.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToUpper();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
