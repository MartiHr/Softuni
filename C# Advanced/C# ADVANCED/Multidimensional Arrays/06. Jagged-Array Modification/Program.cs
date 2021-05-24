using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int i = 0; i < jagged.Length; i++)
                {
                    jagged[row] = arr;
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] elements = command.Split();

                int row = int.Parse(elements[1]);
                int col = int.Parse(elements[2]);
                int value = int.Parse(elements[3]);

                if (row < 0 || row > jagged.Length || col < 0 || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine();
                    continue;
                }

                if (elements[0] == "Add")
                {
                    jagged[row][col] += value;
                }
                else
                {
                    jagged[row][col] -= value;
                }

                command = Console.ReadLine();
            }

            foreach (int[] arr in jagged)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
