using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int addition = Sum(firstNum, secondNum);
            int result = Subtract(addition, thirdNum);

            Console.WriteLine(result);
        }

        private static int Subtract(int a, int b)
        {
            return a - b;
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
