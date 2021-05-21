using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray();

            Stack<string> stack = new Stack<string>(input);
            
            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string character = stack.Pop();
                int second = int.Parse(stack.Pop());

                if (character == "+")
                {
                    stack.Push((first + second).ToString());
                }
                else if (character == "-")
                {
                    stack.Push((first - second).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
