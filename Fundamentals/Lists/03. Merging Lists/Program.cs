using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> combined = new List<int>(firstNums.Count + secondNums.Count);

            for (int i = 0; i < Math.Min(firstNums.Count, secondNums.Count); i++)
            {
                combined.Add(firstNums[i]);
                combined.Add(secondNums[i]);
            }

            if (firstNums.Count != secondNums.Count)
            {
                if (firstNums.Count > secondNums.Count)
                {
                    combined.AddRange(GetRemainingList(firstNums, secondNums));
                }
                else
                {
                    combined.AddRange(GetRemainingList(secondNums, firstNums));
                }
            }

            Console.WriteLine(String.Join(" ", combined));
        }

        private static List<int> GetRemainingList(List<int> biggerList, List<int> smallerList)
        {
            List<int> remaining = new List<int>(biggerList.Count - smallerList.Count);
            
            for (int i = smallerList.Count; i < biggerList.Count; i++)
            {
                remaining.Add(biggerList[i]);
            }

            return remaining;
        }
    }
}
