using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());   
            int second = int.Parse(Console.ReadLine());   
            int third = int.Parse(Console.ReadLine());

            int smallest = FindSmallestOfThree(first, second, third);

            Console.WriteLine(smallest);
        }

        static int FindSmallestOfThree(int first, int second, int third)
        {
            int min = Math.Min(
                Math.Min(first, second)
                ,third);

            return min;
        }
    }
}
