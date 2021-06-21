using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();
           
            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                list.Add(str);
            }

            Box<string> box = new Box<string>(list);

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            box.SwapElements(list, indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
