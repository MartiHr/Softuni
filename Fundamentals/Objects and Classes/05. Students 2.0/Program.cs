using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students_2._0
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Hometown { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] data = input.Split();

                string firstName = data[0];
                string lastName = data[1];
                string age = data[2];
                string hometown = data[3];

                if (StudentExists(students, firstName, lastName))
                {
                    Student existingStudent = GetStudent(students, firstName, lastName);

                    existingStudent.FirstName = firstName;
                    existingStudent.LastName = lastName;
                    existingStudent.Age = age;
                    existingStudent.Hometown = hometown;

                }
                else
                {
                    Student currentStudent = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Hometown = hometown
                    };

                    students.Add(currentStudent);
                }

                input = Console.ReadLine();
            }

            string cityFilter = Console.ReadLine();

            List<Student> filteredStudent = students
                .Where(s => s.Hometown == cityFilter)
                .ToList();

            foreach (Student student in filteredStudent)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        private static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;
            
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }

        private static bool StudentExists(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
