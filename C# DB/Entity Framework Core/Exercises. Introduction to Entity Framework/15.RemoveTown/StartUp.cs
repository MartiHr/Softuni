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

            Console.WriteLine(RemoveTown(context));
        }

        public static string RemoveTown(SoftUniContext context)
        {
            Address[] addressesToRemove = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();

            Employee[] employeesToRemoveAddresses = context
                .Employees
                .ToArray()
                .Where(e => addressesToRemove.Any(a => a.AddressId == e.AddressId))
                .ToArray();

            foreach (var employee in employeesToRemoveAddresses)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToRemove);

            Town townToRemove = context
             .Towns
             .First(t => t.Name == "Seattle");
            
            context.Towns.Remove(townToRemove);
            context.SaveChanges();

            return $"{addressesToRemove.Length} addresses in Seattle were deleted";
        }
    }
}
