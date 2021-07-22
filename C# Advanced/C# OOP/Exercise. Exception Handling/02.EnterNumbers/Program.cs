using System;

namespace _02.EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int start = int.Parse(Console.ReadLine());
                int end = int.Parse(Console.ReadLine());

                int[] numbers = new int[10];

                while (numbers[9] == 0)
                {
                    try
                    {
                        Console.WriteLine("Enter number");
                        int firstNumber = ReadNumber(start, end);

                        if (firstNumber < 2 || firstNumber > 100)
                        {
                            throw new ArgumentOutOfRangeException();
                        }

                        numbers[0] = firstNumber;

                        for (int i = 1; i < numbers.Length; i++)
                        {
                            int previousNumber = numbers[i - 1];
                            Console.WriteLine("Enter number");
                            int currentNumber = ReadNumber(start, end);

                            if (previousNumber < 2 || previousNumber > 100 || currentNumber < previousNumber)
                            {
                                throw new ArgumentOutOfRangeException();
                            }

                            numbers[i] = currentNumber;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        numbers = new int[10];
                        Console.WriteLine($"Number is not int the specified range");
                    }
                    catch (FormatException)
                    {
                        numbers = new int[10];
                        Console.WriteLine("Invalid input");
                    }
                }

                Console.WriteLine("Numbers:");
                foreach (var number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unexcpected failure");
            }
        }

        private static int ReadNumber(int start, int end)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < start || number > end)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return number;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
            catch(FormatException)
            {
                throw new FormatException();
            }
        }
    }
}
