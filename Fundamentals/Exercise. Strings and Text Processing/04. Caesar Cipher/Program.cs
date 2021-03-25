using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string encryptedText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                encryptedText += (char)(text[i] + 3);
            }

            Console.WriteLine(encryptedText);
        }
    }
}
