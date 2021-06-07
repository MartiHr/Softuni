using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<(string name, int age)> people = new List<(string, int)>();
           
            for (int i = 0; i < n; i++)
            {
                string[] nameAndAge = Console.ReadLine()
                    .Split(", ");

                people.Add((nameAndAge[0], int.Parse(nameAndAge[1])));
            }

            Func<(string name, int age), int, bool> younger = (person, age) => { return person.age < age; };
            Func<(string name, int age), int, bool> older = (person, age) => { return person.age >= age; };

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            switch (condition)
            {
                case "younger":
                    people = people
                        .Where(person => younger(person, age))
                        .ToList();
                    break;
                case "older":
                    people = people
                        .Where(person => older(person, age))
                        .ToList();
                    break;
                default:
                    break;
            }

            string[] format = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in people)
            {
                List<string> list = new List<string>();

                if (format.Contains("name"))
                {
                    list.Add(person.name);
                }
                if (format.Contains("age"))
                {
                    list.Add(person.age.ToString());
                }

                Console.WriteLine(string.Join(" - ", list));
            }
        }
    }
}
