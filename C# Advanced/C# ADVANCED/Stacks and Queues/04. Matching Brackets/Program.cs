using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> bracketIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];

                if (ch == '(')
                {
                    bracketIndexes.Push(i);
                }
                else if (ch == ')')
                {
                    int startingIndex = bracketIndexes.Pop();
                    Console.WriteLine(input.Substring(startingIndex, i - startingIndex + 1));
                }
            }
        }
    }
}
