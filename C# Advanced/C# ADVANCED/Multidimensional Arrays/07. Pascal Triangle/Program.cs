using System;

namespace _07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());

            long[][] triangle = new long[height][];


            for (int i = 0; i < height; i++)
            {
                long[] row = new long[i + 1];
                row[0] = 1;
                row[row.Length - 1] = 1;

                for (int j = 1; j < i; j++)
                {
                    row[j] = triangle[i - 1][j] + triangle[i - 1][j - 1];
                }

                triangle[i] = row;
            }

            foreach (long[] item in triangle)
            {   
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
