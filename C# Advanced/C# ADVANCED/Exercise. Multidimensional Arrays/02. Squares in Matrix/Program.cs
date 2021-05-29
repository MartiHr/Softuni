using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char topLeft = matrix[row, col];
                    char topRight = matrix[row, col + 1];
                    char bottomLeft = matrix[row + 1, col];
                    char bottomRight = matrix[row + 1, col + 1];

                    if (topLeft == topRight && topRight == bottomLeft && bottomLeft == bottomRight)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
