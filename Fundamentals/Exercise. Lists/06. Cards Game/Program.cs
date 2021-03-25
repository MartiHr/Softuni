using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstHand.Count > 0 && secondHand.Count > 0)
            {
                if (firstHand[0] > secondHand[0])
                {
                    firstHand.Add(firstHand[0]);
                    firstHand.Add(secondHand[0]);
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
                else if (secondHand[0] > firstHand[0])
                {
                    secondHand.Add(secondHand[0]);
                    secondHand.Add(firstHand[0]);
                    secondHand.RemoveAt(0);
                    firstHand.RemoveAt(0);
                }
                else
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
            }

            int sum = 0;

            if (firstHand.Count > 0)
            {
                foreach (int card in firstHand)
                {
                    sum += card;
                }
                
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                foreach (int card in secondHand)
                {
                    sum += card;
                }

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
