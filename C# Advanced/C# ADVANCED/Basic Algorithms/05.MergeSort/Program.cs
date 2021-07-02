using System;
using System.Linq;

namespace _05.MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            MergeSort<int> sorter = new MergeSort<int>();
            int[] sorted = sorter.Sort(items);
            Console.WriteLine(string.Join(" ", sorted));
        }

        public class MergeSort<T> where T : IComparable
        {
            public T[] Sort(T[] arr)
            {
                if (arr.Length <= 1)
                {
                    return arr;
                }
                int middle = arr.Length / 2;
                T[] firstHalf = new T[middle];
                T[] secondHalf = new T[arr.Length - middle];

                Array.ConstrainedCopy(arr, 0, firstHalf, 0, middle);
                Array.ConstrainedCopy(arr, middle, secondHalf, 0, arr.Length - middle);

                firstHalf = Sort(firstHalf);
                secondHalf = Sort(secondHalf);

                T[] sorted = Merge(firstHalf, secondHalf);
                return sorted;
            }

            private T[] Merge(T[] left, T[] right)
            {
                T[] mergedItems = new T[left.Length + right.Length];

                int rightIndex = 0;
                int leftIndex = 0;

                while (leftIndex < left.Length || rightIndex < right.Length)
                {
                    int mergeIndex = rightIndex + leftIndex;

                    if (leftIndex < left.Length && rightIndex < right.Length)
                    {
                        bool leftItemPredecedesRight = left[leftIndex].CompareTo(right[rightIndex]) < 0;

                        if (leftItemPredecedesRight)
                        {
                            mergedItems[mergeIndex] = left[leftIndex++];
                        }
                        else
                        {
                            mergedItems[mergeIndex] = right[rightIndex++];

                        }
                    }
                    else if (leftIndex < left.Length)
                    {
                        mergedItems[mergeIndex] = left[leftIndex++];
                    }
                    else if (rightIndex < right.Length)
                    {
                        mergedItems[mergeIndex] = right[rightIndex++];
                    }
                }

                return mergedItems;
            }
        }
    }

    
}
