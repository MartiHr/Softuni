using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("words.txt");
            Dictionary<string, int> valueByWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                valueByWords.Add(word, 0);
            }

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }

            string text = File.ReadAllText("text.txt").ToLower();
            string[] wordsInText = text
                .Split(new char[] { '-', ',', '.', '!', '?', '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                foreach (var newWord in wordsInText)
                {
                    if (newWord == word)
                    {
                        valueByWords[word]++;
                    }
                }
               
            }

            List<string> actualResult = new List<string>();
            List<string> expectedResult = new List<string>();

            foreach (var kvp in valueByWords)
            {
                actualResult.Add($"{kvp.Key} - {kvp.Value}");
            }
            foreach (var kvp in valueByWords.OrderByDescending(x => x.Value))
            {
                expectedResult.Add($"{kvp.Key} - {kvp.Value}");
            }

            File.WriteAllLines("actualResults.txt", actualResult);
            File.WriteAllLines("expectedResult.txt", expectedResult);
        }
    }
}
