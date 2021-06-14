using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age)
            : this()
        {
            Age = age;
        }

        public Person(int age, string name)
            : this(age)
        {
            Name = name;
        }


        public string Name { get; set; }
        public int Age { get; set; }

    }
}
