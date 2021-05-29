using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = elements[0];
              
                if (command != "swap" || elements.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                
                int row1 = int.Parse(elements[1]);
                int col1 = int.Parse(elements[2]);
                int row2 = int.Parse(elements[3]);
                int col2 = int.Parse(elements[4]);

                if (row1 < 0 || row1 > matrix.GetLength(0) - 1 || col1 < 0 || col1 > matrix.GetLength(1) - 1
                    || row2 < 0 || row2 > matrix.GetLength(0) - 1 || col2 < 0 || col2 > matrix.GetLength(1) - 1)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                
                string firstElementValue = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = firstElementValue;
                PrintMatrix(matrix);

                input = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
