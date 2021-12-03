namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .ToArray()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po => po.Officer)
                        .Select(o => new
                        {
                            OfficerName = o.FullName,
                            Department = o.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id);

            string officersAsJsonString = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return officersAsJsonString;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Prisoners");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPrisonerInboxesDto[]), xmlRoot);
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);

            string[] prisonersNamesArr = prisonersNames
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            ExportPrisonerInboxesDto[] prisoners = context
                .Prisoners
                .Where(p => prisonersNamesArr.Contains(p.FullName))
                .Select(p => new ExportPrisonerInboxesDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    Messages = p.Mails.Select(m => m.Description)
                        .Select(description => new ExportMessageDto
                        {
                            Description = new string(description.Reverse().ToArray())
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, prisoners, serializerNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}