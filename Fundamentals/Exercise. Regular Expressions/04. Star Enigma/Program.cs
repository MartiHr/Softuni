using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            List<string> attackedPlanetsNames = new List<string>();
            List<string> destroyedPlanetsNames = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();
               
                Regex decryption = new Regex(@"[starSTAR]");
                
                MatchCollection letters = decryption.Matches(encryptedMessage);

                int decryptionKey = letters.Count;

                string decryptedMessage = string.Empty;

                foreach (var letter in encryptedMessage)
                {
                    decryptedMessage += (char)(letter - decryptionKey);
                }

                Regex regex = new Regex
                    (@"@(?<name>[a-zA-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<type>A|D)![^@\-!:>]*->(?<count>\d+)");

                Match match = regex.Match(decryptedMessage);

                if (!match.Success)
                {
                    continue;
                }

                string planetName = match.Groups["name"].Value;
                string planetPopulation = match.Groups["population"].Value;
                string attackType = match.Groups["type"].Value;
                int soldiersCount = int.Parse(match.Groups["count"].Value);

                if (attackType == "A")
                {
                    attackedPlanetsNames.Add(planetName);
                }
                else
                {
                    destroyedPlanetsNames.Add(planetName);
                }
            }

            attackedPlanetsNames.Sort();
            destroyedPlanetsNames.Sort();

            Console.WriteLine($"Attacked planets: {attackedPlanetsNames.Count}");

            foreach (var planet in attackedPlanetsNames)
            {
                Console.WriteLine($"-> {planet}");
            }
            
            Console.WriteLine($"Destroyed planets: {destroyedPlanetsNames.Count}");

            foreach (var planet in destroyedPlanetsNames)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
