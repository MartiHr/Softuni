using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder other = new StringBuilder();

            foreach (var item in text)
            {
                if (char.IsDigit(item))
                {
                    digits.Append(item);
                }
                else if (char.IsLetter(item))
                {
                    letters.Append(item);
                }
                else
                {
                    other.Append(item);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(other);
        }
    }
}
