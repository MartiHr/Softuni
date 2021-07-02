using System;
using System.Linq;

namespace _03.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;
            CustomStack<string> stack = new CustomStack<string>();
            while ((command = Console.ReadLine()) != "END")
            {
                string[] elements = command
                    .Split(new string[]{ " ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                
                if (elements[0] == "Pop")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No elements");
                    }
                }
                else if (elements[0] == "Push")
                {
                    foreach (var item in elements.Skip(1).ToArray())
                    {
                        stack.Push(item);

                    }
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
