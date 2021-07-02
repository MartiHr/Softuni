using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            (int n, int m) dimensions = GetTwoIntegersFromTheConsole(command);
            int n = dimensions.n;
            int m = dimensions.m;

            int[,] gardenMatrix = new int[n, m];
            FillGardenMatrix(gardenMatrix);

            string command2 = string.Empty;

            List<(int row, int col)> plantedCoordinates = new List<(int row, int col)>();

            while ((command2 = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                (int row, int col) coordinates = GetTwoIntegersFromTheConsole(command2);
                int row = coordinates.row;
                int col = coordinates.col;

                if (IsInTheMatrix(gardenMatrix, row, col))
                {
                    plantedCoordinates.Add((row, col));
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            foreach (var coordinate in plantedCoordinates)
            {
                int row = coordinate.row;
                int col = coordinate.col;

                BloomFlowers(row, col, gardenMatrix);
            }

            PrintMatrix(gardenMatrix);
        }

        private static void PrintMatrix(int[,] gardenMatrix)
        {
            for (int i = 0; i < gardenMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < gardenMatrix.GetLength(1); j++)
                {
                    Console.Write($"{gardenMatrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        private static void BloomFlowers(int row, int col, int[,] gardenMatrix)
        {
            for (int i = 0; i < gardenMatrix.GetLength(0); i++)
            {
                gardenMatrix[col, i]++;
            }
            for (int i = 0; i < gardenMatrix.GetLength(1); i++)
            {
                gardenMatrix[i, row]++;
            }

            gardenMatrix[row, col]--;
        }

        private static bool IsInTheMatrix(int[,] gardenMatrix, int row, int col)
        {
            if (row >= 0 && row < gardenMatrix.GetLength(0) && col >= 0 && col < gardenMatrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static void FillGardenMatrix(int[,] gardenMatrix)
        {
            for (int i = 0; i < gardenMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < gardenMatrix.GetLength(1); j++)
                {
                    gardenMatrix[i, j] = 0;
                }
            }
        }

        private static (int, int) GetTwoIntegersFromTheConsole(string command)
        {
            int[] numbers = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return (numbers[0], numbers[1]);
        }
    }
}
