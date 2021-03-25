using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            bool isChanged = false;
            

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] elements = command.Split();

                if (elements[0] == "Contains")
                {
                    bool contains = numbers.Contains(int.Parse(elements[1]));

                    if (contains)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }

                if (elements[0] == "PrintEven")
                {
                    Console.WriteLine(PrintEven(numbers));
                }

                if (elements[0] == "PrintOdd")
                {
                    Console.WriteLine(PrintOdd(numbers));
                }

                if (elements[0] == "GetSum")
                {
                    Console.WriteLine(GetSum(numbers));
                }

                if (elements[0] == "Filter")
                {
                    string condition = elements[1].ToString();
                    int number = int.Parse(elements[2].ToString());

                    GetFiltered(numbers, condition, number);
                }

                command = Console.ReadLine();
            }

            if (isChanged)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }

        static void GetFiltered(List<int> nums, string condtition, int number)
        {
            if (condtition == "<")
            {
                Console.WriteLine(nums.Where(n => n < number)); 
            }
            else if (condtition == ">")
            {
                Console.WriteLine(nums.Where(n => n > number));
            }
            else if (condtition == ">=")
            {
                Console.WriteLine(nums.Where(n => n >= number)); 
            }
            else if (condtition == "<=")
            {
                Console.WriteLine(nums.Where(n => n <= number).ToList()); 
            }
        }

        static string PrintEven(List<int> numbers)
        {
            List<string> result = new List<string>();

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    result.Add(number.ToString());
                }
            }

            return String.Join(" ", result);
        }

        static string PrintOdd(List<int> numbers)
        {
            List<string> result = new List<string>();

            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    result.Add(number.ToString());
                }
            }

            return String.Join(" ", result);
        }

        static int GetSum(List<int> numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}
