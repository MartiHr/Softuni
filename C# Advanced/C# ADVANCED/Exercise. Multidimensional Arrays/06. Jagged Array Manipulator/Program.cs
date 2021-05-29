using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new double[n][];

            for (int i = 0; i < n; i++)
            {
                double[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jagged[i] = arr;
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                    }
                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] /= 2;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                string[] elements = command
                    .Split(" ");

                if (elements[0] == "Add")
                {
                    long row = long.Parse(elements[1]);
                    long col = long.Parse(elements[2]);
                    long value = long.Parse(elements[3]);

                    if (row < 0 || row > jagged.Length - 1 || col < 0 || col > jagged[row].Length - 1)
                    {
                        continue;
                    }

                    jagged[row][col] += value;
                }
                else if (elements[0] == "Subtract")
                {
                    long row = long.Parse(elements[1]);
                    long col = long.Parse(elements[2]);
                    long value = long.Parse(elements[3]);

                    if (row < 0 || row > jagged.Length - 1 || col < 0 || col > jagged[row].Length - 1)
                    {
                        continue;
                    }

                    jagged[row][col] -= value;
                }
                else
                {
                    foreach (var item in jagged)
                    {
                        Console.WriteLine(string.Join(" ", item));
                    }

                    break;
                }
            }
        }
    }
}
