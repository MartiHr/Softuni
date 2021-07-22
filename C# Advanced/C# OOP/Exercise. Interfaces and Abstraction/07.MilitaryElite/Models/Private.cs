using _07.MilitaryElite.Interfaces;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get; set; }

        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
        }
    }
}
