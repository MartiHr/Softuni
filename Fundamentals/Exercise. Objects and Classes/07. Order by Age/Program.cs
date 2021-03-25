using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    public class Person
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] data = input.Split();

                Person currentPerson = new Person
                {
                    Name = data[0],
                    ID = data[1],
                    Age = int.Parse(data[2])
                };

                people.Add(currentPerson);
            }

            List<Person> filtered = people
                .OrderBy(x => x.Age)
                .ToList();

            Console.WriteLine(String.Join(Environment.NewLine, filtered));
        }
    }
}   
