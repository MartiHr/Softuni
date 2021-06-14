using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> checkLength = (str, n) => 
            str.ToCharArray().Select(ch => (int)ch).Sum() >= n;

            Func<string[], int, Func<string, int, bool>, string> firstValidName = (arr, n, func) => arr
                .FirstOrDefault(str => func(str, n));

            var result = firstValidName(names, n, checkLength);

            Console.WriteLine(result);
        }
    }
}
