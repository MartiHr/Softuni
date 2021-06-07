using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");
            string[] results = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];

                int countOfLetters = 0;
                int countOfPunctuationMarks = 0;

                foreach (var character in currentLine)
                {
                    if (char.IsLetter(character))
                    {
                        countOfLetters++;
                    }
                    if (char.IsPunctuation(character))
                    {
                        countOfPunctuationMarks++;
                    }
                }

                results[i] = $"Line {i + 1}: {currentLine} ({countOfLetters})({countOfPunctuationMarks})";
            }

            File.WriteAllLines("output.txt", results);
        }
    }
}
