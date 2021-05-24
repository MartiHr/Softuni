using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
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
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));

            int sum = 0;

            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
