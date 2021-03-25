using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string sign = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (sign == "add")
            {
                Add(a, b);
            }
            else if (sign == "multiply")
            {
                Multiply(a, b);
            }
            else if (sign == "subtract")
            {
                Subtract(a, b);
            }
            else if (sign == "divide")
            {
                Divide(a, b);
            }
        }
        static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
     
        static void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }
      
        static void Subtract(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        static void Divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }
    }
}
