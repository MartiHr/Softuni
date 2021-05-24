using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int diagonalSum = 0;

            for (int i = 0; i < n; i++)
            {
                diagonalSum += matrix[i, i];
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
