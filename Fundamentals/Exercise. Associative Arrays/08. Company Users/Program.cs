using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] elements = input.Split(" -> ");

                string companyName = elements[0];
                string employeeId = elements[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }

                companies[companyName].Add(employeeId);
            }

            foreach (var company in companies)
            {
                List<string> uniqueEmployees = company.Value
                    .Distinct()
                    .ToList();

                Console.WriteLine(company.Key);

                foreach (var employee in uniqueEmployees)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
