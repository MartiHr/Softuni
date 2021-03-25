using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            
            int bestSequenceSize = 0;
            int bestSequenceStartingIndex = 0;
            int bestSeqeunceSum = 0;
            int[] bestSequence = new int[length];
            int bestSample = 1;

            int sample = 0;

            string line = Console.ReadLine();
            while (line != "Clone them!")
            {
                sample++;

                 int[] sequence = line.Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int sequenceSum = 0;
                foreach (int number in sequence)
                {
                    sequenceSum += number;
                }

                for (int i = 0; i < sequence.Length; i++)
                {
                    int currentNumber = sequence[i];
                    if (currentNumber == 0)
                    {
                        continue;
                    }

                    int currentSequenceSize = 0;

                    for (int j = i+1; j < sequence.Length; j++)
                    {
                        if (currentNumber == sequence[j])
                        {
                            currentSequenceSize++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (currentSequenceSize > bestSequenceSize)
                    {
                        bestSequenceSize = currentSequenceSize;
                        bestSequenceStartingIndex = i;
                        bestSeqeunceSum = sequenceSum;
                        bestSequence = sequence;
                        bestSample = sample;
                    }
                    else if (currentSequenceSize == bestSequenceSize)
                    {
                        if (i < bestSequenceStartingIndex)
                        {
                            bestSequenceSize = currentSequenceSize;
                            bestSequenceStartingIndex = i;
                            bestSeqeunceSum = sequenceSum;
                            bestSequence = sequence;
                            bestSample = sample;
                        }
                        else if (i == bestSequenceStartingIndex 
                            && sequenceSum > bestSeqeunceSum)
                        {
                            bestSequenceSize = currentSequenceSize;
                            bestSequenceStartingIndex = i;
                            bestSeqeunceSum = sequenceSum;
                            bestSequence = sequence;
                            bestSample = sample;
                        }
                    }   
                }

                line = Console.ReadLine();
            }


            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSeqeunceSum}.");
            Console.WriteLine(string.Join(' ', bestSequence));
        }
    }
}
