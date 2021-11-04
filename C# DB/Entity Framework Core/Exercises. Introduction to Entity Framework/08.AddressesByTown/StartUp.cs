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

            Console.WriteLine(GetAddressesByTown(context));
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addressesByTown = context
                .Addresses
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    x.Employees
                })
                .OrderByDescending(x => x.Employees.Count())
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10);

            foreach (var item in addressesByTown)
            {
                sb.AppendLine($"{item.AddressText}, {item.TownName} - {item.Employees.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
