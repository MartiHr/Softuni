using System;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();
            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int randomNumber = rnd.Next(words.Length);

                string currentWord = words[i];
                words[i] = words[randomNumber];
                words[randomNumber] = currentWord;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}

