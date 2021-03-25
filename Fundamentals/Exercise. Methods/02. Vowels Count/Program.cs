using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int result = GetVowels(text);

            Console.WriteLine(result);
        }

        private static int GetVowels(string text)
        {
            int counter = 0;
            
            for (int i = 0; i < text.Length; i++)
            {
                string current = text[i].ToString()
                    .ToLower();

                if (current == "a" ||
                    current == "o" ||
                    current == "u" ||
                    current == "y" ||
                    current == "e" ||
                    current == "i")
                {
                    counter++; 
                }
            }

            return counter;
        }
    }
}
