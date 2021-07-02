using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        int[] universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
        int[][] sets = new[]
        {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (int[] set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        List<int[]> listOfSets = new List<int[]>();

        List<int> elementsToFind = universe
            .ToList();

        int biggestSetIndex = -1;
        int mostMatchingElements = int.MinValue;
        
        while (elementsToFind.Count > 0)
        {
            int[] currentSet = FindBiggestSet(sets, elementsToFind, ref biggestSetIndex, ref mostMatchingElements);
            listOfSets.Add(currentSet);
            foreach (var item in currentSet)
            {
                elementsToFind.Remove(item);
            }
            sets.Remove(currentSet);
            mostMatchingElements = 0;
        }

        return listOfSets;
    }

    private static int[] FindBiggestSet(IList<int[]> sets, List<int> elementsToFind, ref int biggestSetIndex, ref int mostMatchingElements)
    {
        foreach (var set in sets)
        {
            int currentSetMathingElements = 0;

            foreach (var item in set)
            {
                if (elementsToFind.Contains(item))
                {
                    currentSetMathingElements++;
                }
            }

            if (currentSetMathingElements > mostMatchingElements)
            {
                mostMatchingElements = currentSetMathingElements;
                biggestSetIndex = sets.IndexOf(set);
            }
        }

        return sets[biggestSetIndex];
    }
}
