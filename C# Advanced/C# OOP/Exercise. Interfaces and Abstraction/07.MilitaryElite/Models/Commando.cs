using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public List<Mission> Missions { get; set; }

        public Commando(string id,
            string firstName,
            string lastName,
            decimal salary,
            SoldierCorpsEnum corps,
            params Mission[] data) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<Mission>(data);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
