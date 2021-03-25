using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int longestSequenceLenght = 0;
            int currentSequenceType = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                int currentSequnceLength = 1;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        currentSequnceLength++; 
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentSequnceLength > longestSequenceLenght)
                {
                    longestSequenceLenght = currentSequnceLength;
                    currentSequenceType = array[i];
                }
            }

            for (int i = 0; i < longestSequenceLenght; i++) 
            {
                Console.Write($"{currentSequenceType} ");
            }
        }
    }
}
