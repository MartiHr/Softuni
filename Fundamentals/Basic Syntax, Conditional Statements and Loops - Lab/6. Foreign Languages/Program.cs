using System;

namespace _6._Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string language = "";

            switch (country)
            {
                case "England":
                case "USA":
                    language = "English";
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    language = "Spanish";
                    break;
                default:
                    language = "unknown";
                    break;
            }

            Console.WriteLine(language);

        }
    }
}
