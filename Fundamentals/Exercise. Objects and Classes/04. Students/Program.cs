using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Student
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split();

                string firstName = data[0];
                string lastName = data[1];
                double grade = double.Parse(data[2]);

                Student currentStudent = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Grade = grade
                };

                students.Add(currentStudent);
            }

            List<Student> filteredList = students
                .OrderByDescending(x => x.Grade)
                .ToList();

            foreach (var student in filteredList)
            {
                Console.WriteLine(student);
            }
        }
    }
}
