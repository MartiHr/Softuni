using System;

namespace _01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0 || number > 120)
                {
                    throw new ArgumentException();
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Number is not in the range [0, 120]");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
