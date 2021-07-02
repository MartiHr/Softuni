using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public int Capacity { get; set; }

        public int Count { get => students.Count; }

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>(Capacity);
        }

        public string RegisterStudent(Student student)
        {
            if (Capacity - Count > 0)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    students.Remove(student);
                    return ($"Dismissed student {firstName} {lastName}" );
                }
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");

            bool hasStudents = false;
            foreach (var student in students)
            {
                if (student.Subject == subject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                    hasStudents = true;
                }
            }

            if (hasStudents == true)
            {
                return sb.ToString().Trim();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return student;
                }
            }

            return null;
        }
    }
}
