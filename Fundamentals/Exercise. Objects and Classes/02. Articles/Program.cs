using System;

namespace _02._Articles
{
    public class Arcitcle
    {
        public string Title { get; set; }

        public string Content { get; set; }
        
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor) 
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(", ");

            Arcitcle article = new Arcitcle()
            {
                Author = elements[2],
                Content = elements[1],
                Title = elements[0]
            };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split(": ");

                string command = commands[0];
                string parameter = commands[1];

                if (command == "Edit")
                {
                    article.Edit(parameter);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(parameter);
                }
                else
                {
                    article.Rename(parameter);
                }
            }

            Console.WriteLine(article);
        }
    }
}
