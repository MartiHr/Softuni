using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
           
            Predicate<string> predicate = str => str.Length <= n;

            names = names
                .Where(str => predicate(str))
                .ToArray();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
