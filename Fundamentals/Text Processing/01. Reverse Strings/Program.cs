using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string word = Console.ReadLine();
                
                if (word == "end")
                {
                    break;
                }

                string reversedWord = new string(word.Reverse().ToArray());
                
                Console.WriteLine($"{word} = {reversedWord}");
            }
        }
    }
}
