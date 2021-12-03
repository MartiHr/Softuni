namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportProjectDto[] projectsWithTasks = context
                .Projects
                .Where(p => p.Tasks.Count > 0)
                .Select(p => new ExportProjectDto
                {
                    ProjectName = p.Name,
                    TasksCount = p.Tasks.Count.ToString(),
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks.Select(t => new ExportTaskDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p =>p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);;

            xmlSerializer.Serialize(stringWriter, projectsWithTasks, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var busiestEmployees = context
                .Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks.Select(et => et.Task)
                        .Where(t => t.OpenDate >= date)
                        .OrderByDescending(t => t.DueDate)
                        .ThenBy(t => t.Name)
                        .Select(t => new
                        {
                            TaskName = t.Name,
                            OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.LabelType.ToString(),
                            ExecutionType = t.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            string serializedEmployees = JsonConvert.SerializeObject(busiestEmployees, Formatting.Indented);

            return serializedEmployees;
        }
    }
}