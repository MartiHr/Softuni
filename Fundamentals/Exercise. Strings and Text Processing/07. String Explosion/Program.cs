using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder(); 

            int bombPower = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];

                if (currentSymbol == '>')
                {
                    bombPower += int.Parse(input[i + 1].ToString());
                    result.Append('>');
                }
                else
                {
                    if (bombPower > 0)
                    {
                        bombPower--;
                    }
                    else
                    {
                        result.Append(currentSymbol);
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
