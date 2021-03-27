using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex numberRegex = new Regex(@"\d");

            decimal threshold = 1;

            MatchCollection digits = numberRegex.Matches(text);

            if (digits.Count != 0)
            {
                foreach (Match match in digits)
                {
                    int digit = int.Parse(match.Value);
                    threshold *= digit;
                }
            }
            else
            {
                threshold = 0;
            }

            Console.WriteLine($"Cool threshold: {threshold}");
            
            Regex textRegex = new Regex(@"([:*])\1(?<letters>[A-Z][a-z]{2,})\1\1");

            MatchCollection emojis = textRegex.Matches(text);

            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            foreach (Match emoji in emojis)
            {
                string letters = emoji.Groups["letters"].Value;
                int coolness = 0;

                foreach (var letter in letters)
                {
                    coolness += letter;
                }

                if (coolness >= threshold)
                {
                    Console.WriteLine(emoji.Groups[0].Value);
                }
            }

        }
    }
}
