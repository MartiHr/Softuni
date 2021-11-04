using System;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            Console.WriteLine(GetEmployeesInPeriod(context));
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 
                                                    && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ProjectStartDate = ep.Project.StartDate,
                            ProjectEndDate = ep.Project.EndDate,
                        }),
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName
                })
                .Take(10);


            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var p in employee.Projects)
                {
                    string startDate = p.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    string endDate = p.ProjectEndDate.HasValue 
                        ? p.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                        : "not finished";

                    sb.AppendLine($"--{p.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
