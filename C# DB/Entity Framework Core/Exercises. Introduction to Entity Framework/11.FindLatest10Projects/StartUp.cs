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

            Console.WriteLine(GetLatestProjects(context));
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var latestProjects = context
                .Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            foreach (var project in latestProjects)
            {
                string projectDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");

                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(projectDate);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
