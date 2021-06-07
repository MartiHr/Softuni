using System;
using System.IO;
using System.Linq;

namespace _01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader str = new StreamReader("text.txt"))
            {
                int count = 0;
                char[] symbols = { '-', ',', '.', '!', '?' };

                while (!str.EndOfStream)
                {
                    string line = str.ReadLine();

                    if (count % 2 == 0)
                    {
                        foreach (var symbol in symbols)
                        {
                            if (line.Contains(symbol))
                            {
                                line = line.Replace(symbol, '@');
                            }
                        }
                    }

                    string[] tokens = line
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                    Console.WriteLine(string.Join(" ", tokens.Reverse()));

                    count++;
                }
            }
        }
    }
}
