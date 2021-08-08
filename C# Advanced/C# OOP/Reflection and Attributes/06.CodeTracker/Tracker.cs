using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type metadata = typeof(StartUp);

            var methods = metadata
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (var attribute in attributes)
                {
                    AuthorAttribute author = attribute as AuthorAttribute;

                    if (author != null)
                    {
                        Console.WriteLine($"{method.Name} is written by {author.Name}");
                    }
                }
            }
        }
    }
}
