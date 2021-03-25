using System;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] elements = command.Split();

                if (elements[0] == "swap")
                {
                    int index1 = int.Parse(elements[1]);
                    int index2 = int.Parse(elements[2]);

                    int firstNum = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = firstNum;
                }
                else if (elements[0] == "multiply")
                {
                    int index1 = int.Parse(elements[1]);
                    int index2 = int.Parse(elements[2]);

                    int multiplied = numbers[index1]* numbers[index2];
                    numbers[index1] = multiplied;
                }
                else
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] -= 1;
                    }
                }

                command = Console.ReadLine();
            }
            
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
