using System;

namespace _07._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxAttacked = 0;
                int knigthRow = 0;
                int knigthCol = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int tempAttacks = CountOfAttacks(row, col, matrix);

                            if (tempAttacks > maxAttacked)
                            {
                                maxAttacked = tempAttacks;
                                knigthRow = row;
                                knigthCol = col;
                            }
                        }
                    }
                }

                if (maxAttacked > 0)
                {
                    matrix[knigthRow, knigthCol] = '0';
                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        private static int CountOfAttacks(int row, int col, char[,] matrix)
        {
            int attacks = 0;

            if (IsInMatrix(row + 2, col + 1, matrix.GetLength(0)) && matrix[row + 2, col + 1] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row + 2, col - 1, matrix.GetLength(0)) && matrix[row + 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row - 2, col + 1, matrix.GetLength(0)) && matrix[row - 2, col + 1] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row - 2, col - 1, matrix.GetLength(0)) && matrix[row - 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row + 1, col - 2, matrix.GetLength(0)) && matrix[row + 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row - 1, col - 2, matrix.GetLength(0)) && matrix[row - 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row + 1, col + 2, matrix.GetLength(0)) && matrix[row + 1, col + 2] == 'K')
            {
                attacks++;
            }

            if (IsInMatrix(row - 1, col + 2, matrix.GetLength(0)) && matrix[row - 1, col + 2] == 'K')
            {
                attacks++;
            }

            return attacks;
        }

        private static bool IsInMatrix(int row, int col, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
