using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = elements[0];
                decimal grade = decimal.Parse(elements[1]);

                if (students.ContainsKey(name) == false)
                {
                    students.Add(name, new List<decimal>());
                }

                students[name].Add(grade);
            }

            foreach (var kvp in students)
            {
                string name = kvp.Key;
                List<decimal> listOfGrades = kvp.Value;

                Console.WriteLine($"{name} -> {string.Join(" ", listOfGrades.Select(x => $"{x:f2}"))} (avg: {listOfGrades.Average():f2})");
            }
        }
    }
}
