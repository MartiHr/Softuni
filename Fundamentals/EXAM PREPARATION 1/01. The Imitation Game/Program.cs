using System;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            while (true)
            {
                string[] elements = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                //string result = string.Empty;

                if (elements[0] == "Decode")
                {
                    break;
                }

                if (elements[0] == "Move")
                {
                    int numberOfLetters = int.Parse(elements[1]);

                    string movePart = encryptedMessage.Substring(0, numberOfLetters);
                    encryptedMessage = encryptedMessage.Remove(0, numberOfLetters);
                    encryptedMessage += movePart;
                }
                else if (elements[0] == "Insert")
                {
                    int index = int.Parse(elements[1]);
                    string value = elements[2];

                    encryptedMessage = encryptedMessage.Insert(index, value);
                }
                else 
                {
                    string substring = elements[1];
                    string replacement = elements[2];

                    encryptedMessage = encryptedMessage.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: { encryptedMessage}");
        }
    }
}
