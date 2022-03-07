using System;
using System.Linq;

namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int boxesCount = 0;

                boxesCount = (int)Math.Ceiling(numbers.Length / 2M);
                bool generalTruth = false;

                for (int k = 0; k < 10; k++)
                {
                    int[] boxes = BruteForce(numbers, boxesCount);
                    bool areSame = true;
                    for (int j = 0; j < boxes.Length - 1; j++)
                    {
                        if (boxes[j] != boxes[j + 1])
                        {
                            areSame = false;
                        }
                    }

                    if (areSame == true)
                    {
                        generalTruth = true;
                    }
                }

                if (generalTruth)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }

            }
        }

        public static int[] BruteForce(int[] numbers, int boxexCount)
        {
            Random rnd = new Random();

            int[] boxes = new int[boxexCount];

            for (int i = 0; i < boxexCount; i++)
            {
                int rndIndex = rnd.Next(numbers.Length);
                int randomNumber = numbers[rndIndex];

                int rndIndex2 = rnd.Next(numbers.Length);

                while (rndIndex2 == rndIndex)
                {
                    rndIndex2 = rnd.Next(numbers.Length);
                }

                int randomNumber2 = numbers[rndIndex2];

                boxes[i] = randomNumber + randomNumber2;
            }

            return boxes;
        }
    }
}
