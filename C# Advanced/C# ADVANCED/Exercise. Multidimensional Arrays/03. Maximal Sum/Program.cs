using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {

                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = FindSumOfSubmatrix(matrix, row, col, 0);

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxRow; i <= maxRow + 2; i++)
            {
                for (int j = maxCol; j <= maxCol + 2; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        
        }

        private static int FindSumOfSubmatrix(int[,] matrix, int row, int col, int currentSum)
        {
            for (int i = row; i <= row + 2; i++)
            {
                for (int j = col; j <= col + 2; j++)
                {
                    currentSum += matrix[i, j];
                }
            }

            return currentSum;
        }
    }
}
