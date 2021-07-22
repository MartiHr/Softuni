using System;
using System.Collections.Generic;
using System.Text;

namespace Person 
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative");
                }

                this.age = value;
            }
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
