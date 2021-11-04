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

            Console.WriteLine(GetEmployee147(context));
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context
                .Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    ProjectsʼNames = x.EmployeesProjects.Select(ep => new 
                    { 
                        ep.Project.Name
                    })
                })
                .FirstOrDefault(x => x.EmployeeId == 147);

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.ProjectsʼNames.OrderBy(p => p.Name))
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
