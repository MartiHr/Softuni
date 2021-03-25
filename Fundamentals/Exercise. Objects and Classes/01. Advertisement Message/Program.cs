using System;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use this product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product."
            };
            
            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            
            string[] authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            string[] cities = new string[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            int n = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            
            for (int i = 0; i < n; i++)
            {
                int rndPhraseIndex = rnd.Next(phrases.Length);
                int rndEventIndex = rnd.Next(events.Length);
                int rndAuthorIndex = rnd.Next(authors.Length);
                int rndCityIndex = rnd.Next(cities.Length);

                string message = $"{phrases[rndPhraseIndex]} {events[rndEventIndex]} {authors[rndAuthorIndex]} – {cities[rndCityIndex]}.";
                
                Console.WriteLine(message);
            }
        }
    }
}
