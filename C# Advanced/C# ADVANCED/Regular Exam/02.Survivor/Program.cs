using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] jagged = new char[n][];
            FillMatrix(n, jagged);

            string command = string.Empty;

            int collectedTokens = 0;
            int enemyTokens = 0;

            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] elements = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (elements[0] == "Find")
                {
                    int row = int.Parse(elements[1]);
                    int col = int.Parse(elements[2]);

                    if (IsInJagged(jagged, row, col))
                    {
                        if (jagged[row][col] == 'T')
                        {
                            collectedTokens++;
                            jagged[row][col] = '-';
                        }
                    }
                }
                else if (elements[0] == "Opponent")
                {
                    int row = int.Parse(elements[1]);
                    int col = int.Parse(elements[2]);
                    string direction = elements[3];
                    int tokensFromMovement = 0;

                    if (IsInJagged(jagged, row, col))
                    {
                        if (jagged[row][col] == 'T')
                        {
                            enemyTokens++;
                            jagged[row][col] = '-';
                        }
                     
                        tokensFromMovement += GetTokensFromMovement(jagged, row, col, direction);
                    }
                    
                    enemyTokens += tokensFromMovement;
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyTokens}");
        }

        private static int GetTokensFromMovement(char[][] jagged, int row, int col, string direction)
        {
            int tokens = 0;
            for (int i = 0; i < 3; i++)
            {
                if (direction == "up")
                {
                    row--;
                    if (IsInJagged(jagged, row, col))
                    {
                        if (jagged[row][col] == 'T')
                        {
                            tokens++;
                            jagged[row][col] = '-';
                        }
                    }
                }
                else if (direction == "down")
                {
                    row++;
                    if (IsInJagged(jagged, row, col))
                    {
                        if (jagged[row][col] == 'T')
                        {
                            tokens++;
                            jagged[row][col] = '-';
                        }
                    }
                }
                else if (direction == "right")
                {
                    col++;
                    if (IsInJagged(jagged, row, col))
                    {
                        if (jagged[row][col] == 'T')
                        {
                            tokens++;
                            jagged[row][col] = '-';
                        }
                    }
                }
                else if (direction == "left")
                {
                    col--;
                    if (IsInJagged(jagged, row, col))
                    {
                        if (jagged[row][col] == 'T')
                        {
                            tokens++;
                            jagged[row][col] = '-';
                        }
                    }
                }
            }

            return tokens;
        }

        private static bool IsInJagged(char[][] jagged, int row, int col)
        {
            if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
            {
                return true;
            }

            return false;
        }

        private static void FillMatrix(int n, char[][] jagged)
        {
            for (int i = 0; i < n; i++)
            {
                char[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                jagged[i] = arr;
            }
        }
    }
}
