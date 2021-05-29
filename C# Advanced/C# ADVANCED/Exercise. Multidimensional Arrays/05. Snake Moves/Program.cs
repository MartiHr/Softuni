using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Snake_Moves
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

            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char>(sizes[0] * sizes[1]);

            foreach (var item in snake)
            {
                queue.Enqueue(item);
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
