using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removeWord = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            int startIndex = text.IndexOf(removeWord);

            while (startIndex != -1)
            {
                text = text.Remove(startIndex, removeWord.Length);
                startIndex = text.IndexOf(removeWord); 
            }

            Console.WriteLine(text);
        }
    }
}
