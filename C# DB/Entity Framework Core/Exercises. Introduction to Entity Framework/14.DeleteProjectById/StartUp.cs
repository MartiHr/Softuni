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

            Console.WriteLine(DeleteProjectById(context));
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projectToDelete = context
              .Projects
              .Where(p => p.ProjectId == 2)
              .FirstOrDefault();

            var employeesProjectsToRemove = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projectToDelete.ProjectId);

            foreach (var ep in employeesProjectsToRemove)
            {
                context.EmployeesProjects.Remove(ep);
            }

            context.Projects.Remove(projectToDelete);
            
            context.SaveChanges();

            var projectsToDisplay = context
                .Projects
                .Take(10)
                .Select(p => p.Name);

            foreach (var project in projectsToDisplay)
            {
                sb.AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
