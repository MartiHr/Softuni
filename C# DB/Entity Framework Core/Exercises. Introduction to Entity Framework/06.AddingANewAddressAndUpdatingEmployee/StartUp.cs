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

            Console.WriteLine(AddNewAddressToEmployee(context));
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee nakovEmployee = context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            nakovEmployee.Address = address;

            context.SaveChanges();

            var employeesAddresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();

            return string.Join(Environment.NewLine, employeesAddresses);
        }
    }
}
