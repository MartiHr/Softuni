using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<Repair> Repairs { get; set; }

        public Engineer(string id,
            string firstName,
            string lastName,
            decimal salary,
            SoldierCorpsEnum corps,
            params Repair[] data) 
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<Repair>(data);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
