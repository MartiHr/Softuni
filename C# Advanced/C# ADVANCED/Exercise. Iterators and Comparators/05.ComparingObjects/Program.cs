using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Person> people = new List<Person>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] elements = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = elements[0];
                int age = int.Parse(elements[1]);
                string town = elements[2];

                people.Add(new Person(name, age, town));
            }

            int n = int.Parse(Console.ReadLine()) - 1;
            Person comparePerson = people[n];
            int matches = 0;
            int notMatches = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].CompareTo(comparePerson) == 0)
                {
                    matches++;
                }
                else
                {
                    notMatches++;
                }
            }

            if (matches > 1)
            {
                Console.WriteLine($"{matches} {notMatches} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
