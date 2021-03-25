using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(?:\b[A-Z][a-z]+) (?:[A-Z][a-z]+)";
           
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            //MatchCollection matches = Regex.Matches(text, pattern); -> Same as two lines above it.

            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
