using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        int[] sortedCoins = coins
                  .OrderByDescending(x => x)
                  .ToArray();

        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        int currentIndex = 0;
        int currentCoin = sortedCoins[currentIndex];

        while (targetSum > 0)
        {
            if (targetSum - currentCoin >= 0)
            {
                if (!dictionary.ContainsKey(currentCoin))
                {
                    dictionary.Add(currentCoin, 0);
                }
                dictionary[currentCoin]++;
                targetSum -= currentCoin;
            }
            else
            {
                if (currentIndex + 1 < coins.Count)
                {
                    currentIndex++;
                }
            }

            currentCoin = sortedCoins[currentIndex];
        }

        return dictionary;
    }
}