using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Stack<string> stack = new Stack<string>(); // holds the history of the changes

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split();

                string command = elements[0];

                if (command == "1")
                {
                    string someString = elements[1];
                    text += someString;
                    
                    stack.Push(text);
                }
                else if (command == "2")
                {
                    int count = int.Parse(elements[1]);
                    text = text.Remove(text.Length - count);
                    
                    stack.Push(text);
                }
                else if (command == "3")
                {
                    int index = int.Parse(elements[1]) - 1;

                    Console.WriteLine(text[index]);
                }
                else
                {
                    if (stack.Any())
                    {
                        if (stack.Peek() == text)
                        {
                            stack.Pop();
                        }

                        text = stack.Pop();
                    }
                    else
                    {
                        text = "";
                    }
                }
            }
        }
    }
}
