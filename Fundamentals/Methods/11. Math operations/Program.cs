using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = int.Parse(Console.ReadLine());
            char mathOperator = char.Parse(Console.ReadLine());
            double secondNumber = int.Parse(Console.ReadLine());

            double result = MathOperations(firstNumber, mathOperator, secondNumber);

            Console.WriteLine($"{Math.Round(result, 2)}");
        }

        static double MathOperations(double firstNum, char sign , double secondNum)
        {
            double result = 0;
            
            switch (sign)
            {
                case '/':
                    result = firstNum / secondNum;
                    break;
                case '*':
                    result = firstNum * secondNum;
                    break;
                case '+':
                    result = firstNum + secondNum;
                    break;
                case '-':
                    result = firstNum - secondNum;
                    break;

            }

            return result;
        }
    }
}
