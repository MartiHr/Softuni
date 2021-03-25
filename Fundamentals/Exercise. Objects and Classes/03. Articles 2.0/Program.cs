using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articlesList = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
               .Split(", ");

                Article currentArticle = new Article()
                {
                    Title = elements[0],
                    Content = elements[1],
                    Author = elements[2]
                };

                articlesList.Add(currentArticle);
            }
            
            string command = Console.ReadLine();

            List <Article> sortedList = new List<Article>();

            if (command == "title")
            {
                sortedList = articlesList
                    .OrderBy(x => x.Title)
                    .ToList() ;
            }
            else if (command == "content")
            {
                sortedList = articlesList
                    .OrderBy(x => x.Content)
                    .ToList();
            }
            else
            {
                sortedList = articlesList
                     .OrderBy(x => x.Author)
                     .ToList();
            }

            foreach (var article in sortedList)
            {
                Console.WriteLine(article);
            }

            // Another way for printing:
            //Console.WriteLine(string.Join(Environment.NewLine, sortedList));
        }
    }
}
