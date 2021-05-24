using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
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

            for (int col = 0; col < sizes[1]; col++)
            {
                int sum = 0;

                for (int row = 0; row < sizes[0]; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }

        }
    }
}
