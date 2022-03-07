using System;
using System.Linq;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int[,] matrix = new int[r, c];
            FillMatrix(matrix);

            Console.WriteLine(GetNumbersInSpiral(matrix, r, c));
        }


        public static bool IsInMatrix(int[,] matrix, int r, int c)
        {
            if (r < 0 || c < 0 || r >= matrix.GetLength(0) || c >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        public static void FillMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }


        static string GetNumbersInSpiral(int[,] matrix, int r, int c)
        {
            string result = string.Empty;

            int i = 0;
            int x = 0;
            int y = 0;

            while (x < r && y < c)
            {
                for (i = y; i < c; ++i)
                {
                    result += matrix[x, i] + " ";
                }
                x++;

                for (i = x; i < r; ++i)
                {
                    result += matrix[i, c - 1] + " ";
                }

                c--;

                if (x < r)
                {
                    for (i = c - 1; i >= y; --i)
                    {
                        result += matrix[r - 1, i] + " ";
                    }

                    r--;
                }

                if (y < c)
                {
                    for (i = r - 1; i >= x; --i)
                    {
                        result += matrix[i, y] + " ";
                    }

                    y++;
                }

            }

            return result;
        }
    }
}
