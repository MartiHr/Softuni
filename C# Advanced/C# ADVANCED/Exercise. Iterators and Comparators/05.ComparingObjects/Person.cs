using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int CompareTo(Person otherPerson)
        {
            int result = Name.CompareTo(otherPerson.Name);

            if (result == 0)
            {
                result = Age.CompareTo(otherPerson.Age);
            }

            if (result == 0)
            {
                result = Town.CompareTo(otherPerson.Town);
            }

            return result;
        }
    }
}
