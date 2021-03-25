using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] elements = input.Split(" : ");

                string courseName = elements[0];
                string studentName = elements[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);
            }

            Dictionary<string, List<string>> orderedCourses = courses
                .OrderByDescending(c => c.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var course in orderedCourses)
            {
                string courseName = course.Key;
                List<string> orderedStudents = course.Value
                   .OrderBy(s => s)
                   .ToList(); 

                Console.WriteLine($"{courseName}: {orderedStudents.Count}");
               
                foreach (var student in orderedStudents)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
