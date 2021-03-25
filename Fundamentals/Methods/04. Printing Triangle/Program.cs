using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= num; i++)
            {
                Print(i);
            }
            for (int i = num - 1; i >= 1; i--)
            {
                Print(i);
            }
        }

        static void Print(int num)
        {
            for (int j = 1; j <= num; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}
