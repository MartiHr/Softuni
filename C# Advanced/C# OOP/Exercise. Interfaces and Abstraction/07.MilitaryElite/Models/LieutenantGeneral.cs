using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<Private> Privates { get; set; }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, params Private[] data) 
            : base(id, firstName, lastName, salary)
        {
            Privates = new List<Private>(data);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Privates:");
            foreach (var @private in Privates)
            {
                sb.AppendLine($"  {@private.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
