using System;
using System.Text.RegularExpressions;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"^(.+)>(?<numbers>\d+)\|(?<lower>[a-z]{3})\|(?<upper>[A-Z]{3})\|(?<character>[^<>]{3})<\1$");

            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();

                Match valid = regex.Match(password);

                if (!valid.Success)
                {
                    Console.WriteLine("Try another password!");
                }
                else
                {
                    string numbers = valid.Groups["numbers"].Value;
                    string lower = valid.Groups["lower"].Value;
                    string upper = valid.Groups["upper"].Value;
                    string character = valid.Groups["character"].Value;

                    Console.WriteLine($"Password: {numbers+lower+upper+character}");
                }

            }
        }
    }
}
