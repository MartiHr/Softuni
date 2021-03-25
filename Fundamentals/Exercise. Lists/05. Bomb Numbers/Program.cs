using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bombData = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bomb = bombData[0];
            int power = bombData[1];

            while (true)
            {
                int bombIndex = numbers.IndexOf(bomb);

                if (bombIndex == -1)
                {
                    break;
                }

                int startIndex = bombIndex - power;

                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                int bombRange = 2 * power + 1;

                if (bombRange > numbers.Count - startIndex)
                {
                    bombRange = numbers.Count - startIndex;
                }

                numbers.RemoveRange(startIndex, bombRange);
            }

            int sum = 0;

            foreach (var number in numbers) 
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
